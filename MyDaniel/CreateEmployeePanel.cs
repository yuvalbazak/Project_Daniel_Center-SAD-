using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class CreateEmployeePanel : UserControl
    {
        private static readonly string[] ROLES = {
            "Center Manager", "Administration Staff", "Accounting Manager",
            "Coordinator", "Instructor"
        };

        private static readonly System.Drawing.Color ERR_BG =
            System.Drawing.Color.FromArgb(255, 220, 220);

        public CreateEmployeePanel()
        {
            InitializeComponent();

            if (!AuthService.CanWriteEmployees())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            comboBox_role.Items.AddRange(ROLES);
            comboBox_role.SelectedIndex = 0;

            // Clear field highlight as soon as the user starts typing
            txt_id.TextChanged        += (s, e) => { clearField(txt_id);        hideError(); };
            txt_full_name.TextChanged  += (s, e) => { clearField(txt_full_name); hideError(); };
            txt_phone.TextChanged      += (s, e) => { clearField(txt_phone);     hideError(); };
            txt_email.TextChanged      += (s, e) => { clearField(txt_email);     hideError(); };
        }

        // =====================================================================
        // Create
        // =====================================================================
        private void btn_create_Click(object sender, EventArgs e)
        {
            clearAllHighlights();
            hideError();

            string id        = txt_id.Text.Trim();
            string full_name = txt_full_name.Text.Trim();
            string phone     = txt_phone.Text.Trim();
            string email     = txt_email.Text.Trim();

            // ── ID ────────────────────────────────────────────────────────────
            if (string.IsNullOrWhiteSpace(id) || id.Length < 2)
            { highlightField(txt_id); showError("מספר עובד חייב להכיל לפחות 2 תווים"); return; }

            if (Employee.seekEmployee(id) != null)
            { highlightField(txt_id); showError("מספר עובד זה כבר קיים במערכת"); return; }

            // ── Full name ─────────────────────────────────────────────────────
            if (string.IsNullOrWhiteSpace(full_name) || full_name.Length < 2)
            { highlightField(txt_full_name); showError("שם מלא חייב להכיל לפחות 2 תווים"); return; }

            // ── Role ──────────────────────────────────────────────────────────
            if (comboBox_role.SelectedIndex < 0)
            { showError("יש לבחור תפקיד"); return; }

            // ── Phone ─────────────────────────────────────────────────────────
            if (!isValidPhone(phone))
            { highlightField(txt_phone); showError("טלפון לא תקין — נדרשות לפחות 9 ספרות"); return; }

            // ── Email ─────────────────────────────────────────────────────────
            if (!isValidEmail(email))
            { highlightField(txt_email); showError("כתובת אימייל לא תקינה"); return; }

            if (Employee.seekByEmail(email) != null || Customer.seekByEmail(email) != null)
            { highlightField(txt_email); showError("כתובת אימייל זו כבר רשומה במערכת"); return; }

            // ── Save ──────────────────────────────────────────────────────────
            string password = Program.generatePassword(email, id);
            new Employee(id, full_name, comboBox_role.Text,
                         dateTimePicker_start.Value.Date, phone, email, password, true);

            MessageBox.Show("העובד נוסף בהצלחה!\nסיסמה שנוצרה: " + password,
                            "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MainForm.showPanel(new EmployeesMenuPanel());
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            MainForm.showPanel(new EmployeesMenuPanel());
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
        }
    }
}
