using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class CustomerProfilePanel : UserControl
    {
        private static readonly System.Drawing.Color ERR_BG =
            System.Drawing.Color.FromArgb(255, 220, 220);

        private Customer _self;

        public CustomerProfilePanel()
        {
            InitializeComponent();

            _self = Customer.seekByEmail(Program.currentUserEmail);
            if (_self == null)
            {
                this.Load += (s, e) => MainForm.showPanel(new LoginPanel());
                return;
            }

            txt_full_name.TextChanged += (s, e) => { clearField(txt_full_name); hideError(); };
            txt_phone.TextChanged     += (s, e) => { clearField(txt_phone);     hideError(); };
            txt_email.TextChanged     += (s, e) => { clearField(txt_email);     hideError(); };
            txt_address.TextChanged   += (s, e) => { clearField(txt_address);   hideError(); };
            txt_emergency.TextChanged += (s, e) => { clearField(txt_emergency); hideError(); };

            populateForm();
        }

        // =====================================================================
        // Populate
        // =====================================================================
        private void populateForm()
        {
            lbl_id_value.Text      = _self.getCustomerId();
            lbl_birth_value.Text   = _self.getBirthDate().ToShortDateString();
            lbl_start_value.Text   = _self.getStartDate().ToShortDateString();
            lbl_status_value.Text  = _self.getCustomerStatus();
            lbl_payment_value.Text = _self.getPaymentStatus();

            txt_full_name.Text = _self.getFullName();
            txt_phone.Text     = _self.getPhone();
            txt_email.Text     = _self.getEmail();
            txt_address.Text   = _self.getAddress();
            txt_emergency.Text = _self.getEmergencyContact();
        }

        // =====================================================================
        // Save
        // =====================================================================
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!validateForm()) return;

            string newEmail = txt_email.Text.Trim();

            _self.setFullName(txt_full_name.Text.Trim());
            _self.setPhone(txt_phone.Text.Trim());
            _self.setEmail(newEmail);
            _self.setAddress(txt_address.Text.Trim());
            _self.setEmergencyContact(txt_emergency.Text.Trim());
            _self.updateCustomer();

            Program.currentUserEmail = newEmail;

            MessageBox.Show("הפרופיל עודכן בהצלחה", "הצלחה",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            clearAllHighlights();
            hideError();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            MainForm.showPanel(new HomePanel());
        }

        // =====================================================================
        // Validation
        // =====================================================================
        private bool validateForm()
        {
            string full_name = txt_full_name.Text.Trim();
            string phone     = txt_phone.Text.Trim();
            string email     = txt_email.Text.Trim();
            string address   = txt_address.Text.Trim();
            string emergency = txt_emergency.Text.Trim();

            if (string.IsNullOrWhiteSpace(full_name) || full_name.Length < 2)
            { highlightField(txt_full_name); showError("שם מלא חייב להכיל לפחות 2 תווים"); return false; }

            if (!isValidPhone(phone))
            { highlightField(txt_phone); showError("טלפון לא תקין — נדרשות לפחות 9 ספרות"); return false; }

            if (!isValidEmail(email))
            { highlightField(txt_email); showError("כתובת אימייל לא תקינה"); return false; }

            Employee empMatch  = Employee.seekByEmail(email);
            Customer custMatch = Customer.seekByEmail(email);
            if (empMatch != null || (custMatch != null && custMatch != _self))
            { highlightField(txt_email); showError("כתובת אימייל זו כבר רשומה במערכת"); return false; }

            if (string.IsNullOrWhiteSpace(address) || address.Length < 2)
            { highlightField(txt_address); showError("יש להזין כתובת מגורים"); return false; }

            if (!isValidPhone(emergency))
            { highlightField(txt_emergency); showError("איש קשר לחירום — יש להזין מספר טלפון תקין"); return false; }

            return true;
        }

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
        private void showError(string msg)  { label_error.Text = msg; label_error.Visible = true; }
        private void hideError()            { label_error.Visible = false; }

        private void highlightField(System.Windows.Forms.Control ctrl)
            => ctrl.BackColor = ERR_BG;

        private void clearField(System.Windows.Forms.Control ctrl)
            => ctrl.BackColor = System.Drawing.SystemColors.Window;

        private void clearAllHighlights()
        {
            clearField(txt_full_name);
            clearField(txt_phone);
            clearField(txt_email);
            clearField(txt_address);
            clearField(txt_emergency);
        }
    }
}
