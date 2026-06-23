namespace MyDaniel
{
    partial class RegisterPanel
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
            this.label_hint         = new System.Windows.Forms.Label();
            this.label_id           = new System.Windows.Forms.Label();
            this.txt_id             = new System.Windows.Forms.TextBox();
            this.label_full_name    = new System.Windows.Forms.Label();
            this.txt_full_name      = new System.Windows.Forms.TextBox();
            this.label_phone        = new System.Windows.Forms.Label();
            this.txt_phone          = new System.Windows.Forms.TextBox();
            this.label_email        = new System.Windows.Forms.Label();
            this.txt_email          = new System.Windows.Forms.TextBox();
            this.label_address      = new System.Windows.Forms.Label();
            this.txt_address        = new System.Windows.Forms.TextBox();
            this.label_birth        = new System.Windows.Forms.Label();
            this.dateTimePicker_birth = new System.Windows.Forms.DateTimePicker();
            this.label_emergency    = new System.Windows.Forms.Label();
            this.txt_emergency      = new System.Windows.Forms.TextBox();
            this.label_error        = new System.Windows.Forms.Label();
            this.btn_register       = new System.Windows.Forms.Button();
            this.btn_back           = new System.Windows.Forms.Button();
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
            this.label_title.Text      = "הרשמה ללקוח חדש";
            //
            // label_hint
            //
            this.label_hint.AutoSize  = true;
            this.label_hint.Font      = new System.Drawing.Font("David", 10F);
            this.label_hint.ForeColor = System.Drawing.Color.DimGray;
            this.label_hint.Location  = new System.Drawing.Point(320, 60);
            this.label_hint.Name      = "label_hint";
            this.label_hint.TabIndex  = 1;
            this.label_hint.Text      = "לאחר ההרשמה תקבלו סיסמה שתוכלו לשנות בכל עת";
            //
            // label_id
            //
            this.label_id.AutoSize = true;
            this.label_id.Font     = new System.Drawing.Font("David", 13F);
            this.label_id.Location = new System.Drawing.Point(660, 92);
            this.label_id.Name     = "label_id";
            this.label_id.TabIndex = 2;
            this.label_id.Text     = "מספר זהות (ת\"ז)";
            //
            // txt_id
            //
            this.txt_id.Font     = new System.Drawing.Font("David", 12F);
            this.txt_id.Location = new System.Drawing.Point(430, 89);
            this.txt_id.Name     = "txt_id";
            this.txt_id.Size     = new System.Drawing.Size(215, 27);
            this.txt_id.TabIndex = 3;
            this.txt_id.TextChanged += new System.EventHandler(this.txt_id_TextChanged);
            //
            // label_full_name
            //
            this.label_full_name.AutoSize = true;
            this.label_full_name.Font     = new System.Drawing.Font("David", 13F);
            this.label_full_name.Location = new System.Drawing.Point(660, 142);
            this.label_full_name.Name     = "label_full_name";
            this.label_full_name.TabIndex = 4;
            this.label_full_name.Text     = "שם מלא";
            //
            // txt_full_name
            //
            this.txt_full_name.Font     = new System.Drawing.Font("David", 12F);
            this.txt_full_name.Location = new System.Drawing.Point(430, 139);
            this.txt_full_name.Name     = "txt_full_name";
            this.txt_full_name.Size     = new System.Drawing.Size(215, 27);
            this.txt_full_name.TabIndex = 5;
            this.txt_full_name.TextChanged += new System.EventHandler(this.txt_full_name_TextChanged);
            //
            // label_phone
            //
            this.label_phone.AutoSize = true;
            this.label_phone.Font     = new System.Drawing.Font("David", 13F);
            this.label_phone.Location = new System.Drawing.Point(660, 192);
            this.label_phone.Name     = "label_phone";
            this.label_phone.TabIndex = 6;
            this.label_phone.Text     = "טלפון";
            //
            // txt_phone
            //
            this.txt_phone.Font     = new System.Drawing.Font("David", 12F);
            this.txt_phone.Location = new System.Drawing.Point(430, 189);
            this.txt_phone.Name     = "txt_phone";
            this.txt_phone.Size     = new System.Drawing.Size(215, 27);
            this.txt_phone.TabIndex = 7;
            this.txt_phone.TextChanged += new System.EventHandler(this.txt_phone_TextChanged);
            //
            // label_email
            //
            this.label_email.AutoSize = true;
            this.label_email.Font     = new System.Drawing.Font("David", 13F);
            this.label_email.Location = new System.Drawing.Point(660, 242);
            this.label_email.Name     = "label_email";
            this.label_email.TabIndex = 8;
            this.label_email.Text     = "אימייל";
            //
            // txt_email
            //
            this.txt_email.Font     = new System.Drawing.Font("David", 12F);
            this.txt_email.Location = new System.Drawing.Point(430, 239);
            this.txt_email.Name     = "txt_email";
            this.txt_email.Size     = new System.Drawing.Size(215, 27);
            this.txt_email.TabIndex = 9;
            this.txt_email.TextChanged += new System.EventHandler(this.txt_email_TextChanged);
            //
            // label_address
            //
            this.label_address.AutoSize = true;
            this.label_address.Font     = new System.Drawing.Font("David", 13F);
            this.label_address.Location = new System.Drawing.Point(660, 292);
            this.label_address.Name     = "label_address";
            this.label_address.TabIndex = 10;
            this.label_address.Text     = "כתובת מגורים";
            //
            // txt_address
            //
            this.txt_address.Font     = new System.Drawing.Font("David", 12F);
            this.txt_address.Location = new System.Drawing.Point(430, 289);
            this.txt_address.Name     = "txt_address";
            this.txt_address.Size     = new System.Drawing.Size(215, 27);
            this.txt_address.TabIndex = 11;
            this.txt_address.TextChanged += new System.EventHandler(this.txt_address_TextChanged);
            //
            // label_birth
            //
            this.label_birth.AutoSize = true;
            this.label_birth.Font     = new System.Drawing.Font("David", 13F);
            this.label_birth.Location = new System.Drawing.Point(660, 342);
            this.label_birth.Name     = "label_birth";
            this.label_birth.TabIndex = 12;
            this.label_birth.Text     = "תאריך לידה";
            //
            // dateTimePicker_birth
            //
            this.dateTimePicker_birth.Font     = new System.Drawing.Font("David", 11F);
            this.dateTimePicker_birth.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_birth.Location = new System.Drawing.Point(430, 339);
            this.dateTimePicker_birth.Name     = "dateTimePicker_birth";
            this.dateTimePicker_birth.Size     = new System.Drawing.Size(215, 26);
            this.dateTimePicker_birth.TabIndex = 13;
            //
            // label_emergency
            //
            this.label_emergency.AutoSize = true;
            this.label_emergency.Font     = new System.Drawing.Font("David", 13F);
            this.label_emergency.Location = new System.Drawing.Point(660, 392);
            this.label_emergency.Name     = "label_emergency";
            this.label_emergency.TabIndex = 14;
            this.label_emergency.Text     = "איש קשר לחירום";
            //
            // txt_emergency
            //
            this.txt_emergency.Font     = new System.Drawing.Font("David", 12F);
            this.txt_emergency.Location = new System.Drawing.Point(430, 389);
            this.txt_emergency.Name     = "txt_emergency";
            this.txt_emergency.Size     = new System.Drawing.Size(215, 27);
            this.txt_emergency.TabIndex = 15;
            this.txt_emergency.TextChanged += new System.EventHandler(this.txt_emergency_TextChanged);
            //
            // label_error
            //
            this.label_error.AutoSize  = false;
            this.label_error.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_error.ForeColor = System.Drawing.Color.Crimson;
            this.label_error.Location  = new System.Drawing.Point(220, 432);
            this.label_error.Name      = "label_error";
            this.label_error.Size      = new System.Drawing.Size(560, 24);
            this.label_error.TabIndex  = 16;
            this.label_error.Text      = "";
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_error.Visible   = false;
            //
            // btn_register
            //
            this.btn_register.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_register.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_register.Font      = new System.Drawing.Font("David", 14F, System.Drawing.FontStyle.Bold);
            this.btn_register.ForeColor = System.Drawing.Color.White;
            this.btn_register.Location  = new System.Drawing.Point(340, 468);
            this.btn_register.Name      = "btn_register";
            this.btn_register.Size      = new System.Drawing.Size(150, 46);
            this.btn_register.TabIndex  = 17;
            this.btn_register.Text      = "הרשמה";
            this.btn_register.UseVisualStyleBackColor = false;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            //
            // btn_back
            //
            this.btn_back.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location  = new System.Drawing.Point(510, 468);
            this.btn_back.Name      = "btn_back";
            this.btn_back.Size      = new System.Drawing.Size(150, 46);
            this.btn_back.TabIndex  = 18;
            this.btn_back.Text      = "חזרה לכניסה";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            //
            // RegisterPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.txt_emergency);
            this.Controls.Add(this.label_emergency);
            this.Controls.Add(this.dateTimePicker_birth);
            this.Controls.Add(this.label_birth);
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
            this.Controls.Add(this.label_hint);
            this.Controls.Add(this.label_title);
            this.Name = "RegisterPanel";
            this.Size = new System.Drawing.Size(1000, 620);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label          label_title;
        private System.Windows.Forms.Label          label_hint;
        private System.Windows.Forms.Label          label_id;
        private System.Windows.Forms.TextBox        txt_id;
        private System.Windows.Forms.Label          label_full_name;
        private System.Windows.Forms.TextBox        txt_full_name;
        private System.Windows.Forms.Label          label_phone;
        private System.Windows.Forms.TextBox        txt_phone;
        private System.Windows.Forms.Label          label_email;
        private System.Windows.Forms.TextBox        txt_email;
        private System.Windows.Forms.Label          label_address;
        private System.Windows.Forms.TextBox        txt_address;
        private System.Windows.Forms.Label          label_birth;
        private System.Windows.Forms.DateTimePicker dateTimePicker_birth;
        private System.Windows.Forms.Label          label_emergency;
        private System.Windows.Forms.TextBox        txt_emergency;
        private System.Windows.Forms.Label          label_error;
        private System.Windows.Forms.Button         btn_register;
        private System.Windows.Forms.Button         btn_back;
    }
}
