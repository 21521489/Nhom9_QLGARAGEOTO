using BUS;
using DAO;
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
    public partial class fPhieuNhapVTPT : Form
    {
        private int _mapn;
        public int Mapnvtpt { get { return _mapn; } set { _mapn = value; } }
        public fPhieuNhapVTPT()
        {
            InitializeComponent();
            //Xu ly lap Phieunhap
            this._mapn = PhieuNhapVTPTBUS.Instance.TuDongTaoMaPN();
            string query = "UPDATE PHIEUNHAPVTPT SET ThoiDiem = @ThoDiem WHERE MaPNVTPT = @Mapn";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] {DateTime.Now, this._mapn});
            if (result != null && result != DBNull.Value)
            {
                MessageBox.Show("Lỗi", "Cảnh báo");
            }
            query = "SELECT TenVTPT as 'Tên VTPT', ctpn.DonGiaNhap as 'Đơn giá nhập', ctpn.SoLuong as 'Số Lượng' FROM VATTUPHUTUNG vtpt, CT_PHIEUNHAPVTPT ctpn WHERE vtpt.MaVTPT = ctpn.MaVTPT AND ctpn.MaPNVTPT = '" + this._mapn + "'";
            dataGridViewPhieuNhapVTPT.DataSource = DataProvider.Instance.ExecuteQuery(query);
            dataGridViewPhieuNhapVTPT.Show();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenvtpt = textBoxTenVTPT.Text;
            int mapn = this._mapn;
            if (string.IsNullOrEmpty(tenvtpt))
            {
                MessageBox.Show("Vui lòng nhập tên VTPT.", "Cảnh báo");
                return;
            }
            else
            {
                if (!int.TryParse(textBoxSoLuongVTPT.Text, out int SoLuong) || SoLuong < 1)
                {
                    MessageBox.Show("Số lượng phải là số nguyên dương.", "Cảnh báo");
                }
                else
                {
                    if (!int.TryParse(textBoxDonGiaNhapVTPT.Text, out int DonGiaNhap) || DonGiaNhap <= 0)
                    {
                        MessageBox.Show("Đơn giá nhập phải là số nguyên dương.", "Cảnh báo");
                    }
                    else
                    {
                        if (PhieuNhapVTPTBUS.Instance.KiemTraMaTonTai(this._mapn, tenvtpt))
                        {
                            MessageBox.Show("Vật tư phụ tùng này đã được nhập trong phiếu này. Nếu bạn muốn thay đổi số lượng nhập hoặc đơn giá nhập hãy bấm nút 'Sửa'", "Cảnh báo");
                        }
                        else
                        {
                            DataTable result = PhieuNhapVTPTBUS.Instance.CapNhatDSVTPTNhap(mapn, tenvtpt, SoLuong, DonGiaNhap);
                            PhieuNhapVTPTBUS.Instance.UpdateDonGiaBan(tenvtpt);
                            dataGridViewPhieuNhapVTPT.DataSource = result;
                            dataGridViewPhieuNhapVTPT.Show();
                            txtThanhTienPN.Text = (PhieuNhapVTPTBUS.Instance.TinhThanhTienPN(this._mapn)).ToString();
                            textBoxTenVTPT.Clear();
                            textBoxSoLuongVTPT.Clear();
                            textBoxDonGiaNhapVTPT.Clear();
                            textBoxTenVTPT.Focus();
                        }
                    }
                }
            }
        }


        private void btnHoanTat_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string tenvtpt = textBoxTenVTPT.Text;
            if (string.IsNullOrEmpty(tenvtpt))
            {
                MessageBox.Show("Vui lòng nhập tên VTPT.", "Cảnh báo");
                return;
            }
            else
            {
                if (PhieuNhapVTPTBUS.Instance.KiemTraMaTonTai(this._mapn, tenvtpt))
                {
                    if (MessageBox.Show("Bạn muốn xóa VTPT này?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        PhieuNhapVTPTBUS.Instance.XoaVTPTTrongPN(this._mapn, tenvtpt);
                        DataTable result = PhieuNhapVTPTBUS.Instance.HienThiDSVTPTTrongPhieuNhap(this._mapn);
                        dataGridViewPhieuNhapVTPT.DataSource = result;
                        dataGridViewPhieuNhapVTPT.Show();
                        txtThanhTienPN.Text = (PhieuNhapVTPTBUS.Instance.TinhThanhTienPN(this._mapn)).ToString();
                        textBoxTenVTPT.Clear();
                        textBoxSoLuongVTPT.Clear();
                        textBoxDonGiaNhapVTPT.Clear();
                        textBoxTenVTPT.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại Vật tư phụ tùng này trong phiếu nhập", "Cảnh báo");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTenVTPT.Text))
            {
                MessageBox.Show("Vui lòng nhập tên VTPT.", "Cảnh báo");
                return;
            }
            else
            {
                if (textBoxSoLuongVTPT.Text == "")
                {
                    MessageBox.Show("Vui lòng điền số lượng.", "Cảnh báo");
                }
                else
                {
                    if (textBoxDonGiaNhapVTPT.Text == "")
                        MessageBox.Show("Vui lòng nhập đơn giá nhập.", "Cảnh báo");
                    else
                    {
                        string tenvtpt = textBoxTenVTPT.Text;
                        int soluong = int.Parse(textBoxSoLuongVTPT.Text);
                        int dongianhap = int.Parse(textBoxDonGiaNhapVTPT.Text);
                        if (string.IsNullOrEmpty(tenvtpt))
                        {
                            MessageBox.Show("Vui lòng nhập tên VTPT.", "Cảnh báo");
                            return;
                        }
                        else
                        {
                            if (PhieuNhapVTPTBUS.Instance.KiemTraMaTonTai(this._mapn, tenvtpt))
                            {
                                if (MessageBox.Show("Bạn muốn sửa VTPT này?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    PhieuNhapVTPTBUS.Instance.SuaVTPTTrongPN(this._mapn, tenvtpt, soluong, dongianhap);
                                    PhieuNhapVTPTBUS.Instance.UpdateDonGiaBan(tenvtpt);
                                    dataGridViewPhieuNhapVTPT.DataSource = PhieuNhapVTPTBUS.Instance.HienThiDSVTPTTrongPhieuNhap(this._mapn);
                                    dataGridViewPhieuNhapVTPT.Show();
                                    txtThanhTienPN.Text = (PhieuNhapVTPTBUS.Instance.TinhThanhTienPN(this._mapn)).ToString();
                                    textBoxTenVTPT.Clear();
                                    textBoxSoLuongVTPT.Clear();
                                    textBoxDonGiaNhapVTPT.Clear();
                                    textBoxTenVTPT.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không tồn tại Vật tư phụ tùng này trong phiếu nhập", "Cảnh báo");
                            }
                        }
                    }
                }
            }
            
        }

        private void fPhieuNhapVTPT_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (PhieuNhapVTPTBUS.Instance.HienThiDSVTPTTrongPhieuNhap(this._mapn).Rows.Count == 0)
            {
                if (MessageBox.Show("Phiếu nhập này rỗng. Bạn có chắc chắn muốn tắt?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Xoa phieu nhap
                    int temp = PhieuNhapVTPTBUS.Instance.XoaPhieuNhap(this._mapn);
                    //Dong phieu nhap
                    if (temp <= 0)
                    {
                        MessageBox.Show("Có lỗi xảy ra", "Cảnh báo");
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Bạn đã hoàn thành phiếu nhập này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    PhieuNhapVTPTBUS.Instance.UpdateThanhTienVaoPN(this._mapn);
                }
            }
        }
    }
}