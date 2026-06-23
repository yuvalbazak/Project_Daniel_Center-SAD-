using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class MainForm : Form
    {
        private static MainForm instance;

        public MainForm()
        {
            InitializeComponent();
            instance = this;
            showPanel(new LoginPanel());
        }

        // ── Panel swap ────────────────────────────────────────────────────────
        public static void showPanel(UserControl panel)
        {
            bool isAuth = panel is LoginPanel
                       || panel is RegisterPanel
                       || panel is ForgotPasswordPanel;

            instance.panel_sidebar.Visible = !isAuth;

            if (!isAuth)
                instance.RefreshSidebar();

            ThemeHelper.ApplyTheme(panel);

            instance.panelMain.Controls.Clear();
            panel.Dock = DockStyle.Fill;
            instance.panelMain.Controls.Add(panel);
        }

        // ── Sidebar navigation ────────────────────────────────────────────────
        private void RefreshSidebar()
        {
            string role = Program.currentUserRole;
            if (panel_nav.Tag?.ToString() == role) return;

            panel_nav.Controls.Clear();

            bool isCustomer   = AuthService.IsCustomer();
            bool isStaff      = AuthService.IsEmployee();
            bool isManager    = AuthService.IsManager();
            bool isInstructor = AuthService.IsInstructor();
            bool isAdminStaff = AuthService.IsAdminStaff();

            var items = new List<(string text, Action action)>();

            // Home destination varies by role
            if (isCustomer)
                items.Add(("⊞  ראשי",          () => showPanel(new StudentMenuPanel())));
            else if (isAdminStaff)
                items.Add(("⊞  ראשי",          () => showPanel(new AdminMenuPanel())));
            else if (isInstructor)
                items.Add(("⊞  ראשי",          () => showPanel(new InstructorMenuPanel())));
            else
                items.Add(("⊞  ראשי",          () => showPanel(new HomePanel())));

            // Instructor-specific items
            if (isInstructor)
            {
                items.Add(("◎  פעילויות שלי",   () => showPanel(new MyActivitiesPanel())));
                items.Add(("◈  תלמידים שלי",    () => showPanel(new MyStudentsPanel())));
                items.Add(("⚡  אירועים חריגים", () => showPanel(new ExceptionalEventPanel())));
            }

            // Customer-specific items
            if (isCustomer)
            {
                items.Add(("👤  הפרופיל שלי",   () => showPanel(new CustomerProfilePanel())));
                items.Add(("📅  לוח פעילויות",  () => showPanel(new CustomerSchedulePanel())));
            }

            // Main staff items (non-instructor)
            if (isStaff && !isInstructor)
            {
                if (AuthService.CanViewEmployees())
                    items.Add(("👤  עובדים",         () => showPanel(new EmployeesMenuPanel())));

                items.Add(("👥  לקוחות",             () => showPanel(new CustomersPanel())));

                if (AuthService.CanWriteBoats() || AuthService.CanViewBoatMaintenance())
                    items.Add(("⛵  סירות",           () => showPanel(new BoatsPanel())));

                items.Add(("◉  פעילויות",            () => showPanel(new ManageActivitiesPanel())));

                if (isManager)
                    items.Add(("⊠  מרכזים חיצוניים", () => showPanel(new ExternalCenterPanel())));

                items.Add(("▣  בקשות הנחה",          () => showPanel(new DiscountRequestPanel())));

                if (AuthService.CanViewMaintenance())
                    items.Add(("⚙  תחזוקה",           () => showPanel(new MaintenancePanel())));

                if (isManager)
                    items.Add(("📊  שעות עבודה",      () => showPanel(new WorkHoursReportPanel())));

                items.Add(("📋  נוכחות",              () => showPanel(new StudentsAttendanceReportPanel())));
            }

            // Logout at bottom — added first (Dock=Top reverses order)
            var btnLogout = NavBtn("↩  התנתקות", () =>
            {
                Program.currentUserEmail = "";
                Program.currentUserType  = "";
                Program.currentUserRole  = "";
                showPanel(new LoginPanel());
            });
            btnLogout.ForeColor = ThemeHelper.DANGER;
            panel_nav.Controls.Add(btnLogout);

            // Add separator above logout
            var sep = new Panel
            {
                Dock      = DockStyle.Top,
                Height    = 1,
                BackColor = ThemeHelper.BORDER
            };
            panel_nav.Controls.Add(sep);

            // Nav items (reversed so Dock=Top yields correct order)
            for (int i = items.Count - 1; i >= 0; i--)
            {
                var item = items[i];
                panel_nav.Controls.Add(NavBtn(item.text, item.action));
            }

            label_sidebar_role.Text = role;
            panel_nav.Tag = role;
        }

        private Button NavBtn(string text, Action action)
        {
            var btn = new Button
            {
                Text      = text,
                Height    = 44,
                Dock      = DockStyle.Top,
                FlatStyle = FlatStyle.Flat,
                BackColor = ThemeHelper.BG_SIDEBAR,
                ForeColor = ThemeHelper.SIDEBAR_TEXT,
                Font      = new Font("Segoe UI", 10f),
                TextAlign = ContentAlignment.MiddleRight,
                Padding   = new Padding(0, 0, 16, 0),
                Cursor    = Cursors.Hand,
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click      += (s, e) => action();
            btn.MouseEnter += (s, e) => { btn.BackColor = ThemeHelper.SIDEBAR_HOVER; btn.ForeColor = Color.White; };
            btn.MouseLeave += (s, e) => { btn.BackColor = ThemeHelper.BG_SIDEBAR; btn.ForeColor = ThemeHelper.SIDEBAR_TEXT; };
            return btn;
        }
    }
}
