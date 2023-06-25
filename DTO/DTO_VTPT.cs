using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_VTPT
    {
        public DTO_VTPT(string maVTPT, string tenVTPT, int dongianhap, int dongiaban, int soluong)
        {
            this.MaVTPT = maVTPT;
            this.TenVTPT = tenVTPT;
            this.DonGiaNhap = dongianhap;
            this.DonGiaBan = dongiaban;
            this.SoLuong = soluong;
        }
        public DTO_VTPT(DataRow row)
        {
            this.MaVTPT = row["maVTPT"].ToString();
            this.TenVTPT = row["tenVTPT"].ToString();
            this.DonGiaNhap = (int)row["dongianhap"];
            this.DonGiaBan = (int)row["dongiaban"];
            this.SoLuong = (int)row["soluong"];

        }

        public string sMaVTPT;
        public string sTenVTPT;
        public int iDonGiaNhap;
        public int iDonGiaBan;
        public int iSoLuong;


        public string MaVTPT
        {
            get { return sMaVTPT; }
            set { sMaVTPT = value; }
        }

        public string TenVTPT
        {
            get { return sTenVTPT; }
            set { sTenVTPT = value; }
        }


        public int DonGiaNhap
        {
            get { return iDonGiaNhap; }
            set { iDonGiaNhap = value; }
        }

        public int DonGiaBan
        {
            get { return iDonGiaBan; }
            set { iDonGiaBan = value; }
        }

        public int SoLuong
        {
            get { return iSoLuong; }
            set { iSoLuong = value; }
        }

    }
}
