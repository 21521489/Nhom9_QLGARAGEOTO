namespace GUI
{
    partial class fChiTietPhieuNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewCTPN = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMaPhieu = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCTPN)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCTPN
            // 
            this.dataGridViewCTPN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCTPN.Location = new System.Drawing.Point(30, 141);
            this.dataGridViewCTPN.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridViewCTPN.Name = "dataGridViewCTPN";
            this.dataGridViewCTPN.ReadOnly = true;
            this.dataGridViewCTPN.RowHeadersWidth = 62;
            this.dataGridViewCTPN.RowTemplate.Height = 28;
            this.dataGridViewCTPN.Size = new System.Drawing.Size(415, 216);
            this.dataGridViewCTPN.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(117, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chi tiết phiếu nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(130, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã phiếu:";
            // 
            // textBoxMaPhieu
            // 
            this.textBoxMaPhieu.Location = new System.Drawing.Point(233, 88);
            this.textBoxMaPhieu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxMaPhieu.Name = "textBoxMaPhieu";
            this.textBoxMaPhieu.ReadOnly = true;
            this.textBoxMaPhieu.Size = new System.Drawing.Size(68, 30);
            this.textBoxMaPhieu.TabIndex = 3;
            // 
            // fChiTietPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 374);
            this.Controls.Add(this.textBoxMaPhieu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewCTPN);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "fChiTietPhieuNhap";
            this.Text = "fChiTietPhieuNhap";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCTPN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCTPN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMaPhieu;
    }
}