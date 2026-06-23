using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class AdminActivitiesPanel : UserControl
    {
        public AdminActivitiesPanel()
        {
            InitializeComponent();

            if (!AuthService.IsAdminStaff() && !AuthService.IsManager())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            populateTypeFilter();
            populateStatusFilter();

            txt_search.TextChanged                   += (s, e) => loadGrid();
            combo_filter_type.SelectedIndexChanged   += (s, e) => loadGrid();
            combo_filter_status.SelectedIndexChanged += (s, e) => loadGrid();

            loadGrid();
        }

        private void populateTypeFilter()
        {
            combo_filter_type.Items.Clear();
            combo_filter_type.Items.Add("הכל");
            var types = new System.Collections.Generic.HashSet<string>();
            foreach (Activity a in Program.Activities)
                if (!string.IsNullOrEmpty(a.getActivityType())) types.Add(a.getActivityType());
            foreach (string t in types) combo_filter_type.Items.Add(t);
            combo_filter_type.SelectedIndex = 0;
        }

        private void populateStatusFilter()
        {
            combo_filter_status.Items.Clear();
            combo_filter_status.Items.Add("הכל");
            combo_filter_status.Items.Add("מתוכנן");
            combo_filter_status.Items.Add("פעיל");
            combo_filter_status.Items.Add("הושלם");
            combo_filter_status.Items.Add("בוטל");
            combo_filter_status.SelectedIndex = 0;
        }

        private void loadGrid()
        {
            string search      = txt_search.Text.Trim().ToLower();
            string typeFilter  = combo_filter_type.SelectedIndex > 0
                                 ? combo_filter_type.SelectedItem.ToString() : null;
            string statFilter  = combo_filter_status.SelectedIndex > 0
                                 ? combo_filter_status.SelectedItem.ToString() : null;

            var rows = new List<(DateTime sortKey, object[] row)>();

            foreach (Activity a in Program.Activities)
            {
                if (typeFilter != null && a.getActivityType() != typeFilter) continue;
                if (statFilter != null && a.getActivityStatus() != statFilter) continue;

                string instrName = a.getInstructor()?.getFullName() ?? "לא שויך";
                Boat   boat      = a.getBoat();
                string boatName  = boat != null
                                   ? $"#{boat.getBoatNumberId()} {boat.getWaterCraftName()}" : "ללא";
                int    count     = a.getRoster().Count;

                if (!string.IsNullOrEmpty(search))
                {
                    bool match = a.getActivityType().ToLower().Contains(search)
                              || a.getLocation().ToLower().Contains(search)
                              || instrName.ToLower().Contains(search)
                              || a.getActivityStatus().ToLower().Contains(search);
                    if (!match) continue;
                }

                rows.Add((a.getDateTime(), new object[] {
                    a.getActivityType(),
                    a.getDateTime().ToString("dd/MM/yyyy"),
                    hebrewDayName(a.getDateTime().DayOfWeek),
                    a.getDateTime().ToString("HH:mm"),
                    a.getLocation(),
                    instrName,
                    boatName,
                    $"{count}/{a.getMaxParticipants()}",
                    a.getActivityStatus()
                }));
            }

            rows.Sort((x, y) => x.sortKey.CompareTo(y.sortKey));

            DataTable dt = new DataTable();
            dt.Columns.Add("שם פעילות", typeof(string));
            dt.Columns.Add("תאריך",      typeof(string));
            dt.Columns.Add("יום",         typeof(string));
            dt.Columns.Add("שעה",         typeof(string));
            dt.Columns.Add("מיקום",       typeof(string));
            dt.Columns.Add("מדריך",       typeof(string));
            dt.Columns.Add("סירה",        typeof(string));
            dt.Columns.Add("משתתפים",     typeof(string));
            dt.Columns.Add("סטטוס",       typeof(string));

            foreach (var (_, row) in rows)
                dt.Rows.Add(row);

            dataGridView_activities.DataSource = dt;
            label_count.Text = $"סה\"כ: {dt.Rows.Count} פעילויות";
        }

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
                default:                  return "";
            }
        }

        private void btn_reset_filter_Click(object sender, EventArgs e)
        {
            txt_search.Text                   = "";
            combo_filter_type.SelectedIndex   = 0;
            combo_filter_status.SelectedIndex = 0;
        }

        private void btn_back_Click(object sender, EventArgs e)
            => MainForm.showPanel(new AdminMenuPanel());
    }
}
