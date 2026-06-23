namespace MyDaniel
{
    partial class CustomerProfilePanel
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label_title       = new System.Windows.Forms.Label();
            this.label_info_header = new System.Windows.Forms.Label();
            this.label_edit_header = new System.Windows.Forms.Label();
            // Left column — read-only info
            this.label_id          = new System.Windows.Forms.Label();
            this.lbl_id_value      = new System.Windows.Forms.Label();
            this.label_birth       = new System.Windows.Forms.Label();
            this.lbl_birth_value   = new System.Windows.Forms.Label();
            this.label_start       = new System.Windows.Forms.Label();
            this.lbl_start_value   = new System.Windows.Forms.Label();
            this.label_status      = new System.Windows.Forms.Label();
            this.lbl_status_value  = new System.Windows.Forms.Label();
            this.label_payment     = new System.Windows.Forms.Label();
            this.lbl_payment_value = new System.Windows.Forms.Label();
            // Right column — editable fields
            this.label_full_name   = new System.Windows.Forms.Label();
            this.txt_full_name     = new System.Windows.Forms.TextBox();
            this.label_phone       = new System.Windows.Forms.Label();
            this.txt_phone         = new System.Windows.Forms.TextBox();
            this.label_email       = new System.Windows.Forms.Label();
            this.txt_email         = new System.Windows.Forms.TextBox();
            this.label_address     = new System.Windows.Forms.Label();
            this.txt_address       = new System.Windows.Forms.TextBox();
            this.label_emergency   = new System.Windows.Forms.Label();
            this.txt_emergency     = new System.Windows.Forms.TextBox();
            // Bottom
            this.label_error       = new System.Windows.Forms.Label();
            this.btn_save          = new System.Windows.Forms.Button();
            this.btn_back          = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // label_title
            //
            this.label_title.AutoSize  = false;
            this.label_title.Font      = new System.Drawing.Font("David", 28F, System.Drawing.FontStyle.Bold);
            this.label_title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_title.Location  = new System.Drawing.Point(10, 15);
            this.label_title.Size      = new System.Drawing.Size(975, 44);
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_title.Name      = "label_title";
            this.label_title.TabIndex  = 0;
            this.label_title.Text      = "הפרופיל שלי";
            //
            // label_info_header  (left column header)
            //
            this.label_info_header.AutoSize  = true;
            this.label_info_header.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            this.label_info_header.ForeColor = System.Drawing.Color.DimGray;
            this.label_info_header.Location  = new System.Drawing.Point(185, 80);
            this.label_info_header.Name      = "label_info_header";
            this.label_info_header.TabIndex  = 1;
            this.label_info_header.Text      = "פרטי חבר (לצפייה בלבד)";
            //
            // label_edit_header  (right column header)
            //
            this.label_edit_header.AutoSize  = true;
            this.label_edit_header.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            this.label_edit_header.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_edit_header.Location  = new System.Drawing.Point(555, 80);
            this.label_edit_header.Name      = "label_edit_header";
            this.label_edit_header.TabIndex  = 2;
            this.label_edit_header.Text      = "פרטים לעדכון";
            //
            // ── LEFT COLUMN — read-only (label X=385, value X=100, W=270, step Y=45)
            //
            // label_id / lbl_id_value
            //
            this.label_id.AutoSize  = true;
            this.label_id.Font      = new System.Drawing.Font("David", 13F);
            this.label_id.Location  = new System.Drawing.Point(385, 115);
            this.label_id.Name      = "label_id";
            this.label_id.TabIndex  = 3;
            this.label_id.Text      = "מספר לקוח";

            this.lbl_id_value.AutoSize  = false;
            this.lbl_id_value.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_id_value.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_id_value.Location  = new System.Drawing.Point(100, 115);
            this.lbl_id_value.Name      = "lbl_id_value";
            this.lbl_id_value.Size      = new System.Drawing.Size(270, 26);
            this.lbl_id_value.TabIndex  = 4;
            this.lbl_id_value.Text      = "";
            //
            // label_birth / lbl_birth_value
            //
            this.label_birth.AutoSize  = true;
            this.label_birth.Font      = new System.Drawing.Font("David", 13F);
            this.label_birth.Location  = new System.Drawing.Point(385, 160);
            this.label_birth.Name      = "label_birth";
            this.label_birth.TabIndex  = 5;
            this.label_birth.Text      = "תאריך לידה";

            this.lbl_birth_value.AutoSize  = false;
            this.lbl_birth_value.Font      = new System.Drawing.Font("David", 12F);
            this.lbl_birth_value.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_birth_value.Location  = new System.Drawing.Point(100, 160);
            this.lbl_birth_value.Name      = "lbl_birth_value";
            this.lbl_birth_value.Size      = new System.Drawing.Size(270, 26);
            this.lbl_birth_value.TabIndex  = 6;
            this.lbl_birth_value.Text      = "";
            //
            // label_start / lbl_start_value
            //
            this.label_start.AutoSize  = true;
            this.label_start.Font      = new System.Drawing.Font("David", 13F);
            this.label_start.Location  = new System.Drawing.Point(385, 205);
            this.label_start.Name      = "label_start";
            this.label_start.TabIndex  = 7;
            this.label_start.Text      = "תאריך הצטרפות";

            this.lbl_start_value.AutoSize  = false;
            this.lbl_start_value.Font      = new System.Drawing.Font("David", 12F);
            this.lbl_start_value.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_start_value.Location  = new System.Drawing.Point(100, 205);
            this.lbl_start_value.Name      = "lbl_start_value";
            this.lbl_start_value.Size      = new System.Drawing.Size(270, 26);
            this.lbl_start_value.TabIndex  = 8;
            this.lbl_start_value.Text      = "";
            //
            // label_status / lbl_status_value
            //
            this.label_status.AutoSize  = true;
            this.label_status.Font      = new System.Drawing.Font("David", 13F);
            this.label_status.Location  = new System.Drawing.Point(385, 250);
            this.label_status.Name      = "label_status";
            this.label_status.TabIndex  = 9;
            this.label_status.Text      = "סטטוס חברות";

            this.lbl_status_value.AutoSize  = false;
            this.lbl_status_value.Font      = new System.Drawing.Font("David", 12F);
            this.lbl_status_value.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_status_value.Location  = new System.Drawing.Point(100, 250);
            this.lbl_status_value.Name      = "lbl_status_value";
            this.lbl_status_value.Size      = new System.Drawing.Size(270, 26);
            this.lbl_status_value.TabIndex  = 10;
            this.lbl_status_value.Text      = "";
            //
            // label_payment / lbl_payment_value
            //
            this.label_payment.AutoSize  = true;
            this.label_payment.Font      = new System.Drawing.Font("David", 13F);
            this.label_payment.Location  = new System.Drawing.Point(385, 295);
            this.label_payment.Name      = "label_payment";
            this.label_payment.TabIndex  = 11;
            this.label_payment.Text      = "סטטוס תשלום";

            this.lbl_payment_value.AutoSize  = false;
            this.lbl_payment_value.Font      = new System.Drawing.Font("David", 12F);
            this.lbl_payment_value.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_payment_value.Location  = new System.Drawing.Point(100, 295);
            this.lbl_payment_value.Name      = "lbl_payment_value";
            this.lbl_payment_value.Size      = new System.Drawing.Size(270, 26);
            this.lbl_payment_value.TabIndex  = 12;
            this.lbl_payment_value.Text      = "";
            //
            // ── RIGHT COLUMN — editable (label X=660, textbox X=430, W=210, step Y=45)
            //
            // label_full_name / txt_full_name
            //
            this.label_full_name.AutoSize  = true;
            this.label_full_name.Font      = new System.Drawing.Font("David", 13F);
            this.label_full_name.Location  = new System.Drawing.Point(660, 115);
            this.label_full_name.Name      = "label_full_name";
            this.label_full_name.TabIndex  = 13;
            this.label_full_name.Text      = "שם מלא";

            this.txt_full_name.Font     = new System.Drawing.Font("David", 12F);
            this.txt_full_name.Location = new System.Drawing.Point(430, 112);
            this.txt_full_name.Name     = "txt_full_name";
            this.txt_full_name.Size     = new System.Drawing.Size(210, 27);
            this.txt_full_name.TabIndex = 14;
            //
            // label_phone / txt_phone
            //
            this.label_phone.AutoSize  = true;
            this.label_phone.Font      = new System.Drawing.Font("David", 13F);
            this.label_phone.Location  = new System.Drawing.Point(660, 160);
            this.label_phone.Name      = "label_phone";
            this.label_phone.TabIndex  = 15;
            this.label_phone.Text      = "טלפון";

            this.txt_phone.Font     = new System.Drawing.Font("David", 12F);
            this.txt_phone.Location = new System.Drawing.Point(430, 157);
            this.txt_phone.Name     = "txt_phone";
            this.txt_phone.Size     = new System.Drawing.Size(210, 27);
            this.txt_phone.TabIndex = 16;
            //
            // label_email / txt_email
            //
            this.label_email.AutoSize  = true;
            this.label_email.Font      = new System.Drawing.Font("David", 13F);
            this.label_email.Location  = new System.Drawing.Point(660, 205);
            this.label_email.Name      = "label_email";
            this.label_email.TabIndex  = 17;
            this.label_email.Text      = "אימייל";

            this.txt_email.Font     = new System.Drawing.Font("David", 12F);
            this.txt_email.Location = new System.Drawing.Point(430, 202);
            this.txt_email.Name     = "txt_email";
            this.txt_email.Size     = new System.Drawing.Size(210, 27);
            this.txt_email.TabIndex = 18;
            //
            // label_address / txt_address
            //
            this.label_address.AutoSize  = true;
            this.label_address.Font      = new System.Drawing.Font("David", 13F);
            this.label_address.Location  = new System.Drawing.Point(660, 250);
            this.label_address.Name      = "label_address";
            this.label_address.TabIndex  = 19;
            this.label_address.Text      = "כתובת";

            this.txt_address.Font     = new System.Drawing.Font("David", 12F);
            this.txt_address.Location = new System.Drawing.Point(430, 247);
            this.txt_address.Name     = "txt_address";
            this.txt_address.Size     = new System.Drawing.Size(210, 27);
            this.txt_address.TabIndex = 20;
            //
            // label_emergency / txt_emergency
            //
            this.label_emergency.AutoSize  = true;
            this.label_emergency.Font      = new System.Drawing.Font("David", 13F);
            this.label_emergency.Location  = new System.Drawing.Point(660, 295);
            this.label_emergency.Name      = "label_emergency";
            this.label_emergency.TabIndex  = 21;
            this.label_emergency.Text      = "איש קשר לחירום";

            this.txt_emergency.Font     = new System.Drawing.Font("David", 12F);
            this.txt_emergency.Location = new System.Drawing.Point(430, 292);
            this.txt_emergency.Name     = "txt_emergency";
            this.txt_emergency.Size     = new System.Drawing.Size(210, 27);
            this.txt_emergency.TabIndex = 22;
            //
            // label_error
            //
            this.label_error.AutoSize  = false;
            this.label_error.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_error.ForeColor = System.Drawing.Color.Crimson;
            this.label_error.Location  = new System.Drawing.Point(100, 345);
            this.label_error.Name      = "label_error";
            this.label_error.Size      = new System.Drawing.Size(800, 24);
            this.label_error.TabIndex  = 23;
            this.label_error.Text      = "";
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_error.Visible   = false;
            //
            // btn_save
            //
            this.btn_save.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_save.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_save.Font      = new System.Drawing.Font("David", 14F, System.Drawing.FontStyle.Bold);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location  = new System.Drawing.Point(310, 395);
            this.btn_save.Name      = "btn_save";
            this.btn_save.Size      = new System.Drawing.Size(165, 42);
            this.btn_save.TabIndex  = 24;
            this.btn_save.Text      = "שמור שינויים";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click    += new System.EventHandler(this.btn_save_Click);
            //
            // btn_back
            //
            this.btn_back.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font      = new System.Drawing.Font("David", 14F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location  = new System.Drawing.Point(520, 395);
            this.btn_back.Name      = "btn_back";
            this.btn_back.Size      = new System.Drawing.Size(140, 42);
            this.btn_back.TabIndex  = 25;
            this.btn_back.Text      = "חזרה";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click    += new System.EventHandler(this.btn_back_Click);
            //
            // CustomerProfilePanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label_error);
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
            this.Controls.Add(this.lbl_payment_value);
            this.Controls.Add(this.label_payment);
            this.Controls.Add(this.lbl_status_value);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.lbl_start_value);
            this.Controls.Add(this.label_start);
            this.Controls.Add(this.lbl_birth_value);
            this.Controls.Add(this.label_birth);
            this.Controls.Add(this.lbl_id_value);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.label_edit_header);
            this.Controls.Add(this.label_info_header);
            this.Controls.Add(this.label_title);
            this.Name = "CustomerProfilePanel";
            this.Size = new System.Drawing.Size(1000, 620);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label   label_title;
        private System.Windows.Forms.Label   label_info_header;
        private System.Windows.Forms.Label   label_edit_header;
        private System.Windows.Forms.Label   label_id;
        private System.Windows.Forms.Label   lbl_id_value;
        private System.Windows.Forms.Label   label_birth;
        private System.Windows.Forms.Label   lbl_birth_value;
        private System.Windows.Forms.Label   label_start;
        private System.Windows.Forms.Label   lbl_start_value;
        private System.Windows.Forms.Label   label_status;
        private System.Windows.Forms.Label   lbl_status_value;
        private System.Windows.Forms.Label   label_payment;
        private System.Windows.Forms.Label   lbl_payment_value;
        private System.Windows.Forms.Label   label_full_name;
        private System.Windows.Forms.TextBox txt_full_name;
        private System.Windows.Forms.Label   label_phone;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.Label   label_email;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label   label_address;
        private System.Windows.Forms.TextBox txt_address;
        private System.Windows.Forms.Label   label_emergency;
        private System.Windows.Forms.TextBox txt_emergency;
        private System.Windows.Forms.Label   label_error;
        private System.Windows.Forms.Button  btn_save;
        private System.Windows.Forms.Button  btn_back;
    }
}
