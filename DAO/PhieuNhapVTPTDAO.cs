using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PhieuNhapVTPTDAO
    {
        private int _mapnvtpt;
        public int Mapnvtpt { get { return _mapnvtpt; } set { _mapnvtpt = value; } }
        private static PhieuNhapVTPTDAO instance;
        private PhieuNhapVTPTDAO() { }
        public static PhieuNhapVTPTDAO Instance
        {
            get { if (instance == null) instance = new PhieuNhapVTPTDAO(); return instance; }
            private set { PhieuNhapVTPTDAO.instance = value; }
        }
        public int TuDongTaoMaPN()
        {
            int mapn = -1;
            string query = "EXEC TuDongTaoMaPN";
            DataProvider.Instance.ExecuteNonQuery(query);

            query = "SELECT MAX(MaPNVTPT) FROM PHIEUNHAPVTPT";
            object result = DataProvider.Instance.ExecuteScalar(query);

            if (result != null && result != DBNull.Value)
            {
                mapn = Convert.ToInt32(result);
            }

            return mapn;
        }
        public int DoiMaVTPT(string tenvtpt)
        {
            int mavtpt = 0;
            string query = "SELECT MaVTPT FROM VATTUPHUTUNG WHERE TenVTPT = @tenvtpt";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { tenvtpt });
            if (dt.Rows.Count > 0 && dt.Rows[0]["MaVTPT"] != DBNull.Value)
            {
                mavtpt = int.Parse(dt.Rows[0]["MaVTPT"].ToString());
            }
            return mavtpt;
        }

        public int NhapVTPT(int mapn, string ten, int soluong, int dongianhap)
        {
            string query = "EXEC NhapVTPT @MPNVTPT = " + mapn + " , @TenPhuTung = N'" + ten + "', @SoLuong = " + soluong + ", @DonGiaNhap = " + dongianhap;
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public int NhapMoiVTPT(int mapn, string ten, int soluong, int dongianhap)
        {
            string query = "EXEC NhapMoiVTPT @MPNVTPT = " + mapn + " , @TenPhuTung = N'" + ten + "', @SoLuong = " + soluong + ", @DonGiaNhap = " + dongianhap;
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public DataTable CacVTPTDaTiepNhan()
        {
            string query = "SELECT TenVTPT as 'Tên VTPT', DonGiaNhap as 'Đơn giá nhập', DonGiaBan as 'Đơn giá bán', SoLuong as 'Số Lượng' FROM VATTUPHUTUNG";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable LamMoiDanhSachVTPT()
        {
            string query = "INSERT TenVTPT as 'Tên VTPT', DonGiaNhap as 'Đơn giá nhập', DonGiaBan as 'Đơn giá bán', SoLuong as 'Số Lượng' FROM VATTUPHUTUNG";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool DeleteVTPT(int mavtpt)
        {
            string query = "XoaVTPT @MaVTPT";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { mavtpt});
            return result > 0;
        }


        public DataTable CapNhatDSVTPTNhap(int mapnvtpt, string tenvtpt, int soluong, int dongianhap)
        {
            int result;
            int KiemTra = 0;
            string query = "SELECT COUNT(MAVTPT) FROM VATTUPHUTUNG WHERE TenVTPT = @TenVTPT";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { tenvtpt });
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                KiemTra = int.Parse(dt.Rows[0][0].ToString());
            }
            if (KiemTra > 0)
            {
                result = NhapVTPT(mapnvtpt, tenvtpt, soluong, dongianhap);
            }
            else
            {
                result = NhapMoiVTPT(mapnvtpt, tenvtpt, soluong, dongianhap);
            }
            if (result == 0)
            {
                return null;
            }
            return HienThiDSVTPTTrongPhieuNhap(mapnvtpt);
        }
        public bool KiemTraMaTonTai(int maPNVTPT, string tenVTPT)
        {
            string query = "SELECT COUNT(*) FROM VATTUPHUTUNG vtpt, CT_PHIEUNHAPVTPT ctpn WHERE MaPNVTPT = @MaPNVTPT AND TenVTPT = @TenVTPT AND vtpt.MaVTPT = ctpn.MaVTPT";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { maPNVTPT, tenVTPT });
            int count = Convert.ToInt32(result);
            return count > 0;
        }


        public DataTable LapDSPhieuNhapVTPT()
        {
            string query = "SELECT MaPNVTPT as 'Mã phiếu', ThanhTienPN as 'Thành tiền', ThoiDiem as 'Thời điểm' FROM PHIEUNHAPVTPT";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }

        public DataTable HienThiDSVTPTTrongPhieuNhap(int mapn)
        {
            string query = "SELECT TenVTPT as 'Tên VTPT', ctpn.DonGiaNhap as 'Đơn giá nhập', ctpn.SoLuong as 'Số Lượng' FROM VATTUPHUTUNG vtpt, CT_PHIEUNHAPVTPT ctpn WHERE vtpt.MaVTPT = ctpn.MaVTPT AND ctpn.MaPNVTPT = " + mapn;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public int XoaPhieuNhap(int mapn)
        {
            string query = "DELETE FROM PHIEUNHAPVTPT WHERE MaPNVTPT =" + mapn;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result;
        }

        public int XoaVTPTTrongPN(int mapn, string tenvtpt)
        {
            string query = "EXEC XoaVTPTTrongPN @MaPN = " + mapn + " , @TenVTPT = N'" + tenvtpt + "'";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public int TinhThanhTienPN(int mapn)
        {
            int result = 0;
            string query = "SELECT SUM(DonGiaNhap * SoLuong) FROM CT_PHIEUNHAPVTPT WHERE MaPNVTPT = " + mapn;
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                result = int.Parse(dt.Rows[0][0].ToString());
            }

            return result;
        }
        public int SuaVTPTTrongPN(int mapn, string tenvtpt, int soluong, int dongianhap)
        {
            int result = XoaVTPTTrongPN(mapn, tenvtpt);
            DataTable dt = CapNhatDSVTPTNhap(mapn, tenvtpt, soluong, dongianhap);
            return dt.Rows.Count;
        }
        public int UpdateThanhTienVaoPN(int mapn)
        {
            string query = "UPDATE PhieuNhapVTPT SET ThanhTienPn = " + TinhThanhTienPN(mapn) + "WHERE MaPNVTPT = @mapn";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mapn });
        }
        public int UpdateDonGiaBan(string tenvtpt)
        {
            float tile = 0;
            int mavtpt = DoiMaVTPT(tenvtpt);
            string query = "SELECT GiaTri FROM THAMSO WHERE TenThamSo = N'Phần trăm tỉ lệ giá bán'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0 && dt.Rows[0]["GiaTri"] != DBNull.Value)
            {
                tile = (float)int.Parse(dt.Rows[0]["GiaTri"].ToString()) / 100;
            }
            query = "UPDATE VATTUPHUTUNG SET DonGiaBan = " + tile + " * DonGiaNhap WHERE MAVTPT = @mavtpt";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mavtpt });
        }
    }
}
