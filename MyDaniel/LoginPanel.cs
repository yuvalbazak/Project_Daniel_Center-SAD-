using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class LoginPanel : UserControl
    {
        public LoginPanel()
        {
            InitializeComponent();
            this.ActiveControl = txt_email;
        }

        // =====================================================================
        // Login
        // =====================================================================
        private void btn_login_Click(object sender, EventArgs e)
        {
            clearError();

            string email    = txt_email.Text.Trim();
            string password = txt_password.Text;

            if (string.IsNullOrWhiteSpace(email))
            { showError("יש להזין אימייל או שם משתמש"); highlightField(txt_email); return; }

            if (string.IsNullOrWhiteSpace(password))
            { showError("יש להזין סיסמה"); highlightField(txt_password); return; }

            // ── Administrator hard-coded account ──────────────────────────────
            if (email.Equals("admin", StringComparison.OrdinalIgnoreCase) && password == "admin123")
            {
                Program.currentUserEmail = "admin";
                Program.currentUserType  = "Employee";
                Program.currentUserRole  = AuthService.ROLE_ADMIN;
                MessageBox.Show("ברוך הבא, מנהל מערכת!", "כניסה בוצעה בהצלחה",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm.showPanel(new HomePanel());
                return;
            }

            if (!isValidEmail(email))
            { showError("כתובת האימייל אינה תקינה"); highlightField(txt_email); return; }

            // Search employee first
            Employee emp = Employee.seekByEmail(email);
            if (emp != null)
            {
                if (emp.getPassword() != password)
                { showError("סיסמה שגויה"); highlightField(txt_password); return; }

                Program.currentUserEmail = email;
                Program.currentUserType  = "Employee";
                Program.currentUserRole  = emp.getRole();
                MessageBox.Show($"ברוך הבא, {emp.getFullName()}!", "כניסה בוצעה בהצלחה",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (AuthService.IsInstructor())
                    MainForm.showPanel(new InstructorMenuPanel());
                else if (AuthService.IsAdminStaff())
                    MainForm.showPanel(new AdminMenuPanel());
                else
                    MainForm.showPanel(new HomePanel());
                return;
            }

            // Search customer
            Customer cust = Customer.seekByEmail(email);
            if (cust != null)
            {
                if (cust.getPassword() != password)
                { showError("סיסמה שגויה"); highlightField(txt_password); return; }

                Program.currentUserEmail = email;
                Program.currentUserType  = "Customer";
                Program.currentUserRole  = AuthService.ROLE_CUSTOMER;
                MessageBox.Show($"ברוך הבא/י, {cust.getFullName()}!", "כניסה בוצעה בהצלחה",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm.showPanel(new StudentMenuPanel());
                return;
            }

            showError("לא נמצא משתמש עם כתובת אימייל זו");
            highlightField(txt_email);
        }

        // =====================================================================
        // ניווט
        // =====================================================================
        private void btn_forgot_Click(object sender, EventArgs e)
        {
            MainForm.showPanel(new ForgotPasswordPanel());
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            MainForm.showPanel(new RegisterPanel());
        }

        // =====================================================================
        // Enter key on password field submits login
        // =====================================================================
        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btn_login_Click(sender, e);
        }

        private void txt_email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txt_password.Focus();
        }

        // =====================================================================
        // Clear highlight when user starts typing
        // =====================================================================
        private void txt_email_TextChanged(object sender, EventArgs e)    { clearField(txt_email); }
        private void txt_password_TextChanged(object sender, EventArgs e) { clearField(txt_password); }

        // =====================================================================
        // Helpers
        // =====================================================================
        private void showError(string msg)
        {
            label_error.Text    = msg;
            label_error.Visible = true;
        }

        private void clearError()
        {
            label_error.Visible = false;
            clearField(txt_email);
            clearField(txt_password);
        }

        private void highlightField(System.Windows.Forms.Control ctrl)
        {
            ctrl.BackColor = System.Drawing.Color.FromArgb(254, 226, 226); // light red on white input
        }

        private void clearField(System.Windows.Forms.Control ctrl)
        {
            ctrl.BackColor = ThemeHelper.BG_INPUT;
        }

        private bool isValidEmail(string email)
        {
            try { var a = new MailAddress(email); return a.Address == email; }
            catch { return false; }
        }
    }
}
