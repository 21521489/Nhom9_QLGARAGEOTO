using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class QuyDinhBUS
    {
        private static QuyDinhBUS instance;
        public static QuyDinhBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new QuyDinhBUS();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        private QuyDinhBUS() { }
        public DataTable LayTatCaQuyDinh()
        {
            return DAO.QuyDinhDAO.Instance.LayTatCaQuyDinh();
        }
        public int LayPhanTramTiLeGiaBan()
        {
            DataTable dt = QuyDinhDAO.Instance.LayPhanTramTiLeGiaBan();
            return int.Parse(dt.Rows[0][0].ToString());
        }
        public int CapNhatPhanTramTiLeGiaBan(string GiaTriMoi)
        {
            int gtm = int.Parse(GiaTriMoi);
            return DAO.QuyDinhDAO.Instance.CapNhatPhanTramTiLeGiaBan(gtm);
        }
        public int LaySoXeSuaToiDa()
        {
            DataTable dt = QuyDinhDAO.Instance.LaySoXeSuaToiDa();
            return int.Parse(dt.Rows[0][0].ToString());
        }
        public int CapNhatSoXeSuaToiDa(string GiaTriMoi)
        {
            int gtm = int.Parse(GiaTriMoi);
            return DAO.QuyDinhDAO.Instance.CapNhatSoXeSuaToiDa(gtm);
        }


    }
}
