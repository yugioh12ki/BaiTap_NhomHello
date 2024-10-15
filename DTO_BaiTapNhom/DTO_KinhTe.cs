using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_BaiTapNhom
{
    public class DTO_KinhTe : DTO_cDeTai, IHoTroKinhPhi
    {
        #region ThuocTinh

        private int soCauHoi;

        public int SoCauHoi { get => soCauHoi; set => soCauHoi = value; }

        #endregion ThuocTinh
        #region method

        public DTO_KinhTe(string maDeTai, string tenDeTai, int kinhPhi, string truongNhom, string ngayBatDau, string ngayKetThuc, string hoTenGV, int soCauHoi) : base(maDeTai, tenDeTai, kinhPhi, truongNhom, ngayBatDau, ngayKetThuc, hoTenGV)
        {
            this.soCauHoi = soCauHoi;
        }

        public DTO_KinhTe()
        {
            soCauHoi = 0;
        }

        public override double TinhKinhPhi()
        {
            if (soCauHoi > 100)
            {
                KinhPhi = 12000000;
            }
            else
            {
                KinhPhi = 7000000;
            }
            return KinhPhi;
            throw new NotImplementedException();
        }


        public double CapNhatKinhPhi()
        {
            return KinhPhi += (KinhPhi * 0.1);
        }

        public int ITinhHoTro()
        {
            if (soCauHoi > 100)
                return soCauHoi * 550;
            else
                return soCauHoi * 450;
            throw new NotImplementedException();
        }

        public override void Xuat()
        {
            string xuat = $"   {MaDeTai}";
            if (TenDeTai.Length < 20)
                xuat = xuat + $"\t{TenDeTai}\t\t{KinhPhi}";
            else
                xuat = xuat + $"\t{TenDeTai}\t{KinhPhi}";
            if (TruongNhom.Length < 20 && HoTenGV.Length < 20)
                xuat = xuat + $"\t{TruongNhom}\t{HoTenGV}";
            else if (TruongNhom.Length > 20 && HoTenGV.Length > 20)
                xuat = xuat + $"  {TruongNhom}  {HoTenGV}";
            else
                xuat = xuat + $"  {TruongNhom}\t{HoTenGV}";
            xuat = xuat + $"\t{NgayBatDau}\t{NgayKetThuc}\t   {ITinhHoTro()}  \t\t  {soCauHoi}";
            Console.WriteLine(xuat);
            //Console.WriteLine($"   {MaDeTai}\t{TenDeTai}\t\t{KinhPhi}\t{TruongNhom}\t{HoTenGV}" +
            //    $"\t {NgayBatDau}\t {NgayKetThuc}\t {SoCauHoi}\t {TinhKinhPhi()}\t {ITinhHoTro()}");
        }

        public void nhapKT()
        {
            base.Nhap();
            Console.WriteLine("Nhập số lượng câu hỏi của Đề Tài Kinh Tế: ");
            soCauHoi = Int32.Parse(Console.ReadLine());
            TinhKinhPhi();
            //throw new NotImplementedException();
        }


        #endregion method
    }
}
