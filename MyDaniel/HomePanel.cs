using System;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class HomePanel : UserControl
    {
        public HomePanel()
        {
            InitializeComponent();
            applyPermissions();
            showWelcome();
        }

        // =====================================================================
        // RBAC — hide buttons the current user is not allowed to access
        // =====================================================================
        private void applyPermissions()
        {
            bool isStaff    = AuthService.IsEmployee();
            bool isCustomer = AuthService.IsCustomer();
            bool isAdmin    = AuthService.IsAdmin();

            btn_employees.Visible    = AuthService.CanViewEmployees();
            btn_customers.Visible    = isStaff;
            btn_my_profile.Visible   = isCustomer;
            btn_boats.Visible        = isStaff;
            btn_activities.Visible   = isStaff;
            btn_my_schedule.Visible  = isCustomer;
            btn_external.Visible     = AuthService.CanViewExternalCenters();
            btn_discount.Visible     = isStaff;
            btn_maintenance.Visible  = AuthService.IsManager() || isAdmin;
            btn_workhours.Visible    = AuthService.IsManager() || isAdmin;
            btn_attendance.Visible   = isStaff;
        }

        private void showWelcome()
        {
            string name;
            if (AuthService.IsAdmin())
            {
                name = "מנהל מערכת";
            }
            else if (AuthService.IsCustomer())
            {
                Customer c = Customer.seekByEmail(Program.currentUserEmail);
                name = c?.getFullName() ?? Program.currentUserEmail;
            }
            else
            {
                Employee e = Employee.seekByEmail(Program.currentUserEmail);
                name = e?.getFullName() ?? Program.currentUserEmail;
            }
            label_welcome.Text = $"שלום, {name}  |  {Program.currentUserRole}";
        }

        // =====================================================================
        // Navigation
        // =====================================================================
        private void btn_employees_Click(object sender, EventArgs e)
        {
            MainForm.showPanel(new EmployeesMenuPanel());
        }

        private void btn_customers_Click(object sender, EventArgs e)
        {
            MainForm.showPanel(new CustomersPanel());
        }

        private void btn_my_profile_Click(object sender, EventArgs e)
        {
            MainForm.showPanel(new CustomerProfilePanel());
        }

        private void btn_boats_Click(object sender, EventArgs e)
        {
            MainForm.showPanel(new BoatsPanel());
        }

        private void btn_activities_Click(object sender, EventArgs e)
        {
            MainForm.showPanel(new ManageActivitiesPanel());
        }

        private void btn_my_schedule_Click(object sender, EventArgs e)
        {
            MainForm.showPanel(new CustomerSchedulePanel());
        }

        private void btn_external_Click(object sender, EventArgs e)
            => MainForm.showPanel(new ExternalCenterPanel());

        private void btn_discount_Click(object sender, EventArgs e)
            => MainForm.showPanel(new DiscountRequestPanel());

        private void btn_maintenance_Click(object sender, EventArgs e)
            => MainForm.showPanel(new MaintenancePanel());

        private void btn_workhours_Click(object sender, EventArgs e)
            => MainForm.showPanel(new WorkHoursReportPanel());

        private void btn_attendance_Click(object sender, EventArgs e)
            => MainForm.showPanel(new StudentsAttendanceReportPanel());

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Program.currentUserEmail = "";
            Program.currentUserType  = "";
            Program.currentUserRole  = "";
            MainForm.showPanel(new LoginPanel());
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
