using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PhieuThuTienDAO
    {
        private static PhieuThuTienDAO instance;
        public static PhieuThuTienDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhieuThuTienDAO();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        private PhieuThuTienDAO() { }

        public DataTable LayTienNoKH(string BienSo)
        {
            string query = "SELECT TienNo from XE WHERE XE.BienSo = '" + BienSo + "'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public int ThemPhieuThuTien(string BienSo, int SoTienThu, DateTime now)
        {
            string query = " ThemPhieuThuTien @BienSo , @TienThu , @NgayThuTien";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { BienSo, SoTienThu, now });
        }

        public DataTable LayThongTinKH(string BienSo)
        {
            string query = "SELECT TenKH, DienThoai, DiaChi FROM KHACHHANG as KH, XE WHERE KH.MaKH = XE.MaKH and XE.BienSo = '" + BienSo + "'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable LayDanhSachXeCoTienNoLonHon0()
        {
            string query = "SELECT BienSo, TienNo FROM XE";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
