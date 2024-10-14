using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO_BaiTapNhom
{
    public class DTO_lstCongNghe
    {
        private List<DTO_CongNghe> lstCongNghe = new List<DTO_CongNghe>();

        public List<DTO_CongNghe> LstCongNghe { get => lstCongNghe; set => lstCongNghe = value; }

        public DTO_lstCongNghe()
        {

        }

        public void NhapDSCongNghe(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Nhập Thông Tin của Đề Tài NCLT {i + 1}");
                DTO_CongNghe congNghe = new DTO_CongNghe();
                congNghe.nhapCN();
                lstCongNghe.Add(congNghe);
            }
        }

        public void XuatDSCongNghe()
        {
            foreach (DTO_CongNghe a in lstCongNghe)
            {
                a.Xuat();
            }
        }

        // 4.4 Xuất Danh Sách Tìm Các Tiêu Chí => Tên Đề Tài,Mã Số, GVHD, Tên Chủ Trì

        public void TimKiemDSTieuChi(string key)
        {
            foreach (var congnghe in lstCongNghe)
            {
                if (congnghe.MaDeTai.ToLower().Contains(key.ToLower()) || congnghe.TenDeTai.ToLower().Contains(key.ToLower())
                    || congnghe.HoTenGV.ToLower().Contains(key.ToLower()) || congnghe.TruongNhom.Contains(key.ToLower()))
                {
                    congnghe.Xuat();
                }
            }
        }

        // 4.7 Xuất danh sách đề tài của Công nghệ mà kinh phí trên 10 triệu 
        public void XuatDSDeTaiTren10TR()
        {
            foreach (DTO_CongNghe a in LstCongNghe)
            {
                if (a.KinhPhi > 10000000)
                {
                    a.Xuat();
                }
            }
        }

        // 4.8 Xuất danh sách đề tài của Công nghệ có GVHD
        public void XuatDSDeTaiCoGVHD()
        {
            bool check = false;
            try
            {
                foreach (DTO_CongNghe a in LstCongNghe)
                {
                    if (a.HoTenGV != null)
                    {
                        a.Xuat();
                        check = true;
                    }
                }
                if (check == false)
                {
                    throw new Exception("\nCác đề tài công nghệ trong danh sách không có GVHD\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // 4.6 cập nhập kinh phí các đề tài của NCLT
        public void CapNhapKinhPhi()
        {
            foreach (DTO_CongNghe a in LstCongNghe)
            {
                a.KinhPhi = a.KinhPhi + (a.KinhPhi * (10 / 100.0));
            }
        }
       
       
        //4.10 In ra danh sách có để tài nghiên cứu thời gian thực trên 4 tháng
        public void XuatDSDeTaiTren4Thang()
        {
            bool check = false; // Biến kiểm tra xem có đề tài nào được tìm thấy không

            try
            {

                foreach (DTO_CongNghe a in LstCongNghe)
                {

                    DateTime ngayBatDau = DateTime.ParseExact(a.NgayBatDau, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime ngayKetThuc = DateTime.ParseExact(a.NgayKetThuc, "dd/MM/yyyy", CultureInfo.InvariantCulture);


                    TimeSpan thoiGianThucHien = ngayKetThuc - ngayBatDau;


                    if (thoiGianThucHien.TotalDays > 120) // 4 tháng = 120 ngày
                    {
                        a.Xuat();
                        check = true;
                    }
                }
                if (!check)
                {

                    throw new Exception("Không có đề tài nào có thời gian thực hiện trên 4 tháng.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }




    }

}

   
