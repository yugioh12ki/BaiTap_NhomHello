using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_BaiTapNhom
{
    public class DTO_NCLT : DTO_cDeTai
    {
        #region thuocTinh
        private bool is_thucTe;
        public bool Is_thucTe { get => is_thucTe; set => is_thucTe = value; }
        

        #endregion thuocTinh
        #region method

        public DTO_NCLT()
        {
            is_thucTe = false;
        }

        public DTO_NCLT(bool is_thucTe)
        {
            this.is_thucTe = is_thucTe;
        }

        public DTO_NCLT(string maDeTai, string tenDeTai, int kinhPhi, string truongNhom, string ngayBatDau, string ngayKetThuc, string hoTenGV, bool ktra) : base(maDeTai, tenDeTai, kinhPhi, truongNhom, ngayBatDau, ngayKetThuc, hoTenGV)
        {
            this.is_thucTe = ktra;
        }

        public override double TinhKinhPhi()
        {
            if (is_thucTe) return KinhPhi = 15000000;
            else return KinhPhi = 8000000;
            
            throw new NotImplementedException();
        }
        public double CapNhatKinhPhi()
        {
            return KinhPhi += (KinhPhi * 0.1);
        }

        public void nhapNCLT()
        {
            string check;
            base.Nhap();
            do {
                Console.WriteLine("Xác nhận có thực tế nghiên cứu lý thyết không (Y/N): ");
                check = Console.ReadLine();
            } while(check != "Y" && check != "N");
            if (check == "Y")
            {
                is_thucTe = true;
            }
            else is_thucTe = false;
            TinhKinhPhi();
            //throw new NotImplementedException();
        }

        public override void Xuat()
        {
            string xuat = $"   {MaDeTai}";
            if(TenDeTai.Length < 20 )
                xuat = xuat + $"\t{TenDeTai}\t\t{KinhPhi}";
            else
                xuat = xuat + $"\t{TenDeTai}\t  {KinhPhi}";
            if (TruongNhom.Length < 20 && HoTenGV.Length < 20)
                xuat = xuat + $"\t{TruongNhom}\t{HoTenGV}";
            else if (TruongNhom.Length > 20 && HoTenGV.Length > 20)
                xuat = xuat + $"  {TruongNhom}  {HoTenGV}";
            else 
                xuat = xuat + $"  {TruongNhom}\t{HoTenGV}";
            xuat = xuat + $"\t{NgayBatDau}\t{NgayKetThuc}\t{Is_thucTe}";
            Console.WriteLine(xuat);
            //Console.WriteLine($"   {MaDeTai}\t{TenDeTai}\t{KinhPhi}\t{TruongNhom}\t{HoTenGV}" +
            //    $"\t {NgayBatDau}\t{NgayKetThuc}\t{TinhKinhPhi()}\t{Is_thucTe}");
        }

        #endregion method
    }
}
