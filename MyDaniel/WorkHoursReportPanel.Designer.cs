namespace MyDaniel
{
    partial class WorkHoursReportPanel
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label_title               = new System.Windows.Forms.Label();
            // Filter row
            this.label_filter              = new System.Windows.Forms.Label();
            this.combo_filter_employee     = new System.Windows.Forms.ComboBox();
            // Grid
            this.dataGridView_work_hours   = new System.Windows.Forms.DataGridView();
            this.label_form_title          = new System.Windows.Forms.Label();
            // RIGHT column
            this.label_id                  = new System.Windows.Forms.Label();
            this.txt_id                    = new System.Windows.Forms.TextBox();
            this.label_reported            = new System.Windows.Forms.Label();
            this.txt_reported_hours        = new System.Windows.Forms.TextBox();
            this.label_actual              = new System.Windows.Forms.Label();
            this.txt_actual_hours          = new System.Windows.Forms.TextBox();
            this.chk_approved              = new System.Windows.Forms.CheckBox();
            // LEFT column
            this.label_employee            = new System.Windows.Forms.Label();
            this.combo_employee            = new System.Windows.Forms.ComboBox();
            this.label_check_in            = new System.Windows.Forms.Label();
            this.dtp_check_in              = new System.Windows.Forms.DateTimePicker();
            this.label_check_out           = new System.Windows.Forms.Label();
            this.dtp_check_out             = new System.Windows.Forms.DateTimePicker();
            this.chk_exception             = new System.Windows.Forms.CheckBox();
            // Approval note
            this.label_approval_note       = new System.Windows.Forms.Label();
            this.txt_approval_note         = new System.Windows.Forms.TextBox();
            // Error + buttons
            this.label_error               = new System.Windows.Forms.Label();
            this.btn_new                   = new System.Windows.Forms.Button();
            this.btn_save                  = new System.Windows.Forms.Button();
            this.btn_update                = new System.Windows.Forms.Button();
            this.btn_delete                = new System.Windows.Forms.Button();
            this.btn_approve               = new System.Windows.Forms.Button();
            this.btn_back                  = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_work_hours)).BeginInit();
            this.SuspendLayout();
            //
            // label_title
            //
            this.label_title.AutoSize  = false;
            this.label_title.Font      = new System.Drawing.Font("David", 26F, System.Drawing.FontStyle.Bold);
            this.label_title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_title.Location  = new System.Drawing.Point(10, 10);
            this.label_title.Size      = new System.Drawing.Size(975, 44);
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_title.Name      = "label_title";
            this.label_title.TabIndex  = 0;
            this.label_title.Text      = "ניהול דוחות שעות עבודה";
            //
            // ── Filter row (Y=38)
            //
            this.label_filter.AutoSize = true;
            this.label_filter.Font     = new System.Drawing.Font("David", 12F);
            this.label_filter.Location = new System.Drawing.Point(779, 42);
            this.label_filter.Name     = "label_filter";
            this.label_filter.TabIndex = 1;
            this.label_filter.Text     = "סנן לפי עובד:";

            this.combo_filter_employee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_filter_employee.Font          = new System.Drawing.Font("David", 11F);
            this.combo_filter_employee.Location      = new System.Drawing.Point(500, 38);
            this.combo_filter_employee.Name          = "combo_filter_employee";
            this.combo_filter_employee.RightToLeft   = System.Windows.Forms.RightToLeft.Yes;
            this.combo_filter_employee.Size          = new System.Drawing.Size(265, 28);
            this.combo_filter_employee.TabIndex      = 2;
            //
            // dataGridView_work_hours (Y=65, H=148)
            //
            this.dataGridView_work_hours.AllowUserToAddRows          = false;
            this.dataGridView_work_hours.AllowUserToDeleteRows       = false;
            this.dataGridView_work_hours.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_work_hours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_work_hours.Font                        = new System.Drawing.Font("David", 10F);
            this.dataGridView_work_hours.Location                    = new System.Drawing.Point(10, 65);
            this.dataGridView_work_hours.MultiSelect                 = false;
            this.dataGridView_work_hours.Name                        = "dataGridView_work_hours";
            this.dataGridView_work_hours.ReadOnly                    = true;
            this.dataGridView_work_hours.RightToLeft                 = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView_work_hours.RowHeadersWidth             = 40;
            this.dataGridView_work_hours.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_work_hours.Size                        = new System.Drawing.Size(1040, 148);
            this.dataGridView_work_hours.TabIndex                    = 3;
            //
            // label_form_title (Y=223)
            //
            this.label_form_title.AutoSize  = true;
            this.label_form_title.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_form_title.ForeColor = System.Drawing.Color.DimGray;
            this.label_form_title.Location  = new System.Drawing.Point(260, 223);
            this.label_form_title.Name      = "label_form_title";
            this.label_form_title.TabIndex  = 4;
            this.label_form_title.Text      = "פרטי דוח שעות עבודה — הוספה / עריכה";
            //
            // ── RIGHT COLUMN  (label X=727, ctrl X=490 W=225)
            // ── Rows at Y: 248, 288, 328, 370
            //
            this.label_id.AutoSize = true;
            this.label_id.Font     = new System.Drawing.Font("David", 13F);
            this.label_id.Location = new System.Drawing.Point(727, 251);
            this.label_id.Name     = "label_id";
            this.label_id.TabIndex = 10;
            this.label_id.Text     = "מספר דוח";

            this.txt_id.Font      = new System.Drawing.Font("David", 12F);
            this.txt_id.Location  = new System.Drawing.Point(490, 248);
            this.txt_id.Name      = "txt_id";
            this.txt_id.ReadOnly  = true;
            this.txt_id.Size      = new System.Drawing.Size(225, 27);
            this.txt_id.TabIndex  = 11;
            this.txt_id.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);

            this.label_reported.AutoSize = true;
            this.label_reported.Font     = new System.Drawing.Font("David", 13F);
            this.label_reported.Location = new System.Drawing.Point(727, 291);
            this.label_reported.Name     = "label_reported";
            this.label_reported.TabIndex = 12;
            this.label_reported.Text     = "שעות מדווחות";

            this.txt_reported_hours.Font     = new System.Drawing.Font("David", 12F);
            this.txt_reported_hours.Location = new System.Drawing.Point(490, 288);
            this.txt_reported_hours.Name     = "txt_reported_hours";
            this.txt_reported_hours.Size     = new System.Drawing.Size(225, 27);
            this.txt_reported_hours.TabIndex = 13;

            this.label_actual.AutoSize = true;
            this.label_actual.Font     = new System.Drawing.Font("David", 13F);
            this.label_actual.Location = new System.Drawing.Point(727, 331);
            this.label_actual.Name     = "label_actual";
            this.label_actual.TabIndex = 14;
            this.label_actual.Text     = "שעות בפועל";

            this.txt_actual_hours.Font     = new System.Drawing.Font("David", 12F);
            this.txt_actual_hours.Location = new System.Drawing.Point(490, 328);
            this.txt_actual_hours.Name     = "txt_actual_hours";
            this.txt_actual_hours.Size     = new System.Drawing.Size(225, 27);
            this.txt_actual_hours.TabIndex = 15;

            this.chk_approved.AutoSize  = true;
            this.chk_approved.Font      = new System.Drawing.Font("David", 12F);
            this.chk_approved.Location  = new System.Drawing.Point(490, 372);
            this.chk_approved.Name      = "chk_approved";
            this.chk_approved.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk_approved.Size      = new System.Drawing.Size(225, 25);
            this.chk_approved.TabIndex  = 16;
            this.chk_approved.Text      = "הדוח מאושר";
            //
            // ── LEFT COLUMN  (label X=385, ctrl X=75 W=295)
            // ── Rows at Y: 248, 288, 328, 370
            //
            this.label_employee.AutoSize = true;
            this.label_employee.Font     = new System.Drawing.Font("David", 13F);
            this.label_employee.Location = new System.Drawing.Point(385, 251);
            this.label_employee.Name     = "label_employee";
            this.label_employee.TabIndex = 20;
            this.label_employee.Text     = "עובד";

            this.combo_employee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_employee.Font          = new System.Drawing.Font("David", 11F);
            this.combo_employee.Location      = new System.Drawing.Point(75, 248);
            this.combo_employee.Name          = "combo_employee";
            this.combo_employee.RightToLeft   = System.Windows.Forms.RightToLeft.Yes;
            this.combo_employee.Size          = new System.Drawing.Size(295, 28);
            this.combo_employee.TabIndex      = 21;

            this.label_check_in.AutoSize = true;
            this.label_check_in.Font     = new System.Drawing.Font("David", 13F);
            this.label_check_in.Location = new System.Drawing.Point(385, 291);
            this.label_check_in.Name     = "label_check_in";
            this.label_check_in.TabIndex = 22;
            this.label_check_in.Text     = "כניסה";

            this.dtp_check_in.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtp_check_in.Font         = new System.Drawing.Font("David", 12F);
            this.dtp_check_in.Format       = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_check_in.Location     = new System.Drawing.Point(75, 288);
            this.dtp_check_in.Name         = "dtp_check_in";
            this.dtp_check_in.RightToLeft  = System.Windows.Forms.RightToLeft.Yes;
            this.dtp_check_in.Size         = new System.Drawing.Size(295, 27);
            this.dtp_check_in.TabIndex     = 23;

            this.label_check_out.AutoSize = true;
            this.label_check_out.Font     = new System.Drawing.Font("David", 13F);
            this.label_check_out.Location = new System.Drawing.Point(385, 331);
            this.label_check_out.Name     = "label_check_out";
            this.label_check_out.TabIndex = 24;
            this.label_check_out.Text     = "יציאה";

            this.dtp_check_out.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtp_check_out.Font         = new System.Drawing.Font("David", 12F);
            this.dtp_check_out.Format       = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_check_out.Location     = new System.Drawing.Point(75, 328);
            this.dtp_check_out.Name         = "dtp_check_out";
            this.dtp_check_out.RightToLeft  = System.Windows.Forms.RightToLeft.Yes;
            this.dtp_check_out.Size         = new System.Drawing.Size(295, 27);
            this.dtp_check_out.TabIndex     = 25;

            this.chk_exception.AutoSize    = true;
            this.chk_exception.Font        = new System.Drawing.Font("David", 12F);
            this.chk_exception.Location    = new System.Drawing.Point(75, 372);
            this.chk_exception.Name        = "chk_exception";
            this.chk_exception.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk_exception.Size        = new System.Drawing.Size(200, 25);
            this.chk_exception.TabIndex    = 26;
            this.chk_exception.Text        = "דיווח חריג";
            //
            // ── Approval note (Y=405, RIGHT col ctrl X=490)
            //
            this.label_approval_note.AutoSize = true;
            this.label_approval_note.Font     = new System.Drawing.Font("David", 13F);
            this.label_approval_note.Location = new System.Drawing.Point(727, 408);
            this.label_approval_note.Name     = "label_approval_note";
            this.label_approval_note.TabIndex = 30;
            this.label_approval_note.Text     = "הערת אישור";

            this.txt_approval_note.Font        = new System.Drawing.Font("David", 11F);
            this.txt_approval_note.Location    = new System.Drawing.Point(490, 405);
            this.txt_approval_note.Multiline   = true;
            this.txt_approval_note.Name        = "txt_approval_note";
            this.txt_approval_note.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_approval_note.ScrollBars  = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_approval_note.Size        = new System.Drawing.Size(225, 44);
            this.txt_approval_note.TabIndex    = 31;
            //
            // label_error (Y=458)
            //
            this.label_error.AutoSize  = false;
            this.label_error.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_error.ForeColor = System.Drawing.Color.Crimson;
            this.label_error.Location  = new System.Drawing.Point(100, 458);
            this.label_error.Name      = "label_error";
            this.label_error.Size      = new System.Drawing.Size(800, 22);
            this.label_error.TabIndex  = 40;
            this.label_error.Text      = "";
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_error.Visible   = false;
            //
            // ── BUTTONS (Y=486)
            //
            this.btn_new.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_new.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_new.Location  = new System.Drawing.Point(20, 486);
            this.btn_new.Name      = "btn_new";
            this.btn_new.Size      = new System.Drawing.Size(130, 42);
            this.btn_new.TabIndex  = 50;
            this.btn_new.Text      = "דוח חדש";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click    += new System.EventHandler(this.btn_new_Click);

            this.btn_save.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_save.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_save.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location  = new System.Drawing.Point(160, 486);
            this.btn_save.Name      = "btn_save";
            this.btn_save.Size      = new System.Drawing.Size(130, 42);
            this.btn_save.TabIndex  = 51;
            this.btn_save.Text      = "שמור";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click    += new System.EventHandler(this.btn_save_Click);

            this.btn_update.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_update.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_update.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_update.ForeColor = System.Drawing.Color.White;
            this.btn_update.Location  = new System.Drawing.Point(160, 486);
            this.btn_update.Name      = "btn_update";
            this.btn_update.Size      = new System.Drawing.Size(130, 42);
            this.btn_update.TabIndex  = 52;
            this.btn_update.Text      = "עדכן";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Visible   = false;
            this.btn_update.Click    += new System.EventHandler(this.btn_update_Click);

            this.btn_delete.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_delete.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_delete.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_delete.Location  = new System.Drawing.Point(300, 486);
            this.btn_delete.Name      = "btn_delete";
            this.btn_delete.Size      = new System.Drawing.Size(130, 42);
            this.btn_delete.TabIndex  = 53;
            this.btn_delete.Text      = "מחק";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Visible   = false;
            this.btn_delete.Click    += new System.EventHandler(this.btn_delete_Click);

            this.btn_approve.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_approve.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_approve.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_approve.ForeColor = System.Drawing.Color.White;
            this.btn_approve.Location  = new System.Drawing.Point(445, 486);
            this.btn_approve.Name      = "btn_approve";
            this.btn_approve.Size      = new System.Drawing.Size(165, 42);
            this.btn_approve.TabIndex  = 54;
            this.btn_approve.Text      = "אשר דוח";
            this.btn_approve.UseVisualStyleBackColor = false;
            this.btn_approve.Visible   = false;
            this.btn_approve.Click    += new System.EventHandler(this.btn_approve_Click);

            this.btn_back.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location  = new System.Drawing.Point(820, 486);
            this.btn_back.Name      = "btn_back";
            this.btn_back.Size      = new System.Drawing.Size(155, 42);
            this.btn_back.TabIndex  = 55;
            this.btn_back.Text      = "חזרה";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click    += new System.EventHandler(this.btn_back_Click);
            //
            // WorkHoursReportPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.label_filter);
            this.Controls.Add(this.combo_filter_employee);
            this.Controls.Add(this.dataGridView_work_hours);
            this.Controls.Add(this.label_form_title);
            // RIGHT col
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label_reported);
            this.Controls.Add(this.txt_reported_hours);
            this.Controls.Add(this.label_actual);
            this.Controls.Add(this.txt_actual_hours);
            this.Controls.Add(this.chk_approved);
            // LEFT col
            this.Controls.Add(this.label_employee);
            this.Controls.Add(this.combo_employee);
            this.Controls.Add(this.label_check_in);
            this.Controls.Add(this.dtp_check_in);
            this.Controls.Add(this.label_check_out);
            this.Controls.Add(this.dtp_check_out);
            this.Controls.Add(this.chk_exception);
            // Approval note
            this.Controls.Add(this.label_approval_note);
            this.Controls.Add(this.txt_approval_note);
            // Error + buttons
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_approve);
            this.Controls.Add(this.btn_back);
            this.Name = "WorkHoursReportPanel";
            this.Size = new System.Drawing.Size(1000, 540);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_work_hours)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label        label_title;
        private System.Windows.Forms.Label        label_filter;
        private System.Windows.Forms.ComboBox     combo_filter_employee;
        private System.Windows.Forms.DataGridView dataGridView_work_hours;
        private System.Windows.Forms.Label        label_form_title;
        private System.Windows.Forms.Label        label_id;
        private System.Windows.Forms.TextBox      txt_id;
        private System.Windows.Forms.Label        label_reported;
        private System.Windows.Forms.TextBox      txt_reported_hours;
        private System.Windows.Forms.Label        label_actual;
        private System.Windows.Forms.TextBox      txt_actual_hours;
        private System.Windows.Forms.CheckBox     chk_approved;
        private System.Windows.Forms.Label        label_employee;
        private System.Windows.Forms.ComboBox     combo_employee;
        private System.Windows.Forms.Label        label_check_in;
        private System.Windows.Forms.DateTimePicker dtp_check_in;
        private System.Windows.Forms.Label        label_check_out;
        private System.Windows.Forms.DateTimePicker dtp_check_out;
        private System.Windows.Forms.CheckBox     chk_exception;
        private System.Windows.Forms.Label        label_approval_note;
        private System.Windows.Forms.TextBox      txt_approval_note;
        private System.Windows.Forms.Label        label_error;
        private System.Windows.Forms.Button       btn_new;
        private System.Windows.Forms.Button       btn_save;
        private System.Windows.Forms.Button       btn_update;
        private System.Windows.Forms.Button       btn_delete;
        private System.Windows.Forms.Button       btn_approve;
        private System.Windows.Forms.Button       btn_back;
    }
}
