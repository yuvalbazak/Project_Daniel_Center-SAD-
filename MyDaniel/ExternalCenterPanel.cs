using System;
using System.Data;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class ExternalCenterPanel : UserControl
    {
        private static readonly System.Drawing.Color ERR_BG =
            System.Drawing.Color.FromArgb(255, 220, 220);

        private ExternalCenter _selected = null;
        private bool _canWrite;

        public ExternalCenterPanel()
        {
            InitializeComponent();

            if (AuthService.IsCustomer())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            _canWrite = AuthService.CanWriteExternalCenters();

            if (!_canWrite)
                label_form_title.Text = "פרטי מרכז חיצוני — צפייה בלבד";

            txt_name.TextChanged    += (s, e) => clearBg(txt_name);
            txt_contact.TextChanged += (s, e) => clearBg(txt_contact);
            txt_phone.TextChanged   += (s, e) => clearBg(txt_phone);

            loadGrid();
            dataGridView_centers.SelectionChanged += onSelectionChanged;
            setMode_new();
        }

        // =====================================================================
        // Grid
        // =====================================================================
        private void loadGrid()
        {
            dataGridView_centers.SelectionChanged -= onSelectionChanged;

            DataTable dt = new DataTable();
            dt.Columns.Add("מספר",      typeof(string));
            dt.Columns.Add("שם המרכז", typeof(string));
            dt.Columns.Add("איש קשר",  typeof(string));
            dt.Columns.Add("טלפון",     typeof(string));

            foreach (ExternalCenter ec in Program.ExternalCenters)
            {
                dt.Rows.Add(
                    ec.getExternalCenterId().ToString(),
                    ec.getCenterName(),
                    string.IsNullOrWhiteSpace(ec.getContactName()) ? "—" : ec.getContactName(),
                    string.IsNullOrWhiteSpace(ec.getPhone())       ? "—" : ec.getPhone()
                );
            }

            dataGridView_centers.DataSource = dt;
            dataGridView_centers.SelectionChanged += onSelectionChanged;
        }

        private void onSelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_centers.SelectedRows.Count == 0) return;

            string idStr = dataGridView_centers.SelectedRows[0].Cells[0].Value?.ToString();
            if (!int.TryParse(idStr, out int id)) return;

            ExternalCenter ec = ExternalCenter.seekExternalCenter(id);
            if (ec == null) return;

            _selected = ec;
            populateForm(ec);
            setMode_edit();
        }

        // =====================================================================
        // Form helpers
        // =====================================================================
        private void populateForm(ExternalCenter ec)
        {
            txt_id.Text      = ec.getExternalCenterId().ToString();
            txt_name.Text    = ec.getCenterName();
            txt_contact.Text = ec.getContactName();
            txt_phone.Text   = ec.getPhone();
        }

        private void clearForm()
        {
            txt_id.Text      = "(אוטומטי)";
            txt_name.Text    = "";
            txt_contact.Text = "";
            txt_phone.Text   = "";
        }

        // =====================================================================
        // Mode switching
        // =====================================================================
        private void setMode_new()
        {
            _selected = null;
            clearForm();

            btn_new.Visible    = _canWrite;
            btn_save.Visible   = _canWrite;
            btn_update.Visible = false;
            btn_delete.Visible = false;

            setFormEnabled(_canWrite);
            clearAllHighlights();
            hideError();
            dataGridView_centers.ClearSelection();
        }

        private void setMode_edit()
        {
            btn_save.Visible   = false;
            btn_update.Visible = _canWrite;
            btn_delete.Visible = _canWrite;

            setFormEnabled(_canWrite);
            clearAllHighlights();
            hideError();
        }

        private void setFormEnabled(bool enabled)
        {
            txt_name.ReadOnly    = !enabled;
            txt_contact.ReadOnly = !enabled;
            txt_phone.ReadOnly   = !enabled;
        }

        // =====================================================================
        // Validation
        // =====================================================================
        private bool validateForm()
        {
            if (string.IsNullOrWhiteSpace(txt_name.Text) || txt_name.Text.Trim().Length < 2)
            {
                txt_name.BackColor = ERR_BG;
                showError("שם המרכז חייב להכיל לפחות 2 תווים");
                return false;
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
            if (!_canWrite) { showError("אין לך הרשאה להוסיף מרכזים חיצוניים"); return; }
            if (!validateForm()) return;

            int newId = 1;
            foreach (ExternalCenter ec in Program.ExternalCenters)
                if (ec.getExternalCenterId() >= newId)
                    newId = ec.getExternalCenterId() + 1;

            new ExternalCenter(newId,
                               txt_name.Text.Trim(),
                               txt_contact.Text.Trim(),
                               txt_phone.Text.Trim(),
                               true);

            MessageBox.Show("המרכז החיצוני נוסף בהצלחה", "הצלחה",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadGrid();
            setMode_new();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            hideError();
            if (!_canWrite) { showError("אין לך הרשאה לעדכן מרכזים חיצוניים"); return; }
            if (_selected == null) return;
            if (!validateForm()) return;

            _selected.setCenterName(txt_name.Text.Trim());
            _selected.setContactName(txt_contact.Text.Trim());
            _selected.setPhone(txt_phone.Text.Trim());
            _selected.updateExternalCenter();

            MessageBox.Show("פרטי המרכז החיצוני עודכנו בהצלחה", "הצלחה",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadGrid();
            setMode_new();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (!_canWrite) { showError("אין לך הרשאה למחוק מרכזים חיצוניים"); return; }
            if (_selected == null) return;

            DialogResult answer = MessageBox.Show(
                $"האם למחוק את המרכז החיצוני \"{_selected.getCenterName()}\"?\nפעולה זו אינה ניתנת לביטול.",
                "אישור מחיקה",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (answer == DialogResult.Yes)
            {
                _selected.deleteExternalCenter();
                MessageBox.Show("המרכז החיצוני נמחק בהצלחה", "הצלחה",
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
        private void clearBg(System.Windows.Forms.Control c)
            => c.BackColor = System.Drawing.SystemColors.Window;
        private void clearAllHighlights()
        {
            txt_name.BackColor    = System.Drawing.SystemColors.Window;
            txt_contact.BackColor = System.Drawing.SystemColors.Window;
            txt_phone.BackColor   = System.Drawing.SystemColors.Window;
        }
    }
}
