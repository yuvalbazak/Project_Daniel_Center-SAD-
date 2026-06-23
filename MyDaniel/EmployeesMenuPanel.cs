using System;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class EmployeesMenuPanel : UserControl
    {
        public EmployeesMenuPanel()
        {
            InitializeComponent();
            this.Load += onLoad;
        }

        private void onLoad(object sender, EventArgs e)
        {
            // Defense-in-depth: block roles that have no employee-view access
            if (!AuthService.CanViewEmployees())
            { MainForm.showPanel(new AccessDeniedPanel()); return; }

            // Coordinators and Admin Staff: view only — hide write operations
            if (!AuthService.CanWriteEmployees())
            {
                btn_create.Visible        = false;
                btn_update_delete.Visible = false;
                // Relabel the watch button to reflect restricted scope
                if (AuthService.ViewInstructorsOnly())
                    btn_watch.Text = "צפייה במדריכים";
            }
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            MainForm.showPanel(new CreateEmployeePanel());
        }

        private void btn_update_delete_Click(object sender, EventArgs e)
        {
            MainForm.showPanel(new UpdateDeleteEmployeePanel());
        }

        private void btn_watch_Click(object sender, EventArgs e)
        {
            MainForm.showPanel(new WatchEmployeesPanel());
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            MainForm.showPanel(new HomePanel());
        }
    }
}
