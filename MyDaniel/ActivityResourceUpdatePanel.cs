using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class ActivityResourceUpdatePanel : UserControl
    {
        private static readonly string[] ACTIVITY_TYPES = {
            "Sailing", "Kayaking", "Academic Rowing"
        };
        private static readonly string[] AGE_GROUPS = {
            "Junior", "Youth", "Senior", "Elite"
        };
        private static readonly string[] BOAT_STATUSES = {
            "Active", "Under Maintenance", "Out of Service"
        };

        private Activity       _selected       = null;
        private List<Employee> _instructorList = new List<Employee>();
        private List<Boat>     _assignBoatList = new List<Boat>();  // for assigning to activity
        private List<Boat>     _statusBoatList = new List<Boat>();  // for updating boat status

        public ActivityResourceUpdatePanel()
        {
            InitializeComponent();

            if (!AuthService.IsInstructor())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            combo_act_type.Items.AddRange(ACTIVITY_TYPES);
            combo_age_group.Items.AddRange(AGE_GROUPS);
            combo_boat_new_status.Items.AddRange(BOAT_STATUSES);

            populateInstructorCombo();
            populateAssignBoatCombo();
            populateStatusBoatCombo();
            loadActivitiesGrid();
            setActivityFormEnabled(false);
        }

        // =====================================================================
        // Grid
        // =====================================================================
        private void loadActivitiesGrid()
        {
            dataGridView_activities.SelectionChanged -= onActivitySelected;

            DataTable dt = new DataTable();
            dt.Columns.Add("מספר",        typeof(string));
            dt.Columns.Add("סוג פעילות", typeof(string));
            dt.Columns.Add("תאריך ושעה", typeof(string));
            dt.Columns.Add("מיקום",       typeof(string));
            dt.Columns.Add("מדריך",       typeof(string));
            dt.Columns.Add("סירה",        typeof(string));
            dt.Columns.Add("סטטוס",       typeof(string));

            Employee self = Employee.seekByEmail(Program.currentUserEmail);
            string   myId = self?.getEmployeeId();
            var toShow = Program.Activities.FindAll(a => a.getInstructorId() == myId);
            if (toShow.Count == 0) toShow = Program.Activities;

            foreach (Activity a in toShow)
            {
                Employee instr = a.getInstructor();
                Boat     boat  = a.getBoat();
                dt.Rows.Add(
                    a.getActivityNumId().ToString(),
                    a.getActivityType(),
                    a.getDateTime().ToString("dd/MM/yyyy HH:mm"),
                    a.getLocation(),
                    instr?.getFullName() ?? "לא שויך",
                    boat  != null ? $"#{boat.getBoatNumberId()} {boat.getWaterCraftName()}" : "ללא",
                    a.getActivityStatus()
                );
            }

            dataGridView_activities.DataSource = dt;
            dataGridView_activities.SelectionChanged += onActivitySelected;
        }

        private void onActivitySelected(object sender, EventArgs e)
        {
            if (dataGridView_activities.SelectedRows.Count == 0) return;

            string idStr = dataGridView_activities.SelectedRows[0].Cells[0].Value?.ToString();
            if (!int.TryParse(idStr, out int id)) return;

            _selected = Activity.seekActivity(id);
            if (_selected == null) return;

            combo_act_type.Text    = _selected.getActivityType();
            combo_age_group.Text   = _selected.getAgeGroup();
            txt_location.Text      = _selected.getLocation();
            dtp_act_datetime.Value = _selected.getDateTime();

            // Pre-select instructor
            combo_instructor.SelectedIndex = 0;
            if (!string.IsNullOrEmpty(_selected.getInstructorId()))
            {
                for (int i = 1; i < _instructorList.Count; i++)
                {
                    if (_instructorList[i]?.getEmployeeId() == _selected.getInstructorId())
                    { combo_instructor.SelectedIndex = i; break; }
                }
            }

            // Pre-select assigned boat
            combo_assign_boat.SelectedIndex = 0;
            if (_selected.getBoatNumberId() != null)
            {
                for (int i = 1; i < _assignBoatList.Count; i++)
                {
                    if (_assignBoatList[i]?.getBoatNumberId() == _selected.getBoatNumberId().Value)
                    { combo_assign_boat.SelectedIndex = i; break; }
                }
            }

            setActivityFormEnabled(true);
            hideError();
        }

        // =====================================================================
        // Combo population
        // =====================================================================
        private void populateInstructorCombo()
        {
            combo_instructor.Items.Clear();
            _instructorList.Clear();
            combo_instructor.Items.Add("--- ללא מדריך ---");
            _instructorList.Add(null);
            foreach (Employee e in Program.Employees)
            {
                if (e.getRole() == AuthService.ROLE_INSTRUCTOR)
                {
                    combo_instructor.Items.Add($"{e.getEmployeeId()} — {e.getFullName()}");
                    _instructorList.Add(e);
                }
            }
            combo_instructor.SelectedIndex = 0;
        }

        private void populateAssignBoatCombo()
        {
            combo_assign_boat.Items.Clear();
            _assignBoatList.Clear();
            combo_assign_boat.Items.Add("--- ללא סירה ---");
            _assignBoatList.Add(null);
            foreach (Boat b in Program.Boats)
            {
                if (!isInternalBoat(b)) continue;          // internal boats only
                if (b.getBoatStatus() != "Active") continue; // available boats only
                combo_assign_boat.Items.Add($"#{b.getBoatNumberId()} — {b.getWaterCraftName()}");
                _assignBoatList.Add(b);
            }
            combo_assign_boat.SelectedIndex = 0;
        }

        private static bool isInternalBoat(Boat b)
        {
            return b.getSourceType() == "Internal";
        }

        private void populateStatusBoatCombo()
        {
            combo_boat.Items.Clear();
            _statusBoatList.Clear();
            combo_boat.Items.Add("--- בחר סירה ---");
            _statusBoatList.Add(null);
            foreach (Boat b in Program.Boats)
            {
                combo_boat.Items.Add($"#{b.getBoatNumberId()} — {b.getWaterCraftName()} ({b.getBoatStatus()})");
                _statusBoatList.Add(b);
            }
            combo_boat.SelectedIndex = 0;
        }

        // =====================================================================
        // Section 1 — Update activity (type, date, location, age group, instructor, boat)
        // =====================================================================
        private void btn_update_activity_Click(object sender, EventArgs e)
        {
            hideError();
            if (_selected == null) { showError("יש לבחור פעילות מהרשימה לפני עדכון"); return; }

            string type     = combo_act_type.Text.Trim();
            string location = txt_location.Text.Trim();
            string ageGroup = combo_age_group.Text.Trim();

            if (string.IsNullOrWhiteSpace(type))
            { showError("יש לבחור סוג פעילות"); return; }

            if (string.IsNullOrWhiteSpace(location) || location.Length < 2)
            { showError("יש להזין מיקום (לפחות 2 תווים)"); return; }

            if (string.IsNullOrWhiteSpace(ageGroup))
            { showError("יש לבחור קבוצת גיל"); return; }

            Employee selInstr = _instructorList[combo_instructor.SelectedIndex];
            Boat     selBoat  = _assignBoatList[combo_assign_boat.SelectedIndex];

            _selected.setActivityType(type);
            _selected.setLocation(location);
            _selected.setAgeGroup(ageGroup);
            _selected.setDateTime(dtp_act_datetime.Value);
            _selected.setInstructorId(selInstr?.getEmployeeId());
            _selected.setBoatNumberId(selBoat != null ? (int?)selBoat.getBoatNumberId() : null);
            _selected.updateActivity();

            MessageBox.Show("פרטי הפעילות עודכנו בהצלחה", "עדכון",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadActivitiesGrid();
            clearActivityForm();
        }

        // =====================================================================
        // Section 2 — Update standalone boat status / report unavailable
        // =====================================================================
        private void btn_update_boat_Click(object sender, EventArgs e)
        {
            hideError();
            int boatIdx = combo_boat.SelectedIndex;
            if (boatIdx <= 0 || boatIdx >= _statusBoatList.Count)
            { showError("יש לבחור סירה לפני עדכון הסטטוס"); return; }

            if (combo_boat_new_status.SelectedIndex < 0)
            { showError("יש לבחור סטטוס חדש לסירה"); return; }

            Boat   selectedBoat = _statusBoatList[boatIdx];
            string newStatus    = combo_boat_new_status.SelectedItem.ToString();
            string oldStatus    = selectedBoat.getBoatStatus();

            selectedBoat.setBoatStatus(newStatus);
            selectedBoat.updateBoat();

            MessageBox.Show(
                $"סטטוס הסירה {selectedBoat.getWaterCraftName()} עודכן מ-\"{oldStatus}\" ל-\"{newStatus}\"",
                "עדכון סטטוס", MessageBoxButtons.OK, MessageBoxIcon.Information);

            populateStatusBoatCombo();
            populateAssignBoatCombo();
        }

        // =====================================================================
        // Helpers
        // =====================================================================
        private void clearActivityForm()
        {
            _selected = null;
            combo_act_type.SelectedIndex    = -1;
            combo_age_group.SelectedIndex   = -1;
            combo_instructor.SelectedIndex  = 0;
            combo_assign_boat.SelectedIndex = 0;
            txt_location.Text               = "";
            dtp_act_datetime.Value          = DateTime.Now;
            setActivityFormEnabled(false);
            dataGridView_activities.ClearSelection();
            hideError();
        }

        private void setActivityFormEnabled(bool enabled)
        {
            combo_act_type.Enabled      = enabled;
            combo_age_group.Enabled     = enabled;
            txt_location.Enabled        = enabled;
            dtp_act_datetime.Enabled    = enabled;
            combo_instructor.Enabled    = enabled;
            combo_assign_boat.Enabled   = enabled;
            btn_update_activity.Enabled = enabled;
        }

        private void btn_back_Click(object sender, EventArgs e)
            => MainForm.showPanel(new InstructorMenuPanel());

        private void showError(string msg) { label_error.Text = msg; label_error.Visible = true; }
        private void hideError()           { label_error.Visible = false; }
    }
}
