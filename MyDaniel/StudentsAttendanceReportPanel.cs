using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class StudentsAttendanceReportPanel : UserControl
    {
        private static readonly string[] ATTENDANCE_STATUSES = {
            "נוכח",
            "נעדר בהודעה מוקדמת",
            "נעדר ללא הודעה"
        };
        private static readonly System.Drawing.Color ERR_BG =
            System.Drawing.Color.FromArgb(255, 220, 220);

        private List<Activity> _activityList   = new List<Activity>();
        private List<Customer> _customerList   = new List<Customer>();
        private Activity       _loadedActivity = null;
        private StudentsAttendanceReport _editingReport = null;
        private bool _canWrite;

        public StudentsAttendanceReportPanel()
        {
            InitializeComponent();

            if (!AuthService.IsEmployee())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            // Coordinators and managers have full write; instructors write for own activities
            _canWrite = AuthService.CanWriteActivities() || AuthService.IsInstructor();

            combo_status.Items.AddRange(ATTENDANCE_STATUSES);

            combo_customer.Items.Add("--- טען פעילות תחילה ---");
            _customerList.Add(null);
            combo_customer.SelectedIndex = 0;
            combo_customer.Enabled       = false;

            populateActivityCombo();

            txt_notes.TextChanged += (s, e) => hideError();

            if (!_canWrite)
            {
                label_form_title.Text  = "נוכחות תלמיד — צפייה בלבד";
                btn_save.Visible       = false;
                combo_status.Enabled   = false;
                txt_notes.ReadOnly     = true;
            }
        }

        // =====================================================================
        // Populate combos
        // =====================================================================
        private void populateActivityCombo()
        {
            combo_activities.Items.Clear();
            _activityList.Clear();

            combo_activities.Items.Add("--- בחר פעילות ---");
            _activityList.Add(null);

            // Instructors see only their own activities; others see all
            List<Activity> toShow = Program.Activities;
            if (AuthService.IsInstructor())
            {
                Employee self = Employee.seekByEmail(Program.currentUserEmail);
                string   myId = self?.getEmployeeId();
                List<Activity> mine = Program.Activities.FindAll(a => a.getInstructorId() == myId);
                if (mine.Count > 0) toShow = mine;
            }

            foreach (Activity a in toShow)
            {
                combo_activities.Items.Add(
                    $"#{a.getActivityNumId()} | {a.getActivityType()} | {a.getDateTime():dd/MM/yyyy HH:mm} | {a.getLocation()}");
                _activityList.Add(a);
            }
            combo_activities.SelectedIndex = 0;
        }

        private void populateCustomerComboFromRoster(Activity a)
        {
            combo_customer.Items.Clear();
            _customerList.Clear();

            var roster = a.getRoster();
            if (roster.Count == 0)
            {
                combo_customer.Items.Add("--- אין תלמידים בפעילות ---");
                _customerList.Add(null);
                combo_customer.SelectedIndex = 0;
                combo_customer.Enabled       = false;
                return;
            }

            combo_customer.Items.Add("--- בחר תלמיד ---");
            _customerList.Add(null);

            foreach (ActivityCustomer ac in roster)
            {
                Customer c = ac.getCustomer() ?? Customer.seekCustomer(ac.getCustomerId());
                if (c == null) continue;
                combo_customer.Items.Add($"{c.getCustomerId()} — {c.getFullName()}");
                _customerList.Add(c);
            }
            combo_customer.SelectedIndex = 0;
            combo_customer.Enabled       = _canWrite;
        }

        // =====================================================================
        // Load attendance grid — all roster students with current status
        // =====================================================================
        private void btn_load_Click(object sender, EventArgs e)
        {
            hideError();
            int idx = combo_activities.SelectedIndex;
            if (idx <= 0 || idx >= _activityList.Count)
            { showError("יש לבחור פעילות לפני טעינת הנוכחות"); return; }

            _loadedActivity = _activityList[idx];
            populateCustomerComboFromRoster(_loadedActivity);
            loadAttendanceGrid(_loadedActivity);
            clearForm();
        }

        private void loadAttendanceGrid(Activity a)
        {
            dataGridView_attendance.SelectionChanged -= onGridSelectionChanged;

            DataTable dt = new DataTable();
            dt.Columns.Add("מ.ז. תלמיד",   typeof(string));
            dt.Columns.Add("שם תלמיד",     typeof(string));
            dt.Columns.Add("סטטוס נוכחות", typeof(string));
            dt.Columns.Add("הערות",         typeof(string));

            int count = 0;
            foreach (ActivityCustomer ac in a.getRoster())
            {
                Customer c = ac.getCustomer() ?? Customer.seekCustomer(ac.getCustomerId());
                StudentsAttendanceReport sar = StudentsAttendanceReport.seekByActivityAndCustomer(
                    a.getActivityNumId(), ac.getCustomerId());

                dt.Rows.Add(
                    ac.getCustomerId(),
                    c?.getFullName() ?? "לא ידוע",
                    sar?.getAttendanceStatus() ?? "לא דווח",
                    sar?.getNotes() ?? ""
                );
                count++;
            }

            dataGridView_attendance.DataSource = dt;
            dataGridView_attendance.SelectionChanged += onGridSelectionChanged;

            if (count == 0)
                label_grid_header.Text = "אין תלמידים המשויכים לפעילות זו — הוסף משתתפים דרך ניהול פעילויות";
            else
                label_grid_header.Text = $"תלמידי הפעילות ({count} תלמידים) — לחץ על שורה לסימון נוכחות";
        }

        // =====================================================================
        // Grid selection → populate form for editing
        // =====================================================================
        private void onGridSelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_attendance.SelectedRows.Count == 0) return;
            if (!_canWrite) return;

            string customerId = dataGridView_attendance.SelectedRows[0].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(customerId) || _loadedActivity == null) return;

            for (int i = 1; i < _customerList.Count; i++)
            {
                if (_customerList[i]?.getCustomerId() == customerId)
                { combo_customer.SelectedIndex = i; break; }
            }

            _editingReport = StudentsAttendanceReport.seekByActivityAndCustomer(
                _loadedActivity.getActivityNumId(), customerId);

            if (_editingReport != null)
            {
                for (int i = 0; i < combo_status.Items.Count; i++)
                {
                    if (combo_status.Items[i].ToString() == _editingReport.getAttendanceStatus())
                    { combo_status.SelectedIndex = i; break; }
                }
                txt_notes.Text = _editingReport.getNotes() ?? "";
            }
            else
            {
                combo_status.SelectedIndex = -1;
                txt_notes.Text             = "";
            }
            hideError();
        }

        // =====================================================================
        // Save attendance (create or update)
        // =====================================================================
        private void btn_save_Click(object sender, EventArgs e)
        {
            hideError();

            if (!_canWrite) { showError("אין לך הרשאה לעדכן נוכחות"); return; }

            if (_loadedActivity == null)
            { showError("יש לטעון פעילות לפני שמירת נוכחות"); return; }

            // Instructor may only record attendance for their own activity
            if (AuthService.IsInstructor())
            {
                Employee self = Employee.seekByEmail(Program.currentUserEmail);
                if (self?.getEmployeeId() != _loadedActivity.getInstructorId())
                { showError("אין לך הרשאה לעדכן נוכחות לפעילות זו"); return; }
            }

            int custIdx = combo_customer.SelectedIndex;
            if (custIdx <= 0 || custIdx >= _customerList.Count)
            { showError("יש לבחור תלמיד"); return; }

            if (combo_status.SelectedIndex < 0)
            { showError("יש לבחור סטטוס נוכחות"); return; }

            Customer selectedCustomer = _customerList[custIdx];
            string statusText = combo_status.SelectedItem.ToString();
            string notes      = txt_notes.Text.Trim();
            int    actId      = _loadedActivity.getActivityNumId();
            string custId     = selectedCustomer.getCustomerId();

            StudentsAttendanceReport existing =
                StudentsAttendanceReport.seekByActivityAndCustomer(actId, custId);

            if (existing != null)
            {
                existing.setAttendanceStatus(statusText);
                existing.setNotes(string.IsNullOrWhiteSpace(notes) ? null : notes);
                existing.updateStudentsAttendanceReport();
                MessageBox.Show("הנוכחות עודכנה בהצלחה", "עדכון",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int newId = Program.StudentsAttendanceReports.Count > 0
                    ? Program.StudentsAttendanceReports[Program.StudentsAttendanceReports.Count - 1].getAttendanceReportId() + 1
                    : 1;

                var newReport = new StudentsAttendanceReport(
                    newId, actId, custId, statusText,
                    string.IsNullOrWhiteSpace(notes) ? null : notes, true);

                selectedCustomer.addAttendanceReport(newReport);
                _loadedActivity.addAttendanceReport(newReport);

                MessageBox.Show("הנוכחות נשמרה בהצלחה", "שמירה",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            loadAttendanceGrid(_loadedActivity);
            clearForm();
        }

        // =====================================================================
        // Navigate to exceptional event panel
        // =====================================================================
        private void btn_exceptional_Click(object sender, EventArgs e)
            => MainForm.showPanel(new ExceptionalEventPanel());

        // =====================================================================
        // Clear / Back
        // =====================================================================
        private void btn_clear_Click(object sender, EventArgs e)
        {
            clearForm();
            dataGridView_attendance.ClearSelection();
        }

        private void clearForm()
        {
            _editingReport = null;
            if (combo_customer.Items.Count > 0) combo_customer.SelectedIndex = 0;
            combo_status.SelectedIndex = -1;
            txt_notes.Text             = "";
            hideError();
        }

        private void btn_back_Click(object sender, EventArgs e)
            => MainForm.showPanel(new HomePanel());

        // =====================================================================
        // UI helpers
        // =====================================================================
        private void showError(string msg) { label_error.Text = msg; label_error.Visible = true; }
        private void hideError()           { label_error.Visible = false; }
    }
}
