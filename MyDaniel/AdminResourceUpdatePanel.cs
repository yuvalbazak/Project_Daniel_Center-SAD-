using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class AdminResourceUpdatePanel : UserControl
    {
        private List<Employee> _instructorList = new List<Employee>();
        private List<Boat>     _boatList       = new List<Boat>();
        private Activity       _selected       = null;

        public AdminResourceUpdatePanel()
        {
            InitializeComponent();

            if (!AuthService.CanAdminPortalWrite())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            populateInstructorCombo();
            populateBoatCombo();

            dataGridView_activities.SelectionChanged += onGridSelectionChanged;
            loadGrid();
            setFormEnabled(false);
        }

        private void populateInstructorCombo()
        {
            _instructorList.Clear();
            combo_new_instructor.Items.Clear();
            combo_new_instructor.Items.Add("--- בחר מדריך חלופי ---");
            _instructorList.Add(null);
            foreach (Employee e in Program.Employees)
            {
                if (e.getRole() == AuthService.ROLE_INSTRUCTOR)
                {
                    combo_new_instructor.Items.Add($"{e.getEmployeeId()} -- {e.getFullName()}");
                    _instructorList.Add(e);
                }
            }
            combo_new_instructor.SelectedIndex = 0;
        }

        private void populateBoatCombo()
        {
            _boatList.Clear();
            combo_new_boat.Items.Clear();
            combo_new_boat.Items.Add("--- בחר סירה זמינה ---");
            _boatList.Add(null);
            foreach (Boat b in Program.Boats)
            {
                combo_new_boat.Items.Add($"#{b.getBoatNumberId()} -- {b.getWaterCraftName()} ({b.getBoatStatus()})");
                _boatList.Add(b);
            }
            combo_new_boat.SelectedIndex = 0;
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
                string s = a.getActivityStatus();
                if (s != "מתוכנן" && s != "פעיל") continue;

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
                    s
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
            setFormEnabled(true);
            hideError();
        }

        private void setFormEnabled(bool enabled)
        {
            combo_new_instructor.Enabled   = enabled;
            txt_instructor_reason.Enabled  = enabled;
            btn_replace_instructor.Enabled = enabled;
            combo_new_boat.Enabled         = enabled;
            txt_boat_reason.Enabled        = enabled;
            btn_replace_boat.Enabled       = enabled;
            btn_report_unavailable.Enabled = enabled;
        }

        private void btn_replace_instructor_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;
            hideError();

            int idx = combo_new_instructor.SelectedIndex;
            if (idx <= 0 || idx >= _instructorList.Count || _instructorList[idx] == null)
            { showError("יש לבחור מדריך חלופי"); return; }

            if (string.IsNullOrWhiteSpace(txt_instructor_reason.Text))
            { showError("יש להזין סיבה להחלפת המדריך"); return; }

            Employee newInstr = _instructorList[idx];
            _selected.setInstructorId(newInstr.getEmployeeId());
            _selected.updateActivity();

            MessageBox.Show($"המדריך הוחלף ל-{newInstr.getFullName()} בהצלחה", "החלפת מדריך",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            txt_instructor_reason.Text         = "";
            combo_new_instructor.SelectedIndex = 0;
            loadGrid();
        }

        private void btn_replace_boat_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;
            hideError();

            int idx = combo_new_boat.SelectedIndex;
            if (idx <= 0 || idx >= _boatList.Count || _boatList[idx] == null)
            { showError("יש לבחור סירה זמינה"); return; }

            if (string.IsNullOrWhiteSpace(txt_boat_reason.Text))
            { showError("יש להזין סיבה להחלפת הסירה"); return; }

            Boat newBoat = _boatList[idx];
            _selected.setBoatNumberId(newBoat.getBoatNumberId());
            _selected.updateActivity();

            MessageBox.Show($"הסירה הוחלפה ל-{newBoat.getWaterCraftName()} בהצלחה", "החלפת סירה",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            txt_boat_reason.Text         = "";
            combo_new_boat.SelectedIndex = 0;
            loadGrid();
        }

        private void btn_report_unavailable_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;
            hideError();

            Boat currentBoat = _selected.getBoat();
            if (currentBoat == null)
            { showError("לפעילות זו לא שויכה סירה"); return; }

            DialogResult confirm = MessageBox.Show(
                $"לדווח שסירה #{currentBoat.getBoatNumberId()} {currentBoat.getWaterCraftName()} אינה זמינה?",
                "אישור דיווח", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            currentBoat.setBoatStatus("Unavailable");
            currentBoat.updateBoat();
            _selected.setBoatNumberId(null);
            _selected.updateActivity();

            MessageBox.Show("הסירה סומנה כלא זמינה ונותקה מהפעילות", "דיווח בוצע",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            populateBoatCombo();
            loadGrid();
        }

        private void btn_back_Click(object sender, EventArgs e)
            => MainForm.showPanel(new AdminMenuPanel());

        private void showError(string msg) { label_error.Text = msg; label_error.Visible = true; }
        private void hideError()           { label_error.Visible = false; }
    }
}
