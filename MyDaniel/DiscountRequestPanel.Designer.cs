namespace MyDaniel
{
    partial class DiscountRequestPanel
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
            this.label_title          = new System.Windows.Forms.Label();
            this.dataGridView_discounts = new System.Windows.Forms.DataGridView();
            this.label_form_title     = new System.Windows.Forms.Label();
            // RIGHT column
            this.label_id             = new System.Windows.Forms.Label();
            this.txt_id               = new System.Windows.Forms.TextBox();
            this.label_customer       = new System.Windows.Forms.Label();
            this.combo_customer       = new System.Windows.Forms.ComboBox();
            this.label_type           = new System.Windows.Forms.Label();
            this.combo_type           = new System.Windows.Forms.ComboBox();
            this.label_status         = new System.Windows.Forms.Label();
            this.combo_status         = new System.Windows.Forms.ComboBox();
            // LEFT column
            this.label_submitted      = new System.Windows.Forms.Label();
            this.dtp_submitted        = new System.Windows.Forms.DateTimePicker();
            this.chk_has_resolved     = new System.Windows.Forms.CheckBox();
            this.dtp_resolved         = new System.Windows.Forms.DateTimePicker();
            this.label_percent        = new System.Windows.Forms.Label();
            this.txt_percent          = new System.Windows.Forms.TextBox();
            this.label_file_path      = new System.Windows.Forms.Label();
            this.txt_file_path        = new System.Windows.Forms.TextBox();
            // Error + buttons
            this.label_error          = new System.Windows.Forms.Label();
            this.btn_new              = new System.Windows.Forms.Button();
            this.btn_save             = new System.Windows.Forms.Button();
            this.btn_update           = new System.Windows.Forms.Button();
            this.btn_delete           = new System.Windows.Forms.Button();
            this.btn_approve          = new System.Windows.Forms.Button();
            this.btn_reject           = new System.Windows.Forms.Button();
            this.btn_back             = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_discounts)).BeginInit();
            this.SuspendLayout();
            //
            // label_title
            //
            this.label_title.AutoSize  = false;
            this.label_title.Font      = new System.Drawing.Font("David", 28F, System.Drawing.FontStyle.Bold);
            this.label_title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_title.Location  = new System.Drawing.Point(10, 12);
            this.label_title.Size      = new System.Drawing.Size(975, 44);
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_title.Name      = "label_title";
            this.label_title.TabIndex  = 0;
            this.label_title.Text      = "ניהול בקשות הנחה";
            //
            // dataGridView_discounts  (Y=55, H=155 — same as BoatsPanel)
            //
            this.dataGridView_discounts.AllowUserToAddRows          = false;
            this.dataGridView_discounts.AllowUserToDeleteRows       = false;
            this.dataGridView_discounts.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_discounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_discounts.Font                        = new System.Drawing.Font("David", 10F);
            this.dataGridView_discounts.Location                    = new System.Drawing.Point(10, 55);
            this.dataGridView_discounts.MultiSelect                 = false;
            this.dataGridView_discounts.Name                        = "dataGridView_discounts";
            this.dataGridView_discounts.ReadOnly                    = true;
            this.dataGridView_discounts.RightToLeft                 = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView_discounts.RowHeadersWidth             = 40;
            this.dataGridView_discounts.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_discounts.Size                        = new System.Drawing.Size(1040, 155);
            this.dataGridView_discounts.TabIndex                    = 1;
            //
            // label_form_title  (Y=218 — same as BoatsPanel)
            //
            this.label_form_title.AutoSize  = true;
            this.label_form_title.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_form_title.ForeColor = System.Drawing.Color.DimGray;
            this.label_form_title.Location  = new System.Drawing.Point(280, 218);
            this.label_form_title.Name      = "label_form_title";
            this.label_form_title.TabIndex  = 2;
            this.label_form_title.Text      = "פרטי בקשת הנחה — הוספה / עריכה";
            //
            // ── RIGHT COLUMN  (label X=725, ctrl X=505, W=210)
            // ── Rows at Y: 234, 274, 314, 354  — identical to BoatsPanel
            //
            this.label_id.AutoSize = true;
            this.label_id.Font     = new System.Drawing.Font("David", 13F);
            this.label_id.Location = new System.Drawing.Point(725, 234);
            this.label_id.Name     = "label_id";
            this.label_id.TabIndex = 3;
            this.label_id.Text     = "מספר בקשה";

            this.txt_id.Font      = new System.Drawing.Font("David", 12F);
            this.txt_id.Location  = new System.Drawing.Point(505, 231);
            this.txt_id.Name      = "txt_id";
            this.txt_id.ReadOnly  = true;
            this.txt_id.Size      = new System.Drawing.Size(210, 27);
            this.txt_id.TabIndex  = 4;
            this.txt_id.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);

            this.label_customer.AutoSize = true;
            this.label_customer.Font     = new System.Drawing.Font("David", 13F);
            this.label_customer.Location = new System.Drawing.Point(725, 274);
            this.label_customer.Name     = "label_customer";
            this.label_customer.TabIndex = 5;
            this.label_customer.Text     = "לקוח";

            this.combo_customer.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_customer.Font              = new System.Drawing.Font("David", 11F);
            this.combo_customer.FormattingEnabled = true;
            this.combo_customer.Location          = new System.Drawing.Point(505, 271);
            this.combo_customer.Name              = "combo_customer";
            this.combo_customer.RightToLeft       = System.Windows.Forms.RightToLeft.Yes;
            this.combo_customer.Size              = new System.Drawing.Size(210, 26);
            this.combo_customer.TabIndex          = 6;

            this.label_type.AutoSize = true;
            this.label_type.Font     = new System.Drawing.Font("David", 13F);
            this.label_type.Location = new System.Drawing.Point(725, 314);
            this.label_type.Name     = "label_type";
            this.label_type.TabIndex = 7;
            this.label_type.Text     = "סוג הנחה";

            this.combo_type.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_type.Font              = new System.Drawing.Font("David", 11F);
            this.combo_type.FormattingEnabled = true;
            this.combo_type.Location          = new System.Drawing.Point(505, 311);
            this.combo_type.Name              = "combo_type";
            this.combo_type.RightToLeft       = System.Windows.Forms.RightToLeft.Yes;
            this.combo_type.Size              = new System.Drawing.Size(210, 26);
            this.combo_type.TabIndex          = 8;

            this.label_status.AutoSize = true;
            this.label_status.Font     = new System.Drawing.Font("David", 13F);
            this.label_status.Location = new System.Drawing.Point(725, 354);
            this.label_status.Name     = "label_status";
            this.label_status.TabIndex = 9;
            this.label_status.Text     = "סטטוס";

            this.combo_status.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_status.Font              = new System.Drawing.Font("David", 11F);
            this.combo_status.FormattingEnabled = true;
            this.combo_status.Location          = new System.Drawing.Point(505, 351);
            this.combo_status.Name              = "combo_status";
            this.combo_status.RightToLeft       = System.Windows.Forms.RightToLeft.Yes;
            this.combo_status.Size              = new System.Drawing.Size(210, 26);
            this.combo_status.TabIndex          = 10;
            //
            // ── LEFT COLUMN  (label X=385, ctrl X=150, W=220)
            // ── Rows at Y: 234, 274, 314, 354  — identical to BoatsPanel
            //
            this.label_submitted.AutoSize = true;
            this.label_submitted.Font     = new System.Drawing.Font("David", 13F);
            this.label_submitted.Location = new System.Drawing.Point(385, 234);
            this.label_submitted.Name     = "label_submitted";
            this.label_submitted.TabIndex = 11;
            this.label_submitted.Text     = "תאריך הגשה";

            this.dtp_submitted.Font     = new System.Drawing.Font("David", 11F);
            this.dtp_submitted.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_submitted.Location = new System.Drawing.Point(150, 231);
            this.dtp_submitted.Name     = "dtp_submitted";
            this.dtp_submitted.Size     = new System.Drawing.Size(220, 26);
            this.dtp_submitted.TabIndex = 12;

            // Row Y=274: checkbox (label+toggle) + conditional date picker
            this.chk_has_resolved.AutoSize    = true;
            this.chk_has_resolved.Font        = new System.Drawing.Font("David", 12F);
            this.chk_has_resolved.Location    = new System.Drawing.Point(325, 276);
            this.chk_has_resolved.Name        = "chk_has_resolved";
            this.chk_has_resolved.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk_has_resolved.TabIndex    = 13;
            this.chk_has_resolved.Text        = "תאריך טיפול";

            this.dtp_resolved.Enabled  = false;
            this.dtp_resolved.Font     = new System.Drawing.Font("David", 11F);
            this.dtp_resolved.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_resolved.Location = new System.Drawing.Point(150, 273);
            this.dtp_resolved.Name     = "dtp_resolved";
            this.dtp_resolved.Size     = new System.Drawing.Size(168, 26);
            this.dtp_resolved.TabIndex = 14;

            this.label_percent.AutoSize = true;
            this.label_percent.Font     = new System.Drawing.Font("David", 13F);
            this.label_percent.Location = new System.Drawing.Point(385, 314);
            this.label_percent.Name     = "label_percent";
            this.label_percent.TabIndex = 15;
            this.label_percent.Text     = "אחוז הנחה (%)";

            this.txt_percent.Font     = new System.Drawing.Font("David", 12F);
            this.txt_percent.Location = new System.Drawing.Point(150, 311);
            this.txt_percent.Name     = "txt_percent";
            this.txt_percent.Size     = new System.Drawing.Size(170, 27);
            this.txt_percent.TabIndex = 16;

            this.label_file_path.AutoSize = true;
            this.label_file_path.Font     = new System.Drawing.Font("David", 13F);
            this.label_file_path.Location = new System.Drawing.Point(385, 354);
            this.label_file_path.Name     = "label_file_path";
            this.label_file_path.TabIndex = 17;
            this.label_file_path.Text     = "מסמך מצורף";

            this.txt_file_path.Font     = new System.Drawing.Font("David", 11F);
            this.txt_file_path.Location = new System.Drawing.Point(150, 351);
            this.txt_file_path.Name     = "txt_file_path";
            this.txt_file_path.Size     = new System.Drawing.Size(220, 27);
            this.txt_file_path.TabIndex = 18;
            //
            // label_error  (Y=393 — same as BoatsPanel)
            //
            this.label_error.AutoSize  = false;
            this.label_error.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_error.ForeColor = System.Drawing.Color.Crimson;
            this.label_error.Location  = new System.Drawing.Point(100, 393);
            this.label_error.Name      = "label_error";
            this.label_error.Size      = new System.Drawing.Size(800, 22);
            this.label_error.TabIndex  = 30;
            this.label_error.Text      = "";
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_error.Visible   = false;
            //
            // ── BUTTONS  (Y=421 — no sub-grid, so raised from BoatsPanel's Y=525)
            //
            this.btn_new.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_new.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_new.Location  = new System.Drawing.Point(20, 421);
            this.btn_new.Name      = "btn_new";
            this.btn_new.Size      = new System.Drawing.Size(145, 42);
            this.btn_new.TabIndex  = 40;
            this.btn_new.Text      = "בקשה חדשה";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click    += new System.EventHandler(this.btn_new_Click);

            this.btn_save.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_save.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_save.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location  = new System.Drawing.Point(180, 421);
            this.btn_save.Name      = "btn_save";
            this.btn_save.Size      = new System.Drawing.Size(145, 42);
            this.btn_save.TabIndex  = 41;
            this.btn_save.Text      = "שמור";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click    += new System.EventHandler(this.btn_save_Click);

            this.btn_update.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_update.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_update.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_update.ForeColor = System.Drawing.Color.White;
            this.btn_update.Location  = new System.Drawing.Point(180, 421);
            this.btn_update.Name      = "btn_update";
            this.btn_update.Size      = new System.Drawing.Size(145, 42);
            this.btn_update.TabIndex  = 42;
            this.btn_update.Text      = "עדכן";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Visible   = false;
            this.btn_update.Click    += new System.EventHandler(this.btn_update_Click);

            this.btn_delete.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_delete.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_delete.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_delete.Location  = new System.Drawing.Point(340, 421);
            this.btn_delete.Name      = "btn_delete";
            this.btn_delete.Size      = new System.Drawing.Size(145, 42);
            this.btn_delete.TabIndex  = 43;
            this.btn_delete.Text      = "מחק";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Visible   = false;
            this.btn_delete.Click    += new System.EventHandler(this.btn_delete_Click);

            this.btn_approve.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_approve.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_approve.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_approve.ForeColor = System.Drawing.Color.White;
            this.btn_approve.Location  = new System.Drawing.Point(503, 421);
            this.btn_approve.Name      = "btn_approve";
            this.btn_approve.Size      = new System.Drawing.Size(175, 42);
            this.btn_approve.TabIndex  = 44;
            this.btn_approve.Text      = "אשר בקשה";
            this.btn_approve.UseVisualStyleBackColor = false;
            this.btn_approve.Visible   = false;
            this.btn_approve.Click    += new System.EventHandler(this.btn_approve_Click);

            this.btn_reject.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_reject.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_reject.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_reject.Location  = new System.Drawing.Point(693, 421);
            this.btn_reject.Name      = "btn_reject";
            this.btn_reject.Size      = new System.Drawing.Size(120, 42);
            this.btn_reject.TabIndex  = 46;
            this.btn_reject.Text      = "דחה בקשה";
            this.btn_reject.UseVisualStyleBackColor = true;
            this.btn_reject.Visible   = false;
            this.btn_reject.Click    += new System.EventHandler(this.btn_reject_Click);

            this.btn_back.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location  = new System.Drawing.Point(820, 421);
            this.btn_back.Name      = "btn_back";
            this.btn_back.Size      = new System.Drawing.Size(150, 42);
            this.btn_back.TabIndex  = 47;
            this.btn_back.Text      = "חזרה";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click    += new System.EventHandler(this.btn_back_Click);
            //
            // DiscountRequestPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.dataGridView_discounts);
            this.Controls.Add(this.label_form_title);
            // RIGHT col
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label_customer);
            this.Controls.Add(this.combo_customer);
            this.Controls.Add(this.label_type);
            this.Controls.Add(this.combo_type);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.combo_status);
            // LEFT col
            this.Controls.Add(this.label_submitted);
            this.Controls.Add(this.dtp_submitted);
            this.Controls.Add(this.chk_has_resolved);
            this.Controls.Add(this.dtp_resolved);
            this.Controls.Add(this.label_percent);
            this.Controls.Add(this.txt_percent);
            this.Controls.Add(this.label_file_path);
            this.Controls.Add(this.txt_file_path);
            // Error + buttons
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_approve);
            this.Controls.Add(this.btn_reject);
            this.Controls.Add(this.btn_back);
            this.Name = "DiscountRequestPanel";
            this.Size = new System.Drawing.Size(1000, 480);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_discounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label          label_title;
        private System.Windows.Forms.DataGridView   dataGridView_discounts;
        private System.Windows.Forms.Label          label_form_title;
        private System.Windows.Forms.Label          label_id;
        private System.Windows.Forms.TextBox        txt_id;
        private System.Windows.Forms.Label          label_customer;
        private System.Windows.Forms.ComboBox       combo_customer;
        private System.Windows.Forms.Label          label_type;
        private System.Windows.Forms.ComboBox       combo_type;
        private System.Windows.Forms.Label          label_status;
        private System.Windows.Forms.ComboBox       combo_status;
        private System.Windows.Forms.Label          label_submitted;
        private System.Windows.Forms.DateTimePicker dtp_submitted;
        private System.Windows.Forms.CheckBox       chk_has_resolved;
        private System.Windows.Forms.DateTimePicker dtp_resolved;
        private System.Windows.Forms.Label          label_percent;
        private System.Windows.Forms.TextBox        txt_percent;
        private System.Windows.Forms.Label          label_file_path;
        private System.Windows.Forms.TextBox        txt_file_path;
        private System.Windows.Forms.Label          label_error;
        private System.Windows.Forms.Button         btn_new;
        private System.Windows.Forms.Button         btn_save;
        private System.Windows.Forms.Button         btn_update;
        private System.Windows.Forms.Button         btn_delete;
        private System.Windows.Forms.Button         btn_approve;
        private System.Windows.Forms.Button         btn_reject;
        private System.Windows.Forms.Button         btn_back;
    }
}
