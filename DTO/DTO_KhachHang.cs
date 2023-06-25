using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_KhachHang
    {
        public DTO_KhachHang(int makh, string tenkh, string dienthoai, string diachi)
        {
            this.iMaKH = makh;
            this.sTenKH = tenkh;
            this.sDienThoai = dienthoai;
            this.sDiaChi = diachi;
        }
        public DTO_KhachHang(DataRow row)
        {
            this.iMaKH = (int)row["makh"];
            this.sTenKH = row["tenkh"].ToString();
            this.sDienThoai = row["dienthoai"].ToString();
            this.sDiaChi = row["diachi"].ToString();
        }

        public int iMaKH;
        public string sTenKH;
        public string sDienThoai;
        public string sDiaChi;

        public int MaKH
        {
            get { return iMaKH; }
            set { iMaKH = value; }
        }
        public string TenKH
        {
            get { return sTenKH; }
            set { sTenKH = value; }
        }
        public string DienThoai
        {
            get { return sDienThoai; }
            set { sDienThoai = value; }
        }
        public string DiaChi
        {
            get { return sDiaChi; }
            set { sDiaChi = value; }
        }

    }
}
