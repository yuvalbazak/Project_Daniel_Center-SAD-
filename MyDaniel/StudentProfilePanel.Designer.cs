namespace MyDaniel
{
    partial class StudentProfilePanel
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
            // ── Section 1: read-only header + value labels ──────────────────
            this.label_info_header  = new System.Windows.Forms.Label();
            // RIGHT read-only col (lbl X=720, value X=490 W=220)
            this.label_name         = new System.Windows.Forms.Label();
            this.lbl_name_val       = new System.Windows.Forms.Label();
            this.label_address      = new System.Windows.Forms.Label();
            this.lbl_address_val    = new System.Windows.Forms.Label();
            this.label_status       = new System.Windows.Forms.Label();
            this.lbl_status_val     = new System.Windows.Forms.Label();
            this.label_payment      = new System.Windows.Forms.Label();
            this.lbl_payment_val    = new System.Windows.Forms.Label();
            // LEFT read-only col (lbl X=380, value X=120 W=245)
            this.label_id           = new System.Windows.Forms.Label();
            this.lbl_id_val         = new System.Windows.Forms.Label();
            this.label_birth        = new System.Windows.Forms.Label();
            this.lbl_birth_val      = new System.Windows.Forms.Label();
            this.label_start        = new System.Windows.Forms.Label();
            this.lbl_start_val      = new System.Windows.Forms.Label();
            // ── Section 2: editable fields ───────────────────────────────────
            this.label_edit_header  = new System.Windows.Forms.Label();
            // RIGHT editable (lbl X=720, ctrl X=490 W=220)
            this.label_email        = new System.Windows.Forms.Label();
            this.txt_email          = new System.Windows.Forms.TextBox();
            this.label_phone        = new System.Windows.Forms.Label();
            this.txt_phone          = new System.Windows.Forms.TextBox();
            // Full-width editable row
            this.label_emergency    = new System.Windows.Forms.Label();
            this.txt_emergency      = new System.Windows.Forms.TextBox();
            // ── Bottom ────────────────────────────────────────────────────────
            this.label_error        = new System.Windows.Forms.Label();
            this.btn_save           = new System.Windows.Forms.Button();
            this.btn_cancel         = new System.Windows.Forms.Button();
            this.btn_back           = new System.Windows.Forms.Button();
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
            this.label_title.Text      = "הפרטים האישיים שלי";
            //
            // ── Section 1 header ─────────────────────────────────────────────
            //
            this.label_info_header.AutoSize  = true;
            this.label_info_header.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            this.label_info_header.ForeColor = System.Drawing.Color.DimGray;
            this.label_info_header.Location  = new System.Drawing.Point(10, 62);
            this.label_info_header.Name      = "label_info_header";
            this.label_info_header.TabIndex  = 1;
            this.label_info_header.Text      = "פרטי חבר (לצפייה בלבד)";
            //
            // ── RIGHT col read-only (lbl X=720, value X=490 W=220): Y=90,130,170,210 ──
            //
            // שם מלא
            //
            this.label_name.AutoSize = true;
            this.label_name.Font     = new System.Drawing.Font("David", 13F);
            this.label_name.Location = new System.Drawing.Point(720, 90);
            this.label_name.Name     = "label_name";
            this.label_name.TabIndex = 2;
            this.label_name.Text     = "שם מלא";

            this.lbl_name_val.AutoSize  = false;
            this.lbl_name_val.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_name_val.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_name_val.Location  = new System.Drawing.Point(490, 90);
            this.lbl_name_val.Name      = "lbl_name_val";
            this.lbl_name_val.Size      = new System.Drawing.Size(220, 26);
            this.lbl_name_val.TabIndex  = 3;
            //
            // כתובת
            //
            this.label_address.AutoSize = true;
            this.label_address.Font     = new System.Drawing.Font("David", 13F);
            this.label_address.Location = new System.Drawing.Point(720, 130);
            this.label_address.Name     = "label_address";
            this.label_address.TabIndex = 4;
            this.label_address.Text     = "כתובת";

            this.lbl_address_val.AutoSize  = false;
            this.lbl_address_val.Font      = new System.Drawing.Font("David", 12F);
            this.lbl_address_val.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_address_val.Location  = new System.Drawing.Point(490, 130);
            this.lbl_address_val.Name      = "lbl_address_val";
            this.lbl_address_val.Size      = new System.Drawing.Size(220, 26);
            this.lbl_address_val.TabIndex  = 5;
            //
            // סטטוס
            //
            this.label_status.AutoSize = true;
            this.label_status.Font     = new System.Drawing.Font("David", 13F);
            this.label_status.Location = new System.Drawing.Point(720, 170);
            this.label_status.Name     = "label_status";
            this.label_status.TabIndex = 6;
            this.label_status.Text     = "סטטוס חברות";

            this.lbl_status_val.AutoSize  = false;
            this.lbl_status_val.Font      = new System.Drawing.Font("David", 12F);
            this.lbl_status_val.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_status_val.Location  = new System.Drawing.Point(490, 170);
            this.lbl_status_val.Name      = "lbl_status_val";
            this.lbl_status_val.Size      = new System.Drawing.Size(220, 26);
            this.lbl_status_val.TabIndex  = 7;
            //
            // סטטוס תשלום
            //
            this.label_payment.AutoSize = true;
            this.label_payment.Font     = new System.Drawing.Font("David", 13F);
            this.label_payment.Location = new System.Drawing.Point(720, 210);
            this.label_payment.Name     = "label_payment";
            this.label_payment.TabIndex = 8;
            this.label_payment.Text     = "סטטוס תשלום";

            this.lbl_payment_val.AutoSize  = false;
            this.lbl_payment_val.Font      = new System.Drawing.Font("David", 12F);
            this.lbl_payment_val.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_payment_val.Location  = new System.Drawing.Point(490, 210);
            this.lbl_payment_val.Name      = "lbl_payment_val";
            this.lbl_payment_val.Size      = new System.Drawing.Size(220, 26);
            this.lbl_payment_val.TabIndex  = 9;
            //
            // ── LEFT col read-only (lbl X=380, value X=120 W=245): Y=90,130,170 ──
            //
            // מ.ז.
            //
            this.label_id.AutoSize = true;
            this.label_id.Font     = new System.Drawing.Font("David", 13F);
            this.label_id.Location = new System.Drawing.Point(380, 90);
            this.label_id.Name     = "label_id";
            this.label_id.TabIndex = 10;
            this.label_id.Text     = "מספר לקוח";

            this.lbl_id_val.AutoSize  = false;
            this.lbl_id_val.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_id_val.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_id_val.Location  = new System.Drawing.Point(120, 90);
            this.lbl_id_val.Name      = "lbl_id_val";
            this.lbl_id_val.Size      = new System.Drawing.Size(245, 26);
            this.lbl_id_val.TabIndex  = 11;
            //
            // תאריך לידה
            //
            this.label_birth.AutoSize = true;
            this.label_birth.Font     = new System.Drawing.Font("David", 13F);
            this.label_birth.Location = new System.Drawing.Point(380, 130);
            this.label_birth.Name     = "label_birth";
            this.label_birth.TabIndex = 12;
            this.label_birth.Text     = "תאריך לידה";

            this.lbl_birth_val.AutoSize  = false;
            this.lbl_birth_val.Font      = new System.Drawing.Font("David", 12F);
            this.lbl_birth_val.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_birth_val.Location  = new System.Drawing.Point(120, 130);
            this.lbl_birth_val.Name      = "lbl_birth_val";
            this.lbl_birth_val.Size      = new System.Drawing.Size(245, 26);
            this.lbl_birth_val.TabIndex  = 13;
            //
            // תאריך הצטרפות
            //
            this.label_start.AutoSize = true;
            this.label_start.Font     = new System.Drawing.Font("David", 13F);
            this.label_start.Location = new System.Drawing.Point(380, 170);
            this.label_start.Name     = "label_start";
            this.label_start.TabIndex = 14;
            this.label_start.Text     = "תאריך הצטרפות";

            this.lbl_start_val.AutoSize  = false;
            this.lbl_start_val.Font      = new System.Drawing.Font("David", 12F);
            this.lbl_start_val.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_start_val.Location  = new System.Drawing.Point(120, 170);
            this.lbl_start_val.Name      = "lbl_start_val";
            this.lbl_start_val.Size      = new System.Drawing.Size(245, 26);
            this.lbl_start_val.TabIndex  = 15;
            //
            // ── Section 2 header ─────────────────────────────────────────────
            //
            this.label_edit_header.AutoSize  = true;
            this.label_edit_header.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            this.label_edit_header.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_edit_header.Location  = new System.Drawing.Point(10, 256);
            this.label_edit_header.Name      = "label_edit_header";
            this.label_edit_header.TabIndex  = 16;
            this.label_edit_header.Text      = "פרטי קשר (ניתן לעדכון)";
            //
            // ── RIGHT editable col (lbl X=720, ctrl X=490 W=220): Y=285, 325 ─
            //
            // אימייל
            //
            this.label_email.AutoSize = true;
            this.label_email.Font     = new System.Drawing.Font("David", 13F);
            this.label_email.Location = new System.Drawing.Point(720, 288);
            this.label_email.Name     = "label_email";
            this.label_email.TabIndex = 17;
            this.label_email.Text     = "אימייל";

            this.txt_email.Font     = new System.Drawing.Font("David", 12F);
            this.txt_email.Location = new System.Drawing.Point(490, 285);
            this.txt_email.Name     = "txt_email";
            this.txt_email.Size     = new System.Drawing.Size(220, 27);
            this.txt_email.TabIndex = 18;
            //
            // טלפון  (RIGHT col, row 2)
            //
            this.label_phone.AutoSize = true;
            this.label_phone.Font     = new System.Drawing.Font("David", 13F);
            this.label_phone.Location = new System.Drawing.Point(720, 328);
            this.label_phone.Name     = "label_phone";
            this.label_phone.TabIndex = 19;
            this.label_phone.Text     = "טלפון";

            this.txt_phone.Font     = new System.Drawing.Font("David", 12F);
            this.txt_phone.Location = new System.Drawing.Point(490, 325);
            this.txt_phone.Name     = "txt_phone";
            this.txt_phone.Size     = new System.Drawing.Size(220, 27);
            this.txt_phone.TabIndex = 20;
            //
            // ── Full-width row: איש קשר לחירום (Y=365) ──────────────────────
            //
            this.label_emergency.AutoSize = true;
            this.label_emergency.Font     = new System.Drawing.Font("David", 13F);
            this.label_emergency.Location = new System.Drawing.Point(875, 368);
            this.label_emergency.Name     = "label_emergency";
            this.label_emergency.TabIndex = 21;
            this.label_emergency.Text     = "איש קשר לחירום";

            this.txt_emergency.Font     = new System.Drawing.Font("David", 12F);
            this.txt_emergency.Location = new System.Drawing.Point(120, 365);
            this.txt_emergency.Name     = "txt_emergency";
            this.txt_emergency.Size     = new System.Drawing.Size(740, 27);
            this.txt_emergency.TabIndex = 22;
            //
            // label_error
            //
            this.label_error.AutoSize  = false;
            this.label_error.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_error.ForeColor = System.Drawing.Color.Crimson;
            this.label_error.Location  = new System.Drawing.Point(100, 408);
            this.label_error.Name      = "label_error";
            this.label_error.Size      = new System.Drawing.Size(800, 22);
            this.label_error.TabIndex  = 30;
            this.label_error.Text      = "";
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_error.Visible   = false;
            //
            // ── Buttons (Y=448) ────────────────────────────────────────────────
            //
            // btn_save
            //
            this.btn_save.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_save.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_save.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location  = new System.Drawing.Point(380, 448);
            this.btn_save.Name      = "btn_save";
            this.btn_save.Size      = new System.Drawing.Size(180, 42);
            this.btn_save.TabIndex  = 31;
            this.btn_save.Text      = "שמור שינויים";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click    += new System.EventHandler(this.btn_save_Click);
            //
            // btn_cancel
            //
            this.btn_cancel.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_cancel.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_cancel.Location  = new System.Drawing.Point(200, 448);
            this.btn_cancel.Name      = "btn_cancel";
            this.btn_cancel.Size      = new System.Drawing.Size(165, 42);
            this.btn_cancel.TabIndex  = 32;
            this.btn_cancel.Text      = "בטל שינויים";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click    += new System.EventHandler(this.btn_cancel_Click);
            //
            // btn_back
            //
            this.btn_back.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location  = new System.Drawing.Point(820, 448);
            this.btn_back.Name      = "btn_back";
            this.btn_back.Size      = new System.Drawing.Size(155, 42);
            this.btn_back.TabIndex  = 33;
            this.btn_back.Text      = "חזרה לתפריט";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click    += new System.EventHandler(this.btn_back_Click);
            //
            // StudentProfilePanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.txt_emergency);
            this.Controls.Add(this.label_emergency);
            this.Controls.Add(this.txt_phone);
            this.Controls.Add(this.label_phone);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.label_edit_header);
            this.Controls.Add(this.lbl_start_val);
            this.Controls.Add(this.label_start);
            this.Controls.Add(this.lbl_birth_val);
            this.Controls.Add(this.label_birth);
            this.Controls.Add(this.lbl_id_val);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.lbl_payment_val);
            this.Controls.Add(this.label_payment);
            this.Controls.Add(this.lbl_status_val);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.lbl_address_val);
            this.Controls.Add(this.label_address);
            this.Controls.Add(this.lbl_name_val);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.label_info_header);
            this.Controls.Add(this.label_title);
            this.Name = "StudentProfilePanel";
            this.Size = new System.Drawing.Size(1000, 620);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label   label_title;
        private System.Windows.Forms.Label   label_info_header;
        private System.Windows.Forms.Label   label_name;
        private System.Windows.Forms.Label   lbl_name_val;
        private System.Windows.Forms.Label   label_address;
        private System.Windows.Forms.Label   lbl_address_val;
        private System.Windows.Forms.Label   label_status;
        private System.Windows.Forms.Label   lbl_status_val;
        private System.Windows.Forms.Label   label_payment;
        private System.Windows.Forms.Label   lbl_payment_val;
        private System.Windows.Forms.Label   label_id;
        private System.Windows.Forms.Label   lbl_id_val;
        private System.Windows.Forms.Label   label_birth;
        private System.Windows.Forms.Label   lbl_birth_val;
        private System.Windows.Forms.Label   label_start;
        private System.Windows.Forms.Label   lbl_start_val;
        private System.Windows.Forms.Label   label_edit_header;
        private System.Windows.Forms.Label   label_email;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label   label_phone;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.Label   label_emergency;
        private System.Windows.Forms.TextBox txt_emergency;
        private System.Windows.Forms.Label   label_error;
        private System.Windows.Forms.Button  btn_save;
        private System.Windows.Forms.Button  btn_cancel;
        private System.Windows.Forms.Button  btn_back;
    }
}
