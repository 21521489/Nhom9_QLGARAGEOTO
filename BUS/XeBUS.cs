using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class XeBUS
    {
        private static XeBUS instance;
        public static XeBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new XeBUS();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        private XeBUS() { }

        public DataTable CacXeDaTiepNhan()
        {
            return XeDAO.Instance.CacXeDaTiepNhan();
        }

        public int SoXeTiepNhanTrongNgay(DateTime now)
        {
            DataTable dt = XeDAO.Instance.SoXeTiepNhanTrongNgay(now);
            return int.Parse(dt.Rows[0][0].ToString());
        }

        public DataTable LamMoiDanhSachXe()
        {
            return XeDAO.Instance.LamMoiDanhSachXe();
        }

        public DataTable TimKiemTuongDoi(string DuLieu)
        {
            return XeDAO.Instance.TimKiemTuongDoi(DuLieu);
        }

        public DataTable TimKiemChinhXac(string BienSo, string HieuXe)
        {
            return XeDAO.Instance.TimKiemChinhXac(BienSo, HieuXe);
        }

        public int ThemXe(string BienSo, string HieuXe, int MaKH, DateTime Now)
        {
            return XeDAO.Instance.ThemXe(BienSo, HieuXe, MaKH, Now);
        }
        public DataTable KhoiTaoDtTraCuu()
        {
            return TaoDataTable(6, new string[] { "Biển số", "Tên hiệu xe", "Tên khách hàng", "Mã phiếu sửa chữa hiện có", "Tổng tiền phiếu sửa chữa", "Tổng tiền nợ hiện tại" });
        }

        public DataTable TaoDataTable(int a, string[] name)//Tạo dt với số cột và nội dung từng cột
        {
            return DAO.XeDAO.Instance.TaoDataTable(a, name);
        }
        public int XoaPTNXe(int maKH, string bienso)
        {
            return XeDAO.Instance.XoaPTNXe(maKH, bienso);
        }
        public int LayMaKHTuXe(string bienso)
        {
            return XeDAO.Instance.LayMaKHTuXe(bienso);
        }
    }
}
