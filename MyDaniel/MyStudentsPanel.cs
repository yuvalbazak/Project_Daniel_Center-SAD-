using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class MyStudentsPanel : UserControl
    {
        public MyStudentsPanel()
        {
            InitializeComponent();

            if (!AuthService.IsInstructor())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            loadGrid();
        }

        private void loadGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("מספר ת.ז.",      typeof(string));
            dt.Columns.Add("שם מלא",          typeof(string));
            dt.Columns.Add("טלפון",           typeof(string));
            dt.Columns.Add("אימייל",          typeof(string));
            dt.Columns.Add("סטטוס",           typeof(string));
            dt.Columns.Add("פעילויות (דוחות)", typeof(string));

            Employee self = Employee.seekByEmail(Program.currentUserEmail);
            string   myId = self?.getEmployeeId();

            // Build set of activity IDs belonging to this instructor
            HashSet<int> myActivityIds = new HashSet<int>();
            foreach (Activity a in Program.Activities)
                if (a.getInstructorId() == myId) myActivityIds.Add(a.getActivityNumId());

            // Build set of customer IDs enrolled in those activities
            HashSet<string> myCustomerIds = new HashSet<string>();
            foreach (ActivityCustomer ac in Program.ActivityCustomers)
                if (myActivityIds.Contains(ac.getActivityNumId()))
                    myCustomerIds.Add(ac.getCustomerId());

            List<Customer> toShow = new List<Customer>();
            foreach (Customer c in Program.Customers)
                if (myCustomerIds.Contains(c.getCustomerId())) toShow.Add(c);

            HashSet<string> activeIds = new HashSet<string>();
            foreach (StudentsAttendanceReport r in Program.StudentsAttendanceReports)
                activeIds.Add(r.getCustomerId());

            foreach (Customer c in toShow)
            {
                int reportCount = c.getAttendanceReports().Count;
                dt.Rows.Add(
                    c.getCustomerId(),
                    c.getFullName(),
                    c.getPhone(),
                    c.getEmail(),
                    c.getCustomerStatus(),
                    reportCount.ToString()
                );
            }

            dataGridView_students.DataSource = dt;

            if (toShow.Count == 0)
                label_note.Text = "אין תלמידים רשומים לפעילויות שלך";
            else
                label_note.Text = $"סה\"כ {toShow.Count} תלמידים | {activeIds.Count} עם דוחות נוכחות";
        }

        private void btn_back_Click(object sender, System.EventArgs e)
            => MainForm.showPanel(new InstructorMenuPanel());
    }
}
