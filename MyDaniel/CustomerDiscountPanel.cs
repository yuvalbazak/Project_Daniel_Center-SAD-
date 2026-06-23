using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MyDaniel
{
    public partial class CustomerDiscountPanel : UserControl
    {
        private static readonly string[] DISCOUNT_TYPES = {
            "חייל", "חד הורי", "משפחה מרובת ילדים", "גמלאי"
        };

        private Customer _self;

        public CustomerDiscountPanel()
        {
            InitializeComponent();

            if (!AuthService.IsCustomer())
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            _self = Customer.seekByEmail(Program.currentUserEmail);
            if (_self == null)
            { this.Load += (s, e) => MainForm.showPanel(new AccessDeniedPanel()); return; }

            combo_type.Items.AddRange(DISCOUNT_TYPES);
            combo_type.SelectedIndex = 0;

            loadGrid();
            dataGridView_requests.SelectionChanged += onSelectionChanged;
        }

        // =====================================================================
        // Grid — shows only this customer's requests
        // =====================================================================
        private void loadGrid()
        {
            dataGridView_requests.SelectionChanged -= onSelectionChanged;

            DataTable dt = new DataTable();
            dt.Columns.Add("מספר",        typeof(string));
            dt.Columns.Add("סוג הנחה",    typeof(string));
            dt.Columns.Add("סטטוס",        typeof(string));
            dt.Columns.Add("תאריך הגשה",  typeof(string));
            dt.Columns.Add("תאריך טיפול", typeof(string));
            dt.Columns.Add("אחוז הנחה",   typeof(string));
            dt.Columns.Add("מסמך",         typeof(string));

            foreach (DiscountRequest dr in _self.getDiscountRequests())
            {
                dt.Rows.Add(
                    dr.getDiscountRequestNumId().ToString(),
                    dr.getDiscountType(),
                    dr.getDiscountStatus(),
                    dr.getSubmittedAt().ToShortDateString(),
                    dr.getResolvedAt()?.ToShortDateString() ?? "—",
                    dr.getDiscountPercent().HasValue
                        ? dr.getDiscountPercent().Value.ToString("F1") + "%" : "—",
                    string.IsNullOrWhiteSpace(dr.getFilePath()) ? "—" : "✓"
                );
            }

            dataGridView_requests.DataSource = dt;
            dataGridView_requests.SelectionChanged += onSelectionChanged;
        }

        private void onSelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_requests.SelectedRows.Count == 0)
            { label_detail.Visible = false; return; }

            string idStr = dataGridView_requests.SelectedRows[0].Cells[0].Value?.ToString();
            if (!int.TryParse(idStr, out int id))
            { label_detail.Visible = false; return; }

            DiscountRequest dr = DiscountRequest.seekDiscountRequest(id);
            if (dr == null) { label_detail.Visible = false; return; }

            string pctText      = dr.getDiscountPercent().HasValue
                                  ? dr.getDiscountPercent().Value.ToString("F1") + "%" : "טרם נקבע";
            string resolvedText = dr.getResolvedAt().HasValue
                                  ? dr.getResolvedAt().Value.ToShortDateString() : "—";
            string docText      = string.IsNullOrWhiteSpace(dr.getFilePath()) ? "לא צורף" : "צורף";

            label_detail.Text    = $"סטטוס: {dr.getDiscountStatus()}  |  הנחה: {pctText}  |  תאריך טיפול: {resolvedText}  |  מסמך: {docText}";
            label_detail.Visible = true;
        }

        // =====================================================================
        // Button handlers
        // =====================================================================
        private void btn_submit_Click(object sender, EventArgs e)
        {
            hideError();

            if (combo_type.SelectedIndex < 0)
            { showError("יש לבחור סוג הנחה"); return; }

            string type     = combo_type.SelectedItem.ToString();
            string filePath = string.IsNullOrWhiteSpace(txt_file.Text) ? null : txt_file.Text.Trim();
            string status   = string.IsNullOrWhiteSpace(filePath) ? "ממתינה לאסמכתאות" : "הוגשה";

            int newId = 1;
            foreach (DiscountRequest dr in Program.DiscountRequests)
                if (dr.getDiscountRequestNumId() >= newId)
                    newId = dr.getDiscountRequestNumId() + 1;

            DiscountRequest newDr = new DiscountRequest(
                newId, _self.getCustomerId(), type, filePath,
                status, null, DateTime.Today, null, true);

            _self.addDiscountRequest(newDr);

            string msg = status == "הוגשה"
                ? "בקשת ההנחה הוגשה בהצלחה! נציג יצור איתך קשר בהמשך."
                : "הבקשה נשמרה — יש לצרף מסמך אסמכתא להשלמת ההגשה.";

            MessageBox.Show(msg, "הגשת בקשת הנחה", MessageBoxButtons.OK, MessageBoxIcon.Information);

            clearForm();
            loadGrid();
            label_detail.Visible = false;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clearForm();
            hideError();
            label_detail.Visible = false;
        }

        private void btn_back_Click(object sender, EventArgs e)
            => MainForm.showPanel(new StudentMenuPanel());

        // =====================================================================
        // Helpers
        // =====================================================================
        private void clearForm()
        {
            combo_type.SelectedIndex = 0;
            txt_file.Text            = "";
            txt_file.BackColor       = System.Drawing.SystemColors.Window;
        }

        private void showError(string msg) { label_error.Text = msg; label_error.Visible = true; }
        private void hideError()           { label_error.Visible = false; }
    }
}
