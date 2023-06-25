using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;
        public static KhachHangDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhachHangDAO();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        private KhachHangDAO() { }
        public int ThemKhachHang(string ten, string sdt, string diachi)
        {
            string query = "ThemKhachHang @TenKH , @DienThoai , @DiaChi";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ten, sdt, diachi });
        }
        public DataTable LayMaKH(string ten, string sdt)
        {
            string query = "SELECT MaKH FROM KHACHHANG WHERE TenKH = '" + ten + "' and DienThoai = '" + sdt + "'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
