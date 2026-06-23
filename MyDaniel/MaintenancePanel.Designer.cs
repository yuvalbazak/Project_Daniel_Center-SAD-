namespace MyDaniel
{
    partial class MaintenancePanel
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
            this.label_title              = new System.Windows.Forms.Label();
            // Filter row
            this.label_filter             = new System.Windows.Forms.Label();
            this.combo_filter_boat        = new System.Windows.Forms.ComboBox();
            // Grid
            this.dataGridView_maintenance = new System.Windows.Forms.DataGridView();
            this.label_form_title         = new System.Windows.Forms.Label();
            // RIGHT column
            this.label_id                 = new System.Windows.Forms.Label();
            this.txt_id                   = new System.Windows.Forms.TextBox();
            this.label_boat               = new System.Windows.Forms.Label();
            this.combo_boat               = new System.Windows.Forms.ComboBox();
            this.label_status             = new System.Windows.Forms.Label();
            this.combo_status             = new System.Windows.Forms.ComboBox();
            this.label_technician         = new System.Windows.Forms.Label();
            this.txt_technician           = new System.Windows.Forms.TextBox();
            // LEFT column
            this.label_reported           = new System.Windows.Forms.Label();
            this.dtp_reported             = new System.Windows.Forms.DateTimePicker();
            this.chk_has_resolved         = new System.Windows.Forms.CheckBox();
            this.dtp_resolved             = new System.Windows.Forms.DateTimePicker();
            this.label_cost               = new System.Windows.Forms.Label();
            this.txt_cost                 = new System.Windows.Forms.TextBox();
            // Full-width description
            this.label_desc               = new System.Windows.Forms.Label();
            this.txt_description          = new System.Windows.Forms.TextBox();
            // Error + buttons
            this.label_error              = new System.Windows.Forms.Label();
            this.btn_new                  = new System.Windows.Forms.Button();
            this.btn_save                 = new System.Windows.Forms.Button();
            this.btn_update               = new System.Windows.Forms.Button();
            this.btn_delete               = new System.Windows.Forms.Button();
            this.btn_close_fault          = new System.Windows.Forms.Button();
            this.btn_back                 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_maintenance)).BeginInit();
            this.SuspendLayout();
            //
            // label_title
            //
            this.label_title.AutoSize  = false;
            this.label_title.Font      = new System.Drawing.Font("David", 28F, System.Drawing.FontStyle.Bold);
            this.label_title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_title.Location  = new System.Drawing.Point(10, 8);
            this.label_title.Size      = new System.Drawing.Size(975, 44);
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_title.Name      = "label_title";
            this.label_title.TabIndex  = 0;
            this.label_title.Text      = "ניהול תחזוקה";
            //
            // Filter row (Y=38)
            //
            this.label_filter.AutoSize  = true;
            this.label_filter.Font      = new System.Drawing.Font("David", 11F);
            this.label_filter.Location  = new System.Drawing.Point(775, 41);
            this.label_filter.Name      = "label_filter";
            this.label_filter.TabIndex  = 3;
            this.label_filter.Text      = "סנן לפי סירה:";

            this.combo_filter_boat.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_filter_boat.Font              = new System.Drawing.Font("David", 10F);
            this.combo_filter_boat.FormattingEnabled = true;
            this.combo_filter_boat.Location          = new System.Drawing.Point(560, 38);
            this.combo_filter_boat.Name              = "combo_filter_boat";
            this.combo_filter_boat.Size              = new System.Drawing.Size(205, 24);
            this.combo_filter_boat.TabIndex          = 4;
            //
            // dataGridView_maintenance (Y=65)
            //
            this.dataGridView_maintenance.AllowUserToAddRows          = false;
            this.dataGridView_maintenance.AllowUserToDeleteRows       = false;
            this.dataGridView_maintenance.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_maintenance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_maintenance.Font                        = new System.Drawing.Font("David", 10F);
            this.dataGridView_maintenance.Location                    = new System.Drawing.Point(10, 65);
            this.dataGridView_maintenance.MultiSelect                 = false;
            this.dataGridView_maintenance.Name                        = "dataGridView_maintenance";
            this.dataGridView_maintenance.ReadOnly                    = true;
            this.dataGridView_maintenance.RightToLeft                 = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView_maintenance.RowHeadersWidth             = 40;
            this.dataGridView_maintenance.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_maintenance.Size                        = new System.Drawing.Size(1040, 148);
            this.dataGridView_maintenance.TabIndex                    = 1;
            //
            // label_form_title
            //
            this.label_form_title.AutoSize  = true;
            this.label_form_title.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_form_title.ForeColor = System.Drawing.Color.DimGray;
            this.label_form_title.Location  = new System.Drawing.Point(295, 220);
            this.label_form_title.Name      = "label_form_title";
            this.label_form_title.TabIndex  = 2;
            this.label_form_title.Text      = "פרטי רשומת תחזוקה — הוספה / עריכה";
            //
            // ── RIGHT COLUMN  (label X=725, ctrl X=505 W=210)
            // ── Rows at Y: 236, 276, 316, 356
            //
            this.label_id.AutoSize = true;
            this.label_id.Font     = new System.Drawing.Font("David", 13F);
            this.label_id.Location = new System.Drawing.Point(725, 236);
            this.label_id.Name     = "label_id";
            this.label_id.TabIndex = 10;
            this.label_id.Text     = "מספר רשומה";

            this.txt_id.Font      = new System.Drawing.Font("David", 12F);
            this.txt_id.Location  = new System.Drawing.Point(505, 233);
            this.txt_id.Name      = "txt_id";
            this.txt_id.ReadOnly  = true;
            this.txt_id.Size      = new System.Drawing.Size(210, 27);
            this.txt_id.TabIndex  = 11;
            this.txt_id.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);

            this.label_boat.AutoSize = true;
            this.label_boat.Font     = new System.Drawing.Font("David", 13F);
            this.label_boat.Location = new System.Drawing.Point(725, 276);
            this.label_boat.Name     = "label_boat";
            this.label_boat.TabIndex = 12;
            this.label_boat.Text     = "סירה";

            this.combo_boat.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_boat.Font              = new System.Drawing.Font("David", 11F);
            this.combo_boat.FormattingEnabled = true;
            this.combo_boat.Location          = new System.Drawing.Point(505, 273);
            this.combo_boat.Name              = "combo_boat";
            this.combo_boat.Size              = new System.Drawing.Size(210, 26);
            this.combo_boat.TabIndex          = 13;

            this.label_status.AutoSize = true;
            this.label_status.Font     = new System.Drawing.Font("David", 13F);
            this.label_status.Location = new System.Drawing.Point(725, 316);
            this.label_status.Name     = "label_status";
            this.label_status.TabIndex = 14;
            this.label_status.Text     = "סטטוס";

            this.combo_status.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_status.Font              = new System.Drawing.Font("David", 11F);
            this.combo_status.FormattingEnabled = true;
            this.combo_status.Location          = new System.Drawing.Point(505, 313);
            this.combo_status.Name              = "combo_status";
            this.combo_status.Size              = new System.Drawing.Size(210, 26);
            this.combo_status.TabIndex          = 15;

            this.label_technician.AutoSize = true;
            this.label_technician.Font     = new System.Drawing.Font("David", 13F);
            this.label_technician.Location = new System.Drawing.Point(725, 356);
            this.label_technician.Name     = "label_technician";
            this.label_technician.TabIndex = 16;
            this.label_technician.Text     = "טכנאי";

            this.txt_technician.Font     = new System.Drawing.Font("David", 12F);
            this.txt_technician.Location = new System.Drawing.Point(505, 353);
            this.txt_technician.Name     = "txt_technician";
            this.txt_technician.Size     = new System.Drawing.Size(210, 27);
            this.txt_technician.TabIndex = 17;
            //
            // ── LEFT COLUMN  (label X=385, ctrl X=150 W=220)
            // ── Rows at Y: 236, 276, 316
            //
            this.label_reported.AutoSize = true;
            this.label_reported.Font     = new System.Drawing.Font("David", 13F);
            this.label_reported.Location = new System.Drawing.Point(385, 236);
            this.label_reported.Name     = "label_reported";
            this.label_reported.TabIndex = 20;
            this.label_reported.Text     = "תאריך דיווח";

            this.dtp_reported.Font     = new System.Drawing.Font("David", 11F);
            this.dtp_reported.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_reported.Location = new System.Drawing.Point(150, 233);
            this.dtp_reported.Name     = "dtp_reported";
            this.dtp_reported.Size     = new System.Drawing.Size(220, 26);
            this.dtp_reported.TabIndex = 21;

            this.chk_has_resolved.AutoSize    = true;
            this.chk_has_resolved.Font        = new System.Drawing.Font("David", 12F);
            this.chk_has_resolved.Location    = new System.Drawing.Point(330, 276);
            this.chk_has_resolved.Name        = "chk_has_resolved";
            this.chk_has_resolved.TabIndex    = 22;
            this.chk_has_resolved.Text        = "תאריך סגירה";
            this.chk_has_resolved.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            this.dtp_resolved.Enabled  = false;
            this.dtp_resolved.Font     = new System.Drawing.Font("David", 11F);
            this.dtp_resolved.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_resolved.Location = new System.Drawing.Point(150, 273);
            this.dtp_resolved.Name     = "dtp_resolved";
            this.dtp_resolved.Size     = new System.Drawing.Size(170, 26);
            this.dtp_resolved.TabIndex = 23;

            this.label_cost.AutoSize = true;
            this.label_cost.Font     = new System.Drawing.Font("David", 13F);
            this.label_cost.Location = new System.Drawing.Point(385, 316);
            this.label_cost.Name     = "label_cost";
            this.label_cost.TabIndex = 24;
            this.label_cost.Text     = "עלות (₪)";

            this.txt_cost.Font     = new System.Drawing.Font("David", 12F);
            this.txt_cost.Location = new System.Drawing.Point(150, 313);
            this.txt_cost.Name     = "txt_cost";
            this.txt_cost.Size     = new System.Drawing.Size(170, 27);
            this.txt_cost.TabIndex = 25;
            //
            // ── Full-width description row (Y=392)
            //
            this.label_desc.AutoSize = true;
            this.label_desc.Font     = new System.Drawing.Font("David", 13F);
            this.label_desc.Location = new System.Drawing.Point(725, 395);
            this.label_desc.Name     = "label_desc";
            this.label_desc.TabIndex = 30;
            this.label_desc.Text     = "תיאור התקלה";

            this.txt_description.Font       = new System.Drawing.Font("David", 11F);
            this.txt_description.Location   = new System.Drawing.Point(10, 392);
            this.txt_description.Multiline  = true;
            this.txt_description.Name       = "txt_description";
            this.txt_description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_description.Size       = new System.Drawing.Size(705, 50);
            this.txt_description.TabIndex   = 31;
            //
            // label_error (Y=452)
            //
            this.label_error.AutoSize  = false;
            this.label_error.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_error.ForeColor = System.Drawing.Color.Crimson;
            this.label_error.Location  = new System.Drawing.Point(100, 452);
            this.label_error.Name      = "label_error";
            this.label_error.Size      = new System.Drawing.Size(800, 22);
            this.label_error.TabIndex  = 40;
            this.label_error.Text      = "";
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_error.Visible   = false;
            //
            // ── BUTTONS (Y=480)
            // btn_new X=20 W=130 | btn_save/btn_update X=160 W=130 | btn_delete X=300 W=130
            // btn_close_fault X=445 W=165 | btn_back X=820 W=155
            //
            this.btn_new.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_new.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_new.Location  = new System.Drawing.Point(20, 480);
            this.btn_new.Name      = "btn_new";
            this.btn_new.Size      = new System.Drawing.Size(130, 42);
            this.btn_new.TabIndex  = 50;
            this.btn_new.Text      = "רשומה חדשה";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click    += new System.EventHandler(this.btn_new_Click);

            this.btn_save.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_save.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_save.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location  = new System.Drawing.Point(160, 480);
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
            this.btn_update.Location  = new System.Drawing.Point(160, 480);
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
            this.btn_delete.Location  = new System.Drawing.Point(300, 480);
            this.btn_delete.Name      = "btn_delete";
            this.btn_delete.Size      = new System.Drawing.Size(130, 42);
            this.btn_delete.TabIndex  = 53;
            this.btn_delete.Text      = "מחק";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Visible   = false;
            this.btn_delete.Click    += new System.EventHandler(this.btn_delete_Click);

            this.btn_close_fault.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_close_fault.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_close_fault.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_close_fault.ForeColor = System.Drawing.Color.White;
            this.btn_close_fault.Location  = new System.Drawing.Point(445, 480);
            this.btn_close_fault.Name      = "btn_close_fault";
            this.btn_close_fault.Size      = new System.Drawing.Size(165, 42);
            this.btn_close_fault.TabIndex  = 54;
            this.btn_close_fault.Text      = "סגור תקלה";
            this.btn_close_fault.UseVisualStyleBackColor = false;
            this.btn_close_fault.Visible   = false;
            this.btn_close_fault.Click    += new System.EventHandler(this.btn_close_fault_Click);

            this.btn_back.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location  = new System.Drawing.Point(820, 480);
            this.btn_back.Name      = "btn_back";
            this.btn_back.Size      = new System.Drawing.Size(155, 42);
            this.btn_back.TabIndex  = 55;
            this.btn_back.Text      = "חזרה";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click    += new System.EventHandler(this.btn_back_Click);
            //
            // MaintenancePanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.label_filter);
            this.Controls.Add(this.combo_filter_boat);
            this.Controls.Add(this.dataGridView_maintenance);
            this.Controls.Add(this.label_form_title);
            // RIGHT
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label_boat);
            this.Controls.Add(this.combo_boat);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.combo_status);
            this.Controls.Add(this.label_technician);
            this.Controls.Add(this.txt_technician);
            // LEFT
            this.Controls.Add(this.label_reported);
            this.Controls.Add(this.dtp_reported);
            this.Controls.Add(this.chk_has_resolved);
            this.Controls.Add(this.dtp_resolved);
            this.Controls.Add(this.label_cost);
            this.Controls.Add(this.txt_cost);
            // Description
            this.Controls.Add(this.label_desc);
            this.Controls.Add(this.txt_description);
            // Error + buttons
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_close_fault);
            this.Controls.Add(this.btn_back);
            this.Name = "MaintenancePanel";
            this.Size = new System.Drawing.Size(1000, 560);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_maintenance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label          label_title;
        private System.Windows.Forms.Label          label_filter;
        private System.Windows.Forms.ComboBox       combo_filter_boat;
        private System.Windows.Forms.DataGridView   dataGridView_maintenance;
        private System.Windows.Forms.Label          label_form_title;
        private System.Windows.Forms.Label          label_id;
        private System.Windows.Forms.TextBox        txt_id;
        private System.Windows.Forms.Label          label_boat;
        private System.Windows.Forms.ComboBox       combo_boat;
        private System.Windows.Forms.Label          label_status;
        private System.Windows.Forms.ComboBox       combo_status;
        private System.Windows.Forms.Label          label_technician;
        private System.Windows.Forms.TextBox        txt_technician;
        private System.Windows.Forms.Label          label_reported;
        private System.Windows.Forms.DateTimePicker dtp_reported;
        private System.Windows.Forms.CheckBox       chk_has_resolved;
        private System.Windows.Forms.DateTimePicker dtp_resolved;
        private System.Windows.Forms.Label          label_cost;
        private System.Windows.Forms.TextBox        txt_cost;
        private System.Windows.Forms.Label          label_desc;
        private System.Windows.Forms.TextBox        txt_description;
        private System.Windows.Forms.Label          label_error;
        private System.Windows.Forms.Button         btn_new;
        private System.Windows.Forms.Button         btn_save;
        private System.Windows.Forms.Button         btn_update;
        private System.Windows.Forms.Button         btn_delete;
        private System.Windows.Forms.Button         btn_close_fault;
        private System.Windows.Forms.Button         btn_back;
    }
}
