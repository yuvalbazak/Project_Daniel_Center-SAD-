using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class ForgotPasswordPanel : UserControl
    {
        private Employee found_employee;
        private Customer found_customer;

        public ForgotPasswordPanel()
        {
            InitializeComponent();
            showPhase1();
        }

        // =====================================================================
        // שלב 1: אימות זהות
        // =====================================================================
        private void btn_verify_Click(object sender, EventArgs e)
        {
            clearMessage();
            string email = txt_email.Text.Trim();
            string id    = txt_id.Text.Trim();

            // Validation
            if (string.IsNullOrWhiteSpace(email))
            { showError("יש להזין כתובת אימייל"); highlightField(txt_email); return; }

            if (!isValidEmail(email))
            { showError("כתובת האימייל אינה תקינה"); highlightField(txt_email); return; }

            if (string.IsNullOrWhiteSpace(id))
            { showError("יש להזין מספר זהות / מספר עובד"); highlightField(txt_id); return; }

            // Search employee: both email AND id must match
            Employee emp = Employee.seekEmployee(id);
            if (emp != null && emp.getEmail().Equals(email, StringComparison.OrdinalIgnoreCase))
            {
                found_employee = emp;
                found_customer = null;
                showPhase2();
                return;
            }

            // Search customer
            Customer cust = Customer.seekCustomer(id);
            if (cust != null && cust.getEmail().Equals(email, StringComparison.OrdinalIgnoreCase))
            {
                found_customer = cust;
                found_employee = null;
                showPhase2();
                return;
            }

            showError("לא נמצא משתמש עם פרטים אלה. ודאו שהאימייל ומספר הזהות/עובד תואמים.");
        }

        // =====================================================================
        // שלב 2: הגדרת סיסמה חדשה
        // =====================================================================
        private void btn_reset_Click(object sender, EventArgs e)
        {
            clearMessage();
            string newPass     = txt_new_pass.Text;
            string confirmPass = txt_confirm.Text;

            if (string.IsNullOrWhiteSpace(newPass))
            { showError("יש להזין סיסמה חדשה"); highlightField(txt_new_pass); return; }

            if (newPass.Length < 6)
            { showError("הסיסמה חייבת להכיל לפחות 6 תווים"); highlightField(txt_new_pass); return; }

            if (newPass != confirmPass)
            { showError("הסיסמאות אינן תואמות"); highlightField(txt_confirm); return; }

            // Update password
            if (found_employee != null)
            {
                found_employee.setPassword(newPass);
                found_employee.updateEmployee();
            }
            else if (found_customer != null)
            {
                found_customer.setPassword(newPass);
                found_customer.updateCustomer();
            }

            MessageBox.Show("הסיסמה אופסה בהצלחה!\n\nתוכלו כעת להתחבר עם הסיסמה החדשה.",
                            "איפוס סיסמה הושלם", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MainForm.showPanel(new LoginPanel());
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            MainForm.showPanel(new LoginPanel());
        }

        // =====================================================================
        // Clear highlights when user types
        // =====================================================================
        private void txt_email_TextChanged(object sender, EventArgs e)    { clearField(txt_email); }
        private void txt_id_TextChanged(object sender, EventArgs e)       { clearField(txt_id); }
        private void txt_new_pass_TextChanged(object sender, EventArgs e) { clearField(txt_new_pass); }
        private void txt_confirm_TextChanged(object sender, EventArgs e)  { clearField(txt_confirm); }

        // =====================================================================
        // UI state helpers
        // =====================================================================
        private void showPhase1()
        {
            label_phase2.Visible   = false;
            txt_new_pass.Visible   = false;
            label_confirm.Visible  = false;
            txt_confirm.Visible    = false;
            btn_reset.Visible      = false;
            label_new_pass.Visible = false;
        }

        private void showPhase2()
        {
            // Pre-fill with generated password as a suggestion
            string suggested = Program.generatePassword(txt_email.Text.Trim(), txt_id.Text.Trim());
            txt_new_pass.Text = suggested;
            txt_confirm.Text  = suggested;

            txt_email.Enabled  = false;
            txt_id.Enabled     = false;
            btn_verify.Enabled = false;

            label_phase2.Visible   = true;
            label_new_pass.Visible = true;
            txt_new_pass.Visible   = true;
            label_confirm.Visible  = true;
            txt_confirm.Visible    = true;
            btn_reset.Visible      = true;

            showSuccess("זהות אומתה בהצלחה. הזינו סיסמה חדשה.");
        }

        private void showError(string msg)
        {
            label_message.ForeColor = System.Drawing.Color.Crimson;
            label_message.Text      = msg;
            label_message.Visible   = true;
        }

        private void showSuccess(string msg)
        {
            label_message.ForeColor = System.Drawing.Color.DarkGreen;
            label_message.Text      = msg;
            label_message.Visible   = true;
        }

        private void clearMessage()
        {
            label_message.Visible = false;
        }

        private void highlightField(System.Windows.Forms.Control ctrl)
        {
            ctrl.BackColor = System.Drawing.Color.FromArgb(255, 220, 220);
        }

        private void clearField(System.Windows.Forms.Control ctrl)
        {
            ctrl.BackColor = System.Drawing.SystemColors.Window;
        }

        private bool isValidEmail(string email)
        {
            try { var a = new MailAddress(email); return a.Address == email; }
            catch { return false; }
        }
    }
}
