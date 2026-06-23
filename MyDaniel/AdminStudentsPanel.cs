using System;
using System.Data;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class AdminStudentsPanel : UserControl
    {
        private static readonly System.Drawing.Color ERR_BG =
            System.Drawing.Color.FromArgb(255, 220, 220);

        private Customer _selected     = null;
        private bool     _showArchived = false;

        public AdminStudentsPanel()
        {
            InitializeComponent();

            if (!AuthService.CanAdminPortalWrite())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            combo_status.Items.AddRange(new string[] { "Active", "Archive", "Pending" });

            txt_search.TextChanged    += (s, e) => loadGrid();
            txt_id.TextChanged        += (s, e) => { clearField(txt_id);    hideError(); };
            txt_name.TextChanged      += (s, e) => { clearField(txt_name);  hideError(); };
            txt_phone.TextChanged     += (s, e) => { clearField(txt_phone); hideError(); };
            txt_email.TextChanged     += (s, e) => { clearField(txt_email); hideError(); };

            dataGridView_students.SelectionChanged += onGridSelectionChanged;
            loadGrid();
            setMode_new();
        }

        private static bool isArchived(Customer c)
            => c.getCustomerStatus().Equals("Archive", StringComparison.OrdinalIgnoreCase);

        private void loadGrid()
        {
            dataGridView_students.SelectionChanged -= onGridSelectionChanged;

            string search = txt_search.Text.Trim().ToLower();

            DataTable dt = new DataTable();
            dt.Columns.Add("מ.ז.",   typeof(string));
            dt.Columns.Add("שם מלא", typeof(string));
            dt.Columns.Add("טלפון",  typeof(string));
            dt.Columns.Add("אימייל", typeof(string));
            dt.Columns.Add("סטטוס",  typeof(string));
            dt.Columns.Add("תשלום",  typeof(string));

            foreach (Customer c in Program.Customers)
            {
                bool archived = isArchived(c);
                if (!_showArchived && archived)  continue;
                if (_showArchived  && !archived) continue;

                if (!string.IsNullOrEmpty(search))
                {
                    bool match = c.getCustomerId().ToLower().Contains(search)
                              || c.getFullName().ToLower().Contains(search)
                              || c.getEmail().ToLower().Contains(search)
                              || c.getPhone().ToLower().Contains(search);
                    if (!match) continue;
                }

                dt.Rows.Add(
                    c.getCustomerId(),
                    c.getFullName(),
                    c.getPhone(),
                    c.getEmail(),
                    c.getCustomerStatus(),
                    c.getPaymentStatus()
                );
            }

            dataGridView_students.DataSource = dt;
            dataGridView_students.SelectionChanged += onGridSelectionChanged;
        }

        private void onGridSelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_students.SelectedRows.Count == 0) return;
            string id = dataGridView_students.SelectedRows[0].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(id)) return;
            Customer c = Customer.seekCustomer(id);
            if (c == null) return;
            _selected = c;
            populateForm(c);
            setMode_edit();
        }

        private void populateForm(Customer c)
        {
            txt_id.Text        = c.getCustomerId();
            txt_name.Text      = c.getFullName();
            txt_phone.Text     = c.getPhone();
            txt_email.Text     = c.getEmail();
            txt_emergency.Text = c.getEmergencyContact();

            DateTime birth = c.getBirthDate();
            dtp_birth.Value = (birth < dtp_birth.MinDate || birth > dtp_birth.MaxDate)
                              ? DateTime.Today.AddYears(-18) : birth;

            int idx = combo_status.Items.IndexOf(c.getCustomerStatus());
            combo_status.SelectedIndex = idx >= 0 ? idx : 0;

            txt_password.Text = c.getPassword();
        }

        private void clearForm()
        {
            txt_id.Text                = "";
            txt_name.Text              = "";
            txt_phone.Text             = "";
            txt_email.Text             = "";
            txt_emergency.Text         = "";
            dtp_birth.Value            = DateTime.Today.AddYears(-18);
            combo_status.SelectedIndex = 0;
            txt_password.Text          = "";
        }

        private void setMode_new()
        {
            _selected        = null;
            txt_id.Enabled   = true;
            txt_id.BackColor = System.Drawing.SystemColors.Window;

            btn_save.Visible    = true;
            btn_update.Visible  = false;
            btn_archive.Visible = false;

            clearForm();
            clearAllHighlights();
            hideError();
            dataGridView_students.ClearSelection();
        }

        private void setMode_edit()
        {
            txt_id.Enabled   = false;
            txt_id.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);

            btn_save.Visible    = false;
            btn_update.Visible  = true;
            btn_archive.Visible = true;

            bool archived = _selected != null && isArchived(_selected);
            btn_archive.Text      = archived ? "שחזר מארכיון" : "שלח לארכיון";
            btn_archive.BackColor = archived ? System.Drawing.Color.SeaGreen : System.Drawing.Color.Peru;

            clearAllHighlights();
            hideError();
        }

        private void btn_toggle_archive_Click(object sender, EventArgs e)
        {
            _showArchived           = !_showArchived;
            btn_toggle_archive.Text = _showArchived ? "הצג פעילים" : "הצג ארכיון";
            loadGrid();
            setMode_new();
        }

        private void btn_new_Click(object sender, EventArgs e) => setMode_new();

        private void btn_save_Click(object sender, EventArgs e)
        {
            hideError();
            if (!validateForm(isNew: true)) return;

            string id     = txt_id.Text.Trim();
            string email  = txt_email.Text.Trim();
            string pass   = string.IsNullOrWhiteSpace(txt_password.Text)
                            ? Program.generatePassword(email, id)
                            : txt_password.Text.Trim();
            string status = combo_status.SelectedIndex >= 0
                            ? combo_status.SelectedItem.ToString() : "Active";

            new Customer(id, txt_name.Text.Trim(), txt_phone.Text.Trim(), email,
                         "", dtp_birth.Value.Date, DateTime.Today,
                         txt_emergency.Text.Trim(), DateTime.Today,
                         status, "Pending", pass, true);

            MessageBox.Show($"התלמיד נוסף בהצלחה!\nסיסמה: {pass}", "הצלחה",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadGrid();
            setMode_new();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            hideError();
            if (_selected == null) return;
            if (!validateForm(isNew: false)) return;

            _selected.setFullName(txt_name.Text.Trim());
            _selected.setPhone(txt_phone.Text.Trim());
            _selected.setEmail(txt_email.Text.Trim());
            _selected.setEmergencyContact(txt_emergency.Text.Trim());
            _selected.setBirthDate(dtp_birth.Value.Date);
            if (combo_status.SelectedIndex >= 0)
                _selected.setCustomerStatus(combo_status.SelectedItem.ToString());
            if (!string.IsNullOrWhiteSpace(txt_password.Text))
                _selected.setPassword(txt_password.Text.Trim());
            _selected.updateCustomer();

            MessageBox.Show("פרטי התלמיד עודכנו בהצלחה", "עדכון",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadGrid();
            setMode_new();
        }

        private void btn_archive_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;

            if (isArchived(_selected))
            {
                _selected.setCustomerStatus("Active");
                _selected.updateCustomer();
                MessageBox.Show($"התלמיד {_selected.getFullName()} שוחזר בהצלחה", "שחזור",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult confirm = MessageBox.Show(
                    $"האם לשלוח את {_selected.getFullName()} לארכיון?",
                    "אישור ארכיון", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;

                _selected.setCustomerStatus("Archive");
                _selected.updateCustomer();
                MessageBox.Show($"התלמיד {_selected.getFullName()} נשלח לארכיון", "ארכיון",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            loadGrid();
            setMode_new();
        }

        private void btn_back_Click(object sender, EventArgs e)
            => MainForm.showPanel(new AdminMenuPanel());

        private bool validateForm(bool isNew)
        {
            string id    = txt_id.Text.Trim();
            string name  = txt_name.Text.Trim();
            string phone = txt_phone.Text.Trim();
            string email = txt_email.Text.Trim();

            if (isNew)
            {
                if (string.IsNullOrWhiteSpace(id) || id.Length < 2)
                { highlightField(txt_id); showError("מ.ז. תלמיד חייב להכיל לפחות 2 תווים"); return false; }
                if (Customer.seekCustomer(id) != null)
                { highlightField(txt_id); showError("מ.ז. זה כבר קיים במערכת"); return false; }
            }

            if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
            { highlightField(txt_name); showError("שם מלא חייב להכיל לפחות 2 תווים"); return false; }

            if (!isValidPhone(phone))
            { highlightField(txt_phone); showError("טלפון לא תקין — נדרשות לפחות 9 ספרות"); return false; }

            if (!isValidEmail(email))
            { highlightField(txt_email); showError("כתובת אימייל לא תקינה"); return false; }

            Employee empMatch  = Employee.seekByEmail(email);
            Customer custMatch = Customer.seekByEmail(email);
            bool takenByOther  = empMatch != null
                              || (custMatch != null && custMatch != _selected);
            if (takenByOther)
            { highlightField(txt_email); showError("כתובת אימייל זו כבר רשומה במערכת"); return false; }

            return true;
        }

        private bool isValidPhone(string p)
        {
            if (string.IsNullOrWhiteSpace(p)) return false;
            string d = p.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "");
            return d.Length >= 9 && Regex.IsMatch(d, @"^\d+$");
        }

        private bool isValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            try { var a = new MailAddress(email); return a.Address == email; }
            catch { return false; }
        }

        private void showError(string msg)  { label_error.Text = msg; label_error.Visible = true; }
        private void hideError()            { label_error.Visible = false; }
        private void highlightField(System.Windows.Forms.Control c) => c.BackColor = ERR_BG;
        private void clearField(System.Windows.Forms.Control c)     => c.BackColor = System.Drawing.SystemColors.Window;
        private void clearAllHighlights()
        {
            clearField(txt_id);
            clearField(txt_name);
            clearField(txt_phone);
            clearField(txt_email);
        }
    }
}
