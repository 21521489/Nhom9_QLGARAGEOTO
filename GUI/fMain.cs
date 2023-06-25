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
    public partial class fMain : Form
    {
        DateTime now = DateTime.Now;

        public fMain()
        {
            InitializeComponent();
        }
        #region Parameters
        private bool btnHoanTatClicked = false;
        private bool textBoxTenVTPTMoi_TextChanged = false;
        private bool textBoxDonGiaNhapVTPT_TextChanged = false;
        private bool textBoxDonGiaBanVTPT_TextChanged = false;
        #endregion

        #region Methods
        void DoiDateTimePickerFormat(DateTimePicker dtp) //Ham thuc hien chuyen format DateTimePicker sang MM/yyyy.
        {
            dtp.CustomFormat = "MM/yyyy";
            dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtp.ShowUpDown = true;
        }

        string LayNgayThangNamHienTai() //Ham thuc hien lay ngay/thang/nam thoi diem hien tai.
        {
            return DateTime.Now.ToString("dd/MM/yyyy");
        }
        void DatThoiDiemHienTai(TextBox tb) //Ham dat noi dung textbox la thoi diem hien tai.
        {
            tb.Text = LayNgayThangNamHienTai();
        }
        void DatLaiDateTimePicker(DateTimePicker dtp) //Dat lai gia tri DatTimePicker thanh hom nay.
        {
            dtp.Value = DateTime.Now;
        }
        void DatVisibleChoControl(Control ctrl, bool result) //Dat thuoc tinh Visible cho Control.
        {
            ctrl.Visible = result;
        }

        void NhapVTPTChoPhieuSuaChua(int DonGia)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)dataGridViewVTPTPhieuSuaChua.DataSource;
            PhieuSuaChuaBUS.Instance.ThemHangVTPT(dt, comboBoxVTPTPhieuSuaChua.Text, textBoxSoLuongVTPTPhieuSuaChua.Text, DonGia, comboBoxVTPTPhieuSuaChua.SelectedValue.ToString());
        }

        void NhapTienCongChoPhieuSuaChua(int ChiPhi)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)dataGridViewTienCongPhieuSuaChua.DataSource;
            PhieuSuaChuaBUS.Instance.ThemHangTienCong(dt, PhieuSuaChuaBUS.Instance.LayNoiDungTienCong(comboBoxTienCongPhieuSuaChua.SelectedValue.ToString()), ChiPhi, comboBoxTienCongPhieuSuaChua.SelectedValue.ToString());
        }

        int TinhTongThanhTien()
        {
            int TongThanhTien = 0;
            foreach (DataGridViewRow row in dataGridViewVTPTPhieuSuaChua.Rows)
            {
                TongThanhTien += int.Parse(row.Cells["Thành tiền"].Value.ToString());
            }
            return TongThanhTien;
        }

        int TinhTongChiPhi()
        {
            int TongChiPhi = 0;
            foreach (DataGridViewRow row in dataGridViewTienCongPhieuSuaChua.Rows)
            {
                TongChiPhi += int.Parse(row.Cells["Chi phí"].Value.ToString());
            }
            return TongChiPhi;
        }

        void KhoiTaoDataGridviewVTPT()
        {
            dataGridViewVTPTPhieuSuaChua.DataSource = PhieuSuaChuaBUS.Instance.KhoiTaoDtVTPT();
            dataGridViewVTPTPhieuSuaChua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewVTPTPhieuSuaChua.AutoResizeColumns();

            //dataGridViewVTPTPhieuSuaChua.Columns["Mã phụ tùng"].Visible = false;
        }

        void KhoiTaoDataGridviewTienCong()
        {
            dataGridViewTienCongPhieuSuaChua.DataSource = PhieuSuaChuaBUS.Instance.KhoiTaoDtTienCong();
            dataGridViewTienCongPhieuSuaChua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTienCongPhieuSuaChua.AutoResizeColumns();

            //dataGridViewVTPTPhieuSuaChua.Columns["Mã tiền công"].Visible = false;
        }

        void KhoiTaoDataGridviewPSCHienCo(string BienSo)
        {
            dataGridViewPSCHienCo.DataSource = PhieuSuaChuaBUS.Instance.HienThiThongTinPhieuSuachua(BienSo);
            dataGridViewPSCHienCo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPSCHienCo.AutoResizeColumns();

        }

        void KhoiTaoDataGridviewTraCuu()
        {
            dataGridViewTraCuu.DataSource = XeBUS.Instance.KhoiTaoDtTraCuu();
            dataGridViewTraCuu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTraCuu.AutoResizeColumns();

        }
        void KhoiTaoDataGridviewHieuXe()
        {
            dataGridViewHX.DataSource = HieuXeBUS.Instance.KhoiTaoDtHieuXe();
            dataGridViewHX.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewHX.AutoResizeColumns();

        }

        void DatMacDinhChoComboBox(ComboBox a)//Thực hiện đặt giá trị mặc định cho comboBox để tránh lỗi.
        {
            a.SelectedItem = null;
            a.Text = "--select--";
        }

        bool QuyenHanAdmin()//Kiểm tra tài khoản hiện tại có phải là admin không
        {
            if (TaiKhoanBUS.Instance.LayQuyenHan().ToUpper() == "ADMIN")
                return true;
            return false;
        }

        void GioiHanQuyenHan()//Thực hiện giới hạn quyền hạn lên các tài khoản không phải là admin.
        {
            if (!QuyenHanAdmin())
            {
                tabControlChung.TabPages.Remove(tabControlChung.TabPages[2]);
                tabControl1.TabPages.Remove(tabControl1.TabPages[3]);
                tabControlChung.TabPages.Remove(tabControlChung.TabPages[1]);
            }
        }
        #endregion
        private void fMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyGarageDataSet.PHIEUNHAPVTPT' table. You can move, or remove it, as needed.
            this.pHIEUNHAPVTPTTableAdapter.Fill(this.quanLyGarageDataSet.PHIEUNHAPVTPT);
            // TODO: This line of code loads data into the 'quanLyGarageDataSet.CT_PHIEUNHAPVTPT' table. You can move, or remove it, as needed.
            this.cT_PHIEUNHAPVTPTTableAdapter.Fill(this.quanLyGarageDataSet.CT_PHIEUNHAPVTPT);
            // TODO: This line of code loads data into the 'quanLyGarageDataSet.HIEUXE' table. You can move, or remove it, as needed.
            this.hIEUXETableAdapter.Fill(this.quanLyGarageDataSet.HIEUXE);
            // TODO: This line of code loads data into the 'quanLyGarageDataSet.TIENCONG' table. You can move, or remove it, as needed.
            this.tIENCONGTableAdapter.Fill(this.quanLyGarageDataSet.TIENCONG);
            // TODO: This line of code loads data into the 'quanLyGarageDataSet.VATTUPHUTUNG' table. You can move, or remove it, as needed.
            this.vATTUPHUTUNGTableAdapter.Fill(this.quanLyGarageDataSet.VATTUPHUTUNG);
            // TODO: This line of code loads data into the 'quanLyGarageDataSet.KHACHHANG' table. You can move, or remove it, as needed.
            this.kHACHHANGTableAdapter.Fill(this.quanLyGarageDataSet.KHACHHANG);
            // TODO: This line of code loads data into the 'quanLyGarageDataSet.XE' table. You can move, or remove it, as needed.
            this.xETableAdapter.Fill(this.quanLyGarageDataSet.XE);
            GioiHanQuyenHan();
            // Lấy dữ liệu các xe đã tiếp nhận
            dataGridViewXeDaTiepNhan.DataSource = XeBUS.Instance.CacXeDaTiepNhan();
            dataGridViewXeDaTiepNhan.Show();
            //Lấy dữ liệu vật tư phụ tùng
            dataGridViewVTPTDaTiepNhan.DataSource = PhieuNhapVTPTBUS.Instance.CacVTPTDaTiepNhan();
            dataGridViewVTPTDaTiepNhan.Show();
            // Lấy thông tin cho progressbar số xe đã tiếp nhận 1 ngày
            //progressBarSoXeDaThem.Maximum = QuyDinhBUS.Instance.LaySoXeSuaToiDa();
            //progressBarSoXeDaThem.Value = XeBUS.Instance.SoXeTiepNhanTrongNgay(now);
            labelSoLuongXeCuaNgay.Text = "Số xe đã tiếp nhận hôm nay:   " + XeBUS.Instance.SoXeTiepNhanTrongNgay(now).ToString() + "/" + QuyDinhBUS.Instance.LaySoXeSuaToiDa();
            //Khởi tạo 1 dt để lưu lại các mã vtpt đã nhập và kiểm tra, so sánh số lượng nhập vào.
            PhieuSuaChuaBUS.Instance.KhoiTaoDtVTPTDangNhap();
            //Khởi tạo Datagridview Phiếu sửa chữa và tiền công
            KhoiTaoDataGridviewTienCong();
            KhoiTaoDataGridviewVTPT();
            KhoiTaoDataGridviewHieuXe();
            // Điển ngày thu tiền
            textBoxNgayThuTien.Text = now.ToString("dd-MM-yyyy");
            textBoxNgayTiepNhan.Text = now.ToString("dd-MM-yyyy");
            DatMacDinhChoComboBox(comboBoxBienSoXe1);
            //KiemTraDuLieuBaoCaoKhiLoad(DateTime.Now);
            dataGridViewBaoCaoTon.DataSource = BaoCaoTonBUS.Instance.KhoiTaoBaoCaoTon();
            dataGridViewBaoCaoTon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBaoCaoTon.AutoResizeColumns();
            DatThoiDiemHienTai(txtBoxNgaySuaChua);
            dateTimePickerChonThoiDiemBaoCaoTon.CustomFormat = "MM/yyyy";
            dateTimePickerChonThoiDiemBaoCaoTon.ShowUpDown = true;
            //Lấy quy định hiện hành
            dataGridViewQuyDinhHienHanh.DataSource = QuyDinhBUS.Instance.LayTatCaQuyDinh();
            dataGridViewQuyDinhHienHanh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewQuyDinhHienHanh.AutoResizeColumns();
            // Lấy dữ liệu các phiếu nhập
            dataGridViewPhieuNhap.DataSource = PhieuNhapVTPTBUS.Instance.LapDSPhieuNhapVTPT();
            dataGridViewPhieuNhap.Show();
            //Nhap Hx
            dataGridViewHX.DataSource = HieuXeBUS.Instance.LamMoiDanhSachHX();
            dataGridViewHX.Show();
            //QUAN LY VTPT
            DatMacDinhChoComboBox(comboBoxTenVTPT);
            DatMacDinhChoComboBox(comboBoxCTPNVTPT);
        }
        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            dataGridViewXeDaTiepNhan.DataSource = XeBUS.Instance.LamMoiDanhSachXe();
            dataGridViewXeDaTiepNhan.Show();
        }

        private void buttonThemXe_Click(object sender, EventArgs e)
        {
            if (txtBoxTenKH.Text.Length == 0)
                MessageBox.Show("Vui lòng nhập tên khách hàng!");
            else
            {
                if (txtBoxDienThoai.Text.Length == 0)
                    MessageBox.Show("Vui lòng nhập điện thoại của khách hàng!");
                else
                {
                    if (txtBoxDiaChi.Text.Length == 0)
                        MessageBox.Show("Vui lòng nhập địa chỉ khách hàng!");
                    else
                    {
                        if (txtBoxBienSo.Text.Length == 0)
                            MessageBox.Show("Vui lòng nhập biển số xe !");
                        else
                        {
                            int test = 0;
                            test = KhachHangBUS.Instance.ThemKhachHang(txtBoxTenKH.Text, txtBoxDienThoai.Text, txtBoxDiaChi.Text);      //thuc hien them khach hang moi
                            test = XeBUS.Instance.ThemXe(txtBoxBienSo.Text, comBoxHieuXe.SelectedValue.ToString(), KhachHangBUS.Instance.LayMaKH(txtBoxTenKH.Text, txtBoxDienThoai.Text), now);
                            if (test != 0)
                            {
                                MessageBox.Show("Thêm xe thành công!");
                                //progressBarSoXeDaThem.Value = progressBarSoXeDaThem.Value + 1;
                                labelSoLuongXeCuaNgay.Text = "Số xe đã tiếp nhận hôm nay:   " + XeBUS.Instance.SoXeTiepNhanTrongNgay(now).ToString() + "/" + QuyDinhBUS.Instance.LaySoXeSuaToiDa();
                                this.xETableAdapter.Fill(this.quanLyGarageDataSet.XE);
                                this.kHACHHANGTableAdapter.Fill(this.quanLyGarageDataSet.KHACHHANG);
                                dataGridViewXeDaTiepNhan.DataSource = XeBUS.Instance.LamMoiDanhSachXe();
                                dataGridViewXeDaTiepNhan.Show();
                            }
                            if (XeBUS.Instance.SoXeTiepNhanTrongNgay(now) == QuyDinhBUS.Instance.LaySoXeSuaToiDa())
                            {
                                txtBoxTenKH.Clear();
                                txtBoxDienThoai.Clear();
                                txtBoxDiaChi.Clear();
                                txtBoxBienSo.Clear();
                                txtBoxTenKH.Visible = false;
                                txtBoxDienThoai.Visible = false;
                                txtBoxDiaChi.Visible = false;
                                txtBoxBienSo.Visible = false;
                                buttonThemXe.Enabled = false;
                                buttonClear.Enabled = false;
                            }
                            else
                            {
                                txtBoxTenKH.Clear();
                                txtBoxDienThoai.Clear();
                                txtBoxDiaChi.Clear();
                                txtBoxBienSo.Clear();
                            }
                        }
                    }
                }
            }

        }

        private void comboBoxTenKhachHangDaTiepNhan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtBoxTenKH.Enabled = false;
            txtBoxDienThoai.Enabled = false;
            txtBoxDiaChi.Enabled = false;
            buttonLuuMoiTiepNhanXe.Visible = false;
        }

        private void comboBoxBienSoXe1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string bienso = comboBoxBienSoXe1.Text;
            KhoiTaoDataGridviewPSCHienCo(bienso);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            txtBoxTenKH.Clear();
            txtBoxDienThoai.Clear();
            txtBoxDiaChi.Clear();
            txtBoxBienSo.Clear();
        }

        private void btnInPhieuTiepNhanXeSua_Click(object sender, EventArgs e)
        {
            printDialogPTNXS.ShowDialog();

        }

        private void txtBoxNgaySuaChua_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonNhapVTPTPhieuSuaChua_Click(object sender, EventArgs e)
        {
            if (comboBoxVTPTPhieuSuaChua.SelectedValue == null)
            {
                MessageBox.Show("Chọn VTPT cần nhập", "Thông báo");
            }
            else
            {
                if (textBoxSoLuongVTPTPhieuSuaChua.Text == "")
                {
                    MessageBox.Show("Hãy nhập số lượng VTPT sử dụng.", "Cảnh báo");
                }
                else
                {
                    if (PhieuSuaChuaBUS.Instance.KiemTraSoLuong(comboBoxVTPTPhieuSuaChua.SelectedValue.ToString(), int.Parse(textBoxSoLuongVTPTPhieuSuaChua.Text)))
                    {
                        NhapVTPTChoPhieuSuaChua(PhieuSuaChuaBUS.Instance.LayDonGiaVTPT(comboBoxVTPTPhieuSuaChua.SelectedValue.ToString()));
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng kiểm tra lại số lượng vật tư phụ tùng! Kho không đủ đáp ứng", "Kho không đủ đáp ứng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void buttonNhapTienCongPhieuSuaChua_Click(object sender, EventArgs e)
        {
            NhapTienCongChoPhieuSuaChua(PhieuSuaChuaBUS.Instance.LayChiPhiTienCong(comboBoxTienCongPhieuSuaChua.SelectedValue.ToString()));

        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            int TongTien = 0;
            TongTien = TinhTongThanhTien() + TinhTongChiPhi();
            if (TongTien == 0)
            {
                MessageBox.Show("Chưa nhập VTPT", "Cảnh báo");
            }
            else
            {
                textBoxTongTienPhieuSuaChua.Text = TongTien.ToString();
                btnHoanTatClicked = true;
            }
        }

        private void btnLuuPSC_Click(object sender, EventArgs e)
        {
            if (comboBoxBienSoXe1.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn xe.", "Thông báo");
            }
            else
            {
                if (btnHoanTatClicked)
                {
                    PhieuSuaChuaBUS.Instance.LuuPhieuSuaChua(comboBoxBienSoXe1.Text, TinhTongChiPhi(), TinhTongThanhTien(), TinhTongChiPhi() + TinhTongThanhTien(), (DataTable)dataGridViewTienCongPhieuSuaChua.DataSource, (DataTable)dataGridViewVTPTPhieuSuaChua.DataSource);
                    PhieuSuaChuaBUS.Instance.CapNhatTienNo(comboBoxBienSoXe1.Text, int.Parse(textBoxTongTienPhieuSuaChua.Text));
                    MessageBox.Show("Đã lưu phiếu sửa chữa!", "Thành công!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PhieuSuaChuaBUS.Instance.NhapVTPT((DataTable)dataGridViewVTPTPhieuSuaChua.DataSource);
                    this.vATTUPHUTUNGTableAdapter.Fill(this.quanLyGarageDataSet.VATTUPHUTUNG);// update lai KHO cho phieusuachua lan sau 
                    this.cT_PHIEUNHAPVTPTTableAdapter.Fill(this.quanLyGarageDataSet.CT_PHIEUNHAPVTPT);
                }
                else
                {
                    MessageBox.Show("Xin vui lòng nhấn Hoàn tất trước khi lưu phiếu sửa chữa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnInPhieuSuaChua_Click(object sender, EventArgs e)
        {
            printDialogPSC.ShowDialog();

        }

        private void btnTaoMoiPCS_Click(object sender, EventArgs e)
        {
            comboBoxBienSoXe1.Text = "";
            comboBoxVTPTPhieuSuaChua.Text = "";
            comboBoxTienCongPhieuSuaChua.Text = "";
            textBoxSoLuongVTPTPhieuSuaChua.Text = "";
            textBoxTongTienPhieuSuaChua.Text = "";
            KhoiTaoDataGridviewVTPT();
            KhoiTaoDataGridviewTienCong();
            PhieuSuaChuaBUS.Instance.XoaDtVTPTDangNhap();
            btnHoanTatClicked = false;
            DatMacDinhChoComboBox(comboBoxBienSoXe1);
        }
        private void buttonLapPhieuNhapVTPT_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            fPhieuNhapVTPT fPhieuNhapVTPT = new fPhieuNhapVTPT();
            fPhieuNhapVTPT.ShowDialog();
            this.Visible = true;
            this.vATTUPHUTUNGTableAdapter.Fill(this.quanLyGarageDataSet.VATTUPHUTUNG);
            this.pHIEUNHAPVTPTTableAdapter.Fill(this.quanLyGarageDataSet.PHIEUNHAPVTPT);
            dataGridViewPhieuNhap.DataSource = PhieuNhapVTPTBUS.Instance.LapDSPhieuNhapVTPT();
            dataGridViewPhieuNhap.Show();
            dataGridViewVTPTDaTiepNhan.DataSource = PhieuNhapVTPTBUS.Instance.CacVTPTDaTiepNhan();
            dataGridViewXeDaTiepNhan.Show();
            DatMacDinhChoComboBox(comboBoxTenVTPT);
            DatMacDinhChoComboBox(comboBoxCTPNVTPT);
        }
        private void buttonInPhieuNhapVTPT_Click(object sender, EventArgs e)
        {
            printDialogPhieuNhapVTPT.ShowDialog();
        }

        private void btnShowVTPT_Click(object sender, EventArgs e)
        {
            dataGridViewVTPTDaTiepNhan.DataSource = PhieuNhapVTPTBUS.Instance.CacVTPTDaTiepNhan();
            dataGridViewXeDaTiepNhan.Show();
        }

        private void comboBoxVTPTPhieuSuaChua_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBoxSoLuongVTPTPhieuSuaChua.Text = "";
        }

        private void buttonLapPhieuThuTienPTT_Click(object sender, EventArgs e)
        {
            if (textBoxSoTienThuPTT.Text != "")
            {
                if (PhieuThuTienBUS.Instance.LayTienNoKH(comboBienSoXe2.Text) < int.Parse(textBoxSoTienThuPTT.Text))
                    MessageBox.Show("Vui lòng nhập lại tiền thu!");
                else
                {
                    int test = 0;
                    test = PhieuThuTienBUS.Instance.ThemPhieuThuTien(comboBienSoXe2.Text, textBoxSoTienThuPTT.Text, now);
                    if (test != 0)
                        MessageBox.Show("Thêm Phiếu Thu Tiền thành công!");

                }
            }
            else
                MessageBox.Show("Vui lòng nhập số tiền thu !");
        }

        private void buttonPhieuThuTienMoiPTT_Click(object sender, EventArgs e)
        {
            textBoxDienThoaiPTT.Clear();
            textBoxDiaChiPTT.Clear();
            textBoxHoTenChuXePTT.Clear();
            textBoxSoTienThuPTT.Clear();
            DateTime now = DateTime.Now;
            textBoxNgayThuTien.Text = now.ToString("dd-MM-yyyy");
        }

        private void buttonInPhieuThuTienPTT_Click(object sender, EventArgs e)
        {
            printDialogPTT.ShowDialog();

        }

        private void comboBienSoXe2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string[] info = PhieuThuTienBUS.Instance.LayThongTinKH(comboBienSoXe2.Text);        //du lieu tra ve: { ten, dien thoai, dia chi}
            textBoxHoTenChuXePTT.Text = info[0];
            textBoxDienThoaiPTT.Text = info[1];
            textBoxDiaChiPTT.Text = info[2];
        }


        private void radioButtonTimTuongDoi_CheckedChanged(object sender, EventArgs e)
        {
            DatVisibleChoControl(flowLayoutPanelTimChinhXac, false);
            lblTraCuuChinh.Visible = true;
            textBoxTraCuuChinh.Visible = true;
        }

        private void radioButtonTimChinhXac_CheckedChanged(object sender, EventArgs e)
        {
            DatVisibleChoControl(flowLayoutPanelTimChinhXac, true);
            lblTraCuuChinh.Visible = false;
            textBoxTraCuuChinh.Visible = false;
        }

        private void btnTimKiemTraCuu_Click(object sender, EventArgs e)
        {
            if (radioButtonTimTuongDoi.Checked == true)
            {
                if (textBoxTraCuuChinh.Text == "")
                    MessageBox.Show("Nhập từ khóa tìm kiếm !");
                else
                {
                    dataGridViewTraCuu.DataSource = XeBUS.Instance.TimKiemTuongDoi(textBoxTraCuuChinh.Text);
                    dataGridViewTraCuu.Show();
                }
            }
            else
            {
                if (txtBoxBienSoTraCuu.Text == "")
                    MessageBox.Show("Nhập từ khóa tìm kiếm !");
                else
                {
                    dataGridViewTraCuu.DataSource = XeBUS.Instance.TimKiemChinhXac(txtBoxBienSoTraCuu.Text, comboBoxHieuXeTraCuu.Text);
                    dataGridViewTraCuu.Show();
                }
            }
        }

        private void btnDatLaiTraCuu_Click(object sender, EventArgs e)
        {
            textBoxTraCuuChinh.Text = "";
            txtBoxBienSoTraCuu.Text = "";
            comboBoxHieuXeTraCuu.Text = "";
        }

        private void btnLapBaoCaoDoanhSo_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxThangBaoCao.Text, out int thang))
            {
                MessageBox.Show("Vui lòng nhập tháng là một số nguyên dương từ 1 -> 12.", "Cảnh báo");
                textBoxThangBaoCao.Text = string.Empty;
                textBoxThangBaoCao.Focus();
            }
            else
            {
                if (int.Parse((textBoxThangBaoCao.Text).ToString()) < 1 || int.Parse((textBoxThangBaoCao.Text).ToString()) > 12)
                {
                    MessageBox.Show("Tháng phải từ 1 -> 12", "Cảnh báo", MessageBoxButtons.OK);
                    textBoxThangBaoCao.Text = string.Empty;
                    textBoxThangBaoCao.Focus();
                }
                else
                {
                    if (!int.TryParse(textBoxNamBaoCao.Text, out int nam))
                    {
                        MessageBox.Show("Vui lòng nhập năm.", "Cảnh báo");
                        textBoxNamBaoCao.Text = string.Empty;
                        textBoxNamBaoCao.Focus();
                    }
                    else
                    {
                        dataGridViewBaoCaoDoanhSo.DataSource = BaoCaoDoanhThuBUS.Instance.BaoCaoDoanhThu(textBoxThangBaoCao.Text, textBoxNamBaoCao.Text);
                        dataGridViewBaoCaoDoanhSo.Show();
                        textBoxTongDoanhThu.Text = BaoCaoDoanhThuBUS.Instance.TongTienDoanhThu(textBoxThangBaoCao.Text, textBoxNamBaoCao.Text);
                    }
                }
            }
        }

        private void btnBaoCaoDoanhSoMoi_Click(object sender, EventArgs e)
        {
            textBoxThangBaoCao.Clear();
            textBoxNamBaoCao.Clear();
            textBoxTongDoanhThu.Clear();
            BaoCaoDoanhThuBUS.Instance.TaoBaoCaoMoi((DataTable)dataGridViewBaoCaoDoanhSo.DataSource);
        }

        private void btnLapBaoCaoTon_Click(object sender, EventArgs e)
        {
            // if (BaoCaoTonDAO.Instance.KiemTraThoiDiem(dateTimePickerChonThoiDiemBaoCaoTon.Value))
            //{
            lblThangBaoCaoTon.Text = "Tháng " + dateTimePickerChonThoiDiemBaoCaoTon.Value.ToString("MM/yyyy");
            dataGridViewBaoCaoTon.DataSource = BaoCaoTonBUS.Instance.TaoBaoCaoTon(dateTimePickerChonThoiDiemBaoCaoTon.Value);
            //}
        }

        private void btnBaoCaoTonMoi_Click(object sender, EventArgs e)
        {
            DatLaiDateTimePicker(dateTimePickerChonThoiDiemBaoCaoTon);
            lblThangBaoCaoTon.Text = "Tháng";
            BaoCaoTonBUS.Instance.TaoBaoCaoMoi((DataTable)dataGridViewBaoCaoTon.DataSource);
            dateTimePickerChonThoiDiemBaoCaoTon.CustomFormat = "MM/yyyy";
            dateTimePickerChonThoiDiemBaoCaoTon.ShowUpDown = true;
        }

        private void btnCapNhatSoXeSuaToiDa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBoxSoXeSuaChuaToiDa.Text, out int SoXeToiDa) || SoXeToiDa < 1)
            {
                MessageBox.Show("Vui lòng nhập một số nguyên dương.", "Cảnh báo");
                txtBoxSoXeSuaChuaToiDa.Text = string.Empty;
                txtBoxSoXeSuaChuaToiDa.Focus();
            }
            else
            {
                int test = BUS.QuyDinhBUS.Instance.CapNhatSoXeSuaToiDa(txtBoxSoXeSuaChuaToiDa.Text);
                if (test != 0)
                {
                    MessageBox.Show("Thay đổi số xe sửa tối đa thành công !");
                    txtBoxSoXeSuaChuaToiDa.Clear();
                    dataGridViewQuyDinhHienHanh.DataSource = BUS.QuyDinhBUS.Instance.LayTatCaQuyDinh();
                    dataGridViewQuyDinhHienHanh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }

        private void buttonLamMoiQuyDinh_Click(object sender, EventArgs e)
        {
            dataGridViewQuyDinhHienHanh.DataSource = BUS.QuyDinhBUS.Instance.LayTatCaQuyDinh();
            dataGridViewQuyDinhHienHanh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnCapNhatPhanTramTiLeGiaBan_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBoxPhanTramTiLeGiaBan.Text, out int SoXeToiDa) || SoXeToiDa < 1)
            {
                MessageBox.Show("Vui lòng nhập một số nguyên dương.", "Cảnh báo");
                txtBoxPhanTramTiLeGiaBan.Text = string.Empty;
                txtBoxPhanTramTiLeGiaBan.Focus();
            }
            else
            {
                int test = BUS.QuyDinhBUS.Instance.CapNhatPhanTramTiLeGiaBan(txtBoxPhanTramTiLeGiaBan.Text);
                if (test != 0)
                {
                    MessageBox.Show("Thay đổi phần trăm tỉ lệ giá bán thành công !");
                    txtBoxPhanTramTiLeGiaBan.Clear();
                    dataGridViewQuyDinhHienHanh.DataSource = BUS.QuyDinhBUS.Instance.LayTatCaQuyDinh();
                    dataGridViewQuyDinhHienHanh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongTinTaiKhoan tttk = new fThongTinTaiKhoan();
            tttk.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void LamMoi_comboBoxTenVTPT()
        {
            DataTable tbl_tenVTPT = new DataTable();
            tbl_tenVTPT = DataProvider.Instance.ExecuteQuery("SELECT TenVTPT FROM VATTUPHUTUNG");
            comboBoxTenVTPT.DataSource = tbl_tenVTPT;
            comboBoxTenVTPT.DisplayMember = "TenVTPT";
            comboBoxTenVTPT.ValueMember = "TenVTPT";
        }

        private void LamMoi_comboBoxVTPTPhieuSuaChua()
        {
            DataTable tbl_tenVTPT = new DataTable();
            tbl_tenVTPT = DataProvider.Instance.ExecuteQuery("SELECT TenVTPT FROM VATTUPHUTUNG");
            comboBoxVTPTPhieuSuaChua.DataSource = tbl_tenVTPT;
            comboBoxVTPTPhieuSuaChua.DisplayMember = "TenVTPT";
            comboBoxVTPTPhieuSuaChua.ValueMember = "TenVTPT";
        }
        private void btnXoaVTPT_Click(object sender, EventArgs e)
        {
            if (comboBoxTenVTPT.Text == "--select--")
            {
                MessageBox.Show("Chọn VTPT", "Cảnh báo");
            }
            else
            {
                if (PhieuNhapVTPTBUS.Instance.DeleteVTPT(int.Parse(comboBoxTenVTPT.SelectedValue.ToString())))
                {
                    MessageBox.Show("Xóa vật tư phụ tùng thành công!");
                    LamMoi_comboBoxTenVTPT();
                    comboBoxTenVTPT.Text = "";
                    LamMoi_comboBoxVTPTPhieuSuaChua();
                    btnLamMoiPhieuNhap_Click(sender, e);
                    btnShowVTPT_Click(sender, e);
                    this.vATTUPHUTUNGTableAdapter.Fill(this.quanLyGarageDataSet.VATTUPHUTUNG);
                    this.pHIEUNHAPVTPTTableAdapter.Fill(this.quanLyGarageDataSet.PHIEUNHAPVTPT);

                }
                else { MessageBox.Show("VTPT này có số lượng tồn > 0 hoặc đang được sử dụng.", "Cảnh báo"); }
            }
        }

        private void btnLamMoiPhieuNhap_Click(object sender, EventArgs e)
        {
            dataGridViewPhieuNhap.DataSource = PhieuNhapVTPTBUS.Instance.LapDSPhieuNhapVTPT();
            dataGridViewPhieuNhap.Show();
        }

        private void comboBoxTenVTPT_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int mavtpt;
            if (comboBoxTenVTPT.SelectedValue != null && int.TryParse(comboBoxTenVTPT.SelectedValue.ToString(), out mavtpt))
            {
                mavtpt = int.Parse(comboBoxTenVTPT.SelectedValue.ToString());
                string query = "SELECT TenVTPT as 'Tên VTPT', DonGiaNhap as 'Đơn giá nhập', DonGiaBan as 'Đơn giá bán', SoLuong as 'Số Lượng' FROM VATTUPHUTUNG WHERE MaVTPT = " + mavtpt;
                DataTable dt = DataProvider.Instance.ExecuteQuery(query);
                dataGridViewVTPTDaTiepNhan.DataSource = dt;
                dataGridViewVTPTDaTiepNhan.Show();
                query = "SELECT MaPNVTPT as 'Mã phiếu', TenVTPT as 'Tên VTPT', ctpn.DonGiaNhap as 'Đơn giá nhập', ctpn.SoLuong as 'Số Lượng' FROM VATTUPHUTUNG vtpt, CT_PHIEUNHAPVTPT ctpn WHERE vtpt.MaVTPT = ctpn.MaVTPT AND vtpt.MaVTPT = " + mavtpt;
                dt = DataProvider.Instance.ExecuteQuery(query);
                dataGridViewPhieuNhap.DataSource = dt;
                dataGridViewPhieuNhap.Show();
            }
            else
            {
                MessageBox.Show("selectedValue: " + comboBoxTenVTPT.SelectedValue);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 3)
            {
                btnLamMoiPhieuNhap_Click(sender, e);
                btnShowVTPT_Click(sender, e);
            }
        }

        private void comboBoxCTPNVTPT_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int mapn = int.Parse(comboBoxCTPNVTPT.SelectedValue.ToString());
            fChiTietPhieuNhap fChiTietPhieuNhap = new fChiTietPhieuNhap(mapn);
            fChiTietPhieuNhap.ShowDialog();
        }

        private void buttonLuuHieuXe_Click(object sender, EventArgs e)
        {
            if (textBoxTenHXMoi.Text == "")
                MessageBox.Show("Vui lòng nhập tên hiệu xe trước khi nhập mới hiệu xe !");
            else
            {
                if (HieuXeBUS.Instance.KiemTraMaTonTaiHX(textBoxTenHXMoi.Text.ToString()) >= 0)
                {
                    MessageBox.Show("Hiệu xe đã tồn tại");
                }
                else
                {
                    int test = 0;
                    test = HieuXeBUS.Instance.NhapMoiHX(textBoxTenHXMoi.Text, now);
                    if (test > 0)
                    {
                        MessageBox.Show("Nhập mới hiệu xe thành công");
                        this.hIEUXETableAdapter.Fill(this.quanLyGarageDataSet.HIEUXE);
                        dataGridViewHX.DataSource = HieuXeBUS.Instance.LamMoiDanhSachHX();
                        dataGridViewHX.Show();
                    }
                }
            }
        }

        private void buttonLamMoiHieuXe_Click(object sender, EventArgs e)
        {
            textBoxTenHXMoi.Clear();
            textBoxTenHXMoi.Enabled = true;
            buttonLuuHieuXe.Visible = true;
            buttonLamMoiHieuXe.Visible = true;
        }

        private void buttonLamMoiTC_Click(object sender, EventArgs e)
        {
            dataGridViewHX.DataSource = HieuXeBUS.Instance.LamMoiDanhSachHX();
            dataGridViewHX.Show();
        }

        private void buttonXoaTiepNhanXe_Click(object sender, EventArgs e)
        {
            string BienSo = txtBoxBienSo.Text;
            if (!int.TryParse(comboBoxTenKhachHangDaTiepNhan.SelectedValue.ToString(), out int makh))
            {
                MessageBox.Show("Chọn khách hàng cần xóa", "Cảnh báo");
            }
            else
            {
                if (string.IsNullOrEmpty(BienSo))
                {
                    MessageBox.Show("Điền biển số cho xe", "Cảnh báo");
                }
                else
                {
                    int result = XeBUS.Instance.XoaPTNXe(makh, BienSo);
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo");
                        labelSoLuongXeCuaNgay.Text = "Số xe đã tiếp nhận hôm nay:   " + XeBUS.Instance.SoXeTiepNhanTrongNgay(now).ToString() + "/" + QuyDinhBUS.Instance.LaySoXeSuaToiDa();
                        this.xETableAdapter.Fill(this.quanLyGarageDataSet.XE);
                        this.kHACHHANGTableAdapter.Fill(this.quanLyGarageDataSet.KHACHHANG);
                        dataGridViewXeDaTiepNhan.DataSource = XeBUS.Instance.LamMoiDanhSachXe();
                        dataGridViewXeDaTiepNhan.Show();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi", "Thông báo");
                    }
                }
            }
        }

        private void buttonSuaTiepNhanXe_Click(object sender, EventArgs e)
        {
            txtBoxTenKH.ReadOnly = false;
            txtBoxDiaChi.ReadOnly = false;
            txtBoxDienThoai.ReadOnly = false;
            if (txtBoxBienSo.Text == "")
            {
                MessageBox.Show("Vui lòng nhập biển số.", "Cảnh báo");
                txtBoxBienSo.Focus();
            }
            else
            {
                if (txtBoxTenKH.Text == "")
                {
                    MessageBox.Show("Nhập tên khách hàng vào ô khách hàng mới", "Cảnh báo");
                    txtBoxTenKH.Focus();
                }
                else
                {
                    if (txtBoxDienThoai.Text == "")
                    {
                        MessageBox.Show("Nhập số điện thoại", "Cảnh báo");
                        txtBoxDienThoai.Focus();
                    }
                    else
                    {
                        if (txtBoxDiaChi.Text == "")
                        {
                            MessageBox.Show("Nhập địa chỉ", "Cảnh báo");
                            txtBoxDiaChi.Focus();
                        }
                        else
                        {
                            if (XeBUS.Instance.LayMaKHTuXe(txtBoxBienSo.Text.ToString()) > -1)
                            {
                                XeBUS.Instance.XoaPTNXe(XeBUS.Instance.LayMaKHTuXe(txtBoxBienSo.Text.ToString()), txtBoxBienSo.Text.ToString());
                                KhachHangBUS.Instance.ThemKhachHang(txtBoxTenKH.Text, txtBoxDienThoai.Text, txtBoxDiaChi.Text);
                                XeBUS.Instance.ThemXe(txtBoxBienSo.Text, comBoxHieuXe.SelectedValue.ToString(), KhachHangBUS.Instance.LayMaKH(txtBoxTenKH.Text, txtBoxDienThoai.Text), now);
                                labelSoLuongXeCuaNgay.Text = "Số xe đã tiếp nhận hôm nay:   " + XeBUS.Instance.SoXeTiepNhanTrongNgay(now).ToString() + "/" + QuyDinhBUS.Instance.LaySoXeSuaToiDa();
                                MessageBox.Show("Sửa thành công.", "Cảnh báo");
                                this.xETableAdapter.Fill(this.quanLyGarageDataSet.XE);
                                this.kHACHHANGTableAdapter.Fill(this.quanLyGarageDataSet.KHACHHANG);
                                dataGridViewXeDaTiepNhan.DataSource = XeBUS.Instance.LamMoiDanhSachXe();
                                dataGridViewXeDaTiepNhan.Show();
                            }
                            else
                            {
                                MessageBox.Show("Chưa tiếp nhận xe này", "Cảnh báo");
                            }
                        }
                    }
                }
            }
        }
    }
}