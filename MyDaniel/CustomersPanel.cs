using System;
using System.Data;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class CustomersPanel : UserControl
    {
        private static readonly string[] CUSTOMER_STATUSES = { "Active", "Unpaid", "Archive" };
        private static readonly string[] PAYMENT_STATUSES  = { "Paid", "Payment In Process", "Unpaid" };

        private static readonly System.Drawing.Color ERR_BG =
            System.Drawing.Color.FromArgb(255, 220, 220);

        private Customer _selected = null;

        public CustomersPanel()
        {
            InitializeComponent();

            // Customers must only see their own profile — redirect before any data loads
            if (AuthService.IsCustomer())
            { this.Load += (s, e) => MainForm.showPanel(new CustomerProfilePanel()); return; }

            // Defense-in-depth: block any role with no customer-view access
            if (!AuthService.CanViewAllCustomers())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            combo_customer_status.Items.AddRange(CUSTOMER_STATUSES);
            combo_payment_status.Items.AddRange(PAYMENT_STATUSES);
            combo_customer_status.SelectedIndex = 0;
            combo_payment_status.SelectedIndex  = 0;

            // Clear field highlight as soon as the user starts typing
            txt_id.TextChanged        += (s, e) => { clearField(txt_id);        hideError(); };
            txt_full_name.TextChanged  += (s, e) => { clearField(txt_full_name); hideError(); };
            txt_phone.TextChanged      += (s, e) => { clearField(txt_phone);     hideError(); };
            txt_email.TextChanged      += (s, e) => { clearField(txt_email);     hideError(); };
            txt_address.TextChanged    += (s, e) => { clearField(txt_address);   hideError(); };
            txt_emergency.TextChanged  += (s, e) => { clearField(txt_emergency); hideError(); };

            loadGrid();
            setMode_new();

            // Read-only mode for Coordinator / Instructor
            if (!AuthService.CanWriteCustomers())
            {
                label_form_title.Text           = "פרטי לקוח — צפייה בלבד";
                txt_full_name.ReadOnly          = true;
                txt_phone.ReadOnly              = true;
                txt_email.ReadOnly              = true;
                txt_address.ReadOnly            = true;
                txt_emergency.ReadOnly          = true;
                dtp_birth.Enabled               = false;
                dtp_start.Enabled               = false;
                dtp_payment.Enabled             = false;
                combo_customer_status.Enabled   = false;
                combo_payment_status.Enabled    = false;
            }
        }

        // =====================================================================
        // Grid
        // =====================================================================
        private void loadGrid()
        {
            dataGridView_customers.SelectionChanged -= dataGridView_customers_SelectionChanged;

            DataTable dt = new DataTable();
            dt.Columns.Add("מספר לקוח",      typeof(string));
            dt.Columns.Add("שם מלא",          typeof(string));
            dt.Columns.Add("טלפון",           typeof(string));
            dt.Columns.Add("אימייל",          typeof(string));
            dt.Columns.Add("כתובת",           typeof(string));
            dt.Columns.Add("תאריך לידה",      typeof(string));
            dt.Columns.Add("תאריך הצטרפות",  typeof(string));
            dt.Columns.Add("איש קשר לחירום", typeof(string));
            dt.Columns.Add("תאריך תשלום",     typeof(string));
            dt.Columns.Add("סטטוס לקוח",     typeof(string));
            dt.Columns.Add("סטטוס תשלום",    typeof(string));

            foreach (Customer c in Program.Customers)
            {
                dt.Rows.Add(
                    c.getCustomerId(),
                    c.getFullName(),
                    c.getPhone(),
                    c.getEmail(),
                    c.getAddress(),
                    c.getBirthDate().ToShortDateString(),
                    c.getStartDate().ToShortDateString(),
                    c.getEmergencyContact(),
                    c.getPaymentDate().ToShortDateString(),
                    c.getCustomerStatus(),
                    c.getPaymentStatus()
                );
            }

            dataGridView_customers.DataSource = dt;
            dataGridView_customers.SelectionChanged += dataGridView_customers_SelectionChanged;
        }

        private void dataGridView_customers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_customers.SelectedRows.Count == 0) return;

            string id = dataGridView_customers.SelectedRows[0].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(id)) return;

            Customer c = Customer.seekCustomer(id);
            if (c == null) return;

            _selected = c;
            populateForm(c);
            setMode_edit();
        }

        // =====================================================================
        // Form helpers
        // =====================================================================
        private void populateForm(Customer c)
        {
            txt_id.Text                    = c.getCustomerId();
            txt_full_name.Text             = c.getFullName();
            txt_phone.Text                 = c.getPhone();
            txt_email.Text                 = c.getEmail();
            txt_address.Text               = c.getAddress();
            txt_emergency.Text             = c.getEmergencyContact();
            dtp_birth.Value                = c.getBirthDate();
            dtp_start.Value                = c.getStartDate();
            dtp_payment.Value              = c.getPaymentDate();
            combo_customer_status.Text     = c.getCustomerStatus();
            combo_payment_status.Text      = c.getPaymentStatus();
        }

        private void clearForm()
        {
            txt_id.Text                         = "";
            txt_full_name.Text                  = "";
            txt_phone.Text                      = "";
            txt_email.Text                      = "";
            txt_address.Text                    = "";
            txt_emergency.Text                  = "";
            dtp_birth.Value                     = DateTime.Today.AddYears(-10);
            dtp_start.Value                     = DateTime.Today;
            dtp_payment.Value                   = DateTime.Today.AddDays(30);
            combo_customer_status.SelectedIndex = 0;
            combo_payment_status.SelectedIndex  = 0;
        }

        // =====================================================================
        // Mode switching
        // =====================================================================
        private void setMode_new()
        {
            _selected        = null;
            txt_id.Enabled   = true;
            txt_id.BackColor = System.Drawing.SystemColors.Window;

            bool canWrite = AuthService.CanWriteCustomers();
            btn_new.Visible    = canWrite;
            btn_save.Visible   = canWrite;
            btn_update.Visible = false;
            btn_delete.Visible = false;

            clearForm();
            clearAllHighlights();
            hideError();
            dataGridView_customers.ClearSelection();
        }

        private void setMode_edit()
        {
            txt_id.Enabled   = false;
            txt_id.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);

            bool canWrite = AuthService.CanWriteCustomers();
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

            string id       = txt_id.Text.Trim();
            string email    = txt_email.Text.Trim();
            string password = Program.generatePassword(email, id);

            new Customer(
                id,
                txt_full_name.Text.Trim(),
                txt_phone.Text.Trim(),
                email,
                txt_address.Text.Trim(),
                dtp_birth.Value.Date,
                dtp_start.Value.Date,
                txt_emergency.Text.Trim(),
                dtp_payment.Value.Date,
                combo_customer_status.Text,
                combo_payment_status.Text,
                password,
                true
            );

            MessageBox.Show("הלקוח נוסף בהצלחה!\nסיסמה שנוצרה: " + password,
                            "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadGrid();
            setMode_new();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;
            if (!validateForm(isNew: false)) return;

            _selected.setFullName(txt_full_name.Text.Trim());
            _selected.setPhone(txt_phone.Text.Trim());
            _selected.setEmail(txt_email.Text.Trim());
            _selected.setAddress(txt_address.Text.Trim());
            _selected.setEmergencyContact(txt_emergency.Text.Trim());
            _selected.setBirthDate(dtp_birth.Value.Date);
            _selected.setStartDate(dtp_start.Value.Date);
            _selected.setPaymentDate(dtp_payment.Value.Date);
            _selected.setCustomerStatus(combo_customer_status.Text);
            _selected.setPaymentStatus(combo_payment_status.Text);
            _selected.updateCustomer();

            MessageBox.Show("פרטי הלקוח עודכנו בהצלחה", "הצלחה",
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
                _selected.setCustomerStatus("Archive");
                _selected.updateCustomer();
                MessageBox.Show("הרשומה הועברה לארכיון בהצלחה", "ארכיון",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadGrid();
                setMode_new();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            MainForm.showPanel(new HomePanel());
        }

        // =====================================================================
        // Validation
        // isNew = true  → ID required + duplicate-ID check + strict email duplicate
        // isNew = false → skip ID (read-only), allow same email as current record
        // =====================================================================
        private bool validateForm(bool isNew)
        {
            string id        = txt_id.Text.Trim();
            string full_name = txt_full_name.Text.Trim();
            string phone     = txt_phone.Text.Trim();
            string email     = txt_email.Text.Trim();
            string address   = txt_address.Text.Trim();
            string emergency = txt_emergency.Text.Trim();

            // ── ID (new records only) ─────────────────────────────────────────
            if (isNew)
            {
                if (string.IsNullOrWhiteSpace(id) || id.Length < 2)
                { highlightField(txt_id); showError("מספר לקוח חייב להכיל לפחות 2 תווים"); return false; }

                if (Customer.seekCustomer(id) != null)
                { highlightField(txt_id); showError("מספר לקוח זה כבר קיים במערכת"); return false; }
            }

            // ── Full name ─────────────────────────────────────────────────────
            if (string.IsNullOrWhiteSpace(full_name) || full_name.Length < 2)
            { highlightField(txt_full_name); showError("שם מלא חייב להכיל לפחות 2 תווים"); return false; }

            // ── Phone ─────────────────────────────────────────────────────────
            if (!isValidPhone(phone))
            { highlightField(txt_phone); showError("טלפון לא תקין — נדרשות לפחות 9 ספרות"); return false; }

            // ── Email ─────────────────────────────────────────────────────────
            if (!isValidEmail(email))
            { highlightField(txt_email); showError("כתובת אימייל לא תקינה"); return false; }

            // Duplicate email: in new mode check all records; in edit mode allow same email
            Employee empMatch  = Employee.seekByEmail(email);
            Customer custMatch = Customer.seekByEmail(email);
            bool emailTakenByOther = empMatch != null
                                  || (custMatch != null && custMatch != _selected);
            if (emailTakenByOther)
            { highlightField(txt_email); showError("כתובת אימייל זו כבר רשומה במערכת"); return false; }

            // ── Address ───────────────────────────────────────────────────────
            if (string.IsNullOrWhiteSpace(address) || address.Length < 2)
            { highlightField(txt_address); showError("יש להזין כתובת מגורים"); return false; }

            // ── Emergency contact — must be a valid phone number ──────────────
            if (!isValidPhone(emergency))
            { highlightField(txt_emergency); showError("איש קשר לחירום — יש להזין מספר טלפון תקין (לפחות 9 ספרות)"); return false; }

            // ── Birth date must be in the past ────────────────────────────────
            if (dtp_birth.Value.Date >= DateTime.Today)
            { showError("תאריך לידה חייב להיות בעבר"); return false; }

            return true;
        }

        // =====================================================================
        // Validation helpers
        // =====================================================================
        private bool isValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            string digits = phone.Replace("-", "").Replace(" ", "")
                                 .Replace("(", "").Replace(")", "");
            return digits.Length >= 9 && Regex.IsMatch(digits, @"^\d+$");
        }

        private bool isValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            try { var a = new MailAddress(email); return a.Address == email; }
            catch { return false; }
        }

        // =====================================================================
        // UI helpers
        // =====================================================================
        private void showError(string msg)
        {
            label_error.Text    = msg;
            label_error.Visible = true;
        }

        private void hideError() => label_error.Visible = false;

        private void highlightField(System.Windows.Forms.Control ctrl)
            => ctrl.BackColor = ERR_BG;

        private void clearField(System.Windows.Forms.Control ctrl)
            => ctrl.BackColor = System.Drawing.SystemColors.Window;

        private void clearAllHighlights()
        {
            clearField(txt_id);
            clearField(txt_full_name);
            clearField(txt_phone);
            clearField(txt_email);
            clearField(txt_address);
            clearField(txt_emergency);
        }
    }
}
