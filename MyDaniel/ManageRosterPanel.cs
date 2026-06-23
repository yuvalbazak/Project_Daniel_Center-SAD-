using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class ManageRosterPanel : UserControl
    {
        private Activity         _activity;
        private ActivityCustomer _selectedReg = null;
        private List<Customer>   _customerList = new List<Customer>();
        private List<Boat>       _boatList     = new List<Boat>();

        public ManageRosterPanel(Activity activity)
        {
            InitializeComponent();

            if (!AuthService.CanManageRoster())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            _activity = activity;

            label_activity_info.Text =
                $"פעילות #{activity.getActivityNumId()} | {activity.getActivityType()} | " +
                $"{activity.getDateTime():dd/MM/yyyy HH:mm} | {activity.getLocation()} | " +
                $"סטטוס: {activity.getActivityStatus()}";

            populateCustomerCombo();
            populateBoatCombo();
            loadRosterGrid();
            dataGridView_roster.SelectionChanged += onRosterSelectionChanged;
        }

        // =====================================================================
        // Combo population
        // =====================================================================
        private void populateCustomerCombo()
        {
            combo_customer.Items.Clear();
            _customerList.Clear();
            combo_customer.Items.Add("--- בחר תלמיד ---");
            _customerList.Add(null);
            foreach (Customer c in Program.Customers)
            {
                combo_customer.Items.Add($"{c.getCustomerId()} — {c.getFullName()}");
                _customerList.Add(c);
            }
            combo_customer.SelectedIndex = 0;
        }

        private void populateBoatCombo()
        {
            combo_boat.Items.Clear();
            _boatList.Clear();
            combo_boat.Items.Add("--- ללא סירה ---");
            _boatList.Add(null);

            // Collect boat IDs already assigned to participants in this activity
            // (excluding the currently selected participant so they can change their own boat)
            HashSet<int> assignedBoatIds = new HashSet<int>();
            string excludedCustId = _selectedReg?.getCustomerId();
            foreach (ActivityCustomer ac in _activity.getRoster())
            {
                if (ac.getCustomerId() == excludedCustId) continue;
                if (ac.getBoatId().HasValue)
                    assignedBoatIds.Add(ac.getBoatId().Value);
            }

            foreach (Boat b in Program.Boats)
            {
                if (!isInternalBoat(b)) continue;           // internal center boats only
                if (b.getBoatStatus() != "Active") continue;  // available boats only
                if (assignedBoatIds.Contains(b.getBoatNumberId())) continue; // not already taken
                combo_boat.Items.Add($"#{b.getBoatNumberId()} — {b.getWaterCraftName()}");
                _boatList.Add(b);
            }
            combo_boat.SelectedIndex = 0;
        }

        private static bool isInternalBoat(Boat b)
        {
            return b.getSourceType() == "Internal";
        }

        // =====================================================================
        // Roster grid
        // =====================================================================
        private void loadRosterGrid()
        {
            dataGridView_roster.SelectionChanged -= onRosterSelectionChanged;

            DataTable dt = new DataTable();
            dt.Columns.Add("מ.ז. תלמיד",    typeof(string));
            dt.Columns.Add("שם מלא",         typeof(string));
            dt.Columns.Add("טלפון",          typeof(string));
            dt.Columns.Add("תאריך הצטרפות", typeof(string));
            dt.Columns.Add("סירה משויכת",   typeof(string));
            dt.Columns.Add("הערות",          typeof(string));

            foreach (ActivityCustomer ac in _activity.getRoster())
            {
                Customer c    = ac.getCustomer() ?? Customer.seekCustomer(ac.getCustomerId());
                string boatDisplay = "לא שויכה";
                if (ac.getBoatId().HasValue)
                {
                    Boat b = Boat.seekBoat(ac.getBoatId().Value);
                    boatDisplay = b != null ? $"#{b.getBoatNumberId()} {b.getWaterCraftName()}" : "לא שויכה";
                }
                dt.Rows.Add(
                    ac.getCustomerId(),
                    c?.getFullName() ?? "לא ידוע",
                    c?.getPhone()    ?? "",
                    ac.getRegistrationDate().ToString("dd/MM/yyyy"),
                    boatDisplay,
                    ac.getNotes() ?? ""
                );
            }

            dataGridView_roster.DataSource = dt;
            dataGridView_roster.SelectionChanged += onRosterSelectionChanged;

            int count   = _activity.getRoster().Count;
            int maxPart = _activity.getMaxParticipants();
            label_capacity.Text = $"רשומים: {count} / {maxPart} משתתפים";
            btn_notify.Enabled  = count > 0;
        }

        private void onRosterSelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_roster.SelectedRows.Count == 0) return;
            string custId = dataGridView_roster.SelectedRows[0].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(custId)) return;

            _selectedReg = ActivityCustomer.seekByActivityAndCustomer(_activity.getActivityNumId(), custId);
            btn_remove.Enabled      = _selectedReg != null;
            btn_assign_boat.Enabled = _selectedReg != null;

            // Refresh combo excluding other participants' boats; then pre-select this participant's boat
            populateBoatCombo();
            if (_selectedReg != null && _selectedReg.getBoatId().HasValue)
            {
                for (int i = 1; i < _boatList.Count; i++)
                {
                    if (_boatList[i]?.getBoatNumberId() == _selectedReg.getBoatId().Value)
                    { combo_boat.SelectedIndex = i; break; }
                }
            }
        }

        // =====================================================================
        // Button handlers
        // =====================================================================
        private void btn_add_Click(object sender, EventArgs e)
        {
            hideError();
            int idx = combo_customer.SelectedIndex;
            if (idx <= 0 || idx >= _customerList.Count)
            { showError("יש לבחור תלמיד להוספה"); return; }

            Customer c      = _customerList[idx];
            string   custId = c.getCustomerId();

            if (ActivityCustomer.seekByActivityAndCustomer(_activity.getActivityNumId(), custId) != null)
            { showError("התלמיד כבר רשום לפעילות זו"); return; }

            if (_activity.getRoster().Count >= _activity.getMaxParticipants())
            { showError($"הגעת למספר המשתתפים המקסימלי ({_activity.getMaxParticipants()})"); return; }

            int newId = Program.ActivityCustomers.Count > 0
                ? Program.ActivityCustomers[Program.ActivityCustomers.Count - 1].getActivityCustomerId() + 1
                : 1;

            string notes    = txt_notes.Text.Trim();
            int?   boatId   = null;
            int    boatIdx  = combo_boat.SelectedIndex;
            if (boatIdx > 0 && boatIdx < _boatList.Count && _boatList[boatIdx] != null)
                boatId = _boatList[boatIdx].getBoatNumberId();

            // Guard: boat cannot be assigned to more than one participant
            if (boatId.HasValue)
            {
                foreach (ActivityCustomer existing in _activity.getRoster())
                {
                    if (existing.getBoatId() == boatId)
                    {
                        Customer other = existing.getCustomer() ?? Customer.seekCustomer(existing.getCustomerId());
                        showError($"הסירה כבר משויכת ל-{other?.getFullName() ?? existing.getCustomerId()}");
                        return;
                    }
                }
            }

            ActivityCustomer ac = new ActivityCustomer(
                newId, _activity.getActivityNumId(), custId,
                DateTime.Now, string.IsNullOrWhiteSpace(notes) ? null : notes,
                true, boatId);

            _activity.addToRoster(ac);
            ac.setCustomer(c);

            if (boatId.HasValue)
                ac.updateActivityCustomerBoat();

            loadRosterGrid();
            clearForm();
            MessageBox.Show("התלמיד נוסף לפעילות בהצלחה", "הוספה",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_assign_boat_Click(object sender, EventArgs e)
        {
            hideError();
            if (_selectedReg == null) { showError("יש לבחור משתתף מהרשימה תחילה"); return; }

            int boatIdx = combo_boat.SelectedIndex;
            int? boatId = null;
            if (boatIdx > 0 && boatIdx < _boatList.Count && _boatList[boatIdx] != null)
                boatId = _boatList[boatIdx].getBoatNumberId();

            // Guard: boat cannot be assigned to more than one participant
            if (boatId.HasValue)
            {
                foreach (ActivityCustomer existing in _activity.getRoster())
                {
                    if (existing.getActivityCustomerId() == _selectedReg.getActivityCustomerId()) continue;
                    if (existing.getBoatId() == boatId)
                    {
                        Customer other = existing.getCustomer() ?? Customer.seekCustomer(existing.getCustomerId());
                        showError($"הסירה כבר משויכת ל-{other?.getFullName() ?? existing.getCustomerId()}");
                        return;
                    }
                }
            }

            _selectedReg.setBoatId(boatId);
            _selectedReg.updateActivityCustomerBoat();

            string boatName = boatId.HasValue
                ? (_boatList[boatIdx]?.getWaterCraftName() ?? boatId.ToString())
                : "ללא סירה";

            MessageBox.Show($"הסירה עודכנה ל: {boatName}", "עדכון סירה",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadRosterGrid();
        }

        private void btn_assign_external_boat_Click(object sender, EventArgs e)
        {
            if (_selectedReg == null)
            {
                showError("יש לבחור משתתף מהרשימה לפני שיוך סירה חיצונית");
                return;
            }
            MessageBox.Show(
                "לשיוך סירה מחוץ לבית הספר, צור קשר עם המרכז החיצוני ועדכן את השיוך ידנית לאחר האישור.",
                "שיוך סירה חיצונית",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (_selectedReg == null) return;

            var confirm = MessageBox.Show(
                "האם אתה בטוח שברצונך להעביר רשומה זו לארכיון?",
                "אישור העברה לארכיון", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            _selectedReg.deleteActivityCustomer();
            _selectedReg            = null;
            btn_remove.Enabled      = false;
            btn_assign_boat.Enabled = false;

            loadRosterGrid();
            clearForm();
            MessageBox.Show("הרשומה הועברה לארכיון בהצלחה", "ארכיון",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_notify_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"הודעה לגבי פעילות #{_activity.getActivityNumId()} — {_activity.getActivityType()}");
            sb.AppendLine($"תאריך: {_activity.getDateTime():dd/MM/yyyy HH:mm} | מיקום: {_activity.getLocation()}");
            sb.AppendLine($"סטטוס: {_activity.getActivityStatus()}");
            sb.AppendLine();
            sb.AppendLine("משתתפים רשומים:");
            foreach (ActivityCustomer ac in _activity.getRoster())
            {
                Customer c = ac.getCustomer() ?? Customer.seekCustomer(ac.getCustomerId());
                string boatInfo = "";
                if (ac.getBoatId().HasValue)
                {
                    Boat b = Boat.seekBoat(ac.getBoatId().Value);
                    boatInfo = b != null ? $" | סירה: {b.getWaterCraftName()}" : "";
                }
                sb.AppendLine($"  • {c?.getFullName() ?? ac.getCustomerId()} ({c?.getPhone() ?? "ללא טלפון"}){boatInfo}");
            }
            MessageBox.Show(sb.ToString(), "סימולציית הודעה",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_back_Click(object sender, EventArgs e)
            => MainForm.showPanel(new ManageActivitiesPanel());

        // =====================================================================
        // UI helpers
        // =====================================================================
        private void clearForm()
        {
            combo_customer.SelectedIndex = 0;
            combo_boat.SelectedIndex     = 0;
            txt_notes.Text               = "";
            _selectedReg                 = null;
            btn_remove.Enabled           = false;
            btn_assign_boat.Enabled      = false;
            hideError();
        }

        private void showError(string msg) { label_error.Text = msg; label_error.Visible = true; }
        private void hideError()           { label_error.Visible = false; }
    }
}
