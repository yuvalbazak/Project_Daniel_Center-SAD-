namespace MyDaniel
{
    partial class WatchEmployeesPanel
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
            this.label_title             = new System.Windows.Forms.Label();
            this.dataGridView_employees  = new System.Windows.Forms.DataGridView();
            this.btn_back                = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_employees)).BeginInit();
            this.SuspendLayout();
            //
            // label_title
            //
            this.label_title.AutoSize = false;
            this.label_title.Font = new System.Drawing.Font("David", 28F, System.Drawing.FontStyle.Bold);
            this.label_title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_title.Location = new System.Drawing.Point(10, 15);
            this.label_title.Size = new System.Drawing.Size(975, 44);
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_title.Name = "label_title";
            this.label_title.TabIndex = 0;
            this.label_title.Text = "רשימת עובדים";
            //
            // dataGridView_employees
            //
            this.dataGridView_employees.AllowUserToAddRows = false;
            this.dataGridView_employees.AllowUserToDeleteRows = false;
            this.dataGridView_employees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_employees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_employees.Font = new System.Drawing.Font("David", 11F);
            this.dataGridView_employees.Location = new System.Drawing.Point(20, 70);
            this.dataGridView_employees.Name = "dataGridView_employees";
            this.dataGridView_employees.ReadOnly = true;
            this.dataGridView_employees.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView_employees.RowHeadersWidth = 51;
            this.dataGridView_employees.Size = new System.Drawing.Size(960, 460);
            this.dataGridView_employees.TabIndex = 1;
            //
            // btn_back
            //
            this.btn_back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font = new System.Drawing.Font("David", 14F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location = new System.Drawing.Point(425, 548);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(150, 42);
            this.btn_back.TabIndex = 2;
            this.btn_back.Text = "חזרה";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            //
            // WatchEmployeesPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.dataGridView_employees);
            this.Controls.Add(this.label_title);
            this.Name = "WatchEmployeesPanel";
            this.Size = new System.Drawing.Size(1000, 620);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_employees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label       label_title;
        private System.Windows.Forms.DataGridView dataGridView_employees;
        private System.Windows.Forms.Button      btn_back;
    }
}
