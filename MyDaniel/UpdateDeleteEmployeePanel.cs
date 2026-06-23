using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class UpdateDeleteEmployeePanel : UserControl
    {
        private static readonly string[] ROLES = {
            "Center Manager", "Administration Staff", "Accounting Manager",
            "Coordinator", "Instructor"
        };

        private static readonly System.Drawing.Color ERR_BG =
            System.Drawing.Color.FromArgb(255, 220, 220);

        private Employee found_employee;

        public UpdateDeleteEmployeePanel()
        {
            InitializeComponent();

            if (!AuthService.CanWriteEmployees())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            setFieldsEnabled(false);
            btn_update.Hide();
            btn_delete.Hide();

            txt_full_name.TextChanged += (s, e) => { clearField(txt_full_name); hideError(); };
            txt_phone.TextChanged     += (s, e) => { clearField(txt_phone);     hideError(); };
            txt_email.TextChanged     += (s, e) => { clearField(txt_email);     hideError(); };
        }

        private void setFieldsEnabled(bool enabled)
        {
            txt_full_name.Enabled        = enabled;
            comboBox_role.Enabled        = enabled;
            dateTimePicker_start.Enabled = enabled;
            txt_phone.Enabled            = enabled;
            txt_email.Enabled            = enabled;
        }

        // =====================================================================
        // Search
        // =====================================================================
        private void btn_search_Click(object sender, EventArgs e)
        {
            hideError();
            string searchId = txt_id.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchId))
            { showError("יש להזין מספר עובד לחיפוש"); return; }

            found_employee = Employee.seekEmployee(searchId);
            if (found_employee == null)
            {
                showError("עובד עם מספר '" + searchId + "' לא נמצא במערכת");
                return;
            }

            txt_full_name.Text         = found_employee.getFullName();
            txt_phone.Text             = found_employee.getPhone();
            txt_email.Text             = found_employee.getEmail();
            dateTimePicker_start.Value  = found_employee.getStartDate();

            comboBox_role.Items.Clear();
            comboBox_role.Items.AddRange(ROLES);
            comboBox_role.Text = found_employee.getRole();

            clearAllHighlights();
            hideError();
            setFieldsEnabled(true);
            btn_update.Show();
            btn_delete.Show();
        }

        // =====================================================================
        // Update — full validation before save
        // =====================================================================
        private void btn_update_Click(object sender, EventArgs e)
        {
            clearAllHighlights();
            hideError();

            string full_name = txt_full_name.Text.Trim();
            string phone     = txt_phone.Text.Trim();
            string email     = txt_email.Text.Trim();

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

            // Allow keeping the same email; block only if another record owns it
            Employee otherEmp  = Employee.seekByEmail(email);
            Customer otherCust = Customer.seekByEmail(email);
            bool emailTakenByOther = (otherEmp  != null && otherEmp  != found_employee)
                                  || (otherCust != null);
            if (emailTakenByOther)
            { highlightField(txt_email); showError("כתובת אימייל זו כבר רשומה במערכת"); return; }

            // ── Save ──────────────────────────────────────────────────────────
            found_employee.setFullName(full_name);
            found_employee.setRole(comboBox_role.Text);
            found_employee.setStartDate(dateTimePicker_start.Value.Date);
            found_employee.setPhone(phone);
            found_employee.setEmail(email);
            found_employee.updateEmployee();

            MessageBox.Show("פרטי העובד עודכנו בהצלחה", "הצלחה",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            MainForm.showPanel(new EmployeesMenuPanel());
        }

        // =====================================================================
        // Delete — confirmation required
        // =====================================================================
        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show(
                "האם אתה בטוח שברצונך להעביר רשומה זו לארכיון?",
                "אישור העברה לארכיון",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (answer == DialogResult.Yes)
            {
                found_employee.deleteEmployee();
                MessageBox.Show("הרשומה הועברה לארכיון בהצלחה", "ארכיון",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm.showPanel(new EmployeesMenuPanel());
            }
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
            clearField(txt_full_name);
            clearField(txt_phone);
            clearField(txt_email);
        }
    }
}
