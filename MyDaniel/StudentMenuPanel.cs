using System;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class StudentMenuPanel : UserControl
    {
        public StudentMenuPanel()
        {
            InitializeComponent();

            if (!AuthService.IsCustomer())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            Customer self = Customer.seekByEmail(Program.currentUserEmail);
            string name = self?.getFullName() ?? Program.currentUserEmail;
            label_welcome.Text = $"שלום, {name}  |  תלמיד/ה";
        }

        private void btn_schedule_Click(object sender, EventArgs e)
            => MainForm.showPanel(new StudentSchedulePanel());

        private void btn_profile_Click(object sender, EventArgs e)
            => MainForm.showPanel(new StudentProfilePanel());

        private void btn_discount_Click(object sender, EventArgs e)
            => MainForm.showPanel(new CustomerDiscountPanel());

        private void btn_register_Click(object sender, EventArgs e)
            => MessageBox.Show("פיצ'ר זה יהיה זמין בקרוב — הרשמה לפעילות", "בקרוב",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Program.currentUserEmail = "";
            Program.currentUserType  = "";
            Program.currentUserRole  = "";
            MainForm.showPanel(new LoginPanel());
        }
    }
}
