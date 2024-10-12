using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_BaiTapNhom
{
    public abstract class DTO_cDeTai
    {
        #region ThuocTinh
        //DeTai
        private string maDeTai;
        private string tenDeTai;
        private double kinhPhi;
        private string truongNhom;
        private string ngayBatDau;
        private string ngayKetThuc;
        private string hoTenGV;

        

        public string MaDeTai { get => maDeTai; set => maDeTai = value; }
        public string TenDeTai { get => tenDeTai; set => tenDeTai = value; }
        public double KinhPhi { get => kinhPhi; set => kinhPhi = value; }
        public string TruongNhom { get => truongNhom; set => truongNhom = value; }
        public string NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public string NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public string HoTenGV { get => hoTenGV; set => hoTenGV = value; }



        #endregion ThuocTinh

        #region method

        public DTO_cDeTai()
        {
            this.kinhPhi = 0;
            this.NgayBatDau = "1/1/1980";
        }

        public DTO_cDeTai(string maDeTai, string tenDeTai, int kinhPhi, string truongNhom, string ngayBatDau, string ngayKetThuc, string hoTenGV)
        {
            this.maDeTai = maDeTai;
            this.tenDeTai = tenDeTai;
            this.kinhPhi = kinhPhi;
            this.truongNhom = truongNhom;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
            this.hoTenGV = hoTenGV;
        }

        public abstract double TinhKinhPhi();

        public void insertDeTai()
        {

        }

        #endregion method
    }
    //tạo lớp con của ĐTO_cDeTai
    public class Concrete_cDeTai : DTO_cDeTai
    {
        // Hàm khởi tạo, nếu cần bạn có thể thêm tham số tùy ý
        public Concrete_cDeTai() : base() { }
        public Concrete_cDeTai(string maDeTai, string tenDeTai, int kinhPhi, string truongNhom, string ngayBatDau, string ngayKetThuc, string hoTenGV)
            : base(maDeTai, tenDeTai, kinhPhi, truongNhom, ngayBatDau, ngayKetThuc, hoTenGV) { }
        // Hiện thực hóa phương thức abstract từ DTO_cDeTai
        public override double TinhKinhPhi()
        {
            // Giả sử đây là tính kinh phi
            return this.KinhPhi;
        }
    }

}
