using System;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class InstructorMenuPanel : UserControl
    {
        public InstructorMenuPanel()
        {
            InitializeComponent();

            if (!AuthService.IsInstructor())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            Employee self = Employee.seekByEmail(Program.currentUserEmail);
            string name = self?.getFullName() ?? Program.currentUserEmail;
            label_welcome.Text = $"שלום, {name}  |  מדריך";

            btn_resources.Visible = false; // Activity Resource Update removed from instructor menu
        }

        private void btn_attendance_Click(object sender, EventArgs e)
            => MainForm.showPanel(new AttendanceReportPanel());

        private void btn_resources_Click(object sender, EventArgs e)
            => MainForm.showPanel(new ActivityResourceUpdatePanel());

        private void btn_events_Click(object sender, EventArgs e)
            => MainForm.showPanel(new ExceptionalEventPanel());

        private void btn_my_activities_Click(object sender, EventArgs e)
            => MainForm.showPanel(new MyActivitiesPanel());

        private void btn_my_students_Click(object sender, EventArgs e)
            => MainForm.showPanel(new MyStudentsPanel());

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Program.currentUserEmail = "";
            Program.currentUserType  = "";
            Program.currentUserRole  = "";
            MainForm.showPanel(new LoginPanel());
        }
    }
}
