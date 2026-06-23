namespace MyDaniel
{
    partial class AccessDeniedPanel
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label_code    = new System.Windows.Forms.Label();
            this.label_title   = new System.Windows.Forms.Label();
            this.label_message = new System.Windows.Forms.Label();
            this.btn_back      = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // label_code  — big "403"
            //
            this.label_code.AutoSize  = true;
            this.label_code.Font      = new System.Drawing.Font("David", 72F, System.Drawing.FontStyle.Bold);
            this.label_code.ForeColor = System.Drawing.Color.Crimson;
            this.label_code.Location  = new System.Drawing.Point(375, 90);
            this.label_code.Name      = "label_code";
            this.label_code.TabIndex  = 0;
            this.label_code.Text      = "403";
            //
            // label_title
            //
            this.label_title.AutoSize  = false;
            this.label_title.Font      = new System.Drawing.Font("David", 28F, System.Drawing.FontStyle.Bold);
            this.label_title.ForeColor = System.Drawing.Color.Crimson;
            this.label_title.Location  = new System.Drawing.Point(10, 230);
            this.label_title.Size      = new System.Drawing.Size(975, 44);
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_title.Name      = "label_title";
            this.label_title.TabIndex  = 1;
            this.label_title.Text      = "אין הרשאת גישה";
            //
            // label_message
            //
            this.label_message.AutoSize  = false;
            this.label_message.Font      = new System.Drawing.Font("David", 14F);
            this.label_message.ForeColor = System.Drawing.Color.DimGray;
            this.label_message.Location  = new System.Drawing.Point(100, 300);
            this.label_message.Name      = "label_message";
            this.label_message.Size      = new System.Drawing.Size(800, 50);
            this.label_message.TabIndex  = 2;
            this.label_message.Text      = "אין לך הרשאה לגשת לדף זה. פנה למנהל המרכז במידת הצורך.";
            this.label_message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btn_back
            //
            this.btn_back.Cursor   = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font     = new System.Drawing.Font("David", 14F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location = new System.Drawing.Point(425, 390);
            this.btn_back.Name     = "btn_back";
            this.btn_back.Size     = new System.Drawing.Size(150, 42);
            this.btn_back.TabIndex = 3;
            this.btn_back.Text     = "חזרה לתפריט";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click   += new System.EventHandler(this.btn_back_Click);
            //
            // AccessDeniedPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.label_message);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.label_code);
            this.Name = "AccessDeniedPanel";
            this.Size = new System.Drawing.Size(1000, 620);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label  label_code;
        private System.Windows.Forms.Label  label_title;
        private System.Windows.Forms.Label  label_message;
        private System.Windows.Forms.Button btn_back;
    }
}
