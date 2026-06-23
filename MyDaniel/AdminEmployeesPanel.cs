using System;
using System.Data;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class AdminEmployeesPanel : UserControl
    {
        private static readonly string[] ROLES = {
            AuthService.ROLE_CENTER_MANAGER,
            AuthService.ROLE_ACCOUNTING_MANAGER,
            AuthService.ROLE_ADMIN_STAFF,
            AuthService.ROLE_COORDINATOR,
            AuthService.ROLE_INSTRUCTOR
        };

        private static readonly System.Drawing.Color ERR_BG =
            System.Drawing.Color.FromArgb(255, 220, 220);

        private Employee _selected    = null;
        private bool     _showArchived = false;

        public AdminEmployeesPanel()
        {
            InitializeComponent();

            if (!AuthService.CanAdminPortalWrite())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            combo_role.Items.AddRange(ROLES);

            txt_search.TextChanged += (s, e) => loadGrid();

            txt_id.TextChanged    += (s, e) => { clearField(txt_id);    hideError(); };
            txt_name.TextChanged  += (s, e) => { clearField(txt_name);  hideError(); };
            txt_phone.TextChanged += (s, e) => { clearField(txt_phone); hideError(); };
            txt_email.TextChanged += (s, e) => { clearField(txt_email); hideError(); };

            dataGridView_employees.SelectionChanged += onGridSelectionChanged;
            loadGrid();
            setMode_new();
        }

        // =====================================================================
        // Archive helpers
        // =====================================================================
        private static bool isArchived(Employee e)
            => e.getRole().StartsWith("ARCH:", StringComparison.Ordinal);

        private static string displayRole(Employee e)
        {
            string r = e.getRole();
            return isArchived(e) ? r.Substring(5) + " (בארכיון)" : r;
        }

        // =====================================================================
        // Grid
        // =====================================================================
        private void loadGrid()
        {
            dataGridView_employees.SelectionChanged -= onGridSelectionChanged;

            string search = txt_search.Text.Trim().ToLower();

            DataTable dt = new DataTable();
            dt.Columns.Add("מ.ז.",              typeof(string));
            dt.Columns.Add("שם מלא",             typeof(string));
            dt.Columns.Add("תפקיד",              typeof(string));
            dt.Columns.Add("תאריך הצטרפות",      typeof(string));
            dt.Columns.Add("טלפון",              typeof(string));
            dt.Columns.Add("אימייל",             typeof(string));

            foreach (Employee e in Program.Employees)
            {
                bool archived = isArchived(e);
                if (!_showArchived && archived) continue;
                if (_showArchived  && !archived) continue;

                if (!string.IsNullOrEmpty(search))
                {
                    bool match = e.getEmployeeId().ToLower().Contains(search)
                              || e.getFullName().ToLower().Contains(search)
                              || e.getEmail().ToLower().Contains(search)
                              || displayRole(e).ToLower().Contains(search);
                    if (!match) continue;
                }

                dt.Rows.Add(
                    e.getEmployeeId(),
                    e.getFullName(),
                    displayRole(e),
                    e.getStartDate().ToString("dd/MM/yyyy"),
                    e.getPhone(),
                    e.getEmail()
                );
            }

            dataGridView_employees.DataSource = dt;
            dataGridView_employees.SelectionChanged += onGridSelectionChanged;
        }

        private void onGridSelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_employees.SelectedRows.Count == 0) return;
            string id = dataGridView_employees.SelectedRows[0].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(id)) return;
            Employee emp = Employee.seekEmployee(id);
            if (emp == null) return;
            _selected = emp;
            populateForm(emp);
            setMode_edit();
        }

        // =====================================================================
        // Form helpers
        // =====================================================================
        private void populateForm(Employee e)
        {
            txt_id.Text    = e.getEmployeeId();
            txt_name.Text  = e.getFullName();
            txt_phone.Text = e.getPhone();
            txt_email.Text = e.getEmail();
            dtp_start.Value = e.getStartDate();

            // Role combo: strip ARCH: prefix if archived
            string role = isArchived(e) ? e.getRole().Substring(5) : e.getRole();
            for (int i = 0; i < combo_role.Items.Count; i++)
                if (combo_role.Items[i].ToString() == role) { combo_role.SelectedIndex = i; break; }

            txt_password.Text = e.getPassword();
        }

        private void clearForm()
        {
            txt_id.Text                = "";
            txt_name.Text              = "";
            txt_phone.Text             = "";
            txt_email.Text             = "";
            combo_role.SelectedIndex   = -1;
            dtp_start.Value            = DateTime.Today;
            txt_password.Text          = "";
        }

        // =====================================================================
        // Mode switching
        // =====================================================================
        private void setMode_new()
        {
            _selected      = null;
            txt_id.Enabled = true;
            txt_id.BackColor = System.Drawing.SystemColors.Window;

            btn_save.Visible    = true;
            btn_update.Visible  = false;
            btn_archive.Visible = false;

            clearForm();
            clearAllHighlights();
            hideError();
            dataGridView_employees.ClearSelection();
        }

        private void setMode_edit()
        {
            txt_id.Enabled   = false;
            txt_id.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);

            btn_save.Visible    = false;
            btn_update.Visible  = true;
            btn_archive.Visible = true;

            bool archived = _selected != null && isArchived(_selected);
            btn_archive.Text      = archived ? "שחזר מארכיון" : "שלח לארכיון";
            btn_archive.BackColor = archived ? System.Drawing.Color.SeaGreen : System.Drawing.Color.Peru;

            clearAllHighlights();
            hideError();
        }

        // =====================================================================
        // Button handlers
        // =====================================================================
        private void btn_toggle_archive_Click(object sender, EventArgs e)
        {
            _showArchived = !_showArchived;
            btn_toggle_archive.Text = _showArchived ? "הצג פעילים" : "הצג ארכיון";
            loadGrid();
            setMode_new();
        }

        private void btn_new_Click(object sender, EventArgs e) => setMode_new();

        private void btn_save_Click(object sender, EventArgs e)
        {
            hideError();
            if (!validateForm(isNew: true)) return;

            string id    = txt_id.Text.Trim();
            string email = txt_email.Text.Trim();
            string pass  = string.IsNullOrWhiteSpace(txt_password.Text)
                           ? Program.generatePassword(email, id)
                           : txt_password.Text.Trim();

            new Employee(id, txt_name.Text.Trim(), combo_role.SelectedItem.ToString(),
                         dtp_start.Value.Date, txt_phone.Text.Trim(), email, pass, true);

            MessageBox.Show($"העובד נוסף בהצלחה!\nסיסמה: {pass}", "הצלחה",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadGrid();
            setMode_new();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            hideError();
            if (_selected == null) return;
            if (!validateForm(isNew: false)) return;

            // Preserve ARCH: prefix if currently archived
            string newRole = combo_role.SelectedItem.ToString();
            if (isArchived(_selected)) newRole = "ARCH:" + newRole;

            _selected.setFullName(txt_name.Text.Trim());
            _selected.setRole(newRole);
            _selected.setPhone(txt_phone.Text.Trim());
            _selected.setEmail(txt_email.Text.Trim());
            _selected.setStartDate(dtp_start.Value.Date);
            if (!string.IsNullOrWhiteSpace(txt_password.Text))
                _selected.setPassword(txt_password.Text.Trim());
            _selected.updateEmployee();

            MessageBox.Show("פרטי העובד עודכנו בהצלחה", "עדכון",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadGrid();
            setMode_new();
        }

        private void btn_archive_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;

            if (isArchived(_selected))
            {
                // Restore
                string originalRole = _selected.getRole().Substring(5);
                _selected.setRole(originalRole);
                _selected.updateEmployee();
                MessageBox.Show($"העובד {_selected.getFullName()} שוחזר בהצלחה", "שחזור",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Archive
                DialogResult confirm = MessageBox.Show(
                    $"האם לשלוח את {_selected.getFullName()} לארכיון?",
                    "אישור ארכיון", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;

                _selected.setRole("ARCH:" + _selected.getRole());
                _selected.updateEmployee();
                MessageBox.Show($"העובד {_selected.getFullName()} נשלח לארכיון", "ארכיון",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            loadGrid();
            setMode_new();
        }

        private void btn_back_Click(object sender, EventArgs e)
            => MainForm.showPanel(new AdminMenuPanel());

        // =====================================================================
        // Validation
        // =====================================================================
        private bool validateForm(bool isNew)
        {
            string id    = txt_id.Text.Trim();
            string name  = txt_name.Text.Trim();
            string phone = txt_phone.Text.Trim();
            string email = txt_email.Text.Trim();

            if (isNew)
            {
                if (string.IsNullOrWhiteSpace(id) || id.Length < 2)
                { highlightField(txt_id); showError("מ.ז. עובד חייב להכיל לפחות 2 תווים"); return false; }
                if (Employee.seekEmployee(id) != null)
                { highlightField(txt_id); showError("מ.ז. עובד זה כבר קיים במערכת"); return false; }
            }

            if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
            { highlightField(txt_name); showError("שם מלא חייב להכיל לפחות 2 תווים"); return false; }

            if (combo_role.SelectedIndex < 0)
            { showError("יש לבחור תפקיד"); return false; }

            if (!isValidPhone(phone))
            { highlightField(txt_phone); showError("טלפון לא תקין — נדרשות לפחות 9 ספרות"); return false; }

            if (!isValidEmail(email))
            { highlightField(txt_email); showError("כתובת אימייל לא תקינה"); return false; }

            Employee empMatch  = Employee.seekByEmail(email);
            Customer custMatch = Customer.seekByEmail(email);
            bool takenByOther  = custMatch != null
                              || (empMatch != null && empMatch != _selected);
            if (takenByOther)
            { highlightField(txt_email); showError("כתובת אימייל זו כבר רשומה במערכת"); return false; }

            return true;
        }

        private bool isValidPhone(string p)
        {
            if (string.IsNullOrWhiteSpace(p)) return false;
            string d = p.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "");
            return d.Length >= 9 && Regex.IsMatch(d, @"^\d+$");
        }

        private bool isValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            try { var a = new MailAddress(email); return a.Address == email; }
            catch { return false; }
        }

        // =====================================================================
        // UI helpers
        // =====================================================================
        private void showError(string msg)  { label_error.Text = msg; label_error.Visible = true; }
        private void hideError()            { label_error.Visible = false; }
        private void highlightField(System.Windows.Forms.Control c) => c.BackColor = ERR_BG;
        private void clearField(System.Windows.Forms.Control c)     => c.BackColor = System.Drawing.SystemColors.Window;
        private void clearAllHighlights()
        {
            clearField(txt_id);
            clearField(txt_name);
            clearField(txt_phone);
            clearField(txt_email);
        }
    }
}
