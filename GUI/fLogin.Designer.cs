
namespace GUI
{
    partial class fLogin
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
            this.buttonThoat = new System.Windows.Forms.Button();
            this.buttonDangNhap = new System.Windows.Forms.Button();
            this.textMatKhau = new System.Windows.Forms.TextBox();
            this.textDangNhap = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.Label();
            this.account = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonThoat
            // 
            this.buttonThoat.BackColor = System.Drawing.Color.Transparent;
            this.buttonThoat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonThoat.Location = new System.Drawing.Point(372, 157);
            this.buttonThoat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(112, 35);
            this.buttonThoat.TabIndex = 17;
            this.buttonThoat.Text = "Thoát";
            this.buttonThoat.UseVisualStyleBackColor = false;
            this.buttonThoat.Click += new System.EventHandler(this.buttonThoat_Click);
            // 
            // buttonDangNhap
            // 
            this.buttonDangNhap.BackColor = System.Drawing.Color.Transparent;
            this.buttonDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDangNhap.Location = new System.Drawing.Point(230, 157);
            this.buttonDangNhap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonDangNhap.Name = "buttonDangNhap";
            this.buttonDangNhap.Size = new System.Drawing.Size(112, 35);
            this.buttonDangNhap.TabIndex = 16;
            this.buttonDangNhap.Text = "Đăng nhập";
            this.buttonDangNhap.UseVisualStyleBackColor = false;
            this.buttonDangNhap.Click += new System.EventHandler(this.buttonDangNhap_Click);
            // 
            // textMatKhau
            // 
            this.textMatKhau.Location = new System.Drawing.Point(230, 89);
            this.textMatKhau.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textMatKhau.MaxLength = 30;
            this.textMatKhau.Name = "textMatKhau";
            this.textMatKhau.Size = new System.Drawing.Size(254, 26);
            this.textMatKhau.TabIndex = 15;
            this.textMatKhau.UseSystemPasswordChar = true;
            this.textMatKhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textMatKhau_KeyDown);
            // 
            // textDangNhap
            // 
            this.textDangNhap.Location = new System.Drawing.Point(230, 46);
            this.textDangNhap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textDangNhap.MaxLength = 30;
            this.textDangNhap.Name = "textDangNhap";
            this.textDangNhap.Size = new System.Drawing.Size(254, 26);
            this.textDangNhap.TabIndex = 14;
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.BackColor = System.Drawing.Color.Transparent;
            this.password.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(69, 88);
            this.password.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(121, 27);
            this.password.TabIndex = 13;
            this.password.Text = "Mật Khẩu: ";
            // 
            // account
            // 
            this.account.AutoSize = true;
            this.account.BackColor = System.Drawing.Color.Transparent;
            this.account.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.account.Location = new System.Drawing.Point(69, 45);
            this.account.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.account.Name = "account";
            this.account.Size = new System.Drawing.Size(176, 27);
            this.account.TabIndex = 12;
            this.account.Text = "Tên Đăng Nhập: ";
            // 
            // fLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 238);
            this.Controls.Add(this.buttonThoat);
            this.Controls.Add(this.buttonDangNhap);
            this.Controls.Add(this.textMatKhau);
            this.Controls.Add(this.textDangNhap);
            this.Controls.Add(this.password);
            this.Controls.Add(this.account);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "fLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fLogin_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonThoat;
        private System.Windows.Forms.Button buttonDangNhap;
        private System.Windows.Forms.TextBox textMatKhau;
        private System.Windows.Forms.TextBox textDangNhap;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.Label account;
    }
}

