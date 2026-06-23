namespace MyDaniel
{
    partial class ExceptionalEventPanel
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
            this.label_title            = new System.Windows.Forms.Label();
            this.dataGridView_events    = new System.Windows.Forms.DataGridView();
            this.label_form_title       = new System.Windows.Forms.Label();
            // RIGHT col controls
            this.label_event_activity   = new System.Windows.Forms.Label();
            this.combo_event_activity   = new System.Windows.Forms.ComboBox();
            this.label_event_customer   = new System.Windows.Forms.Label();
            this.combo_event_customer   = new System.Windows.Forms.ComboBox();
            this.label_severity         = new System.Windows.Forms.Label();
            this.combo_severity         = new System.Windows.Forms.ComboBox();
            // LEFT col controls
            this.label_event_datetime   = new System.Windows.Forms.Label();
            this.dtp_event_datetime     = new System.Windows.Forms.DateTimePicker();
            this.label_event_type       = new System.Windows.Forms.Label();
            this.combo_event_type       = new System.Windows.Forms.ComboBox();
            this.label_follow_up        = new System.Windows.Forms.Label();
            this.combo_follow_up        = new System.Windows.Forms.ComboBox();
            // Description row
            this.label_desc             = new System.Windows.Forms.Label();
            this.txt_description        = new System.Windows.Forms.TextBox();
            // Error + buttons
            this.label_error            = new System.Windows.Forms.Label();
            this.btn_save               = new System.Windows.Forms.Button();
            this.btn_clear              = new System.Windows.Forms.Button();
            this.btn_back               = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_events)).BeginInit();
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
            this.label_title.Text      = "דוח אירועים חריגים";
            //
            // dataGridView_events
            //
            this.dataGridView_events.AllowUserToAddRows          = false;
            this.dataGridView_events.AllowUserToDeleteRows       = false;
            this.dataGridView_events.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_events.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_events.Font                        = new System.Drawing.Font("David", 9F);
            this.dataGridView_events.Location                    = new System.Drawing.Point(10, 55);
            this.dataGridView_events.MultiSelect                 = false;
            this.dataGridView_events.Name                        = "dataGridView_events";
            this.dataGridView_events.ReadOnly                    = true;
            this.dataGridView_events.RightToLeft                 = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView_events.RowHeadersWidth             = 40;
            this.dataGridView_events.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_events.Size                        = new System.Drawing.Size(1040, 145);
            this.dataGridView_events.TabIndex                    = 1;
            //
            // label_form_title
            //
            this.label_form_title.AutoSize  = true;
            this.label_form_title.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_form_title.ForeColor = System.Drawing.Color.DimGray;
            this.label_form_title.Location  = new System.Drawing.Point(330, 210);
            this.label_form_title.Name      = "label_form_title";
            this.label_form_title.TabIndex  = 2;
            this.label_form_title.Text      = "הוספת אירוע חריג חדש";
            //
            // ── RIGHT col (lbl X=740, ctrl X=490, W=240): Y=235, 275, 315
            //
            // label_event_activity
            //
            this.label_event_activity.AutoSize = true;
            this.label_event_activity.Font     = new System.Drawing.Font("David", 12F);
            this.label_event_activity.Location = new System.Drawing.Point(740, 237);
            this.label_event_activity.Name     = "label_event_activity";
            this.label_event_activity.TabIndex = 3;
            this.label_event_activity.Text     = "פעילות";
            //
            // combo_event_activity
            //
            this.combo_event_activity.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_event_activity.Font              = new System.Drawing.Font("David", 10F);
            this.combo_event_activity.FormattingEnabled = true;
            this.combo_event_activity.Location          = new System.Drawing.Point(490, 234);
            this.combo_event_activity.Name              = "combo_event_activity";
            this.combo_event_activity.Size              = new System.Drawing.Size(240, 25);
            this.combo_event_activity.TabIndex          = 4;
            //
            // label_event_customer
            //
            this.label_event_customer.AutoSize = true;
            this.label_event_customer.Font     = new System.Drawing.Font("David", 12F);
            this.label_event_customer.Location = new System.Drawing.Point(740, 274);
            this.label_event_customer.Name     = "label_event_customer";
            this.label_event_customer.TabIndex = 5;
            this.label_event_customer.Text     = "תלמיד (אם רלוונטי)";
            //
            // combo_event_customer
            //
            this.combo_event_customer.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_event_customer.Font              = new System.Drawing.Font("David", 10F);
            this.combo_event_customer.FormattingEnabled = true;
            this.combo_event_customer.Location          = new System.Drawing.Point(490, 271);
            this.combo_event_customer.Name              = "combo_event_customer";
            this.combo_event_customer.Size              = new System.Drawing.Size(240, 25);
            this.combo_event_customer.TabIndex          = 6;
            //
            // label_severity
            //
            this.label_severity.AutoSize = true;
            this.label_severity.Font     = new System.Drawing.Font("David", 12F);
            this.label_severity.Location = new System.Drawing.Point(740, 314);
            this.label_severity.Name     = "label_severity";
            this.label_severity.TabIndex = 7;
            this.label_severity.Text     = "חומרה";
            //
            // combo_severity
            //
            this.combo_severity.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_severity.Font              = new System.Drawing.Font("David", 10F);
            this.combo_severity.FormattingEnabled = true;
            this.combo_severity.Location          = new System.Drawing.Point(490, 311);
            this.combo_severity.Name              = "combo_severity";
            this.combo_severity.Size              = new System.Drawing.Size(240, 25);
            this.combo_severity.TabIndex          = 8;
            //
            // ── LEFT col (lbl X=375, ctrl X=120, W=240): Y=235, 275, 315
            //
            // label_event_datetime
            //
            this.label_event_datetime.AutoSize = true;
            this.label_event_datetime.Font     = new System.Drawing.Font("David", 12F);
            this.label_event_datetime.Location = new System.Drawing.Point(375, 237);
            this.label_event_datetime.Name     = "label_event_datetime";
            this.label_event_datetime.TabIndex = 9;
            this.label_event_datetime.Text     = "תאריך ושעה";
            //
            // dtp_event_datetime
            //
            this.dtp_event_datetime.Font         = new System.Drawing.Font("David", 10F);
            this.dtp_event_datetime.Format       = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_event_datetime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtp_event_datetime.ShowUpDown   = true;
            this.dtp_event_datetime.Location     = new System.Drawing.Point(120, 234);
            this.dtp_event_datetime.Name         = "dtp_event_datetime";
            this.dtp_event_datetime.Size         = new System.Drawing.Size(240, 25);
            this.dtp_event_datetime.TabIndex     = 10;
            //
            // label_event_type
            //
            this.label_event_type.AutoSize = true;
            this.label_event_type.Font     = new System.Drawing.Font("David", 12F);
            this.label_event_type.Location = new System.Drawing.Point(375, 274);
            this.label_event_type.Name     = "label_event_type";
            this.label_event_type.TabIndex = 11;
            this.label_event_type.Text     = "סוג אירוע";
            //
            // combo_event_type
            //
            this.combo_event_type.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_event_type.Font              = new System.Drawing.Font("David", 10F);
            this.combo_event_type.FormattingEnabled = true;
            this.combo_event_type.Location          = new System.Drawing.Point(120, 271);
            this.combo_event_type.Name              = "combo_event_type";
            this.combo_event_type.Size              = new System.Drawing.Size(240, 25);
            this.combo_event_type.TabIndex          = 12;
            //
            // label_follow_up
            //
            this.label_follow_up.AutoSize = true;
            this.label_follow_up.Font     = new System.Drawing.Font("David", 12F);
            this.label_follow_up.Location = new System.Drawing.Point(375, 314);
            this.label_follow_up.Name     = "label_follow_up";
            this.label_follow_up.TabIndex = 13;
            this.label_follow_up.Text     = "מעקב נדרש";
            //
            // combo_follow_up
            //
            this.combo_follow_up.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_follow_up.Font              = new System.Drawing.Font("David", 10F);
            this.combo_follow_up.FormattingEnabled = true;
            this.combo_follow_up.Location          = new System.Drawing.Point(120, 311);
            this.combo_follow_up.Name              = "combo_follow_up";
            this.combo_follow_up.Size              = new System.Drawing.Size(240, 25);
            this.combo_follow_up.TabIndex          = 14;
            //
            // ── Description row (Y=350) ───────────────────────────────────────
            //
            // label_desc
            //
            this.label_desc.AutoSize  = false;
            this.label_desc.Font      = new System.Drawing.Font("David", 12F);
            this.label_desc.Location  = new System.Drawing.Point(730, 358);
            this.label_desc.Size      = new System.Drawing.Size(145, 24);
            this.label_desc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_desc.Name      = "label_desc";
            this.label_desc.TabIndex  = 15;
            this.label_desc.Text      = "תיאור האירוע";
            //
            // txt_description
            //
            this.txt_description.Font       = new System.Drawing.Font("David", 11F);
            this.txt_description.Location   = new System.Drawing.Point(100, 352);
            this.txt_description.Multiline  = true;
            this.txt_description.Name       = "txt_description";
            this.txt_description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_description.Size       = new System.Drawing.Size(620, 60);
            this.txt_description.TabIndex   = 16;
            //
            // label_error
            //
            this.label_error.AutoSize  = false;
            this.label_error.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_error.ForeColor = System.Drawing.Color.Crimson;
            this.label_error.Location  = new System.Drawing.Point(100, 422);
            this.label_error.Name      = "label_error";
            this.label_error.Size      = new System.Drawing.Size(800, 22);
            this.label_error.TabIndex  = 30;
            this.label_error.Text      = "";
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_error.Visible   = false;
            //
            // btn_save
            //
            this.btn_save.BackColor = System.Drawing.Color.Tomato;
            this.btn_save.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_save.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location  = new System.Drawing.Point(100, 453);
            this.btn_save.Name      = "btn_save";
            this.btn_save.Size      = new System.Drawing.Size(165, 42);
            this.btn_save.TabIndex  = 20;
            this.btn_save.Text      = "שמור דוח";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click    += new System.EventHandler(this.btn_save_Click);
            //
            // btn_clear
            //
            this.btn_clear.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_clear.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_clear.Location  = new System.Drawing.Point(285, 453);
            this.btn_clear.Name      = "btn_clear";
            this.btn_clear.Size      = new System.Drawing.Size(145, 42);
            this.btn_clear.TabIndex  = 21;
            this.btn_clear.Text      = "נקה טופס";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click    += new System.EventHandler(this.btn_clear_Click);
            //
            // btn_back
            //
            this.btn_back.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location  = new System.Drawing.Point(820, 453);
            this.btn_back.Name      = "btn_back";
            this.btn_back.Size      = new System.Drawing.Size(155, 42);
            this.btn_back.TabIndex  = 22;
            this.btn_back.Text      = "חזרה לתפריט";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click    += new System.EventHandler(this.btn_back_Click);
            //
            // ExceptionalEventPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.txt_description);
            this.Controls.Add(this.label_desc);
            this.Controls.Add(this.combo_follow_up);
            this.Controls.Add(this.label_follow_up);
            this.Controls.Add(this.combo_event_type);
            this.Controls.Add(this.label_event_type);
            this.Controls.Add(this.dtp_event_datetime);
            this.Controls.Add(this.label_event_datetime);
            this.Controls.Add(this.combo_severity);
            this.Controls.Add(this.label_severity);
            this.Controls.Add(this.combo_event_customer);
            this.Controls.Add(this.label_event_customer);
            this.Controls.Add(this.combo_event_activity);
            this.Controls.Add(this.label_event_activity);
            this.Controls.Add(this.label_form_title);
            this.Controls.Add(this.dataGridView_events);
            this.Controls.Add(this.label_title);
            this.Name = "ExceptionalEventPanel";
            this.Size = new System.Drawing.Size(1000, 620);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_events)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label        label_title;
        private System.Windows.Forms.DataGridView dataGridView_events;
        private System.Windows.Forms.Label        label_form_title;
        private System.Windows.Forms.Label        label_event_activity;
        private System.Windows.Forms.ComboBox     combo_event_activity;
        private System.Windows.Forms.Label        label_event_customer;
        private System.Windows.Forms.ComboBox     combo_event_customer;
        private System.Windows.Forms.Label        label_severity;
        private System.Windows.Forms.ComboBox     combo_severity;
        private System.Windows.Forms.Label        label_event_datetime;
        private System.Windows.Forms.DateTimePicker dtp_event_datetime;
        private System.Windows.Forms.Label        label_event_type;
        private System.Windows.Forms.ComboBox     combo_event_type;
        private System.Windows.Forms.Label        label_follow_up;
        private System.Windows.Forms.ComboBox     combo_follow_up;
        private System.Windows.Forms.Label        label_desc;
        private System.Windows.Forms.TextBox      txt_description;
        private System.Windows.Forms.Label        label_error;
        private System.Windows.Forms.Button       btn_save;
        private System.Windows.Forms.Button       btn_clear;
        private System.Windows.Forms.Button       btn_back;
    }
}
