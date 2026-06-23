using System;
using System.Data;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class BoatsPanel : UserControl
    {
        private static readonly string[] BOAT_TYPES = {
            "Kayak", "Sailing boat", "Academic Kayak"
        };
        private static readonly string[] BOAT_STATUSES = {
            "Active", "Under Maintenance", "Out of Service"
        };
        private static readonly string[] SOURCE_TYPES = {
            "רכישה", "תרומה", "השאלה", "שכירות"
        };

        private static bool isInternalBoat(Boat b)
        {
            return b.getSourceType() == "Internal";
        }

        private static readonly System.Drawing.Color ERR_BG =
            System.Drawing.Color.FromArgb(255, 220, 220);

        private Boat _selected = null;

        public BoatsPanel()
        {
            InitializeComponent();

            // Customers cannot see the general boat catalogue
            if (AuthService.IsCustomer())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            combo_type.Items.AddRange(BOAT_TYPES);
            combo_status.Items.AddRange(BOAT_STATUSES);
            combo_source.Items.AddRange(SOURCE_TYPES);
            combo_type.SelectedIndex   = 0;
            combo_status.SelectedIndex = 0;
            combo_source.SelectedIndex = 0;

            // Source field is internal-only metadata; hide it from the UI
            label_source.Visible = false;
            combo_source.Visible = false;

            txt_id.TextChanged   += (s, e) => { clearField(txt_id);   hideError(); };
            txt_name.TextChanged += (s, e) => { clearField(txt_name); hideError(); };

            loadGrid();
            setMode_new();
            applyRoleRestrictions();
        }

        // =====================================================================
        // RBAC — apply read-only constraints based on current role
        // =====================================================================
        private void applyRoleRestrictions()
        {
            if (!AuthService.CanWriteBoats())
            {
                label_form_title.Text   = "פרטי סירה — צפייה בלבד";
                txt_name.ReadOnly       = true;
                combo_type.Enabled      = false;
                combo_status.Enabled    = false;
                combo_source.Enabled    = false;
                dtp_purchase.Enabled    = false;
                dtp_license.Enabled     = false;
                dtp_maint_date.Enabled  = false;
            }

            bool canViewMaint = AuthService.CanViewBoatMaintenance();
            label_maint_header.Visible       = canViewMaint;
            dataGridView_maintenance.Visible  = canViewMaint;

            // fault button shown only when a boat is selected (done in SelectionChanged)
            btn_report_fault.Visible = false;
        }

        // =====================================================================
        // Grids
        // =====================================================================
        private void loadGrid()
        {
            dataGridView_boats.SelectionChanged -= dataGridView_boats_SelectionChanged;

            DataTable dt = new DataTable();
            dt.Columns.Add("מספר",           typeof(string));
            dt.Columns.Add("סוג",            typeof(string));
            dt.Columns.Add("שם",             typeof(string));
            dt.Columns.Add("סטטוס",          typeof(string));
            dt.Columns.Add("תאריך רכישה",   typeof(string));
            dt.Columns.Add("תאריך רישיון",  typeof(string));
            dt.Columns.Add("תחזוקה שנתית",  typeof(string));
            dt.Columns.Add("מקור",           typeof(string));

            foreach (Boat b in Program.Boats)
            {
                if (!isInternalBoat(b)) continue; // display internal center boats only
                dt.Rows.Add(
                    b.getBoatNumberId().ToString(),
                    b.getBoatType(),
                    b.getWaterCraftName(),
                    b.getBoatStatus(),
                    b.getPurchaseDate().ToShortDateString(),
                    b.getLicenseDate().ToShortDateString(),
                    b.getAnnualMaintenanceDate().ToShortDateString(),
                    b.getSourceType()
                );
            }

            dataGridView_boats.DataSource = dt;
            dataGridView_boats.SelectionChanged += dataGridView_boats_SelectionChanged;
        }

        private void loadMaintenance()
        {
            if (_selected == null || !AuthService.CanViewBoatMaintenance())
            {
                dataGridView_maintenance.DataSource = null;
                return;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("תאריך דיווח",  typeof(string));
            dt.Columns.Add("תיאור",         typeof(string));
            dt.Columns.Add("סטטוס",         typeof(string));
            dt.Columns.Add("תאריך סגירה",  typeof(string));
            dt.Columns.Add("עלות",          typeof(string));
            dt.Columns.Add("טכנאי",         typeof(string));

            foreach (Maintenance m in _selected.getMaintenances())
            {
                dt.Rows.Add(
                    m.getReportedAt().ToShortDateString(),
                    m.getDescription(),
                    m.getStatus(),
                    m.getResolvedAt()?.ToShortDateString() ?? "—",
                    m.getCost()?.ToString("F2") + " ₪" ?? "—",
                    string.IsNullOrWhiteSpace(m.getTechnicianName()) ? "—" : m.getTechnicianName()
                );
            }

            dataGridView_maintenance.DataSource = dt;
        }

        // =====================================================================
        // Selection
        // =====================================================================
        private void dataGridView_boats_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_boats.SelectedRows.Count == 0) return;

            string idStr = dataGridView_boats.SelectedRows[0].Cells[0].Value?.ToString();
            if (!int.TryParse(idStr, out int id)) return;

            Boat b = Boat.seekBoat(id);
            if (b == null) return;

            _selected = b;
            populateForm(b);
            setMode_edit();
            loadMaintenance();

            btn_report_fault.Visible = AuthService.CanReportBoatFault();
        }

        // =====================================================================
        // Form helpers
        // =====================================================================
        private void populateForm(Boat b)
        {
            txt_id.Text          = b.getBoatNumberId().ToString();
            combo_type.Text      = b.getBoatType();
            txt_name.Text        = b.getWaterCraftName();
            combo_status.Text    = b.getBoatStatus();
            dtp_purchase.Value   = b.getPurchaseDate();
            dtp_license.Value    = b.getLicenseDate();
            dtp_maint_date.Value = b.getAnnualMaintenanceDate();
            combo_source.Text    = b.getSourceType();
        }

        private void clearForm()
        {
            txt_id.Text               = "";
            txt_name.Text             = "";
            combo_type.SelectedIndex   = 0;
            combo_status.SelectedIndex = 0;
            combo_source.SelectedIndex = 0;
            dtp_purchase.Value         = DateTime.Today;
            dtp_license.Value          = DateTime.Today;
            dtp_maint_date.Value       = DateTime.Today.AddYears(1);
        }

        // =====================================================================
        // Mode switching
        // =====================================================================
        private void setMode_new()
        {
            _selected        = null;
            txt_id.Enabled   = true;
            txt_id.BackColor = System.Drawing.SystemColors.Window;

            bool canWrite = AuthService.CanWriteBoats();
            btn_new.Visible    = canWrite;
            btn_save.Visible   = canWrite;
            btn_update.Visible = false;
            btn_delete.Visible = false;

            btn_report_fault.Visible            = false;
            dataGridView_maintenance.DataSource = null;

            clearForm();
            clearAllHighlights();
            hideError();
            dataGridView_boats.ClearSelection();
        }

        private void setMode_edit()
        {
            txt_id.Enabled   = false;
            txt_id.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);

            bool canWrite = AuthService.CanWriteBoats();
            btn_save.Visible   = false;
            btn_update.Visible = canWrite;
            btn_delete.Visible = canWrite;

            clearAllHighlights();
            hideError();
        }

        // =====================================================================
        // Button handlers
        // =====================================================================
        private void btn_new_Click(object sender, EventArgs e)
        {
            setMode_new();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!validateForm(isNew: true)) return;

            int id = int.Parse(txt_id.Text.Trim());
            new Boat(
                id,
                combo_type.Text,
                txt_name.Text.Trim(),
                combo_status.Text,
                dtp_purchase.Value.Date,
                dtp_license.Value.Date,
                dtp_maint_date.Value.Date,
                "Internal",
                true
            );

            MessageBox.Show("הסירה נוספה בהצלחה", "הצלחה",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadGrid();
            setMode_new();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;
            if (!validateForm(isNew: false)) return;

            _selected.setBoatType(combo_type.Text);
            _selected.setWaterCraftName(txt_name.Text.Trim());
            _selected.setBoatStatus(combo_status.Text);
            _selected.setPurchaseDate(dtp_purchase.Value.Date);
            _selected.setLicenseDate(dtp_license.Value.Date);
            _selected.setAnnualMaintenanceDate(dtp_maint_date.Value.Date);
            _selected.setSourceType(combo_source.Text);
            _selected.updateBoat();

            MessageBox.Show("פרטי הסירה עודכנו בהצלחה", "הצלחה",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadGrid();
            setMode_new();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;

            DialogResult answer = MessageBox.Show(
                "האם אתה בטוח שברצונך להעביר רשומה זו לארכיון?",
                "אישור העברה לארכיון",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (answer == DialogResult.Yes)
            {
                _selected.setBoatStatus("Out of Service");
                _selected.updateBoat();
                MessageBox.Show("הרשומה הועברה לארכיון בהצלחה", "ארכיון",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadGrid();
                setMode_new();
            }
        }

        private void btn_report_fault_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;
            MainForm.showPanel(new MaintenancePanel(_selected, fromBoatsPanel: true));
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            MainForm.showPanel(new HomePanel());
        }

        // =====================================================================
        // Validation
        // =====================================================================
        private bool validateForm(bool isNew)
        {
            string idStr = txt_id.Text.Trim();
            string name  = txt_name.Text.Trim();

            if (isNew)
            {
                if (string.IsNullOrWhiteSpace(idStr) || !int.TryParse(idStr, out int parsed) || parsed <= 0)
                { highlightField(txt_id); showError("מספר סירה חייב להיות מספר חיובי תקין"); return false; }

                if (Boat.seekBoat(int.Parse(idStr)) != null)
                { highlightField(txt_id); showError("מספר סירה זה כבר קיים במערכת"); return false; }
            }

            if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
            { highlightField(txt_name); showError("שם הסירה חייב להכיל לפחות 2 תווים"); return false; }

            if (dtp_purchase.Value.Date > DateTime.Today)
            { showError("תאריך רכישה לא יכול להיות בעתיד"); return false; }

            if (dtp_license.Value.Date < dtp_purchase.Value.Date)
            { showError("תאריך רישיון לא יכול להיות לפני תאריך רכישה"); return false; }

            return true;
        }

        // =====================================================================
        // UI helpers
        // =====================================================================
        private void showError(string msg)  { label_error.Text = msg; label_error.Visible = true; }
        private void hideError()            { label_error.Visible = false; }

        private void highlightField(System.Windows.Forms.Control ctrl) => ctrl.BackColor = ERR_BG;
        private void clearField(System.Windows.Forms.Control ctrl)     => ctrl.BackColor = System.Drawing.SystemColors.Window;

        private void clearAllHighlights()
        {
            clearField(txt_id);
            clearField(txt_name);
        }
    }
}
