using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class HieuXeDAO
    {
        private static HieuXeDAO instance;
        private HieuXeDAO() { }
        public static HieuXeDAO Instance
        {
            get { if (instance == null) instance = new HieuXeDAO(); return instance; }
            private set { HieuXeDAO.instance = value; }
        }

        public int NhapMoiHX(string ten, DateTime now)
        {
            string query = "NhapMoiHX @TenHieuXe , @ThoiDiem";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ten, now });
        }
        public DataTable LayThongTinHX()
        {
            string query = "SELECT TenHieuXe as 'Tên hiệu xe' FROM HIEUXE";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable LamMoiDanhSachHX()
        {
            string query = "SELECT TenHieuXe as 'Tên hiệu xe' FROM HIEUXE";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable HieuXeHienTai()
        {
            string query = "SELECT TenHieuXe as 'Tên hiệu xe' FROM HIEUXE";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool DeleteHX(string tenHX)
        {
            string query = "XoaHX @TenHX";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { tenHX });
            return result > 0;
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
        public int KiemTraMaTonTaiHX(string tenHX)
        {
            string query = "SELECT MaHX FROM HIEUXE WHERE TenHieuXe = '" + tenHX + "'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                return int.Parse(dt.Rows[0][0].ToString());
            }
            return -1;
        }
    }
}
