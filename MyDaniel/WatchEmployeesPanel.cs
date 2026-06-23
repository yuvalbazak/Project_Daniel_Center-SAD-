using System;
using System.Data;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class WatchEmployeesPanel : UserControl
    {
        public WatchEmployeesPanel()
        {
            InitializeComponent();
            this.Load += onLoad;
        }

        private void onLoad(object sender, EventArgs e)
        {
            if (!AuthService.CanViewEmployees())
            { MainForm.showPanel(new AccessDeniedPanel()); return; }

            loadEmployees();
        }

        private void loadEmployees()
        {
            bool instructorsOnly = AuthService.ViewInstructorsOnly();

            label_title.Text = instructorsOnly ? "רשימת מדריכים" : "רשימת עובדים";

            DataTable dt = new DataTable();
            dt.Columns.Add("מספר עובד",    typeof(string));
            dt.Columns.Add("שם מלא",       typeof(string));
            dt.Columns.Add("תפקיד",        typeof(string));
            dt.Columns.Add("תאריך התחלה", typeof(string));
            dt.Columns.Add("טלפון",        typeof(string));
            dt.Columns.Add("אימייל",       typeof(string));

            foreach (Employee emp in Program.Employees)
            {
                // Coordinators may only see Instructor records
                if (instructorsOnly && emp.getRole() != AuthService.ROLE_INSTRUCTOR)
                    continue;

                dt.Rows.Add(
                    emp.getEmployeeId(),
                    emp.getFullName(),
                    emp.getRole(),
                    emp.getStartDate().ToShortDateString(),
                    emp.getPhone(),
                    emp.getEmail()
                );
            }

            dataGridView_employees.DataSource = dt;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            MainForm.showPanel(new EmployeesMenuPanel());
        }
    }
}
