using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class ExceptionalEventPanel : UserControl
    {
        private static readonly string[] EVENT_TYPES = {
            "תאונה / פציעה",
            "תקלת ציוד",
            "מזג אוויר",
            "התנהגות חריגה",
            "בעיה רפואית",
            "אירוע בטיחות",
            "אחר"
        };
        private static readonly string[] SEVERITY_LEVELS = {
            "נמוכה", "בינונית", "גבוהה", "קריטית"
        };
        private static readonly string[] FOLLOW_UP_OPTIONS = { "כן", "לא" };

        private List<Activity> _activityList = new List<Activity>();
        private List<Customer> _customerList = new List<Customer>();

        public ExceptionalEventPanel()
        {
            InitializeComponent();

            if (!AuthService.IsInstructor())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            combo_event_type.Items.AddRange(EVENT_TYPES);
            combo_severity.Items.AddRange(SEVERITY_LEVELS);
            combo_follow_up.Items.AddRange(FOLLOW_UP_OPTIONS);
            combo_follow_up.SelectedIndex = 1; // default: לא

            populateActivityCombo();
            populateCustomerCombo(null);
            loadEventsGrid();
            combo_event_activity.SelectedIndexChanged += onActivitySelected;

            txt_description.TextChanged += (s, e) => hideError();
        }

        // =====================================================================
        // Combo population
        // =====================================================================
        private void populateActivityCombo()
        {
            combo_event_activity.Items.Clear();
            _activityList.Clear();
            combo_event_activity.Items.Add("--- בחר פעילות ---");
            _activityList.Add(null);
            foreach (Activity a in Program.Activities)
            {
                combo_event_activity.Items.Add(
                    $"#{a.getActivityNumId()} | {a.getActivityType()} | {a.getDateTime():dd/MM/yyyy HH:mm}");
                _activityList.Add(a);
            }
            combo_event_activity.SelectedIndex = 0;
        }

        private void populateCustomerCombo(Activity forActivity)
        {
            combo_event_customer.Items.Clear();
            _customerList.Clear();
            combo_event_customer.Items.Add("--- לא רלוונטי לתלמיד ספציפי ---");
            _customerList.Add(null);

            if (forActivity == null)
            {
                combo_event_customer.SelectedIndex = 0;
                return;
            }

            // Show only participants assigned to this activity
            foreach (ActivityCustomer ac in forActivity.getRoster())
            {
                Customer c = ac.getCustomer() ?? Customer.seekCustomer(ac.getCustomerId());
                if (c == null) continue;
                combo_event_customer.Items.Add($"{c.getCustomerId()} — {c.getFullName()}");
                _customerList.Add(c);
            }
            combo_event_customer.SelectedIndex = 0;
        }

        private void onActivitySelected(object sender, EventArgs e)
        {
            int idx = combo_event_activity.SelectedIndex;
            Activity selected = (idx > 0 && idx < _activityList.Count) ? _activityList[idx] : null;
            populateCustomerCombo(selected);
        }

        // =====================================================================
        // Events grid
        // =====================================================================
        private void loadEventsGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("מספר אירוע",   typeof(string));
            dt.Columns.Add("פעילות",        typeof(string));
            dt.Columns.Add("תאריך ושעה",   typeof(string));
            dt.Columns.Add("תלמיד",         typeof(string));
            dt.Columns.Add("סוג אירוע",    typeof(string));
            dt.Columns.Add("חומרה",         typeof(string));
            dt.Columns.Add("מעקב נדרש",    typeof(string));
            dt.Columns.Add("תיאור",         typeof(string));

            foreach (ExceptionalEvent ev in Program.ExceptionalEvents)
            {
                Activity a = Activity.seekActivity(ev.getActivityNumId());
                Customer c = string.IsNullOrEmpty(ev.getCustomerId())
                    ? null : Customer.seekCustomer(ev.getCustomerId());

                dt.Rows.Add(
                    ev.getEventId().ToString(),
                    a != null ? $"#{a.getActivityNumId()} {a.getActivityType()}" : ev.getActivityNumId().ToString(),
                    ev.getEventDateTime().ToString("dd/MM/yyyy HH:mm"),
                    c?.getFullName() ?? "—",
                    ev.getEventType(),
                    ev.getSeverity() ?? "—",
                    ev.getFollowUpRequired() ? "כן" : "לא",
                    ev.getDescription()
                );
            }

            dataGridView_events.DataSource = dt;
        }

        // =====================================================================
        // Save new event
        // =====================================================================
        private void btn_save_Click(object sender, EventArgs e)
        {
            hideError();

            int actIdx = combo_event_activity.SelectedIndex;
            if (actIdx <= 0 || actIdx >= _activityList.Count)
            { showError("יש לבחור פעילות"); return; }

            if (combo_event_type.SelectedIndex < 0)
            { showError("יש לבחור סוג אירוע"); return; }

            string desc = txt_description.Text.Trim();
            if (string.IsNullOrWhiteSpace(desc) || desc.Length < 5)
            { showError("יש לכתוב תיאור האירוע (לפחות 5 תווים)"); return; }

            if (combo_follow_up.SelectedIndex < 0)
            { showError("יש לציין האם נדרש מעקב"); return; }

            Activity selectedActivity = _activityList[actIdx];
            int custIdx = combo_event_customer.SelectedIndex;
            Customer selectedCustomer = (custIdx > 0 && custIdx < _customerList.Count)
                ? _customerList[custIdx] : null;

            string severity = combo_severity.SelectedIndex >= 0
                ? combo_severity.SelectedItem.ToString() : null;
            bool followUp = combo_follow_up.SelectedItem.ToString() == "כן";

            int newId = Program.ExceptionalEvents.Count > 0
                ? Program.ExceptionalEvents[Program.ExceptionalEvents.Count - 1].getEventId() + 1
                : 1;

            var ev = new ExceptionalEvent(
                newId,
                selectedActivity.getActivityNumId(),
                dtp_event_datetime.Value,
                selectedCustomer?.getCustomerId(),
                combo_event_type.SelectedItem.ToString(),
                desc,
                severity,
                followUp,
                true
            );

            ev.setActivity(selectedActivity);
            if (selectedCustomer != null) ev.setCustomer(selectedCustomer);

            MessageBox.Show("הדוח נשמר בהצלחה במערכת", "דוח אירוע חריג",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            loadEventsGrid();
            clearForm();
        }

        // =====================================================================
        // Helpers
        // =====================================================================
        private void clearForm()
        {
            combo_event_activity.SelectedIndex  = 0;
            combo_event_customer.SelectedIndex  = 0;
            combo_event_type.SelectedIndex      = -1;
            combo_severity.SelectedIndex        = -1;
            combo_follow_up.SelectedIndex       = 1;
            dtp_event_datetime.Value            = DateTime.Now;
            txt_description.Text                = "";
            hideError();
        }

        private void btn_clear_Click(object sender, EventArgs e) => clearForm();

        private void btn_back_Click(object sender, EventArgs e)
            => MainForm.showPanel(new InstructorMenuPanel());

        private void showError(string msg) { label_error.Text = msg; label_error.Visible = true; }
        private void hideError()           { label_error.Visible = false; }
    }
}
