using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class ManageActivitiesPanel : UserControl
    {
        private static readonly string[] ACTIVITY_TYPES = {
            "Sailing", "Kayaking", "Academic Rowing"
        };
        private static readonly string[] AGE_GROUPS = {
            "Junior", "Youth", "Senior", "Elite"
        };
        private static readonly string[] ACTIVITY_STATUSES = {
            "מתוכנן", "פעיל", "בוטל", "הושלם", "בארכיון"
        };
        private static readonly System.Drawing.Color ERR_BG =
            System.Drawing.Color.FromArgb(255, 220, 220);

        private Activity       _selected       = null;
        private List<Employee> _instructorList = new List<Employee>();
        private bool           _canWrite;

        public ManageActivitiesPanel()
        {
            InitializeComponent();

            if (!AuthService.CanViewActivities())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            _canWrite = AuthService.CanWriteActivities();

            combo_type.Items.AddRange(ACTIVITY_TYPES);
            combo_age_group.Items.AddRange(AGE_GROUPS);
            combo_status.Items.AddRange(ACTIVITY_STATUSES);

            populateInstructorCombo();

            combo_status.SelectedIndexChanged += (s, e) => onStatusChanged();
            txt_location.TextChanged          += (s, e) => clearFieldError(txt_location);
            txt_max.TextChanged               += (s, e) => clearFieldError(txt_max);

            loadGrid();
            dataGridView_activities.SelectionChanged += onGridSelectionChanged;
            setMode_new();
        }

        // =====================================================================
        // Combo population
        // =====================================================================
        private void populateInstructorCombo()
        {
            combo_instructor.Items.Clear();
            _instructorList.Clear();
            combo_instructor.Items.Add("--- לא שויך ---");
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

        // =====================================================================
        // Grid
        // =====================================================================
        private void loadGrid()
        {
            dataGridView_activities.SelectionChanged -= onGridSelectionChanged;

            DataTable dt = new DataTable();
            dt.Columns.Add("מספר",      typeof(string));
            dt.Columns.Add("סוג",       typeof(string));
            dt.Columns.Add("תאריך",     typeof(string));
            dt.Columns.Add("מיקום",     typeof(string));
            dt.Columns.Add("קבוצת גיל", typeof(string));
            dt.Columns.Add("מדריך",     typeof(string));
            dt.Columns.Add("סטטוס",     typeof(string));
            dt.Columns.Add("משתתפים",   typeof(string));

            foreach (Activity a in Program.Activities)
            {
                Employee instr = a.getInstructor();
                int      count = a.getRoster().Count;
                dt.Rows.Add(
                    a.getActivityNumId().ToString(),
                    a.getActivityType(),
                    a.getDateTime().ToString("dd/MM/yyyy HH:mm"),
                    a.getLocation(),
                    a.getAgeGroup(),
                    instr?.getFullName() ?? "לא שויך",
                    a.getActivityStatus(),
                    $"{count} / {a.getMaxParticipants()}"
                );
            }

            dataGridView_activities.DataSource = dt;
            dataGridView_activities.SelectionChanged += onGridSelectionChanged;
        }

        private void onGridSelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_activities.SelectedRows.Count == 0) return;
            string idStr = dataGridView_activities.SelectedRows[0].Cells[0].Value?.ToString();
            if (!int.TryParse(idStr, out int id)) return;
            Activity a = Activity.seekActivity(id);
            if (a == null) return;
            _selected = a;
            selectActivityInForm(a);
            setMode_edit();
        }

        // =====================================================================
        // Form population
        // =====================================================================
        private void selectActivityInForm(Activity a)
        {
            txt_id.Text = a.getActivityNumId().ToString();

            selectInCombo(combo_type, a.getActivityType());
            dtp_datetime.Value = a.getDateTime();
            txt_location.Text  = a.getLocation();
            selectInCombo(combo_age_group, a.getAgeGroup());

            combo_instructor.SelectedIndex = 0;
            if (!string.IsNullOrEmpty(a.getInstructorId()))
            {
                for (int i = 1; i < _instructorList.Count; i++)
                {
                    if (_instructorList[i]?.getEmployeeId() == a.getInstructorId())
                    { combo_instructor.SelectedIndex = i; break; }
                }
            }

            selectInCombo(combo_status, a.getActivityStatus());
            txt_max.Text = a.getMaxParticipants().ToString();
            txt_cancel_reason.Text = a.getCancellationReason() ?? "";

            bool cancelled = a.getActivityStatus() == "בוטל";
            txt_cancel_reason.Visible = cancelled;
            label_cancel_lbl.Visible  = cancelled;

            label_roster_count.Text = $"רשומים: {a.getRoster().Count} / {a.getMaxParticipants()}";
        }

        private void selectInCombo(ComboBox combo, string value)
        {
            for (int i = 0; i < combo.Items.Count; i++)
                if (combo.Items[i].ToString() == value) { combo.SelectedIndex = i; return; }
        }

        private void onStatusChanged()
        {
            bool cancelled = combo_status.SelectedItem?.ToString() == "בוטל";
            txt_cancel_reason.Visible = cancelled;
            label_cancel_lbl.Visible  = cancelled;
        }

        // =====================================================================
        // Mode switching
        // =====================================================================
        private void setMode_new()
        {
            _selected = null;
            btn_cancel_activity.Visible = false;
            txt_id.Text = "(יוגדר אוטומטית)";

            combo_type.SelectedIndex       = -1;
            dtp_datetime.Value             = DateTime.Now;
            txt_location.Text              = "";
            combo_age_group.SelectedIndex  = -1;
            combo_instructor.SelectedIndex = 0;
            combo_status.SelectedIndex     = 0;
            txt_max.Text                   = "10";
            txt_cancel_reason.Text         = "";
            txt_cancel_reason.Visible      = false;
            label_cancel_lbl.Visible       = false;
            label_roster_count.Text        = "רשומים: 0";

            btn_save.Visible   = true;
            btn_update.Visible = false;
            btn_delete.Visible = false;
            btn_roster.Enabled = false;

            setFormEnabled(true);
            clearFieldErrors();
            hideError();
        }

        private void setMode_edit()
        {
            btn_save.Visible   = false;
            btn_update.Visible = true;
            btn_delete.Visible = true;
            btn_roster.Enabled = _canWrite;

            // Cancel Activity button: visible when selected activity is not already cancelled
            btn_cancel_activity.Visible = _canWrite &&
                _selected != null &&
                _selected.getActivityStatus() != "בוטל";

            setFormEnabled(_canWrite);
            clearFieldErrors();
            hideError();
        }

        private void setFormEnabled(bool enabled)
        {
            combo_type.Enabled         = enabled;
            dtp_datetime.Enabled       = enabled;
            txt_location.ReadOnly      = !enabled;
            combo_age_group.Enabled    = enabled;
            combo_instructor.Enabled   = enabled;
            combo_status.Enabled       = enabled;
            txt_max.ReadOnly           = !enabled;
            txt_cancel_reason.ReadOnly = !enabled;
        }

        // =====================================================================
        // Validation
        // =====================================================================
        private bool validateForm(bool isNew)
        {
            bool ok = true;

            if (combo_type.SelectedIndex < 0)
            { showError("יש לבחור סוג פעילות"); ok = false; }

            if (string.IsNullOrWhiteSpace(txt_location.Text))
            {
                txt_location.BackColor = ERR_BG;
                if (ok) showError("יש להזין מיקום");
                ok = false;
            }

            if (combo_age_group.SelectedIndex < 0)
            { if (ok) showError("יש לבחור קבוצת גיל"); ok = false; }

            if (combo_status.SelectedIndex < 0)
            { if (ok) showError("יש לבחור סטטוס"); ok = false; }

            if (!int.TryParse(txt_max.Text.Trim(), out int max) || max <= 0)
            {
                txt_max.BackColor = ERR_BG;
                if (ok) showError("מספר משתתפים מקסימלי חייב להיות מספר חיובי");
                ok = false;
            }

            if (combo_status.SelectedItem?.ToString() == "בוטל" &&
                string.IsNullOrWhiteSpace(txt_cancel_reason.Text))
            {
                txt_cancel_reason.BackColor = ERR_BG;
                if (ok) showError("יש להזין סיבת ביטול עבור פעילות מבוטלת");
                ok = false;
            }

            return ok;
        }

        // =====================================================================
        // Button handlers
        // =====================================================================
        private void btn_new_Click(object sender, EventArgs e)
        {
            dataGridView_activities.ClearSelection();
            setMode_new();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            hideError();
            if (!_canWrite) { showError("אין לך הרשאה ליצור פעילויות"); return; }
            if (!validateForm(true)) return;

            int newId = Program.Activities.Count > 0
                ? Program.Activities[Program.Activities.Count - 1].getActivityNumId() + 1
                : 1;

            Employee selInstr = _instructorList[combo_instructor.SelectedIndex];
            string   status   = combo_status.SelectedItem.ToString();
            int.TryParse(txt_max.Text.Trim(), out int max);
            string cancelReason = (status == "בוטל" && !string.IsNullOrWhiteSpace(txt_cancel_reason.Text))
                ? txt_cancel_reason.Text.Trim() : null;

            new Activity(newId,
                combo_type.SelectedItem.ToString(),
                dtp_datetime.Value,
                txt_location.Text.Trim(),
                combo_age_group.SelectedItem.ToString(),
                selInstr?.getEmployeeId(), null,
                status, max, cancelReason, true);

            loadGrid();
            setMode_new();
            MessageBox.Show("הפעילות נשמרה בהצלחה", "שמירה",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            hideError();
            if (!_canWrite) { showError("אין לך הרשאה לעדכן פעילויות"); return; }
            if (_selected == null) return;
            if (!validateForm(false)) return;

            string prevStatus = _selected.getActivityStatus();

            Employee selInstr = _instructorList[combo_instructor.SelectedIndex];
            string   status   = combo_status.SelectedItem.ToString();
            int.TryParse(txt_max.Text.Trim(), out int max);
            string cancelReason = (status == "בוטל" && !string.IsNullOrWhiteSpace(txt_cancel_reason.Text))
                ? txt_cancel_reason.Text.Trim() : null;

            _selected.setActivityType(combo_type.SelectedItem.ToString());
            _selected.setDateTime(dtp_datetime.Value);
            _selected.setLocation(txt_location.Text.Trim());
            _selected.setAgeGroup(combo_age_group.SelectedItem.ToString());
            _selected.setInstructorId(selInstr?.getEmployeeId());
            // Boat is managed per-participant; preserve the existing activity-level boat value
            _selected.setActivityStatus(status);
            _selected.setMaxParticipants(max);
            _selected.setCancellationReason(cancelReason);
            _selected.updateActivity();

            if (prevStatus != "בוטל" && status == "בוטל")
                notifyParticipants(_selected);

            loadGrid();
            selectActivityInForm(_selected);
            MessageBox.Show("הפעילות עודכנה בהצלחה", "עדכון",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (!_canWrite) { showError("אין לך הרשאה להעביר פעילויות לארכיון"); return; }
            if (_selected == null) return;

            var confirm = MessageBox.Show(
                "האם אתה בטוח שברצונך להעביר רשומה זו לארכיון?",
                "אישור העברה לארכיון", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            _selected.setActivityStatus("בארכיון");
            _selected.updateActivity();
            loadGrid();
            setMode_new();
            MessageBox.Show("הרשומה הועברה לארכיון בהצלחה", "ארכיון",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_roster_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;
            MainForm.showPanel(new ManageRosterPanel(_selected));
        }

        private void btn_cancel_activity_Click(object sender, EventArgs e)
        {
            hideError();
            if (!_canWrite) { showError("אין לך הרשאה לבטל פעילויות"); return; }
            if (_selected == null) return;
            if (_selected.getActivityStatus() == "בוטל")
            { showError("הפעילות כבר מבוטלת"); return; }

            // Ensure the cancellation reason field is visible and filled
            txt_cancel_reason.Visible = true;
            label_cancel_lbl.Visible  = true;

            string reason = txt_cancel_reason.Text.Trim();
            if (string.IsNullOrWhiteSpace(reason))
            {
                txt_cancel_reason.BackColor = System.Drawing.Color.FromArgb(255, 220, 220);
                showError("יש להזין סיבת ביטול בשדה 'סיבת ביטול' לפני ביטול הפעילות");
                return;
            }

            var confirm = MessageBox.Show(
                $"האם לבטל את פעילות #{_selected.getActivityNumId()} — {_selected.getActivityType()}?\nסיבה: {reason}",
                "אישור ביטול פעילות", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            _selected.setCancellationReason(reason);
            _selected.setActivityStatus("בוטל");
            _selected.updateActivity();

            notifyParticipants(_selected);

            loadGrid();
            selectActivityInForm(_selected);
            setMode_edit();
            MessageBox.Show("הפעילות בוטלה בהצלחה והמשתתפים קיבלו הודעה", "ביטול פעילות",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_back_Click(object sender, EventArgs e)
            => MainForm.showPanel(new HomePanel());

        // =====================================================================
        // Notification simulation
        // =====================================================================
        private void notifyParticipants(Activity a)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine($"הפעילות #{a.getActivityNumId()} — {a.getActivityType()} בוטלה.");
            sb.AppendLine($"סיבה: {a.getCancellationReason()}");
            sb.AppendLine();
            int count = a.getRoster().Count;
            if (count == 0)
                sb.AppendLine("אין משתתפים רשומים לפעילות זו.");
            else
            {
                sb.AppendLine($"הודעה נשלחה ל-{count} משתתפים:");
                foreach (ActivityCustomer ac in a.getRoster())
                {
                    Customer c = ac.getCustomer() ?? Customer.seekCustomer(ac.getCustomerId());
                    sb.AppendLine($"  • {c?.getFullName() ?? ac.getCustomerId()}");
                }
            }
            MessageBox.Show(sb.ToString(), "הודעת ביטול — סימולציה",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =====================================================================
        // UI helpers
        // =====================================================================
        private void showError(string msg)  { label_error.Text = msg; label_error.Visible = true; }
        private void hideError()            { label_error.Visible = false; }
        private void clearFieldError(Control c) { c.BackColor = System.Drawing.SystemColors.Window; }
        private void clearFieldErrors()
        {
            txt_location.BackColor      = System.Drawing.SystemColors.Window;
            txt_max.BackColor           = System.Drawing.SystemColors.Window;
            txt_cancel_reason.BackColor = System.Drawing.SystemColors.Window;
        }
    }
}
