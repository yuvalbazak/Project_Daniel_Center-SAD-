using System.Data;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class CustomerSchedulePanel : UserControl
    {
        public CustomerSchedulePanel()
        {
            InitializeComponent();

            if (!AuthService.IsCustomer())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            loadGrid();
        }

        private void loadGrid()
        {
            Customer self = Customer.seekByEmail(Program.currentUserEmail);
            if (self == null) { label_note.Text = "לא נמצא לקוח מחובר"; return; }

            string myId = self.getCustomerId();

            DataTable dt = new DataTable();
            dt.Columns.Add("שם פעילות",   typeof(string));
            dt.Columns.Add("תאריך",       typeof(string));
            dt.Columns.Add("שעה",         typeof(string));
            dt.Columns.Add("מדריך",       typeof(string));
            dt.Columns.Add("סירה משויכת", typeof(string));

            int count = 0;
            foreach (ActivityCustomer ac in Program.ActivityCustomers)
            {
                if (ac.getCustomerId() != myId) continue;

                Activity a = ac.getActivity() ?? Activity.seekActivity(ac.getActivityNumId());
                if (a == null) continue;

                Employee instr     = a.getInstructor();
                string   instrName = instr?.getFullName() ?? "לא שויך";

                string boatDisplay = "לא שויכה";
                if (ac.getBoatId().HasValue)
                {
                    Boat b = Boat.seekBoat(ac.getBoatId().Value);
                    boatDisplay = b != null ? $"{b.getWaterCraftName()}" : "לא שויכה";
                }

                dt.Rows.Add(
                    a.getActivityType(),
                    a.getDateTime().ToString("dd/MM/yyyy"),
                    a.getDateTime().ToString("HH:mm"),
                    instrName,
                    boatDisplay
                );
                count++;
            }

            dataGridView_schedule.DataSource = dt;

            label_note.Text = count == 0
                ? "אינך רשום/ה לאף פעילות כרגע"
                : $"רשום/ה ל-{count} פעילויות";
        }

        private void btn_back_Click(object sender, System.EventArgs e)
            => MainForm.showPanel(new HomePanel());
    }
}
