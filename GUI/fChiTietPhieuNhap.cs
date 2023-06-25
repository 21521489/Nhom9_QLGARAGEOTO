using DAO;
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
    public partial class fChiTietPhieuNhap : Form
    {
        public fChiTietPhieuNhap()
        {
            InitializeComponent();
        }
        public fChiTietPhieuNhap(int mapn)
        {
            InitializeComponent();
            dataGridViewCTPN.DataSource = PhieuNhapVTPTBUS.Instance.HienThiDSVTPTTrongPhieuNhap(mapn);
            dataGridViewCTPN.Show();
            textBoxMaPhieu.Text = mapn.ToString();
        }

    }
}
