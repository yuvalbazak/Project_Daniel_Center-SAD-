using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class RegisterPanel : UserControl
    {
        public RegisterPanel()
        {
            InitializeComponent();
            dateTimePicker_birth.Value    = DateTime.Today.AddYears(-18);
            dateTimePicker_birth.MaxDate  = DateTime.Today.AddYears(-5);
        }

        // =====================================================================
        // הרשמה
        // =====================================================================
        private void btn_register_Click(object sender, EventArgs e)
        {
            clearAllHighlights();
            label_error.Visible = false;

            string id        = txt_id.Text.Trim();
            string full_name = txt_full_name.Text.Trim();
            string phone     = txt_phone.Text.Trim();
            string email     = txt_email.Text.Trim();
            string address   = txt_address.Text.Trim();
            string emergency = txt_emergency.Text.Trim();
            DateTime birth   = dateTimePicker_birth.Value.Date;

            // ── Required fields ──
            if (string.IsNullOrWhiteSpace(id) || id.Length < 5)
            { highlightField(txt_id); showError("מספר זהות חייב להכיל לפחות 5 ספרות"); return; }

            if (!Regex.IsMatch(id, @"^\d+$"))
            { highlightField(txt_id); showError("מספר זהות חייב להכיל ספרות בלבד"); return; }

            if (string.IsNullOrWhiteSpace(full_name) || full_name.Length < 2)
            { highlightField(txt_full_name); showError("שם מלא חייב להכיל לפחות 2 תווים"); return; }

            if (!isValidPhone(phone))
            { highlightField(txt_phone); showError("מספר טלפון לא תקין — נדרשות לפחות 9 ספרות"); return; }

            if (!isValidEmail(email))
            { highlightField(txt_email); showError("כתובת אימייל לא תקינה"); return; }

            if (string.IsNullOrWhiteSpace(address))
            { highlightField(txt_address); showError("יש להזין כתובת מגורים"); return; }

            if (birth >= DateTime.Today)
            { showError("תאריך לידה חייב להיות בעבר"); return; }

            if (string.IsNullOrWhiteSpace(emergency))
            { highlightField(txt_emergency); showError("יש להזין פרטי איש קשר לחירום"); return; }

            // ── Duplicate checks ──
            if (Customer.seekCustomer(id) != null)
            { highlightField(txt_id); showError("מספר זהות זה כבר רשום במערכת"); return; }

            if (Customer.seekByEmail(email) != null || Employee.seekByEmail(email) != null)
            { highlightField(txt_email); showError("כתובת אימייל זו כבר רשומה במערכת"); return; }

            // ── Create customer ──
            string password = Program.generatePassword(email, id);

            new Customer(
                id, full_name, phone, email, address,
                birth, DateTime.Today, emergency,
                DateTime.Today.AddDays(30),
                "Active", "Unpaid",
                password, true
            );

            MessageBox.Show(
                $"ההרשמה הושלמה בהצלחה!\n\nהסיסמה שלך היא:\n{password}\n\nשמור/י סיסמה זו במקום בטוח.",
                "הרשמה הושלמה",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            MainForm.showPanel(new LoginPanel());
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            MainForm.showPanel(new LoginPanel());
        }

        // =====================================================================
        // Clear highlights when user edits fields
        // =====================================================================
        private void txt_id_TextChanged(object sender, EventArgs e)        { clearField(txt_id); }
        private void txt_full_name_TextChanged(object sender, EventArgs e) { clearField(txt_full_name); }
        private void txt_phone_TextChanged(object sender, EventArgs e)     { clearField(txt_phone); }
        private void txt_email_TextChanged(object sender, EventArgs e)     { clearField(txt_email); }
        private void txt_address_TextChanged(object sender, EventArgs e)   { clearField(txt_address); }
        private void txt_emergency_TextChanged(object sender, EventArgs e) { clearField(txt_emergency); }

        // =====================================================================
        // Helpers
        // =====================================================================
        private void showError(string msg)
        {
            label_error.Text    = msg;
            label_error.Visible = true;
        }

        private void highlightField(System.Windows.Forms.Control ctrl)
        {
            ctrl.BackColor = System.Drawing.Color.FromArgb(255, 220, 220);
        }

        private void clearField(System.Windows.Forms.Control ctrl)
        {
            ctrl.BackColor = System.Drawing.SystemColors.Window;
            label_error.Visible = false;
        }

        private void clearAllHighlights()
        {
            clearField(txt_id);
            clearField(txt_full_name);
            clearField(txt_phone);
            clearField(txt_email);
            clearField(txt_address);
            clearField(txt_emergency);
        }

        private bool isValidEmail(string email)
        {
            try { var a = new MailAddress(email); return a.Address == email; }
            catch { return false; }
        }

        private bool isValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            string digits = phone.Replace("-", "").Replace(" ", "");
            return digits.Length >= 9 && Regex.IsMatch(digits, @"^\d+$");
        }
    }
}
