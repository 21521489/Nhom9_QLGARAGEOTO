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
    public partial class fThongTinTaiKhoan : Form
    {
        public fThongTinTaiKhoan()
        {
            InitializeComponent();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            fThayDoiMatKhau tdmk = new fThayDoiMatKhau();
            tdmk.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            txtBoxHoTen.Text = TaiKhoanBUS.Instance.LayHoTen();
            txtBoxTaiKhoan.Text = TaiKhoanBUS.Instance.LayTenTaiKhoan();
            txtBoxQuyenHan.Text = TaiKhoanBUS.Instance.LayQuyenHan();
        }
    }
}
