namespace MyDaniel
{
    partial class AttendanceReportPanel
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
            this.label_title        = new System.Windows.Forms.Label();
            // Activity selection bar
            this.label_act_lbl      = new System.Windows.Forms.Label();
            this.combo_activities   = new System.Windows.Forms.ComboBox();
            this.btn_load           = new System.Windows.Forms.Button();
            // Attendance grid
            this.label_grid_header  = new System.Windows.Forms.Label();
            this.dataGridView_attendance = new System.Windows.Forms.DataGridView();
            // Form section
            this.label_form_title   = new System.Windows.Forms.Label();
            // Right column
            this.label_cust         = new System.Windows.Forms.Label();
            this.combo_customer     = new System.Windows.Forms.ComboBox();
            this.label_status       = new System.Windows.Forms.Label();
            this.combo_status       = new System.Windows.Forms.ComboBox();
            // Left column
            this.label_notes        = new System.Windows.Forms.Label();
            this.txt_notes          = new System.Windows.Forms.TextBox();
            // Error + buttons
            this.label_error        = new System.Windows.Forms.Label();
            this.btn_save           = new System.Windows.Forms.Button();
            this.btn_clear          = new System.Windows.Forms.Button();
            this.btn_exceptional    = new System.Windows.Forms.Button();
            this.btn_back           = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_attendance)).BeginInit();
            this.SuspendLayout();
            //
            // label_title
            //
            this.label_title.AutoSize  = false;
            this.label_title.Font      = new System.Drawing.Font("David", 26F, System.Drawing.FontStyle.Bold);
            this.label_title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_title.Location  = new System.Drawing.Point(10, 12);
            this.label_title.Size      = new System.Drawing.Size(975, 44);
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_title.Name      = "label_title";
            this.label_title.TabIndex  = 0;
            this.label_title.Text      = "דוח נוכחות תלמידים";
            //
            // ── Activity selector bar (Y=55) ──────────────────────────────────
            //
            // label_act_lbl
            //
            this.label_act_lbl.AutoSize = true;
            this.label_act_lbl.Font     = new System.Drawing.Font("David", 12F);
            this.label_act_lbl.Location = new System.Drawing.Point(790, 60);
            this.label_act_lbl.Name     = "label_act_lbl";
            this.label_act_lbl.TabIndex = 1;
            this.label_act_lbl.Text     = "פעילות:";
            //
            // combo_activities
            //
            this.combo_activities.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_activities.Font              = new System.Drawing.Font("David", 11F);
            this.combo_activities.FormattingEnabled = true;
            this.combo_activities.Location          = new System.Drawing.Point(470, 57);
            this.combo_activities.Name              = "combo_activities";
            this.combo_activities.Size              = new System.Drawing.Size(310, 26);
            this.combo_activities.TabIndex          = 2;
            //
            // btn_load
            //
            this.btn_load.BackColor = System.Drawing.Color.DimGray;
            this.btn_load.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_load.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.btn_load.ForeColor = System.Drawing.Color.White;
            this.btn_load.Location  = new System.Drawing.Point(355, 55);
            this.btn_load.Name      = "btn_load";
            this.btn_load.Size      = new System.Drawing.Size(105, 30);
            this.btn_load.TabIndex  = 3;
            this.btn_load.Text      = "טען נוכחות";
            this.btn_load.UseVisualStyleBackColor = false;
            this.btn_load.Click    += new System.EventHandler(this.btn_load_Click);
            //
            // ── Attendance grid (Y=92) ────────────────────────────────────────
            //
            // label_grid_header
            //
            this.label_grid_header.AutoSize  = true;
            this.label_grid_header.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_grid_header.ForeColor = System.Drawing.Color.DimGray;
            this.label_grid_header.Location  = new System.Drawing.Point(10, 93);
            this.label_grid_header.Name      = "label_grid_header";
            this.label_grid_header.TabIndex  = 4;
            this.label_grid_header.Text      = "טען פעילות כדי לראות את רשימת הנוכחות";
            //
            // dataGridView_attendance
            //
            this.dataGridView_attendance.AllowUserToAddRows          = false;
            this.dataGridView_attendance.AllowUserToDeleteRows       = false;
            this.dataGridView_attendance.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_attendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_attendance.Font                        = new System.Drawing.Font("David", 10F);
            this.dataGridView_attendance.Location                    = new System.Drawing.Point(10, 113);
            this.dataGridView_attendance.MultiSelect                 = false;
            this.dataGridView_attendance.Name                        = "dataGridView_attendance";
            this.dataGridView_attendance.ReadOnly                    = true;
            this.dataGridView_attendance.RightToLeft                 = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView_attendance.RowHeadersWidth             = 40;
            this.dataGridView_attendance.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_attendance.Size                        = new System.Drawing.Size(1040, 170);
            this.dataGridView_attendance.TabIndex                    = 5;
            //
            // ── Form section (Y=293) ──────────────────────────────────────────
            //
            // label_form_title
            //
            this.label_form_title.AutoSize  = true;
            this.label_form_title.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_form_title.ForeColor = System.Drawing.Color.DimGray;
            this.label_form_title.Location  = new System.Drawing.Point(310, 293);
            this.label_form_title.Name      = "label_form_title";
            this.label_form_title.TabIndex  = 6;
            this.label_form_title.Text      = "הוספה / עדכון נוכחות תלמיד";
            //
            // ── RIGHT col (label X=740, ctrl X=490, W=240): Y=320, 360
            //
            // label_cust
            //
            this.label_cust.AutoSize = true;
            this.label_cust.Font     = new System.Drawing.Font("David", 13F);
            this.label_cust.Location = new System.Drawing.Point(740, 320);
            this.label_cust.Name     = "label_cust";
            this.label_cust.TabIndex = 7;
            this.label_cust.Text     = "תלמיד";
            //
            // combo_customer
            //
            this.combo_customer.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_customer.Font              = new System.Drawing.Font("David", 11F);
            this.combo_customer.FormattingEnabled = true;
            this.combo_customer.Location          = new System.Drawing.Point(490, 317);
            this.combo_customer.Name              = "combo_customer";
            this.combo_customer.Size              = new System.Drawing.Size(240, 26);
            this.combo_customer.TabIndex          = 8;
            //
            // label_status
            //
            this.label_status.AutoSize = true;
            this.label_status.Font     = new System.Drawing.Font("David", 13F);
            this.label_status.Location = new System.Drawing.Point(740, 360);
            this.label_status.Name     = "label_status";
            this.label_status.TabIndex = 9;
            this.label_status.Text     = "סטטוס נוכחות";
            //
            // combo_status
            //
            this.combo_status.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_status.Font              = new System.Drawing.Font("David", 11F);
            this.combo_status.FormattingEnabled = true;
            this.combo_status.Location          = new System.Drawing.Point(490, 357);
            this.combo_status.Name              = "combo_status";
            this.combo_status.Size              = new System.Drawing.Size(240, 26);
            this.combo_status.TabIndex          = 10;
            //
            // ── LEFT col (label X=365, ctrl X=75, W=280): notes spans Y=320-380
            //
            // label_notes
            //
            this.label_notes.AutoSize = true;
            this.label_notes.Font     = new System.Drawing.Font("David", 13F);
            this.label_notes.Location = new System.Drawing.Point(365, 320);
            this.label_notes.Name     = "label_notes";
            this.label_notes.TabIndex = 11;
            this.label_notes.Text     = "הערות";
            //
            // txt_notes
            //
            this.txt_notes.Font       = new System.Drawing.Font("David", 11F);
            this.txt_notes.Location   = new System.Drawing.Point(75, 317);
            this.txt_notes.Multiline  = true;
            this.txt_notes.Name       = "txt_notes";
            this.txt_notes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_notes.Size       = new System.Drawing.Size(278, 65);
            this.txt_notes.TabIndex   = 12;
            //
            // label_error
            //
            this.label_error.AutoSize  = false;
            this.label_error.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_error.ForeColor = System.Drawing.Color.Crimson;
            this.label_error.Location  = new System.Drawing.Point(100, 396);
            this.label_error.Name      = "label_error";
            this.label_error.Size      = new System.Drawing.Size(800, 22);
            this.label_error.TabIndex  = 30;
            this.label_error.Text      = "";
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_error.Visible   = false;
            //
            // ── Buttons (Y=428) ───────────────────────────────────────────────
            //
            // btn_save
            //
            this.btn_save.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_save.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_save.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location  = new System.Drawing.Point(100, 428);
            this.btn_save.Name      = "btn_save";
            this.btn_save.Size      = new System.Drawing.Size(175, 42);
            this.btn_save.TabIndex  = 20;
            this.btn_save.Text      = "שמור נוכחות";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click    += new System.EventHandler(this.btn_save_Click);
            //
            // btn_clear
            //
            this.btn_clear.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_clear.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_clear.Location  = new System.Drawing.Point(295, 428);
            this.btn_clear.Name      = "btn_clear";
            this.btn_clear.Size      = new System.Drawing.Size(145, 42);
            this.btn_clear.TabIndex  = 21;
            this.btn_clear.Text      = "נקה טופס";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click    += new System.EventHandler(this.btn_clear_Click);
            //
            // btn_exceptional
            //
            this.btn_exceptional.BackColor = System.Drawing.Color.Tomato;
            this.btn_exceptional.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_exceptional.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_exceptional.ForeColor = System.Drawing.Color.White;
            this.btn_exceptional.Location  = new System.Drawing.Point(455, 428);
            this.btn_exceptional.Name      = "btn_exceptional";
            this.btn_exceptional.Size      = new System.Drawing.Size(250, 42);
            this.btn_exceptional.TabIndex  = 23;
            this.btn_exceptional.Text      = "דיווח אירוע חריג";
            this.btn_exceptional.UseVisualStyleBackColor = false;
            this.btn_exceptional.Click    += new System.EventHandler(this.btn_exceptional_Click);
            //
            // btn_back
            //
            this.btn_back.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location  = new System.Drawing.Point(820, 428);
            this.btn_back.Name      = "btn_back";
            this.btn_back.Size      = new System.Drawing.Size(155, 42);
            this.btn_back.TabIndex  = 22;
            this.btn_back.Text      = "חזרה לתפריט";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click    += new System.EventHandler(this.btn_back_Click);
            //
            // AttendanceReportPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_exceptional);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.txt_notes);
            this.Controls.Add(this.label_notes);
            this.Controls.Add(this.combo_status);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.combo_customer);
            this.Controls.Add(this.label_cust);
            this.Controls.Add(this.label_form_title);
            this.Controls.Add(this.dataGridView_attendance);
            this.Controls.Add(this.label_grid_header);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.combo_activities);
            this.Controls.Add(this.label_act_lbl);
            this.Controls.Add(this.label_title);
            this.Name = "AttendanceReportPanel";
            this.Size = new System.Drawing.Size(1000, 620);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_attendance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label        label_title;
        private System.Windows.Forms.Label        label_act_lbl;
        private System.Windows.Forms.ComboBox     combo_activities;
        private System.Windows.Forms.Button       btn_load;
        private System.Windows.Forms.Label        label_grid_header;
        private System.Windows.Forms.DataGridView dataGridView_attendance;
        private System.Windows.Forms.Label        label_form_title;
        private System.Windows.Forms.Label        label_cust;
        private System.Windows.Forms.ComboBox     combo_customer;
        private System.Windows.Forms.Label        label_status;
        private System.Windows.Forms.ComboBox     combo_status;
        private System.Windows.Forms.Label        label_notes;
        private System.Windows.Forms.TextBox      txt_notes;
        private System.Windows.Forms.Label        label_error;
        private System.Windows.Forms.Button       btn_save;
        private System.Windows.Forms.Button       btn_clear;
        private System.Windows.Forms.Button       btn_exceptional;
        private System.Windows.Forms.Button       btn_back;
    }
}
