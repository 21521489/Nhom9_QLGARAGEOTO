using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HieuXeBUS
    {
        private static HieuXeBUS instance;
        private HieuXeBUS() { }
        public static HieuXeBUS Instance
        {
            get { if (instance == null) instance = new HieuXeBUS(); return instance; }
            private set { HieuXeBUS.instance = value; }
        }
        public int NhapMoiHX(string ten, DateTime now)
        {
            return HieuXeDAO.Instance.NhapMoiHX(ten, now);
        }

        public bool DeleteTC(string TenHX)
        {
            return HieuXeDAO.Instance.DeleteHX(TenHX);

        }
        public DataTable HieuXeHienTai()
        {
            return HieuXeDAO.Instance.HieuXeHienTai();
        }
        public DataTable LamMoiDanhSachHX()
        {
            return HieuXeDAO.Instance.LamMoiDanhSachHX();
        }

        public string[] LayThongTinTC()
        {
            DataTable dt = HieuXeDAO.Instance.LayThongTinHX();
            string[] info = { dt.Rows[0][0].ToString() };
            return info;
        }

        public DataTable KhoiTaoDtHieuXe()
        {
            return TaoDataTable(1, new string[] { "Tên hiệu xe" });
        }

        public DataTable TaoDataTable(int a, string[] name)//Tạo dt với số cột và nội dung từng cột
        {
            return DAO.XeDAO.Instance.TaoDataTable(a, name);
        }

        public int KiemTraMaTonTaiHX(string tenHX)
        {
            return HieuXeDAO.Instance.KiemTraMaTonTaiHX(tenHX);
        }
    }
}
