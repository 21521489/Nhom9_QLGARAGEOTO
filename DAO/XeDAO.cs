using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class XeDAO
    {
        private static XeDAO instance;
        public static XeDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new XeDAO();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        private XeDAO() { }

        public DataTable CacXeDaTiepNhan()
        {
            string query = "SELECT BienSo AS 'Biển số', TenHieuXe as 'Tên hiệu xe', TenKH as 'Tên khách hàng', DienThoai as 'Điện thoại', DiaChi as 'Địa chỉ' FROM XE, HIEUXE as HX, KHACHHANG as KH WHERE XE.MaKH = KH.MaKH and XE.MaHX = HX.MaHX";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable SoXeTiepNhanTrongNgay(DateTime now)
        {
            string query = "SELECT COUNT(BienSo) FROM XE WHERE day(NgayTiepNhan) = " + now.Day + " and month(NgayTiepNhan) = " + now.Month + " and year(NgayTiepNhan) = " + now.Year;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable LamMoiDanhSachXe()
        {
            string query = "SELECT BienSo AS 'Biển số', TenHieuXe as 'Tên hiệu xe', TenKH as 'Tên khách hàng', DienThoai as 'Điện thoại', DiaChi as 'Địa chỉ' FROM XE, HIEUXE as HX, KHACHHANG as KH WHERE Xe.MaKH = KH.MaKH and Xe.MaHX = HX.MaHX";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable TimKiemTuongDoi(string DL)
        {
            string query = "TimKiemTuongDoi @DuLieu";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { DL });
        }

        public DataTable TimKiemChinhXac(string BienSo, string HieuXe)
        {
            string query = "TimKiemChinhXac @BienSo , @HieuXe";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { BienSo, HieuXe });
        }
        public int ThemXe(string BienSo, string HieuXe, int MaKH, DateTime now)
        {
            string query = "ThemXe @BienSo , @HieuXe , @NgayTiepNhan , @MaKH , @TienNo";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { BienSo, HieuXe, now, MaKH, 0 });
        }


        public DataTable TaoDataTable(int a, string[] name)//Tạo dt với số cột và nội dung từng cột
        {
            DataTable dt = new DataTable();
            dt.Clear();
            for (int i = 0; i < a; i++)
            {
                dt.Columns.Add(name[i]);
            }
            return dt;
        }

        public int XoaPTNXe(int maKH, string bienso)
        {
            string query = "EXEC XoaPTNXe @MaKH = "+ maKH +", @BienSo = '"+ bienso +"'";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public int LayMaKHTuXe(string bienso)
        {
            string query = "SELECT MaKH FROM XE WHERE BienSo = @bienso";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] {bienso});
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                return int.Parse(dt.Rows[0][0].ToString());
            }
            return -1;
        }

    }
}
