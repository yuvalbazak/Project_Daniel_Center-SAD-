using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class StudentSchedulePanel : UserControl
    {
        private enum ViewMode { Weekly, Monthly }

        private ViewMode _mode     = ViewMode.Weekly;
        private DateTime _viewDate = DateTime.Today;

        public StudentSchedulePanel()
        {
            InitializeComponent();

            if (!AuthService.IsCustomer())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            refreshView();
        }

        // =====================================================================
        // View refresh
        // =====================================================================
        private void refreshView()
        {
            // Toggle button styles
            btn_weekly.BackColor  = _mode == ViewMode.Weekly  ? System.Drawing.Color.SteelBlue : System.Drawing.Color.LightGray;
            btn_weekly.ForeColor  = _mode == ViewMode.Weekly  ? System.Drawing.Color.White     : System.Drawing.Color.DimGray;
            btn_monthly.BackColor = _mode == ViewMode.Monthly ? System.Drawing.Color.SteelBlue : System.Drawing.Color.LightGray;
            btn_monthly.ForeColor = _mode == ViewMode.Monthly ? System.Drawing.Color.White     : System.Drawing.Color.DimGray;

            DateTime from, to;
            if (_mode == ViewMode.Weekly)
            {
                // Start of week = Sunday before or on _viewDate
                int daysFromSunday = (int)_viewDate.DayOfWeek;
                from = _viewDate.AddDays(-daysFromSunday).Date;
                to   = from.AddDays(6);
                label_period.Text = $"שבוע {from:dd/MM/yyyy} — {to:dd/MM/yyyy}";
            }
            else
            {
                from = new DateTime(_viewDate.Year, _viewDate.Month, 1);
                to   = from.AddMonths(1).AddDays(-1);
                label_period.Text = $"{hebrewMonthName(_viewDate.Month)} {_viewDate.Year}";
            }

            loadGrid(from, to);
        }

        // =====================================================================
        // Grid load with date-sorted rows
        // =====================================================================
        private void loadGrid(DateTime from, DateTime to)
        {
            Customer self = Customer.seekByEmail(Program.currentUserEmail);
            if (self == null) { label_note.Text = "שגיאה: לא נמצא משתמש מחובר"; return; }
            string myId = self.getCustomerId();

            DataTable dt = new DataTable();
            dt.Columns.Add("שם פעילות",  typeof(string));
            dt.Columns.Add("תאריך",       typeof(string));
            dt.Columns.Add("יום בשבוע",  typeof(string));
            dt.Columns.Add("שעת התחלה",  typeof(string));
            dt.Columns.Add("שעת סיום",   typeof(string));
            dt.Columns.Add("מדריך",       typeof(string));
            dt.Columns.Add("סירה",        typeof(string));
            dt.Columns.Add("סטטוס",       typeof(string));

            // Collect and sort by DateTime before inserting rows
            var collected = new List<(DateTime sortKey, object[] row)>();

            foreach (ActivityCustomer ac in Program.ActivityCustomers)
            {
                if (ac.getCustomerId() != myId) continue;

                Activity a = ac.getActivity() ?? Activity.seekActivity(ac.getActivityNumId());
                if (a == null) continue;

                DateTime actDate = a.getDateTime().Date;
                if (actDate < from.Date || actDate > to.Date) continue;

                Employee instr  = a.getInstructor();
                int?     boatId = ac.getBoatId();
                Boat     boat   = boatId.HasValue ? Boat.seekBoat(boatId.Value) : null;

                collected.Add((a.getDateTime(), new object[] {
                    a.getActivityType(),
                    a.getDateTime().ToString("dd/MM/yyyy"),
                    hebrewDayName(a.getDateTime().DayOfWeek),
                    a.getDateTime().ToString("HH:mm"),
                    a.getDateTime().AddHours(1).ToString("HH:mm"),
                    instr?.getFullName() ?? "לא שויך",
                    boat != null ? $"#{boat.getBoatNumberId()} {boat.getWaterCraftName()}" : "ללא",
                    a.getActivityStatus()
                }));
            }

            collected.Sort((x, y) => x.sortKey.CompareTo(y.sortKey));
            foreach (var item in collected)
                dt.Rows.Add(item.row);

            dataGridView_schedule.DataSource = dt;

            int count = collected.Count;
            if (count == 0)
            {
                string period = _mode == ViewMode.Weekly ? "בשבוע זה" : "בחודש זה";
                label_note.Text = $"אין פעילויות מתוכננות {period}";
            }
            else
                label_note.Text = $"סה\"כ {count} פעילויות בתקופה זו";
        }

        // =====================================================================
        // Toggle handlers
        // =====================================================================
        private void btn_weekly_Click(object sender, EventArgs e)
        {
            _mode     = ViewMode.Weekly;
            _viewDate = DateTime.Today;
            refreshView();
        }

        private void btn_monthly_Click(object sender, EventArgs e)
        {
            _mode     = ViewMode.Monthly;
            _viewDate = DateTime.Today;
            refreshView();
        }

        // =====================================================================
        // Navigation (prev / next)
        // =====================================================================
        private void btn_prev_Click(object sender, EventArgs e)
        {
            _viewDate = _mode == ViewMode.Weekly ? _viewDate.AddDays(-7) : _viewDate.AddMonths(-1);
            refreshView();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            _viewDate = _mode == ViewMode.Weekly ? _viewDate.AddDays(7) : _viewDate.AddMonths(1);
            refreshView();
        }

        private void btn_back_Click(object sender, EventArgs e)
            => MainForm.showPanel(new StudentMenuPanel());

        // =====================================================================
        // Helpers
        // =====================================================================
        private static string hebrewDayName(DayOfWeek d)
        {
            switch (d)
            {
                case DayOfWeek.Sunday:    return "ראשון";
                case DayOfWeek.Monday:    return "שני";
                case DayOfWeek.Tuesday:   return "שלישי";
                case DayOfWeek.Wednesday: return "רביעי";
                case DayOfWeek.Thursday:  return "חמישי";
                case DayOfWeek.Friday:    return "שישי";
                case DayOfWeek.Saturday:  return "שבת";
                default:                   return "";
            }
        }

        private static string hebrewMonthName(int m)
        {
            string[] names = { "ינואר", "פברואר", "מרץ", "אפריל", "מאי", "יוני",
                                "יולי", "אוגוסט", "ספטמבר", "אוקטובר", "נובמבר", "דצמבר" };
            return (m >= 1 && m <= 12) ? names[m - 1] : m.ToString();
        }
    }
}
