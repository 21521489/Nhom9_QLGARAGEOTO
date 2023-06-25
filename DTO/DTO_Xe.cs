using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Xe
    {
        public DTO_Xe(int makh, string bienso, string hieuxe, DateTime ngaytiepnhan, int tienno)
        {
            this.iMaKH = makh;
            this.sBienSo = bienso;
            this.sHieuXe = hieuxe;
            this.dtNgayTiepNhan = ngaytiepnhan;
            this.iTienNo = tienno;

        }
        public DTO_Xe(DataRow row)
        {
            this.iMaKH = (int)row["makh"];
            this.sBienSo = row["bienso"].ToString();
            this.sHieuXe = row["hieuxe"].ToString();
            //this.dtNgayTiepNhan = ngaytiepnhan;
            this.iTienNo = (int)row["tienno"];
        }


        public int iMaKH;
        public string sBienSo;
        public string sHieuXe;
        public DateTime dtNgayTiepNhan;
        public int iTienNo;


        public int MaKH
        {
            get { return iMaKH; }
            set { iMaKH = value; }
        }

        public string BienSo
        {
            get { return sBienSo; }
            set { sBienSo = value; }
        }

        public string HieuXe
        {
            get { return sHieuXe; }
            set { sHieuXe = value; }
        }

        public DateTime NgayTiepNhan
        {
            get { return dtNgayTiepNhan; }
            set { dtNgayTiepNhan = value; }
        }

        public int TienNo
        {
            get { return iTienNo; }
            set { iTienNo = value; }
        }

    }
}
