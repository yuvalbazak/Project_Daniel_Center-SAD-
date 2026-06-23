using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class AdminResourceAssignPanel : UserControl
    {
        private List<Employee> _instructorList = new List<Employee>();
        private List<Boat>     _boatList       = new List<Boat>();
        private Activity       _selected       = null;

        public AdminResourceAssignPanel()
        {
            InitializeComponent();

            if (!AuthService.CanAdminPortalWrite())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            populateInstructorCombo();
            populateBoatCombo();
            populateStatusCombo();

            dataGridView_activities.SelectionChanged += onGridSelectionChanged;
            loadGrid();
            setFormEnabled(false);
        }

        private void populateInstructorCombo()
        {
            _instructorList.Clear();
            combo_instructor.Items.Clear();
            combo_instructor.Items.Add("--- ללא מדריך ---");
            _instructorList.Add(null);
            foreach (Employee e in Program.Employees)
            {
                if (e.getRole() == AuthService.ROLE_INSTRUCTOR)
                {
                    combo_instructor.Items.Add($"{e.getEmployeeId()} — {e.getFullName()}");
                    _instructorList.Add(e);
                }
            }
            combo_instructor.SelectedIndex = 0;
        }

        private void populateBoatCombo()
        {
            _boatList.Clear();
            combo_boat.Items.Clear();
            combo_boat.Items.Add("--- ללא סירה ---");
            _boatList.Add(null);
            foreach (Boat b in Program.Boats)
            {
                combo_boat.Items.Add($"#{b.getBoatNumberId()} — {b.getWaterCraftName()} ({b.getBoatStatus()})");
                _boatList.Add(b);
            }
            combo_boat.SelectedIndex = 0;
        }

        private void populateStatusCombo()
        {
            combo_status.Items.Clear();
            combo_status.Items.Add("ללא שינוי");
            combo_status.Items.Add("מתוכנן");
            combo_status.Items.Add("פעיל");
            combo_status.Items.Add("הושלם");
            combo_status.Items.Add("בוטל");
            combo_status.SelectedIndex = 0;
        }

        private void loadGrid()
        {
            dataGridView_activities.SelectionChanged -= onGridSelectionChanged;

            DataTable dt = new DataTable();
            dt.Columns.Add("#",          typeof(int));
            dt.Columns.Add("שם פעילות", typeof(string));
            dt.Columns.Add("תאריך",      typeof(string));
            dt.Columns.Add("שעה",        typeof(string));
            dt.Columns.Add("מדריך",      typeof(string));
            dt.Columns.Add("סירה",       typeof(string));
            dt.Columns.Add("סטטוס",      typeof(string));

            var rows = new List<(DateTime sortKey, object[] row)>();
            foreach (Activity a in Program.Activities)
            {
                string instrName = a.getInstructor()?.getFullName() ?? "לא שויך";
                Boat   boat      = a.getBoat();
                string boatName  = boat != null
                                   ? $"#{boat.getBoatNumberId()} {boat.getWaterCraftName()}" : "ללא";
                rows.Add((a.getDateTime(), new object[] {
                    a.getActivityNumId(),
                    a.getActivityType(),
                    a.getDateTime().ToString("dd/MM/yyyy"),
                    a.getDateTime().ToString("HH:mm"),
                    instrName,
                    boatName,
                    a.getActivityStatus()
                }));
            }
            rows.Sort((x, y) => x.sortKey.CompareTo(y.sortKey));
            foreach (var (_, row) in rows) dt.Rows.Add(row);

            dataGridView_activities.DataSource = dt;
            dataGridView_activities.SelectionChanged += onGridSelectionChanged;
        }

        private void onGridSelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_activities.SelectedRows.Count == 0) return;
            var val = dataGridView_activities.SelectedRows[0].Cells[0].Value;
            if (val == null) return;
            if (!int.TryParse(val.ToString(), out int id)) return;
            Activity a = Activity.seekActivity(id);
            if (a == null) return;
            _selected = a;

            // Pre-select current instructor
            combo_instructor.SelectedIndex = 0;
            if (!string.IsNullOrEmpty(a.getInstructorId()))
                for (int i = 1; i < _instructorList.Count; i++)
                    if (_instructorList[i]?.getEmployeeId() == a.getInstructorId())
                    { combo_instructor.SelectedIndex = i; break; }

            // Pre-select current boat
            combo_boat.SelectedIndex = 0;
            if (a.getBoatNumberId() != null)
                for (int i = 1; i < _boatList.Count; i++)
                    if (_boatList[i]?.getBoatNumberId() == a.getBoatNumberId().Value)
                    { combo_boat.SelectedIndex = i; break; }

            combo_status.SelectedIndex = 0;

            string instrName = a.getInstructor()?.getFullName() ?? "לא שויך";
            string boatName  = a.getBoat()?.getWaterCraftName() ?? "ללא";
            label_current.Text = $"מדריך נוכחי: {instrName}  |  סירה: {boatName}  |  סטטוס: {a.getActivityStatus()}";

            setFormEnabled(true);
            hideError();
        }

        private void setFormEnabled(bool enabled)
        {
            combo_instructor.Enabled = enabled;
            combo_boat.Enabled       = enabled;
            combo_status.Enabled     = enabled;
            btn_assign.Enabled       = enabled;
        }

        private void btn_assign_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;
            hideError();

            int instrIdx = combo_instructor.SelectedIndex;
            if (instrIdx >= 0 && instrIdx < _instructorList.Count)
                _selected.setInstructorId(_instructorList[instrIdx]?.getEmployeeId());

            int boatIdx = combo_boat.SelectedIndex;
            if (boatIdx >= 0 && boatIdx < _boatList.Count)
            {
                Boat b = _boatList[boatIdx];
                _selected.setBoatNumberId(b != null ? (int?)b.getBoatNumberId() : null);
            }

            if (combo_status.SelectedIndex > 0)
                _selected.setActivityStatus(combo_status.SelectedItem.ToString());

            _selected.updateActivity();

            MessageBox.Show("המשאבים שויכו לפעילות בהצלחה", "שיוך בוצע",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadGrid();
            _selected = null;
            label_current.Text = "";
            setFormEnabled(false);
        }

        private void btn_back_Click(object sender, EventArgs e)
            => MainForm.showPanel(new AdminMenuPanel());

        private void showError(string msg) { label_error.Text = msg; label_error.Visible = true; }
        private void hideError()           { label_error.Visible = false; }
    }
}
