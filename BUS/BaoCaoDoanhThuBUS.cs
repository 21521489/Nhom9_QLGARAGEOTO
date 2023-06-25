using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BaoCaoDoanhThuBUS
    {
        private static BaoCaoDoanhThuBUS instance;
        public static BaoCaoDoanhThuBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new BaoCaoDoanhThuBUS();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        private BaoCaoDoanhThuBUS() { }
        public void TaoBaoCaoMoi(DataTable a)//Xóa các hàng của báo cáo
        {
            a.Clear();
        }

        public DataTable BaoCaoDoanhThu(string Thang, string Nam)
        {
            return BaoCaoDoanhThuDAO.Instance.BaoCaoDoanhThu(int.Parse(Thang), int.Parse(Nam));
        }
        public string TongTienDoanhThu(string Thang, string Nam)
        {
            DataTable dt = BaoCaoDoanhThuDAO.Instance.TongTienDoanhThu(int.Parse(Thang), int.Parse(Nam));
            return dt.Rows[0][0].ToString();
        }
    }
}
