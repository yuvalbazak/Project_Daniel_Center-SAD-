using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class DiscountRequestPanel : UserControl
    {
        private static readonly string[] DISCOUNT_TYPES = {
            "חייל", "חד הורי", "משפחה מרובת ילדים", "גמלאי"
        };
        private static readonly string[] DISCOUNT_STATUSES = {
            "ממתינה לאסמכתאות", "הוגשה", "בטיפול", "מאושרת", "נדחתה"
        };
        private static readonly System.Drawing.Color ERR_BG =
            System.Drawing.Color.FromArgb(255, 220, 220);

        private bool            _canWrite;
        private DiscountRequest _selected     = null;
        private List<Customer>  _customerList = new List<Customer>();

        public DiscountRequestPanel()
        {
            InitializeComponent();

            if (!AuthService.CanViewDiscountRequests())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            _canWrite = AuthService.CanManageDiscountRequests();

            combo_type.Items.AddRange(DISCOUNT_TYPES);
            combo_status.Items.AddRange(DISCOUNT_STATUSES);
            combo_type.SelectedIndex   = 0;
            combo_status.SelectedIndex = 0;

            populateCustomerCombo();

            chk_has_resolved.CheckedChanged += (s, e) =>
                dtp_resolved.Enabled = chk_has_resolved.Checked && chk_has_resolved.Enabled;
            txt_percent.TextChanged += (s, e) => clearField(txt_percent);

            loadGrid();
            dataGridView_discounts.SelectionChanged += onSelectionChanged;
            setMode_new();
            applyRoleRestrictions();
        }

        // =====================================================================
        // RBAC
        // =====================================================================
        private void applyRoleRestrictions()
        {
            if (!_canWrite)
                label_form_title.Text = "פרטי בקשת הנחה — צפייה בלבד";
        }

        // =====================================================================
        // Combo population
        // =====================================================================
        private void populateCustomerCombo()
        {
            combo_customer.Items.Clear();
            _customerList.Clear();
            combo_customer.Items.Add("--- בחר לקוח ---");
            _customerList.Add(null);
            foreach (Customer c in Program.Customers)
            {
                combo_customer.Items.Add($"{c.getCustomerId()} — {c.getFullName()}");
                _customerList.Add(c);
            }
            combo_customer.SelectedIndex = 0;
        }

        // =====================================================================
        // Grid
        // =====================================================================
        private void loadGrid()
        {
            dataGridView_discounts.SelectionChanged -= onSelectionChanged;

            DataTable dt = new DataTable();
            dt.Columns.Add("מספר",         typeof(string));
            dt.Columns.Add("לקוח",          typeof(string));
            dt.Columns.Add("סוג הנחה",     typeof(string));
            dt.Columns.Add("סטטוס",         typeof(string));
            dt.Columns.Add("תאריך הגשה",   typeof(string));
            dt.Columns.Add("תאריך טיפול",  typeof(string));
            dt.Columns.Add("אחוז הנחה",    typeof(string));
            dt.Columns.Add("מסמך",          typeof(string));

            foreach (DiscountRequest dr in Program.DiscountRequests)
            {
                Customer c = dr.getCustomer() ?? Customer.seekCustomer(dr.getCustomerId());
                string custDisplay = c != null
                    ? $"{c.getCustomerId()} — {c.getFullName()}"
                    : dr.getCustomerId();

                dt.Rows.Add(
                    dr.getDiscountRequestNumId().ToString(),
                    custDisplay,
                    dr.getDiscountType(),
                    dr.getDiscountStatus(),
                    dr.getSubmittedAt().ToShortDateString(),
                    dr.getResolvedAt()?.ToShortDateString() ?? "—",
                    dr.getDiscountPercent().HasValue
                        ? dr.getDiscountPercent().Value.ToString("F1") + "%" : "—",
                    string.IsNullOrWhiteSpace(dr.getFilePath()) ? "—" : "✓"
                );
            }

            dataGridView_discounts.DataSource = dt;
            dataGridView_discounts.SelectionChanged += onSelectionChanged;
        }

        private void onSelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_discounts.SelectedRows.Count == 0) return;
            string idStr = dataGridView_discounts.SelectedRows[0].Cells[0].Value?.ToString();
            if (!int.TryParse(idStr, out int id)) return;

            DiscountRequest dr = DiscountRequest.seekDiscountRequest(id);
            if (dr == null) return;

            _selected = dr;
            populateForm(dr);
            setMode_edit();
        }

        // =====================================================================
        // Form helpers
        // =====================================================================
        private void populateForm(DiscountRequest dr)
        {
            txt_id.Text = dr.getDiscountRequestNumId().ToString();
            txt_id.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);

            combo_customer.SelectedIndex = 0;
            for (int i = 1; i < _customerList.Count; i++)
            {
                if (_customerList[i]?.getCustomerId() == dr.getCustomerId())
                { combo_customer.SelectedIndex = i; break; }
            }

            combo_type.SelectedIndex = -1;
            for (int i = 0; i < combo_type.Items.Count; i++)
                if (combo_type.Items[i].ToString() == dr.getDiscountType())
                { combo_type.SelectedIndex = i; break; }
            if (combo_type.SelectedIndex < 0) combo_type.Text = dr.getDiscountType();

            combo_status.SelectedIndex = -1;
            for (int i = 0; i < combo_status.Items.Count; i++)
                if (combo_status.Items[i].ToString() == dr.getDiscountStatus())
                { combo_status.SelectedIndex = i; break; }
            if (combo_status.SelectedIndex < 0) combo_status.Text = dr.getDiscountStatus();

            dtp_submitted.Value = dr.getSubmittedAt();

            if (dr.getResolvedAt().HasValue)
            {
                chk_has_resolved.Checked = true;
                dtp_resolved.Value       = dr.getResolvedAt().Value;
                dtp_resolved.Enabled     = _canWrite;
            }
            else
            {
                chk_has_resolved.Checked = false;
                dtp_resolved.Enabled     = false;
            }

            txt_percent.Text   = dr.getDiscountPercent().HasValue
                                  ? dr.getDiscountPercent().Value.ToString("F1") : "";
            txt_file_path.Text = dr.getFilePath() ?? "";
        }

        private void clearForm()
        {
            txt_id.Text                  = "(אוטומטי)";
            txt_id.BackColor             = System.Drawing.SystemColors.Window;
            combo_customer.SelectedIndex = 0;
            combo_type.SelectedIndex     = 0;
            combo_status.SelectedIndex   = 0;
            dtp_submitted.Value          = DateTime.Today;
            chk_has_resolved.Checked     = false;
            dtp_resolved.Value           = DateTime.Today;
            dtp_resolved.Enabled         = false;
            txt_percent.Text             = "";
            txt_file_path.Text           = "";
        }

        // =====================================================================
        // Mode switching
        // =====================================================================
        private void setMode_new()
        {
            _selected = null;
            clearForm();

            btn_new.Visible     = _canWrite;
            btn_save.Visible    = _canWrite;
            btn_update.Visible  = false;
            btn_delete.Visible  = false;
            btn_approve.Visible = false;
            btn_reject.Visible  = false;

            setFormEnabled(_canWrite);
            combo_customer.Enabled = _canWrite;
            clearAllHighlights();
            hideError();
            dataGridView_discounts.ClearSelection();
        }

        private void setMode_edit()
        {
            btn_save.Visible    = false;
            btn_update.Visible  = _canWrite;
            btn_delete.Visible  = _canWrite;
            btn_approve.Visible = _canWrite && _selected?.getDiscountStatus() != "מאושרת";
            btn_reject.Visible  = _canWrite && _selected?.getDiscountStatus() != "נדחתה";

            setFormEnabled(_canWrite);
            combo_customer.Enabled = false;
            clearAllHighlights();
            hideError();
        }

        private void setFormEnabled(bool enabled)
        {
            combo_type.Enabled       = enabled;
            combo_status.Enabled     = enabled;
            dtp_submitted.Enabled    = enabled;
            chk_has_resolved.Enabled = enabled;
            dtp_resolved.Enabled     = enabled && chk_has_resolved.Checked;
            txt_percent.ReadOnly     = !enabled;
            txt_file_path.ReadOnly   = !enabled;
        }

        // =====================================================================
        // Validation
        // =====================================================================
        private bool validateForm(bool isNew)
        {
            if (isNew && combo_customer.SelectedIndex <= 0)
            { showError("יש לבחור לקוח"); return false; }

            if (combo_type.SelectedIndex < 0 && string.IsNullOrWhiteSpace(combo_type.Text))
            { showError("יש לבחור סוג הנחה"); return false; }

            if (combo_status.SelectedIndex < 0 && string.IsNullOrWhiteSpace(combo_status.Text))
            { showError("יש לבחור סטטוס"); return false; }

            if (!string.IsNullOrWhiteSpace(txt_percent.Text))
            {
                if (!decimal.TryParse(txt_percent.Text.Trim(), out decimal pct) || pct < 0 || pct > 100)
                { txt_percent.BackColor = ERR_BG; showError("אחוז ההנחה חייב להיות מספר בין 0 ל-100"); return false; }
            }

            return true;
        }

        // =====================================================================
        // Button handlers
        // =====================================================================
        private void btn_new_Click(object sender, EventArgs e)
            => setMode_new();

        private void btn_save_Click(object sender, EventArgs e)
        {
            hideError();
            if (!_canWrite) { showError("אין לך הרשאה להוסיף בקשות הנחה"); return; }
            if (!validateForm(true)) return;

            int newId = 1;
            foreach (DiscountRequest dr in Program.DiscountRequests)
                if (dr.getDiscountRequestNumId() >= newId)
                    newId = dr.getDiscountRequestNumId() + 1;

            Customer  selCust    = _customerList[combo_customer.SelectedIndex];
            string    type       = combo_type.SelectedIndex >= 0
                                   ? combo_type.SelectedItem.ToString() : combo_type.Text.Trim();
            string    status     = combo_status.SelectedIndex >= 0
                                   ? combo_status.SelectedItem.ToString() : combo_status.Text.Trim();
            decimal?  pct        = string.IsNullOrWhiteSpace(txt_percent.Text)
                                   ? (decimal?)null : decimal.Parse(txt_percent.Text.Trim());
            string    filePath   = string.IsNullOrWhiteSpace(txt_file_path.Text)
                                   ? null : txt_file_path.Text.Trim();
            DateTime? resolvedAt = chk_has_resolved.Checked
                                   ? (DateTime?)dtp_resolved.Value.Date : null;

            DiscountRequest newDr = new DiscountRequest(
                newId, selCust.getCustomerId(), type, filePath,
                status, pct, dtp_submitted.Value.Date, resolvedAt, true);

            selCust.addDiscountRequest(newDr);

            MessageBox.Show("בקשת ההנחה נשמרה בהצלחה", "שמירה",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadGrid();
            setMode_new();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            hideError();
            if (!_canWrite) { showError("אין לך הרשאה לעדכן בקשות הנחה"); return; }
            if (_selected == null) return;
            if (!validateForm(false)) return;

            string    type     = combo_type.SelectedIndex >= 0
                                 ? combo_type.SelectedItem.ToString() : combo_type.Text.Trim();
            string    status   = combo_status.SelectedIndex >= 0
                                 ? combo_status.SelectedItem.ToString() : combo_status.Text.Trim();
            decimal?  pct      = string.IsNullOrWhiteSpace(txt_percent.Text)
                                 ? (decimal?)null : decimal.Parse(txt_percent.Text.Trim());
            string    filePath = string.IsNullOrWhiteSpace(txt_file_path.Text)
                                 ? null : txt_file_path.Text.Trim();
            DateTime? resolvedAt = chk_has_resolved.Checked
                                   ? (DateTime?)dtp_resolved.Value.Date : null;

            _selected.setDiscountType(type);
            _selected.setDiscountStatus(status);
            _selected.setDiscountPercent(pct);
            _selected.setFilePath(filePath);
            _selected.setSubmittedAt(dtp_submitted.Value.Date);
            _selected.setResolvedAt(resolvedAt);
            _selected.updateDiscountRequest();

            MessageBox.Show("בקשת ההנחה עודכנה בהצלחה", "עדכון",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadGrid();
            setMode_new();
        }

        private void btn_approve_Click(object sender, EventArgs e)
        {
            if (!_canWrite || _selected == null) return;

            string pctText = txt_percent.Text.Trim();
            if (string.IsNullOrWhiteSpace(pctText))
            { showError("יש להזין אחוז הנחה לפני האישור"); return; }
            if (!decimal.TryParse(pctText, out decimal pct) || pct < 0 || pct > 100)
            { txt_percent.BackColor = ERR_BG; showError("אחוז ההנחה חייב להיות מספר בין 0 ל-100"); return; }

            var confirm = MessageBox.Show(
                $"לאשר את בקשת ההנחה #{_selected.getDiscountRequestNumId()} עם {pct:F1}% הנחה?",
                "אישור בקשת הנחה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            _selected.setDiscountPercent(pct);
            _selected.setDiscountStatus("מאושרת");
            _selected.setResolvedAt(DateTime.Today);
            _selected.updateDiscountRequest();

            MessageBox.Show("בקשת ההנחה אושרה בהצלחה", "אושר",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadGrid();
            setMode_new();
        }

        private void btn_reject_Click(object sender, EventArgs e)
        {
            if (!_canWrite || _selected == null) return;

            var confirm = MessageBox.Show(
                $"לדחות את בקשת ההנחה #{_selected.getDiscountRequestNumId()}?",
                "דחיית בקשת הנחה", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            _selected.setDiscountStatus("נדחתה");
            _selected.setResolvedAt(DateTime.Today);
            _selected.updateDiscountRequest();

            MessageBox.Show("בקשת ההנחה נדחתה", "עדכון סטטוס",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadGrid();
            setMode_new();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (!_canWrite || _selected == null) return;

            DialogResult answer = MessageBox.Show(
                $"האם למחוק את בקשת ההנחה #{_selected.getDiscountRequestNumId()}?\nפעולה זו אינה ניתנת לביטול.",
                "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer == DialogResult.Yes)
            {
                _selected.deleteDiscountRequest();
                MessageBox.Show("בקשת ההנחה נמחקה בהצלחה", "הצלחה",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadGrid();
                setMode_new();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
            => MainForm.showPanel(new HomePanel());

        // =====================================================================
        // UI helpers
        // =====================================================================
        private void showError(string msg) { label_error.Text = msg; label_error.Visible = true; }
        private void hideError()           { label_error.Visible = false; }
        private void clearField(System.Windows.Forms.Control c)
            => c.BackColor = System.Drawing.SystemColors.Window;
        private void clearAllHighlights()
            => txt_percent.BackColor = System.Drawing.SystemColors.Window;
    }
}
