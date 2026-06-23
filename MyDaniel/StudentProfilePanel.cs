using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class StudentProfilePanel : UserControl
    {
        private static readonly System.Drawing.Color ERR_BG =
            System.Drawing.Color.FromArgb(255, 220, 220);

        private Customer _self;

        public StudentProfilePanel()
        {
            InitializeComponent();

            _self = Customer.seekByEmail(Program.currentUserEmail);
            if (_self == null)
            { this.Load += (s, e) => MainForm.showPanel(new LoginPanel()); return; }

            if (!AuthService.IsCustomer())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            txt_email.TextChanged     += (s, e) => { clearField(txt_email);     hideError(); };
            txt_phone.TextChanged     += (s, e) => { clearField(txt_phone);     hideError(); };
            txt_emergency.TextChanged += (s, e) => { clearField(txt_emergency); hideError(); };

            populateForm();
        }

        // =====================================================================
        // Populate
        // =====================================================================
        private void populateForm()
        {
            // Read-only display
            lbl_id_val.Text      = _self.getCustomerId();
            lbl_name_val.Text    = _self.getFullName();
            lbl_address_val.Text = _self.getAddress();
            lbl_birth_val.Text   = _self.getBirthDate().ToString("dd/MM/yyyy");
            lbl_start_val.Text   = _self.getStartDate().ToString("dd/MM/yyyy");
            lbl_status_val.Text  = _self.getCustomerStatus();
            lbl_payment_val.Text = $"{_self.getPaymentStatus()} ({_self.getPaymentDate():dd/MM/yyyy})";

            // Editable fields
            txt_email.Text     = _self.getEmail();
            txt_phone.Text     = _self.getPhone();
            txt_emergency.Text = _self.getEmergencyContact();
        }

        // =====================================================================
        // Save
        // =====================================================================
        private void btn_save_Click(object sender, EventArgs e)
        {
            hideError();
            if (!validateForm()) return;

            string newEmail     = txt_email.Text.Trim();
            string newPhone     = txt_phone.Text.Trim();
            string newEmergency = txt_emergency.Text.Trim();

            _self.setEmail(newEmail);
            _self.setPhone(newPhone);
            _self.setEmergencyContact(newEmergency);
            _self.updateCustomer();

            Program.currentUserEmail = newEmail;

            MessageBox.Show("הפרטים עודכנו בהצלחה", "הצלחה",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            clearAllHighlights();
            hideError();
        }

        // =====================================================================
        // Cancel — revert editable fields to last saved values
        // =====================================================================
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            txt_email.Text     = _self.getEmail();
            txt_phone.Text     = _self.getPhone();
            txt_emergency.Text = _self.getEmergencyContact();
            clearAllHighlights();
            hideError();
        }

        private void btn_back_Click(object sender, EventArgs e)
            => MainForm.showPanel(new StudentMenuPanel());

        // =====================================================================
        // Validation
        // =====================================================================
        private bool validateForm()
        {
            string email     = txt_email.Text.Trim();
            string phone     = txt_phone.Text.Trim();
            string emergency = txt_emergency.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            { highlightField(txt_email); showError("שדה אימייל לא יכול להיות ריק"); return false; }

            if (!isValidEmail(email))
            { highlightField(txt_email); showError("כתובת אימייל לא תקינה"); return false; }

            Employee empMatch  = Employee.seekByEmail(email);
            Customer custMatch = Customer.seekByEmail(email);
            if (empMatch != null || (custMatch != null && custMatch != _self))
            { highlightField(txt_email); showError("כתובת אימייל זו כבר רשומה במערכת"); return false; }

            if (string.IsNullOrWhiteSpace(phone))
            { highlightField(txt_phone); showError("שדה טלפון לא יכול להיות ריק"); return false; }

            if (!isValidPhone(phone))
            { highlightField(txt_phone); showError("טלפון לא תקין — נדרשות לפחות 9 ספרות"); return false; }

            if (string.IsNullOrWhiteSpace(emergency))
            { highlightField(txt_emergency); showError("שדה איש קשר לחירום לא יכול להיות ריק"); return false; }

            if (!isValidPhone(emergency))
            { highlightField(txt_emergency); showError("מספר איש קשר לחירום לא תקין — נדרשות לפחות 9 ספרות"); return false; }

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
            clearField(txt_email);
            clearField(txt_phone);
            clearField(txt_emergency);
        }
    }
}
