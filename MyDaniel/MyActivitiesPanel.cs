using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class MyActivitiesPanel : UserControl
    {
        private List<Activity> _myActivities = new List<Activity>();

        public MyActivitiesPanel()
        {
            InitializeComponent();

            if (!AuthService.IsInstructor())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            loadGrid();
            dataGridView_activities.SelectionChanged += onActivitySelected;
        }

        private void loadGrid()
        {
            dataGridView_activities.SelectionChanged -= onActivitySelected;

            Employee self = Employee.seekByEmail(Program.currentUserEmail);
            string   myId = self?.getEmployeeId();

            _myActivities = Program.Activities.FindAll(a => a.getInstructorId() == myId);

            DataTable dt = new DataTable();
            dt.Columns.Add("מספר פעילות",   typeof(string));
            dt.Columns.Add("סוג פעילות",    typeof(string));
            dt.Columns.Add("תאריך ושעה",    typeof(string));
            dt.Columns.Add("מיקום",          typeof(string));
            dt.Columns.Add("קבוצת גיל",     typeof(string));
            dt.Columns.Add("סטטוס",          typeof(string));
            dt.Columns.Add("משתתפים רשומים", typeof(string));

            foreach (Activity a in _myActivities)
            {
                dt.Rows.Add(
                    a.getActivityNumId().ToString(),
                    a.getActivityType(),
                    a.getDateTime().ToString("dd/MM/yyyy HH:mm"),
                    a.getLocation(),
                    a.getAgeGroup(),
                    a.getActivityStatus(),
                    $"{a.getRoster().Count} / {a.getMaxParticipants()}"
                );
            }

            dataGridView_activities.DataSource = dt;
            dataGridView_activities.SelectionChanged += onActivitySelected;

            label_note.Text = _myActivities.Count == 0
                ? "אין פעילויות מוצמדות אליך כרגע"
                : $"סה\"כ {_myActivities.Count} פעילויות — לחץ על שורה לצפיה בפרטים";

            hideDetail();
        }

        private void onActivitySelected(object sender, System.EventArgs e)
        {
            if (dataGridView_activities.SelectedRows.Count == 0) return;
            string idStr = dataGridView_activities.SelectedRows[0].Cells[0].Value?.ToString();
            if (!int.TryParse(idStr, out int actId)) return;
            Activity a = Activity.seekActivity(actId);
            if (a == null) return;

            showDetail(a);
        }

        private void showDetail(Activity a)
        {
            Employee instr = a.getInstructor();
            Boat     boat  = a.getBoat();

            label_detail_info.Text =
                $"סוג: {a.getActivityType()}  |  " +
                $"תאריך: {a.getDateTime():dd/MM/yyyy HH:mm}  |  " +
                $"מיקום: {a.getLocation()}  |  " +
                $"קבוצת גיל: {a.getAgeGroup()}  |  " +
                $"מדריך: {instr?.getFullName() ?? "לא שויך"}  |  " +
                $"סירה: {(boat != null ? $"#{boat.getBoatNumberId()} {boat.getWaterCraftName()}" : "ללא")}  |  " +
                $"סטטוס: {a.getActivityStatus()}";

            DataTable dt = new DataTable();
            dt.Columns.Add("מ.ז. תלמיד",  typeof(string));
            dt.Columns.Add("שם מלא",       typeof(string));
            dt.Columns.Add("טלפון",        typeof(string));
            dt.Columns.Add("סירה משויכת", typeof(string));
            dt.Columns.Add("הערות",        typeof(string));

            foreach (ActivityCustomer ac in a.getRoster())
            {
                Customer c = ac.getCustomer() ?? Customer.seekCustomer(ac.getCustomerId());
                string boatDisplay = "לא שויכה";
                if (ac.getBoatId().HasValue)
                {
                    Boat b = Boat.seekBoat(ac.getBoatId().Value);
                    boatDisplay = b != null ? $"#{b.getBoatNumberId()} {b.getWaterCraftName()}" : "לא שויכה";
                }
                dt.Rows.Add(
                    ac.getCustomerId(),
                    c?.getFullName() ?? "לא ידוע",
                    c?.getPhone()    ?? "",
                    boatDisplay,
                    ac.getNotes() ?? ""
                );
            }

            dataGridView_participants.DataSource = dt;

            label_detail_header.Text    = $"פרטי פעילות #{a.getActivityNumId()} — {a.getActivityType()} ({a.getRoster().Count} משתתפים):";
            label_detail_header.Visible = true;
            label_detail_info.Visible   = true;
            dataGridView_participants.Visible = true;
        }

        private void hideDetail()
        {
            label_detail_header.Visible      = false;
            label_detail_info.Visible        = false;
            dataGridView_participants.Visible = false;
        }

        private void btn_back_Click(object sender, System.EventArgs e)
            => MainForm.showPanel(new InstructorMenuPanel());
    }
}
