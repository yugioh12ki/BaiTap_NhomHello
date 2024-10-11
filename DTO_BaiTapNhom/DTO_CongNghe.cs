using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_BaiTapNhom
{
    public class DTO_CongNghe:DTO_cDeTai,IHoTroKinhPhi
    {
        #region ThuocTinh

        private string moiTruong;
        public string MoiTruong 
        {
            get {  return moiTruong; }
            set { if (moiTruong == "web" || moiTruong == "mobile" || moiTruong == "window") moiTruong = value;
                else throw new ArgumentException("Môi Trường phải là web, mobile, window");            
            } 
        }


        #endregion ThuocTinh
        #region method

        public DTO_CongNghe(string maDeTai, string tenDeTai, int kinhPhi, string truongNhom, string ngayBatDau, string ngayKetThuc, string hoTenGV,string mt) : base(maDeTai, tenDeTai, kinhPhi, truongNhom, ngayBatDau, ngayKetThuc, hoTenGV)
        {
            this.moiTruong = mt;
        }

        public DTO_CongNghe()
        {
        }

        public override double TinhKinhPhi()
        {
            if (MoiTruong == "web" && MoiTruong == "mobile")
                KinhPhi = 15000000;
            else if (MoiTruong == "window")
                KinhPhi = 10000000;
            return KinhPhi;
            throw new NotImplementedException();
        }

        public int ITinhHoTro()
        {
            if (MoiTruong == "mobile")
                return 1000000;
            else if (MoiTruong == "web")
                return 800000;
            else if(MoiTruong == "window") return 500000;
            throw new NotImplementedException();
        }

        public void xuat()
        {
            throw new NotImplementedException();
        }

        public void nhap()
        {
            throw new NotImplementedException();
        }

        #endregion method
    }
}
