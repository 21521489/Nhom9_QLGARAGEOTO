using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }
        bool DangNhap(string TaiKhoan, string MatKhau)
        {
            return TaiKhoanBUS.Instance.DangNhap(TaiKhoan, MatKhau);
        }
        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            if (textDangNhap.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tài khoản!");
            }
            else if (textMatKhau.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
            }
            else
            {
                string TaiKhoan = textDangNhap.Text;
                string MatKhau = textMatKhau.Text;
                if (DangNhap(TaiKhoan, MatKhau))
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông Báo");
                    fMain frm = new fMain();
                    this.Hide();
                    frm.ShowDialog();
                    this.Show();
                    textDangNhap.Clear();
                    textMatKhau.Clear();
                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra lại tên hoặc mật khẩu!");
                }

            }
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void textMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textDangNhap.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập tài khoản!");
                }
                else if (textMatKhau.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!");
                }
                else
                {
                    string TaiKhoan = textDangNhap.Text;
                    string MatKhau = textMatKhau.Text;
                    if (DangNhap(TaiKhoan, MatKhau))
                    {
                        MessageBox.Show("Đăng nhập thành công!", "Thông Báo");
                        fMain frm = new fMain();
                        this.Hide();
                        frm.ShowDialog();
                        this.Show();
                        textDangNhap.Clear();
                        textMatKhau.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng kiểm tra lại tên hoặc mật khẩu!");
                    }

                }
            }
        }

        
    }
}
