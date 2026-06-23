namespace MyDaniel
{
    partial class CustomersPanel
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
            this.dataGridView_customers   = new System.Windows.Forms.DataGridView();
            this.label_form_title         = new System.Windows.Forms.Label();
            // Right column — text fields
            this.label_id                 = new System.Windows.Forms.Label();
            this.txt_id                   = new System.Windows.Forms.TextBox();
            this.label_full_name          = new System.Windows.Forms.Label();
            this.txt_full_name            = new System.Windows.Forms.TextBox();
            this.label_phone              = new System.Windows.Forms.Label();
            this.txt_phone                = new System.Windows.Forms.TextBox();
            this.label_email              = new System.Windows.Forms.Label();
            this.txt_email                = new System.Windows.Forms.TextBox();
            this.label_address            = new System.Windows.Forms.Label();
            this.txt_address              = new System.Windows.Forms.TextBox();
            this.label_emergency          = new System.Windows.Forms.Label();
            this.txt_emergency            = new System.Windows.Forms.TextBox();
            // Left column — dates & status
            this.label_birth              = new System.Windows.Forms.Label();
            this.dtp_birth                = new System.Windows.Forms.DateTimePicker();
            this.label_start              = new System.Windows.Forms.Label();
            this.dtp_start                = new System.Windows.Forms.DateTimePicker();
            this.label_payment_date       = new System.Windows.Forms.Label();
            this.dtp_payment              = new System.Windows.Forms.DateTimePicker();
            this.label_customer_status    = new System.Windows.Forms.Label();
            this.combo_customer_status    = new System.Windows.Forms.ComboBox();
            this.label_payment_status     = new System.Windows.Forms.Label();
            this.combo_payment_status     = new System.Windows.Forms.ComboBox();
            // Buttons
            this.btn_new                  = new System.Windows.Forms.Button();
            this.btn_save                 = new System.Windows.Forms.Button();
            this.btn_update               = new System.Windows.Forms.Button();
            this.btn_delete               = new System.Windows.Forms.Button();
            this.btn_back                 = new System.Windows.Forms.Button();
            this.label_error              = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_customers)).BeginInit();
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
            this.label_title.Text      = "ניהול לקוחות";
            //
            // dataGridView_customers
            //
            this.dataGridView_customers.AllowUserToAddRows           = false;
            this.dataGridView_customers.AllowUserToDeleteRows        = false;
            this.dataGridView_customers.AutoSizeColumnsMode          = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_customers.ColumnHeadersHeightSizeMode  = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_customers.Font                         = new System.Drawing.Font("David", 10F);
            this.dataGridView_customers.Location                     = new System.Drawing.Point(10, 60);
            this.dataGridView_customers.MultiSelect                  = false;
            this.dataGridView_customers.Name                         = "dataGridView_customers";
            this.dataGridView_customers.ReadOnly                     = true;
            this.dataGridView_customers.RightToLeft                  = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView_customers.RowHeadersWidth              = 40;
            this.dataGridView_customers.SelectionMode                = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_customers.Size                         = new System.Drawing.Size(1040, 185);
            this.dataGridView_customers.TabIndex                     = 1;
            this.dataGridView_customers.SelectionChanged            += new System.EventHandler(this.dataGridView_customers_SelectionChanged);
            //
            // label_form_title
            //
            this.label_form_title.AutoSize  = true;
            this.label_form_title.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_form_title.ForeColor = System.Drawing.Color.DimGray;
            this.label_form_title.Location  = new System.Drawing.Point(350, 252);
            this.label_form_title.Name      = "label_form_title";
            this.label_form_title.TabIndex  = 2;
            this.label_form_title.Text      = "פרטי לקוח — הוספה / עריכה";
            //
            // ── RIGHT COLUMN  (label X=725, textbox X=505, W=210)
            // ── Y: 280, 320, 360, 400, 440, 480
            //
            // label_id
            //
            this.label_id.AutoSize = true;
            this.label_id.Font     = new System.Drawing.Font("David", 13F);
            this.label_id.Location = new System.Drawing.Point(725, 280);
            this.label_id.Name     = "label_id";
            this.label_id.TabIndex = 3;
            this.label_id.Text     = "מספר לקוח";
            //
            // txt_id
            //
            this.txt_id.Font     = new System.Drawing.Font("David", 12F);
            this.txt_id.Location = new System.Drawing.Point(505, 277);
            this.txt_id.Name     = "txt_id";
            this.txt_id.Size     = new System.Drawing.Size(210, 27);
            this.txt_id.TabIndex = 4;
            //
            // label_full_name
            //
            this.label_full_name.AutoSize = true;
            this.label_full_name.Font     = new System.Drawing.Font("David", 13F);
            this.label_full_name.Location = new System.Drawing.Point(725, 320);
            this.label_full_name.Name     = "label_full_name";
            this.label_full_name.TabIndex = 5;
            this.label_full_name.Text     = "שם מלא";
            //
            // txt_full_name
            //
            this.txt_full_name.Font     = new System.Drawing.Font("David", 12F);
            this.txt_full_name.Location = new System.Drawing.Point(505, 317);
            this.txt_full_name.Name     = "txt_full_name";
            this.txt_full_name.Size     = new System.Drawing.Size(210, 27);
            this.txt_full_name.TabIndex = 6;
            //
            // label_phone
            //
            this.label_phone.AutoSize = true;
            this.label_phone.Font     = new System.Drawing.Font("David", 13F);
            this.label_phone.Location = new System.Drawing.Point(725, 360);
            this.label_phone.Name     = "label_phone";
            this.label_phone.TabIndex = 7;
            this.label_phone.Text     = "טלפון";
            //
            // txt_phone
            //
            this.txt_phone.Font     = new System.Drawing.Font("David", 12F);
            this.txt_phone.Location = new System.Drawing.Point(505, 357);
            this.txt_phone.Name     = "txt_phone";
            this.txt_phone.Size     = new System.Drawing.Size(210, 27);
            this.txt_phone.TabIndex = 8;
            //
            // label_email
            //
            this.label_email.AutoSize = true;
            this.label_email.Font     = new System.Drawing.Font("David", 13F);
            this.label_email.Location = new System.Drawing.Point(725, 400);
            this.label_email.Name     = "label_email";
            this.label_email.TabIndex = 9;
            this.label_email.Text     = "אימייל";
            //
            // txt_email
            //
            this.txt_email.Font     = new System.Drawing.Font("David", 12F);
            this.txt_email.Location = new System.Drawing.Point(505, 397);
            this.txt_email.Name     = "txt_email";
            this.txt_email.Size     = new System.Drawing.Size(210, 27);
            this.txt_email.TabIndex = 10;
            //
            // label_address
            //
            this.label_address.AutoSize = true;
            this.label_address.Font     = new System.Drawing.Font("David", 13F);
            this.label_address.Location = new System.Drawing.Point(725, 440);
            this.label_address.Name     = "label_address";
            this.label_address.TabIndex = 11;
            this.label_address.Text     = "כתובת";
            //
            // txt_address
            //
            this.txt_address.Font     = new System.Drawing.Font("David", 12F);
            this.txt_address.Location = new System.Drawing.Point(505, 437);
            this.txt_address.Name     = "txt_address";
            this.txt_address.Size     = new System.Drawing.Size(210, 27);
            this.txt_address.TabIndex = 12;
            //
            // label_emergency
            //
            this.label_emergency.AutoSize = true;
            this.label_emergency.Font     = new System.Drawing.Font("David", 13F);
            this.label_emergency.Location = new System.Drawing.Point(725, 480);
            this.label_emergency.Name     = "label_emergency";
            this.label_emergency.TabIndex = 13;
            this.label_emergency.Text     = "איש קשר לחירום";
            //
            // txt_emergency
            //
            this.txt_emergency.Font     = new System.Drawing.Font("David", 12F);
            this.txt_emergency.Location = new System.Drawing.Point(505, 477);
            this.txt_emergency.Name     = "txt_emergency";
            this.txt_emergency.Size     = new System.Drawing.Size(210, 27);
            this.txt_emergency.TabIndex = 14;
            //
            // ── LEFT COLUMN  (label X=385, control X=150, W=220)
            // ── Y: 280, 320, 360, 400, 440
            //
            // label_birth
            //
            this.label_birth.AutoSize = true;
            this.label_birth.Font     = new System.Drawing.Font("David", 13F);
            this.label_birth.Location = new System.Drawing.Point(385, 280);
            this.label_birth.Name     = "label_birth";
            this.label_birth.TabIndex = 15;
            this.label_birth.Text     = "תאריך לידה";
            //
            // dtp_birth
            //
            this.dtp_birth.Font     = new System.Drawing.Font("David", 11F);
            this.dtp_birth.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_birth.Location = new System.Drawing.Point(150, 277);
            this.dtp_birth.Name     = "dtp_birth";
            this.dtp_birth.Size     = new System.Drawing.Size(220, 26);
            this.dtp_birth.TabIndex = 16;
            //
            // label_start
            //
            this.label_start.AutoSize = true;
            this.label_start.Font     = new System.Drawing.Font("David", 13F);
            this.label_start.Location = new System.Drawing.Point(385, 320);
            this.label_start.Name     = "label_start";
            this.label_start.TabIndex = 17;
            this.label_start.Text     = "תאריך הצטרפות";
            //
            // dtp_start
            //
            this.dtp_start.Font     = new System.Drawing.Font("David", 11F);
            this.dtp_start.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_start.Location = new System.Drawing.Point(150, 317);
            this.dtp_start.Name     = "dtp_start";
            this.dtp_start.Size     = new System.Drawing.Size(220, 26);
            this.dtp_start.TabIndex = 18;
            //
            // label_payment_date
            //
            this.label_payment_date.AutoSize = true;
            this.label_payment_date.Font     = new System.Drawing.Font("David", 13F);
            this.label_payment_date.Location = new System.Drawing.Point(385, 360);
            this.label_payment_date.Name     = "label_payment_date";
            this.label_payment_date.TabIndex = 19;
            this.label_payment_date.Text     = "תאריך תשלום";
            //
            // dtp_payment
            //
            this.dtp_payment.Font     = new System.Drawing.Font("David", 11F);
            this.dtp_payment.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_payment.Location = new System.Drawing.Point(150, 357);
            this.dtp_payment.Name     = "dtp_payment";
            this.dtp_payment.Size     = new System.Drawing.Size(220, 26);
            this.dtp_payment.TabIndex = 20;
            //
            // label_customer_status
            //
            this.label_customer_status.AutoSize = true;
            this.label_customer_status.Font     = new System.Drawing.Font("David", 13F);
            this.label_customer_status.Location = new System.Drawing.Point(385, 400);
            this.label_customer_status.Name     = "label_customer_status";
            this.label_customer_status.TabIndex = 21;
            this.label_customer_status.Text     = "סטטוס לקוח";
            //
            // combo_customer_status
            //
            this.combo_customer_status.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_customer_status.Font              = new System.Drawing.Font("David", 11F);
            this.combo_customer_status.FormattingEnabled = true;
            this.combo_customer_status.Location          = new System.Drawing.Point(150, 397);
            this.combo_customer_status.Name              = "combo_customer_status";
            this.combo_customer_status.Size              = new System.Drawing.Size(220, 26);
            this.combo_customer_status.TabIndex          = 22;
            //
            // label_payment_status
            //
            this.label_payment_status.AutoSize = true;
            this.label_payment_status.Font     = new System.Drawing.Font("David", 13F);
            this.label_payment_status.Location = new System.Drawing.Point(385, 440);
            this.label_payment_status.Name     = "label_payment_status";
            this.label_payment_status.TabIndex = 23;
            this.label_payment_status.Text     = "סטטוס תשלום";
            //
            // combo_payment_status
            //
            this.combo_payment_status.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_payment_status.Font              = new System.Drawing.Font("David", 11F);
            this.combo_payment_status.FormattingEnabled = true;
            this.combo_payment_status.Location          = new System.Drawing.Point(150, 437);
            this.combo_payment_status.Name              = "combo_payment_status";
            this.combo_payment_status.Size              = new System.Drawing.Size(220, 26);
            this.combo_payment_status.TabIndex          = 24;
            //
            // label_error
            //
            this.label_error.AutoSize  = false;
            this.label_error.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_error.ForeColor = System.Drawing.Color.Crimson;
            this.label_error.Location  = new System.Drawing.Point(150, 509);
            this.label_error.Name      = "label_error";
            this.label_error.Size      = new System.Drawing.Size(680, 22);
            this.label_error.TabIndex  = 40;
            this.label_error.Text      = "";
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_error.Visible   = false;
            //
            // ── BUTTONS  (Y=535)
            //
            // btn_new
            //
            this.btn_new.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_new.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_new.Location  = new System.Drawing.Point(20, 535);
            this.btn_new.Name      = "btn_new";
            this.btn_new.Size      = new System.Drawing.Size(145, 42);
            this.btn_new.TabIndex  = 25;
            this.btn_new.Text      = "לקוח חדש";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click    += new System.EventHandler(this.btn_new_Click);
            //
            // btn_save  (visible when _selected == null)
            //
            this.btn_save.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_save.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_save.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location  = new System.Drawing.Point(180, 535);
            this.btn_save.Name      = "btn_save";
            this.btn_save.Size      = new System.Drawing.Size(145, 42);
            this.btn_save.TabIndex  = 26;
            this.btn_save.Text      = "שמור";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Visible   = true;
            this.btn_save.Click    += new System.EventHandler(this.btn_save_Click);
            //
            // btn_update  (same position as btn_save; visible when _selected != null)
            //
            this.btn_update.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_update.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_update.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_update.ForeColor = System.Drawing.Color.White;
            this.btn_update.Location  = new System.Drawing.Point(180, 535);
            this.btn_update.Name      = "btn_update";
            this.btn_update.Size      = new System.Drawing.Size(145, 42);
            this.btn_update.TabIndex  = 27;
            this.btn_update.Text      = "עדכן";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Visible   = false;
            this.btn_update.Click    += new System.EventHandler(this.btn_update_Click);
            //
            // btn_delete  (visible when _selected != null)
            //
            this.btn_delete.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_delete.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_delete.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_delete.Location  = new System.Drawing.Point(340, 535);
            this.btn_delete.Name      = "btn_delete";
            this.btn_delete.Size      = new System.Drawing.Size(145, 42);
            this.btn_delete.TabIndex  = 28;
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
            this.btn_back.Size      = new System.Drawing.Size(150, 42);
            this.btn_back.TabIndex  = 29;
            this.btn_back.Text      = "חזרה";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click    += new System.EventHandler(this.btn_back_Click);
            //
            // CustomersPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.combo_payment_status);
            this.Controls.Add(this.label_payment_status);
            this.Controls.Add(this.combo_customer_status);
            this.Controls.Add(this.label_customer_status);
            this.Controls.Add(this.dtp_payment);
            this.Controls.Add(this.label_payment_date);
            this.Controls.Add(this.dtp_start);
            this.Controls.Add(this.label_start);
            this.Controls.Add(this.dtp_birth);
            this.Controls.Add(this.label_birth);
            this.Controls.Add(this.txt_emergency);
            this.Controls.Add(this.label_emergency);
            this.Controls.Add(this.txt_address);
            this.Controls.Add(this.label_address);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.txt_phone);
            this.Controls.Add(this.label_phone);
            this.Controls.Add(this.txt_full_name);
            this.Controls.Add(this.label_full_name);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.label_form_title);
            this.Controls.Add(this.dataGridView_customers);
            this.Controls.Add(this.label_title);
            this.Name = "CustomersPanel";
            this.Size = new System.Drawing.Size(1000, 620);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_customers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label            label_title;
        private System.Windows.Forms.DataGridView     dataGridView_customers;
        private System.Windows.Forms.Label            label_form_title;
        private System.Windows.Forms.Label            label_id;
        private System.Windows.Forms.TextBox          txt_id;
        private System.Windows.Forms.Label            label_full_name;
        private System.Windows.Forms.TextBox          txt_full_name;
        private System.Windows.Forms.Label            label_phone;
        private System.Windows.Forms.TextBox          txt_phone;
        private System.Windows.Forms.Label            label_email;
        private System.Windows.Forms.TextBox          txt_email;
        private System.Windows.Forms.Label            label_address;
        private System.Windows.Forms.TextBox          txt_address;
        private System.Windows.Forms.Label            label_emergency;
        private System.Windows.Forms.TextBox          txt_emergency;
        private System.Windows.Forms.Label            label_birth;
        private System.Windows.Forms.DateTimePicker   dtp_birth;
        private System.Windows.Forms.Label            label_start;
        private System.Windows.Forms.DateTimePicker   dtp_start;
        private System.Windows.Forms.Label            label_payment_date;
        private System.Windows.Forms.DateTimePicker   dtp_payment;
        private System.Windows.Forms.Label            label_customer_status;
        private System.Windows.Forms.ComboBox         combo_customer_status;
        private System.Windows.Forms.Label            label_payment_status;
        private System.Windows.Forms.ComboBox         combo_payment_status;
        private System.Windows.Forms.Button           btn_new;
        private System.Windows.Forms.Button           btn_save;
        private System.Windows.Forms.Button           btn_update;
        private System.Windows.Forms.Button           btn_delete;
        private System.Windows.Forms.Button           btn_back;
        private System.Windows.Forms.Label            label_error;
    }
}
