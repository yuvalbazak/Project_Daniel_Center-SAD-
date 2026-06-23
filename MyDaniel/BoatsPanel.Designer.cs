namespace MyDaniel
{
    partial class BoatsPanel
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
            this.dataGridView_boats       = new System.Windows.Forms.DataGridView();
            this.label_form_title         = new System.Windows.Forms.Label();
            // Right column
            this.label_id                 = new System.Windows.Forms.Label();
            this.txt_id                   = new System.Windows.Forms.TextBox();
            this.label_type               = new System.Windows.Forms.Label();
            this.combo_type               = new System.Windows.Forms.ComboBox();
            this.label_name               = new System.Windows.Forms.Label();
            this.txt_name                 = new System.Windows.Forms.TextBox();
            this.label_status             = new System.Windows.Forms.Label();
            this.combo_status             = new System.Windows.Forms.ComboBox();
            // Left column
            this.label_purchase           = new System.Windows.Forms.Label();
            this.dtp_purchase             = new System.Windows.Forms.DateTimePicker();
            this.label_license            = new System.Windows.Forms.Label();
            this.dtp_license              = new System.Windows.Forms.DateTimePicker();
            this.label_maint_date         = new System.Windows.Forms.Label();
            this.dtp_maint_date           = new System.Windows.Forms.DateTimePicker();
            this.label_source             = new System.Windows.Forms.Label();
            this.combo_source             = new System.Windows.Forms.ComboBox();
            // Error label
            this.label_error              = new System.Windows.Forms.Label();
            // Maintenance section
            this.label_maint_header       = new System.Windows.Forms.Label();
            this.btn_report_fault         = new System.Windows.Forms.Button();
            this.dataGridView_maintenance = new System.Windows.Forms.DataGridView();
            // Buttons
            this.btn_new                  = new System.Windows.Forms.Button();
            this.btn_save                 = new System.Windows.Forms.Button();
            this.btn_update               = new System.Windows.Forms.Button();
            this.btn_delete               = new System.Windows.Forms.Button();
            this.btn_back                 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_boats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_maintenance)).BeginInit();
            this.SuspendLayout();
            //
            // label_title
            //
            this.label_title.AutoSize  = false;
            this.label_title.Font      = new System.Drawing.Font("David", 28F, System.Drawing.FontStyle.Bold);
            this.label_title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_title.Location  = new System.Drawing.Point(10, 12);
            this.label_title.Size      = new System.Drawing.Size(1040, 44);
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_title.Name      = "label_title";
            this.label_title.TabIndex  = 0;
            this.label_title.Text      = "ניהול סירות";
            //
            // dataGridView_boats
            //
            this.dataGridView_boats.AllowUserToAddRows           = false;
            this.dataGridView_boats.AllowUserToDeleteRows        = false;
            this.dataGridView_boats.AutoSizeColumnsMode          = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_boats.ColumnHeadersHeightSizeMode  = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_boats.Font                         = new System.Drawing.Font("David", 10F);
            this.dataGridView_boats.Location                     = new System.Drawing.Point(10, 55);
            this.dataGridView_boats.MultiSelect                  = false;
            this.dataGridView_boats.Name                         = "dataGridView_boats";
            this.dataGridView_boats.ReadOnly                     = true;
            this.dataGridView_boats.RightToLeft                  = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView_boats.RowHeadersWidth              = 40;
            this.dataGridView_boats.SelectionMode                = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_boats.Size                         = new System.Drawing.Size(1040, 165);
            this.dataGridView_boats.TabIndex                     = 1;
            this.dataGridView_boats.SelectionChanged            += new System.EventHandler(this.dataGridView_boats_SelectionChanged);
            //
            // label_form_title
            //
            this.label_form_title.AutoSize  = true;
            this.label_form_title.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_form_title.ForeColor = System.Drawing.Color.DimGray;
            this.label_form_title.Location  = new System.Drawing.Point(310, 218);
            this.label_form_title.Name      = "label_form_title";
            this.label_form_title.TabIndex  = 2;
            this.label_form_title.Text      = "פרטי סירה — הוספה / עריכה";
            //
            // ── RIGHT COLUMN  (label X=725, control X=505, W=210)
            // ── Y: 234, 274, 314, 354
            //
            // label_id
            //
            this.label_id.AutoSize = true;
            this.label_id.Font     = new System.Drawing.Font("David", 13F);
            this.label_id.Location = new System.Drawing.Point(725, 234);
            this.label_id.Name     = "label_id";
            this.label_id.TabIndex = 3;
            this.label_id.Text     = "מספר סירה";
            //
            // txt_id
            //
            this.txt_id.Font     = new System.Drawing.Font("David", 12F);
            this.txt_id.Location = new System.Drawing.Point(505, 231);
            this.txt_id.Name     = "txt_id";
            this.txt_id.Size     = new System.Drawing.Size(210, 27);
            this.txt_id.TabIndex = 4;
            //
            // label_type
            //
            this.label_type.AutoSize = true;
            this.label_type.Font     = new System.Drawing.Font("David", 13F);
            this.label_type.Location = new System.Drawing.Point(725, 274);
            this.label_type.Name     = "label_type";
            this.label_type.TabIndex = 5;
            this.label_type.Text     = "סוג סירה";
            //
            // combo_type
            //
            this.combo_type.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_type.Font              = new System.Drawing.Font("David", 11F);
            this.combo_type.FormattingEnabled = true;
            this.combo_type.Location          = new System.Drawing.Point(505, 271);
            this.combo_type.Name              = "combo_type";
            this.combo_type.Size              = new System.Drawing.Size(210, 26);
            this.combo_type.TabIndex          = 6;
            //
            // label_name
            //
            this.label_name.AutoSize = true;
            this.label_name.Font     = new System.Drawing.Font("David", 13F);
            this.label_name.Location = new System.Drawing.Point(725, 314);
            this.label_name.Name     = "label_name";
            this.label_name.TabIndex = 7;
            this.label_name.Text     = "שם כלי השיט";
            //
            // txt_name
            //
            this.txt_name.Font     = new System.Drawing.Font("David", 12F);
            this.txt_name.Location = new System.Drawing.Point(505, 311);
            this.txt_name.Name     = "txt_name";
            this.txt_name.Size     = new System.Drawing.Size(210, 27);
            this.txt_name.TabIndex = 8;
            //
            // label_status
            //
            this.label_status.AutoSize = true;
            this.label_status.Font     = new System.Drawing.Font("David", 13F);
            this.label_status.Location = new System.Drawing.Point(725, 354);
            this.label_status.Name     = "label_status";
            this.label_status.TabIndex = 9;
            this.label_status.Text     = "סטטוס";
            //
            // combo_status
            //
            this.combo_status.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_status.Font              = new System.Drawing.Font("David", 11F);
            this.combo_status.FormattingEnabled = true;
            this.combo_status.Location          = new System.Drawing.Point(505, 351);
            this.combo_status.Name              = "combo_status";
            this.combo_status.Size              = new System.Drawing.Size(210, 26);
            this.combo_status.TabIndex          = 10;
            //
            // ── LEFT COLUMN  (label X=385, control X=150, W=220)
            // ── Y: 234, 274, 314, 354
            //
            // label_purchase
            //
            this.label_purchase.AutoSize = true;
            this.label_purchase.Font     = new System.Drawing.Font("David", 13F);
            this.label_purchase.Location = new System.Drawing.Point(385, 234);
            this.label_purchase.Name     = "label_purchase";
            this.label_purchase.TabIndex = 11;
            this.label_purchase.Text     = "תאריך רכישה";
            //
            // dtp_purchase
            //
            this.dtp_purchase.Font     = new System.Drawing.Font("David", 11F);
            this.dtp_purchase.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_purchase.Location = new System.Drawing.Point(150, 231);
            this.dtp_purchase.Name     = "dtp_purchase";
            this.dtp_purchase.Size     = new System.Drawing.Size(220, 26);
            this.dtp_purchase.TabIndex = 12;
            //
            // label_license
            //
            this.label_license.AutoSize = true;
            this.label_license.Font     = new System.Drawing.Font("David", 13F);
            this.label_license.Location = new System.Drawing.Point(385, 274);
            this.label_license.Name     = "label_license";
            this.label_license.TabIndex = 13;
            this.label_license.Text     = "תאריך רישיון";
            //
            // dtp_license
            //
            this.dtp_license.Font     = new System.Drawing.Font("David", 11F);
            this.dtp_license.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_license.Location = new System.Drawing.Point(150, 271);
            this.dtp_license.Name     = "dtp_license";
            this.dtp_license.Size     = new System.Drawing.Size(220, 26);
            this.dtp_license.TabIndex = 14;
            //
            // label_maint_date
            //
            this.label_maint_date.AutoSize = true;
            this.label_maint_date.Font     = new System.Drawing.Font("David", 13F);
            this.label_maint_date.Location = new System.Drawing.Point(385, 314);
            this.label_maint_date.Name     = "label_maint_date";
            this.label_maint_date.TabIndex = 15;
            this.label_maint_date.Text     = "תחזוקה שנתית";
            //
            // dtp_maint_date
            //
            this.dtp_maint_date.Font     = new System.Drawing.Font("David", 11F);
            this.dtp_maint_date.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_maint_date.Location = new System.Drawing.Point(150, 311);
            this.dtp_maint_date.Name     = "dtp_maint_date";
            this.dtp_maint_date.Size     = new System.Drawing.Size(220, 26);
            this.dtp_maint_date.TabIndex = 16;
            //
            // label_source
            //
            this.label_source.AutoSize = true;
            this.label_source.Font     = new System.Drawing.Font("David", 13F);
            this.label_source.Location = new System.Drawing.Point(385, 354);
            this.label_source.Name     = "label_source";
            this.label_source.TabIndex = 17;
            this.label_source.Text     = "מקור";
            //
            // combo_source
            //
            this.combo_source.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_source.Font              = new System.Drawing.Font("David", 11F);
            this.combo_source.FormattingEnabled = true;
            this.combo_source.Location          = new System.Drawing.Point(150, 351);
            this.combo_source.Name              = "combo_source";
            this.combo_source.Size              = new System.Drawing.Size(220, 26);
            this.combo_source.TabIndex          = 18;
            //
            // label_error
            //
            this.label_error.AutoSize  = false;
            this.label_error.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_error.ForeColor = System.Drawing.Color.Crimson;
            this.label_error.Location  = new System.Drawing.Point(100, 393);
            this.label_error.Name      = "label_error";
            this.label_error.Size      = new System.Drawing.Size(800, 22);
            this.label_error.TabIndex  = 40;
            this.label_error.Text      = "";
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_error.Visible   = false;
            //
            // label_maint_header
            //
            this.label_maint_header.AutoSize  = true;
            this.label_maint_header.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_maint_header.ForeColor = System.Drawing.Color.DimGray;
            this.label_maint_header.Location  = new System.Drawing.Point(10, 420);
            this.label_maint_header.Name      = "label_maint_header";
            this.label_maint_header.TabIndex  = 41;
            this.label_maint_header.Text      = "היסטוריית תחזוקה לסירה שנבחרה";
            this.label_maint_header.Visible   = true;
            //
            // btn_report_fault
            //
            this.btn_report_fault.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_report_fault.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_report_fault.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.btn_report_fault.ForeColor = System.Drawing.Color.White;
            this.btn_report_fault.Location  = new System.Drawing.Point(805, 414);
            this.btn_report_fault.Name      = "btn_report_fault";
            this.btn_report_fault.Size      = new System.Drawing.Size(165, 30);
            this.btn_report_fault.TabIndex  = 42;
            this.btn_report_fault.Text      = "דיווח תקלה";
            this.btn_report_fault.UseVisualStyleBackColor = false;
            this.btn_report_fault.Visible   = false;
            this.btn_report_fault.Click    += new System.EventHandler(this.btn_report_fault_Click);
            //
            // dataGridView_maintenance
            //
            this.dataGridView_maintenance.AllowUserToAddRows          = false;
            this.dataGridView_maintenance.AllowUserToDeleteRows       = false;
            this.dataGridView_maintenance.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_maintenance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_maintenance.Font                        = new System.Drawing.Font("David", 10F);
            this.dataGridView_maintenance.Location                    = new System.Drawing.Point(10, 448);
            this.dataGridView_maintenance.MultiSelect                 = false;
            this.dataGridView_maintenance.Name                        = "dataGridView_maintenance";
            this.dataGridView_maintenance.ReadOnly                    = true;
            this.dataGridView_maintenance.RightToLeft                 = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView_maintenance.RowHeadersWidth             = 40;
            this.dataGridView_maintenance.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_maintenance.Size                        = new System.Drawing.Size(1040, 80);
            this.dataGridView_maintenance.TabIndex                    = 43;
            this.dataGridView_maintenance.Visible                     = true;
            //
            // ── BUTTONS  (Y=525)
            //
            // btn_new
            //
            this.btn_new.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_new.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_new.Location  = new System.Drawing.Point(20, 535);
            this.btn_new.Name      = "btn_new";
            this.btn_new.Size      = new System.Drawing.Size(145, 42);
            this.btn_new.TabIndex  = 20;
            this.btn_new.Text      = "סירה חדשה";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click    += new System.EventHandler(this.btn_new_Click);
            //
            // btn_save  (visible in new mode)
            //
            this.btn_save.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_save.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_save.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location  = new System.Drawing.Point(180, 535);
            this.btn_save.Name      = "btn_save";
            this.btn_save.Size      = new System.Drawing.Size(145, 42);
            this.btn_save.TabIndex  = 21;
            this.btn_save.Text      = "שמור";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Visible   = true;
            this.btn_save.Click    += new System.EventHandler(this.btn_save_Click);
            //
            // btn_update  (same position as btn_save; visible in edit mode)
            //
            this.btn_update.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_update.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_update.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_update.ForeColor = System.Drawing.Color.White;
            this.btn_update.Location  = new System.Drawing.Point(180, 535);
            this.btn_update.Name      = "btn_update";
            this.btn_update.Size      = new System.Drawing.Size(145, 42);
            this.btn_update.TabIndex  = 22;
            this.btn_update.Text      = "עדכן";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Visible   = false;
            this.btn_update.Click    += new System.EventHandler(this.btn_update_Click);
            //
            // btn_delete  (visible in edit mode)
            //
            this.btn_delete.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_delete.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_delete.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_delete.Location  = new System.Drawing.Point(350, 535);
            this.btn_delete.Name      = "btn_delete";
            this.btn_delete.Size      = new System.Drawing.Size(145, 42);
            this.btn_delete.TabIndex  = 23;
            this.btn_delete.Text      = "מחק";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Visible   = false;
            this.btn_delete.Click    += new System.EventHandler(this.btn_delete_Click);
            //
            // btn_back
            //
            this.btn_back.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location  = new System.Drawing.Point(820, 535);
            this.btn_back.Name      = "btn_back";
            this.btn_back.Size      = new System.Drawing.Size(155, 42);
            this.btn_back.TabIndex  = 24;
            this.btn_back.Text      = "חזרה";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click    += new System.EventHandler(this.btn_back_Click);
            //
            // BoatsPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = ThemeHelper.BG_CONTENT;
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.dataGridView_maintenance);
            this.Controls.Add(this.btn_report_fault);
            this.Controls.Add(this.label_maint_header);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.combo_source);
            this.Controls.Add(this.label_source);
            this.Controls.Add(this.dtp_maint_date);
            this.Controls.Add(this.label_maint_date);
            this.Controls.Add(this.dtp_license);
            this.Controls.Add(this.label_license);
            this.Controls.Add(this.dtp_purchase);
            this.Controls.Add(this.label_purchase);
            this.Controls.Add(this.combo_status);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.combo_type);
            this.Controls.Add(this.label_type);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.label_form_title);
            this.Controls.Add(this.dataGridView_boats);
            this.Controls.Add(this.label_title);
            this.Name = "BoatsPanel";
            this.Size = new System.Drawing.Size(1000, 620);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_boats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_maintenance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label            label_title;
        private System.Windows.Forms.DataGridView     dataGridView_boats;
        private System.Windows.Forms.Label            label_form_title;
        private System.Windows.Forms.Label            label_id;
        private System.Windows.Forms.TextBox          txt_id;
        private System.Windows.Forms.Label            label_type;
        private System.Windows.Forms.ComboBox         combo_type;
        private System.Windows.Forms.Label            label_name;
        private System.Windows.Forms.TextBox          txt_name;
        private System.Windows.Forms.Label            label_status;
        private System.Windows.Forms.ComboBox         combo_status;
        private System.Windows.Forms.Label            label_purchase;
        private System.Windows.Forms.DateTimePicker   dtp_purchase;
        private System.Windows.Forms.Label            label_license;
        private System.Windows.Forms.DateTimePicker   dtp_license;
        private System.Windows.Forms.Label            label_maint_date;
        private System.Windows.Forms.DateTimePicker   dtp_maint_date;
        private System.Windows.Forms.Label            label_source;
        private System.Windows.Forms.ComboBox         combo_source;
        private System.Windows.Forms.Label            label_error;
        private System.Windows.Forms.Label            label_maint_header;
        private System.Windows.Forms.Button           btn_report_fault;
        private System.Windows.Forms.DataGridView     dataGridView_maintenance;
        private System.Windows.Forms.Button           btn_new;
        private System.Windows.Forms.Button           btn_save;
        private System.Windows.Forms.Button           btn_update;
        private System.Windows.Forms.Button           btn_delete;
        private System.Windows.Forms.Button           btn_back;
    }
}
