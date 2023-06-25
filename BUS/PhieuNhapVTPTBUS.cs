using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class PhieuNhapVTPTBUS
    {
        private static PhieuNhapVTPTBUS instance;
        private PhieuNhapVTPTBUS() { }
        public static PhieuNhapVTPTBUS Instance
        {
            get { if (instance == null) instance = new PhieuNhapVTPTBUS(); return instance; }
            private set { PhieuNhapVTPTBUS.instance = value; }
        }
        private int _mapnvtpt;
        public int Mapnvtpt { get {  return _mapnvtpt; } set { _mapnvtpt = value; } }
        public int TuDongTaoMaPN()
        {
            return PhieuNhapVTPTDAO.Instance.TuDongTaoMaPN();
        }
        public int NhapVTPT(int mapnvtpt, string ten, int soluong, int dongianhap)
        {
            return PhieuNhapVTPTDAO.Instance.NhapVTPT(mapnvtpt, ten, soluong, dongianhap);
        }
        public int NhapMoiVTPT(int mapnvtpt, string ten, int soluong, int dongianhap)
        {
            return PhieuNhapVTPTDAO.Instance.NhapMoiVTPT(mapnvtpt, ten, soluong, dongianhap);
        }

        public DataTable CacVTPTDaTiepNhan()
        {
            return PhieuNhapVTPTDAO.Instance.CacVTPTDaTiepNhan();
        }

        public DataTable LamMoiDanhSachVTPT()
        {
            return PhieuNhapVTPTDAO.Instance.LamMoiDanhSachVTPT();
        }

        public bool DeleteVTPT(int mavtpt)
        {
            return PhieuNhapVTPTDAO.Instance.DeleteVTPT(mavtpt);

        }
        public DataTable CapNhatDSVTPTNhap(int mapnvtpt, string tenvtpt, int soluong, int dongianhap)
        {
            return PhieuNhapVTPTDAO.Instance.CapNhatDSVTPTNhap(mapnvtpt, tenvtpt, soluong, dongianhap);
        }
        public bool KiemTraMaTonTai(int maPNVTPT, string tenVTPT)
        {
            return PhieuNhapVTPTDAO.Instance.KiemTraMaTonTai(maPNVTPT, tenVTPT);
        }
        public DataTable LapDSPhieuNhapVTPT()
        {
            return PhieuNhapVTPTDAO.Instance.LapDSPhieuNhapVTPT();
        }
        public DataTable HienThiDSVTPTTrongPhieuNhap(int mapn)
        {
            return PhieuNhapVTPTDAO.Instance.HienThiDSVTPTTrongPhieuNhap(mapn);
        }
        public int XoaPhieuNhap(int mapn)
        {
            return PhieuNhapVTPTDAO.Instance.XoaPhieuNhap(mapn);
        }

        public int XoaVTPTTrongPN(int mapn, string tenvtpt)
        {
            return PhieuNhapVTPTDAO.Instance.XoaVTPTTrongPN(mapn, tenvtpt);
        }
        public int TinhThanhTienPN(int mapn)
        {
            return PhieuNhapVTPTDAO.Instance.TinhThanhTienPN(mapn);
        }
        public int SuaVTPTTrongPN(int mapn, string tenvtpt, int soluong, int dongianhap)
        {
            return PhieuNhapVTPTDAO.Instance.SuaVTPTTrongPN(mapn, tenvtpt, soluong, dongianhap);
        }
        public int UpdateThanhTienVaoPN(int mapn)
        {
            return PhieuNhapVTPTDAO.Instance.UpdateThanhTienVaoPN(mapn);
        }
        public int UpdateDonGiaBan(string tenvtpt)
        {
            return PhieuNhapVTPTDAO.Instance.UpdateDonGiaBan(tenvtpt);
        }
    }
}
