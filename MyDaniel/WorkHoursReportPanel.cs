using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class WorkHoursReportPanel : UserControl
    {
        private static readonly System.Drawing.Color ERR_BG =
            System.Drawing.Color.FromArgb(255, 220, 220);

        private WorkHoursReport _selected    = null;
        private List<Employee>  _employeeList = new List<Employee>();

        public WorkHoursReportPanel()
        {
            InitializeComponent();

            if (!AuthService.IsManager())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            populateEmployeeCombos();

            // Wire filter AFTER populate to avoid premature loadGrid()
            combo_filter_employee.SelectedIndexChanged += (s, e) => loadGrid();
            txt_reported_hours.TextChanged += (s, e) => clearBg(txt_reported_hours);
            txt_actual_hours.TextChanged   += (s, e) => clearBg(txt_actual_hours);

            loadGrid();
            dataGridView_work_hours.SelectionChanged += onSelectionChanged;
            setMode_new();
        }

        // =====================================================================
        // Combo population
        // =====================================================================
        private void populateEmployeeCombos()
        {
            combo_employee.Items.Clear();
            _employeeList.Clear();
            combo_employee.Items.Add("--- בחר עובד ---");
            _employeeList.Add(null);

            foreach (Employee emp in Program.Employees)
            {
                combo_employee.Items.Add($"{emp.getEmployeeId()} — {emp.getFullName()}");
                _employeeList.Add(emp);
            }
            combo_employee.SelectedIndex = 0;

            combo_filter_employee.Items.Clear();
            combo_filter_employee.Items.Add("הכל");
            foreach (Employee emp in Program.Employees)
                combo_filter_employee.Items.Add($"{emp.getEmployeeId()} — {emp.getFullName()}");
            combo_filter_employee.SelectedIndex = 0;
        }

        // =====================================================================
        // Grid
        // =====================================================================
        private void loadGrid()
        {
            dataGridView_work_hours.SelectionChanged -= onSelectionChanged;

            DataTable dt = new DataTable();
            dt.Columns.Add("מספר",         typeof(string));
            dt.Columns.Add("עובד",          typeof(string));
            dt.Columns.Add("כניסה",         typeof(string));
            dt.Columns.Add("יציאה",         typeof(string));
            dt.Columns.Add("שעות מדווחות",  typeof(string));
            dt.Columns.Add("שעות בפועל",    typeof(string));
            dt.Columns.Add("חריג",          typeof(string));
            dt.Columns.Add("אושר",          typeof(string));

            string filterEmpId = null;
            int fi = combo_filter_employee.SelectedIndex;
            if (fi > 0 && fi - 1 < Program.Employees.Count)
                filterEmpId = Program.Employees[fi - 1].getEmployeeId();

            var rows = new List<(DateTime sortKey, object[] row)>();
            foreach (WorkHoursReport r in Program.WorkHoursReports)
            {
                if (filterEmpId != null && r.getEmployeeId() != filterEmpId)
                    continue;

                Employee emp = r.getEmployee() ?? Employee.seekEmployee(r.getEmployeeId());
                string empDisplay = emp?.getFullName() ?? r.getEmployeeId();

                rows.Add((r.getCheckIn(), new object[] {
                    r.getWorkHoursReportNumId().ToString(),
                    empDisplay,
                    r.getCheckIn().ToString("dd/MM/yyyy HH:mm"),
                    r.getCheckOut().ToString("dd/MM/yyyy HH:mm"),
                    r.getReportedHours().ToString("F2"),
                    r.getActualHours().ToString("F2"),
                    r.getException()   ? "כן" : "לא",
                    r.getIsApproved()  ? "✓"  : "—"
                }));
            }
            rows.Sort((x, y) => y.sortKey.CompareTo(x.sortKey));
            foreach (var (_, row) in rows) dt.Rows.Add(row);

            dataGridView_work_hours.DataSource = dt;
            dataGridView_work_hours.SelectionChanged += onSelectionChanged;
        }

        private void onSelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_work_hours.SelectedRows.Count == 0) return;
            string idStr = dataGridView_work_hours.SelectedRows[0].Cells[0].Value?.ToString();
            if (!int.TryParse(idStr, out int id)) return;

            WorkHoursReport r = WorkHoursReport.seekWorkHoursReport(id);
            if (r == null) return;

            _selected = r;
            selectInForm(r);
            setMode_edit();
        }

        // =====================================================================
        // Form population
        // =====================================================================
        private void selectInForm(WorkHoursReport r)
        {
            txt_id.Text = r.getWorkHoursReportNumId().ToString();

            combo_employee.SelectedIndex = 0;
            for (int i = 1; i < _employeeList.Count; i++)
            {
                if (_employeeList[i]?.getEmployeeId() == r.getEmployeeId())
                { combo_employee.SelectedIndex = i; break; }
            }

            dtp_check_in.Value       = r.getCheckIn();
            dtp_check_out.Value      = r.getCheckOut();
            txt_reported_hours.Text  = r.getReportedHours().ToString("F2");
            txt_actual_hours.Text    = r.getActualHours().ToString("F2");
            chk_exception.Checked    = r.getException();
            chk_approved.Checked     = r.getIsApproved();
            txt_approval_note.Text   = r.getApprovalNote() ?? "";
        }

        // =====================================================================
        // Mode switching
        // =====================================================================
        private void setMode_new()
        {
            _selected = null;
            txt_id.Text                  = "(אוטומטי)";
            combo_employee.SelectedIndex = 0;
            dtp_check_in.Value           = DateTime.Today.AddHours(8);
            dtp_check_out.Value          = DateTime.Today.AddHours(16);
            txt_reported_hours.Text      = "8.00";
            txt_actual_hours.Text        = "8.00";
            chk_exception.Checked        = false;
            chk_approved.Checked         = false;
            txt_approval_note.Text       = "";

            btn_save.Visible    = true;
            btn_update.Visible  = false;
            btn_delete.Visible  = false;
            btn_approve.Visible = false;

            setFormEnabled(true);
            combo_employee.Enabled = true;
            clearAllHighlights();
            hideError();
            dataGridView_work_hours.ClearSelection();
        }

        private void setMode_edit()
        {
            btn_save.Visible    = false;
            btn_update.Visible  = true;
            btn_delete.Visible  = true;
            btn_approve.Visible = !(_selected?.getIsApproved() ?? true);

            setFormEnabled(true);
            combo_employee.Enabled = false;
            clearAllHighlights();
            hideError();
        }

        private void setFormEnabled(bool enabled)
        {
            dtp_check_in.Enabled          = enabled;
            dtp_check_out.Enabled         = enabled;
            txt_reported_hours.ReadOnly   = !enabled;
            txt_actual_hours.ReadOnly     = !enabled;
            chk_exception.Enabled         = enabled;
            chk_approved.Enabled          = enabled;
            txt_approval_note.ReadOnly    = !enabled;
        }

        // =====================================================================
        // Validation
        // =====================================================================
        private bool validateForm(bool isNew)
        {
            if (isNew && combo_employee.SelectedIndex <= 0)
            { showError("יש לבחור עובד"); return false; }

            if (dtp_check_out.Value <= dtp_check_in.Value)
            { showError("שעת היציאה חייבת להיות מאוחרת משעת הכניסה"); return false; }

            if (!decimal.TryParse(txt_reported_hours.Text.Trim(), out decimal rep) || rep < 0)
            { txt_reported_hours.BackColor = ERR_BG; showError("שעות מדווחות חייבות להיות מספר חיובי"); return false; }

            if (!decimal.TryParse(txt_actual_hours.Text.Trim(), out decimal act) || act < 0)
            { txt_actual_hours.BackColor = ERR_BG; showError("שעות בפועל חייבות להיות מספר חיובי"); return false; }

            return true;
        }

        // =====================================================================
        // Button handlers
        // =====================================================================
        private void btn_new_Click(object sender, EventArgs e)
        {
            dataGridView_work_hours.ClearSelection();
            setMode_new();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            hideError();
            if (!validateForm(true)) return;

            int newId = Program.WorkHoursReports.Count > 0
                ? Program.WorkHoursReports[Program.WorkHoursReports.Count - 1].getWorkHoursReportNumId() + 1
                : 1;

            Employee selEmp   = _employeeList[combo_employee.SelectedIndex];
            decimal  rep      = decimal.Parse(txt_reported_hours.Text.Trim());
            decimal  act      = decimal.Parse(txt_actual_hours.Text.Trim());
            string   note     = txt_approval_note.Text.Trim();

            WorkHoursReport r = new WorkHoursReport(
                newId,
                selEmp.getEmployeeId(),
                dtp_check_in.Value,
                dtp_check_out.Value,
                rep, act,
                chk_exception.Checked,
                chk_approved.Checked,
                string.IsNullOrWhiteSpace(note) ? null : note,
                true);

            selEmp.addWorkHoursReport(r);

            loadGrid();
            setMode_new();
            MessageBox.Show("דוח שעות העבודה נשמר בהצלחה", "שמירה",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            hideError();
            if (_selected == null) return;
            if (!validateForm(false)) return;

            decimal rep  = decimal.Parse(txt_reported_hours.Text.Trim());
            decimal act  = decimal.Parse(txt_actual_hours.Text.Trim());
            string  note = txt_approval_note.Text.Trim();

            _selected.setCheckIn(dtp_check_in.Value);
            _selected.setCheckOut(dtp_check_out.Value);
            _selected.setReportedHours(rep);
            _selected.setActualHours(act);
            _selected.setException(chk_exception.Checked);
            _selected.setIsApproved(chk_approved.Checked);
            _selected.setApprovalNote(string.IsNullOrWhiteSpace(note) ? null : note);
            _selected.updateWorkHoursReport();

            loadGrid();
            selectInForm(_selected);
            setMode_edit();
            MessageBox.Show("דוח שעות העבודה עודכן בהצלחה", "עדכון",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_approve_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;

            var confirm = MessageBox.Show(
                $"לאשר את דוח שעות העבודה #{_selected.getWorkHoursReportNumId()}?",
                "אישור דוח", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            _selected.setIsApproved(true);
            string note = txt_approval_note.Text.Trim();
            if (!string.IsNullOrWhiteSpace(note))
                _selected.setApprovalNote(note);
            _selected.updateWorkHoursReport();

            loadGrid();
            selectInForm(_selected);
            setMode_edit();
            MessageBox.Show("הדוח אושר בהצלחה", "אישור",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;

            var confirm = MessageBox.Show(
                $"האם למחוק דוח שעות עבודה #{_selected.getWorkHoursReportNumId()}?\nפעולה זו אינה ניתנת לביטול.",
                "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            _selected.deleteWorkHoursReport();
            loadGrid();
            setMode_new();
        }

        private void btn_back_Click(object sender, EventArgs e)
            => MainForm.showPanel(new HomePanel());

        // =====================================================================
        // UI helpers
        // =====================================================================
        private void showError(string msg) { label_error.Text = msg; label_error.Visible = true; }
        private void hideError()           { label_error.Visible = false; }
        private void clearBg(System.Windows.Forms.Control c)
            => c.BackColor = System.Drawing.SystemColors.Window;
        private void clearAllHighlights()
        {
            txt_reported_hours.BackColor = System.Drawing.SystemColors.Window;
            txt_actual_hours.BackColor   = System.Drawing.SystemColors.Window;
        }
    }
}
