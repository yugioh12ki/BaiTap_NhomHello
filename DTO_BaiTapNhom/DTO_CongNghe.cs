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
            set
            {
                if (value == "web" || value == "mobile" || value == "window")
                    moiTruong = value;
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
            else if(MoiTruong == "window")
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

        public double CapNhatKinhPhi()
        {
            return KinhPhi += (KinhPhi * 0.1);
        }

        public override void Xuat()
        {
            TinhKinhPhi();
            string xuat = $"   {MaDeTai}";
            if (TenDeTai.Length < 20)
                xuat = xuat + $"\t{TenDeTai}\t{KinhPhi}";
            else
                xuat = xuat + $"\t{TenDeTai}   {KinhPhi}";
            if (TruongNhom.Length < 20 && HoTenGV.Length < 20)
                xuat = xuat + $"\t{TruongNhom}\t{HoTenGV}";
            else if (TruongNhom.Length > 20 && HoTenGV.Length > 20)
                xuat = xuat + $"  {TruongNhom}  {HoTenGV}";
            else
                xuat = xuat + $"  {TruongNhom}\t{HoTenGV}";
            xuat = xuat + $"\t{NgayBatDau}\t{NgayKetThuc}\t  {ITinhHoTro()}     \t\t {MoiTruong}";
            Console.WriteLine(xuat);
        }

        public void nhapCN()
        {
            base.Nhap();
            Console.WriteLine("Nhập môi trường phát triển cho đề tài công nghệ:");
            moiTruong = Console.ReadLine();
            TinhKinhPhi();
            throw new NotImplementedException();
        }

        #endregion method
    }
}
