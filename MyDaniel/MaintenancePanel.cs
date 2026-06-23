using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class MaintenancePanel : UserControl
    {
        private static readonly string[] ALL_STATUSES  = { "פתוח", "בטיפול", "סגור" };
        private static readonly string[] OPEN_STATUSES = { "פתוח", "בטיפול" };
        private static readonly System.Drawing.Color ERR_BG =
            System.Drawing.Color.FromArgb(255, 220, 220);

        private readonly Boat _preSelectedBoat;
        private readonly bool _fromBoatsPanel;
        private bool _canCreate;
        private bool _canEdit;
        private bool _canClose;
        private bool _canDelete;

        private Maintenance _selected = null;
        private List<Boat>  _boatList = new List<Boat>();

        public MaintenancePanel(Boat preSelectedBoat = null, bool fromBoatsPanel = false)
        {
            _preSelectedBoat = preSelectedBoat;
            _fromBoatsPanel  = fromBoatsPanel;

            InitializeComponent();

            if (!AuthService.CanViewMaintenance())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            _canCreate = AuthService.CanCreateMaintenance();
            _canEdit   = AuthService.CanEditMaintenance();
            _canClose  = AuthService.CanCloseMaintenance();
            _canDelete = AuthService.CanDeleteMaintenance();

            if (_preSelectedBoat != null)
                label_title.Text = $"דיווח תקלה — {_preSelectedBoat.getWaterCraftName()}";

            combo_status.Items.AddRange(
                AuthService.IsInstructor() ? OPEN_STATUSES : ALL_STATUSES);

            populateBoatCombos();

            // Wire events AFTER populateBoatCombos to avoid premature loadGrid() calls
            combo_filter_boat.SelectedIndexChanged += (s, e) => loadGrid();
            chk_has_resolved.CheckedChanged += (s, e) =>
                dtp_resolved.Enabled = chk_has_resolved.Checked && chk_has_resolved.Enabled;
            txt_cost.TextChanged        += (s, e) => clearBg(txt_cost);
            txt_description.TextChanged += (s, e) => clearBg(txt_description);

            btn_new.Visible = _canCreate;

            loadGrid();
            dataGridView_maintenance.SelectionChanged += onSelectionChanged;
            setMode_new();
        }

        // =====================================================================
        // Combo population
        // =====================================================================
        private void populateBoatCombos()
        {
            combo_boat.Items.Clear();
            _boatList.Clear();
            combo_boat.Items.Add("--- בחר סירה ---");
            _boatList.Add(null);
            foreach (Boat b in Program.Boats)
            {
                combo_boat.Items.Add($"#{b.getBoatNumberId()} — {b.getWaterCraftName()} ({b.getBoatStatus()})");
                _boatList.Add(b);
            }
            combo_boat.SelectedIndex = 0;

            combo_filter_boat.Items.Clear();
            combo_filter_boat.Items.Add("הכל");
            foreach (Boat b in Program.Boats)
                combo_filter_boat.Items.Add($"#{b.getBoatNumberId()} — {b.getWaterCraftName()}");

            if (_preSelectedBoat != null)
            {
                for (int i = 1; i < _boatList.Count; i++)
                {
                    if (_boatList[i]?.getBoatNumberId() == _preSelectedBoat.getBoatNumberId())
                    { combo_boat.SelectedIndex = i; break; }
                }
                for (int i = 0; i < Program.Boats.Count; i++)
                {
                    if (Program.Boats[i].getBoatNumberId() == _preSelectedBoat.getBoatNumberId())
                    { combo_filter_boat.SelectedIndex = i + 1; break; }
                }
                combo_boat.Enabled = false;
            }
            else
            {
                combo_filter_boat.SelectedIndex = 0;
            }
        }

        // =====================================================================
        // Grid
        // =====================================================================
        private void loadGrid()
        {
            dataGridView_maintenance.SelectionChanged -= onSelectionChanged;

            DataTable dt = new DataTable();
            dt.Columns.Add("מספר",         typeof(string));
            dt.Columns.Add("סירה",         typeof(string));
            dt.Columns.Add("תאריך דיווח", typeof(string));
            dt.Columns.Add("תיאור",        typeof(string));
            dt.Columns.Add("סטטוס",        typeof(string));
            dt.Columns.Add("תאריך סגירה", typeof(string));
            dt.Columns.Add("עלות",         typeof(string));
            dt.Columns.Add("טכנאי",        typeof(string));

            int filterBoatId = -1;
            if (combo_filter_boat.SelectedIndex > 0)
            {
                int idx = combo_filter_boat.SelectedIndex - 1;
                if (idx >= 0 && idx < Program.Boats.Count)
                    filterBoatId = Program.Boats[idx].getBoatNumberId();
            }

            var rows = new List<(DateTime sortKey, object[] row)>();
            foreach (Maintenance m in Program.Maintenances)
            {
                if (filterBoatId > 0 && m.getBoatNumberId() != filterBoatId)
                    continue;

                Boat b = m.getBoat() ?? Boat.seekBoat(m.getBoatNumberId());
                string boatDisplay = b != null
                    ? $"#{b.getBoatNumberId()} {b.getWaterCraftName()}"
                    : m.getBoatNumberId().ToString();
                string costDisplay = m.getCost().HasValue
                    ? m.getCost().Value.ToString("F2") + " ₪" : "—";

                rows.Add((m.getReportedAt(), new object[] {
                    m.getMaintenanceId().ToString(),
                    boatDisplay,
                    m.getReportedAt().ToString("dd/MM/yyyy"),
                    m.getDescription(),
                    m.getStatus(),
                    m.getResolvedAt()?.ToString("dd/MM/yyyy") ?? "—",
                    costDisplay,
                    string.IsNullOrWhiteSpace(m.getTechnicianName()) ? "—" : m.getTechnicianName()
                }));
            }
            rows.Sort((x, y) => y.sortKey.CompareTo(x.sortKey));
            foreach (var (_, row) in rows) dt.Rows.Add(row);

            dataGridView_maintenance.DataSource = dt;
            dataGridView_maintenance.SelectionChanged += onSelectionChanged;
        }

        private void onSelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_maintenance.SelectedRows.Count == 0) return;
            string idStr = dataGridView_maintenance.SelectedRows[0].Cells[0].Value?.ToString();
            if (!int.TryParse(idStr, out int id)) return;
            Maintenance m = Maintenance.seekMaintenance(id);
            if (m == null) return;
            _selected = m;
            selectInForm(m);

            if (_canEdit)
                setMode_edit();
            else
                setMode_viewOnly();
        }

        // =====================================================================
        // Form population
        // =====================================================================
        private void selectInForm(Maintenance m)
        {
            txt_id.Text = m.getMaintenanceId().ToString();

            combo_boat.SelectedIndex = 0;
            for (int i = 1; i < _boatList.Count; i++)
            {
                if (_boatList[i]?.getBoatNumberId() == m.getBoatNumberId())
                { combo_boat.SelectedIndex = i; break; }
            }

            combo_status.SelectedIndex = -1;
            for (int i = 0; i < combo_status.Items.Count; i++)
                if (combo_status.Items[i].ToString() == m.getStatus())
                { combo_status.SelectedIndex = i; break; }

            txt_technician.Text = m.getTechnicianName() ?? "";
            dtp_reported.Value  = m.getReportedAt();

            if (m.getResolvedAt().HasValue)
            {
                chk_has_resolved.Checked = true;
                dtp_resolved.Value       = m.getResolvedAt().Value;
                dtp_resolved.Enabled     = true;
            }
            else
            {
                chk_has_resolved.Checked = false;
                dtp_resolved.Enabled     = false;
            }

            txt_cost.Text        = m.getCost()?.ToString("F2") ?? "";
            txt_description.Text = m.getDescription();
        }

        // =====================================================================
        // Mode switching
        // =====================================================================
        private void setMode_new()
        {
            _selected = null;
            txt_id.Text                = "(אוטומטי)";
            combo_status.SelectedIndex = 0;
            dtp_reported.Value         = DateTime.Now;
            chk_has_resolved.Checked   = false;
            dtp_resolved.Value         = DateTime.Today;
            dtp_resolved.Enabled       = false;
            txt_cost.Text              = "";
            txt_technician.Text        = "";
            txt_description.Text       = "";

            if (_preSelectedBoat == null)
                combo_boat.SelectedIndex = 0;

            btn_save.Visible        = _canCreate;
            btn_update.Visible      = false;
            btn_delete.Visible      = false;
            btn_close_fault.Visible = false;

            setFormEnabled(_canCreate);
            combo_boat.Enabled = _canCreate && _preSelectedBoat == null;
            clearAllHighlights();
            hideError();
            dataGridView_maintenance.ClearSelection();
        }

        private void setMode_edit()
        {
            btn_save.Visible        = false;
            btn_update.Visible      = _canEdit;
            btn_delete.Visible      = _canDelete;
            btn_close_fault.Visible = _canClose && _selected?.getStatus() != "סגור";

            setFormEnabled(_canEdit);
            combo_boat.Enabled = false;
            clearAllHighlights();
            hideError();
        }

        private void setMode_viewOnly()
        {
            btn_save.Visible        = false;
            btn_update.Visible      = false;
            btn_delete.Visible      = false;
            btn_close_fault.Visible = false;

            setFormEnabled(false);
            combo_boat.Enabled = false;
            clearAllHighlights();
            hideError();
        }

        private void setFormEnabled(bool enabled)
        {
            combo_status.Enabled     = enabled;
            dtp_reported.Enabled     = enabled;
            chk_has_resolved.Enabled = enabled;
            dtp_resolved.Enabled     = enabled && chk_has_resolved.Checked;
            txt_cost.ReadOnly        = !enabled;
            txt_technician.ReadOnly  = !enabled;
            txt_description.ReadOnly = !enabled;
        }

        // =====================================================================
        // Validation
        // =====================================================================
        private bool validateForm(bool isNew)
        {
            if (isNew && combo_boat.SelectedIndex <= 0)
            { showError("יש לבחור סירה"); return false; }

            if (combo_status.SelectedIndex < 0)
            { showError("יש לבחור סטטוס"); return false; }

            if (string.IsNullOrWhiteSpace(txt_description.Text))
            { txt_description.BackColor = ERR_BG; showError("יש להזין תיאור התקלה"); return false; }

            if (!string.IsNullOrWhiteSpace(txt_cost.Text))
            {
                if (!decimal.TryParse(txt_cost.Text.Trim(), out decimal cv) || cv < 0)
                { txt_cost.BackColor = ERR_BG; showError("עלות חייבת להיות מספר חיובי"); return false; }
            }

            return true;
        }

        // =====================================================================
        // Button handlers
        // =====================================================================
        private void btn_new_Click(object sender, EventArgs e)
        {
            dataGridView_maintenance.ClearSelection();
            setMode_new();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            hideError();
            if (!_canCreate) { showError("אין לך הרשאה להוסיף רשומות תחזוקה"); return; }
            if (!validateForm(true)) return;

            int newId = Program.Maintenances.Count > 0
                ? Program.Maintenances[Program.Maintenances.Count - 1].getMaintenanceId() + 1
                : 1;

            Boat      selBoat    = _boatList[combo_boat.SelectedIndex];
            string    status     = combo_status.SelectedItem.ToString();
            DateTime? resolvedAt = chk_has_resolved.Checked
                                   ? (DateTime?)dtp_resolved.Value.Date : null;
            decimal?  cost       = string.IsNullOrWhiteSpace(txt_cost.Text)
                                   ? (decimal?)null : decimal.Parse(txt_cost.Text.Trim());
            string    tech       = txt_technician.Text.Trim();
            string    desc       = txt_description.Text.Trim();

            Maintenance m = new Maintenance(newId, selBoat.getBoatNumberId(),
                dtp_reported.Value, desc, status, resolvedAt, cost, tech, true);
            selBoat.addMaintenance(m);

            // Open/in-progress fault → mark boat as requiring maintenance
            if (status != "סגור")
            {
                selBoat.setBoatStatus("Under Maintenance");
                selBoat.updateBoat();
            }

            loadGrid();
            setMode_new();
            MessageBox.Show(
                $"רשומת התחזוקה נשמרה בהצלחה.\nסטטוס הסירה עודכן ל-\"Under Maintenance\".",
                "שמירה", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            hideError();
            if (!_canEdit) { showError("אין לך הרשאה לעדכן רשומות תחזוקה"); return; }
            if (_selected == null) return;
            if (!validateForm(false)) return;

            string oldStatus = _selected.getStatus();
            string newStatus = combo_status.SelectedItem.ToString();

            DateTime? resolvedAt = chk_has_resolved.Checked
                                   ? (DateTime?)dtp_resolved.Value.Date : null;
            decimal?  cost       = string.IsNullOrWhiteSpace(txt_cost.Text)
                                   ? (decimal?)null : decimal.Parse(txt_cost.Text.Trim());

            _selected.setStatus(newStatus);
            _selected.setReportedAt(dtp_reported.Value);
            _selected.setResolvedAt(resolvedAt);
            _selected.setCost(cost);
            _selected.setTechnicianName(txt_technician.Text.Trim());
            _selected.setDescription(txt_description.Text.Trim());
            _selected.updateMaintenance();

            // Reopening a closed record → mark boat as needing maintenance again
            if (oldStatus == "סגור" && newStatus != "סגור")
            {
                Boat boat = _selected.getBoat() ?? Boat.seekBoat(_selected.getBoatNumberId());
                if (boat != null)
                {
                    boat.setBoatStatus("Under Maintenance");
                    boat.updateBoat();
                }
            }

            loadGrid();
            selectInForm(_selected);
            setMode_edit();
            MessageBox.Show("רשומת התחזוקה עודכנה בהצלחה", "עדכון",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_close_fault_Click(object sender, EventArgs e)
        {
            if (!_canClose) { showError("אין לך הרשאה לסגור רשומות תחזוקה"); return; }
            if (_selected == null) return;

            var confirm = MessageBox.Show(
                $"לסגור את רשומת התחזוקה #{_selected.getMaintenanceId()}?\n" +
                "הסירה תחזור לסטטוס \"Active\".",
                "אישור סגירת תקלה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            _selected.setStatus("סגור");
            if (!_selected.getResolvedAt().HasValue)
                _selected.setResolvedAt(DateTime.Today);
            _selected.updateMaintenance();

            Boat boat = _selected.getBoat() ?? Boat.seekBoat(_selected.getBoatNumberId());
            if (boat != null)
            {
                boat.setBoatStatus("Active");
                boat.updateBoat();
            }

            loadGrid();
            selectInForm(_selected);
            setMode_edit();
            MessageBox.Show(
                $"התקלה נסגרה בהצלחה.\nסטטוס הסירה עודכן ל-\"Active\".",
                "תקלה נסגרה", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (!_canDelete) { showError("אין לך הרשאה למחוק רשומות תחזוקה"); return; }
            if (_selected == null) return;

            var confirm = MessageBox.Show(
                $"האם למחוק רשומת תחזוקה #{_selected.getMaintenanceId()}?\nפעולה זו אינה ניתנת לביטול.",
                "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            _selected.getBoat()?.removeMaintenance(_selected);
            _selected.deleteMaintenance();
            loadGrid();
            setMode_new();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            if (_fromBoatsPanel)
                MainForm.showPanel(new BoatsPanel());
            else
                MainForm.showPanel(new AdminMenuPanel());
        }

        // =====================================================================
        // UI helpers
        // =====================================================================
        private void showError(string msg) { label_error.Text = msg; label_error.Visible = true; }
        private void hideError()           { label_error.Visible = false; }
        private void clearBg(System.Windows.Forms.Control c)
            => c.BackColor = System.Drawing.SystemColors.Window;
        private void clearAllHighlights()
        {
            txt_cost.BackColor        = System.Drawing.SystemColors.Window;
            txt_description.BackColor = System.Drawing.SystemColors.Window;
        }
    }
}
