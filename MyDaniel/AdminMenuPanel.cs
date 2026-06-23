using System;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class AdminMenuPanel : UserControl
    {
        public AdminMenuPanel()
        {
            InitializeComponent();

            if (!AuthService.IsAdminStaff() && !AuthService.IsManager())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            Employee self = Employee.seekByEmail(Program.currentUserEmail);
            string name = self?.getFullName() ?? Program.currentUserEmail;
            label_welcome.Text = $"שלום, {name}  |  צוות מנהלה";
        }

        // ── Implemented features ──────────────────────────────────────────────
        private void btn_employees_Click(object sender, EventArgs e)
            => MainForm.showPanel(new AdminEmployeesPanel());

        private void btn_students_Click(object sender, EventArgs e)
            => MainForm.showPanel(new AdminStudentsPanel());

        private void btn_activities_Click(object sender, EventArgs e)
            => MainForm.showPanel(new AdminActivitiesPanel());

        private void btn_assign_Click(object sender, EventArgs e)
            => MainForm.showPanel(new AdminResourceAssignPanel());

        private void btn_resource_update_Click(object sender, EventArgs e)
            => MainForm.showPanel(new AdminResourceUpdatePanel());

        // ── Placeholder features ─────────────────────────────────────────────
        private void btn_maintenance_Click(object sender, EventArgs e)
            => MainForm.showPanel(new MaintenancePanel());

        private void btn_payroll_Click(object sender, EventArgs e)
            => MessageBox.Show("סינכרון שכר ונוכחות — יהיה זמין בקרוב", "בקרוב",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void btn_dashboard_Click(object sender, EventArgs e)
            => MessageBox.Show("לוח מצב שבועי — יהיה זמין בקרוב", "בקרוב",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void btn_payment_Click(object sender, EventArgs e)
            => MessageBox.Show("ניהול תשלומים — יהיה זמין בקרוב", "בקרוב",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void btn_archive_Click(object sender, EventArgs e)
            => MessageBox.Show("רשומות ארכיון — יהיה זמין בקרוב", "בקרוב",
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
