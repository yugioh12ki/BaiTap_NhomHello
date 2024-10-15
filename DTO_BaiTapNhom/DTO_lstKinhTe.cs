using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_BaiTapNhom
{
    public class DTO_lstKinhTe
    {
        private List<DTO_KinhTe> lstKinhTe= new List<DTO_KinhTe>();

        public List<DTO_KinhTe> LstKinhTe { get => lstKinhTe; set => lstKinhTe = value; }

        public DTO_lstKinhTe()
        {
            lstKinhTe = new List<DTO_KinhTe>();
        }

        public void NhapDSKinhTe(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Nhập Thông Tin của Đề Tài NCLT {i + 1}");
                DTO_KinhTe kinhte = new DTO_KinhTe();
                kinhte.nhapKT();
                lstKinhTe.Add(kinhte);
            }
        }

        public void XuatDSKinhTe()
        {
            foreach (DTO_KinhTe a in lstKinhTe)
            {
                a.Xuat();
            }
        }

        // 4.4 Xuất Danh Sách Tìm Các Tiêu Chí => Tên Đề Tài,Mã Số, GVHD, Tên Chủ Trì

        public void TimKiemDSTieuChi(string key)
        {
            foreach (var kinhte in lstKinhTe)
            {
                if (kinhte.MaDeTai.ToLower().Contains(key.ToLower()) || kinhte.TenDeTai.ToLower().Contains(key.ToLower())
                    || kinhte.HoTenGV.ToLower().Contains(key.ToLower()) || kinhte.TruongNhom.Contains(key.ToLower()))
                {
                    kinhte.Xuat();
                }
            }
        }

        // 4.7 Xuất danh sách đề tài của kinh tế mà kinh phí trên 10 triệu 
        public void XuatDSDeTaiTren10TR()
        {
            foreach (DTO_KinhTe a in LstKinhTe)
            {
                if (a.KinhPhi > 10000000)
                {
                    a.Xuat();
                }
            }
        }
        
        // 4.5 Xuất danh sách đề tài của kinh tế có GVHD 
        public void XuatDSDeTaiCoGVHD()
        {
            bool check = false;
            try
            {
                foreach (DTO_KinhTe a in LstKinhTe)
                {
                    if (a.HoTenGV != "")
                    {
                        a.Xuat();
                        check = true;
                    }
                }
                if (check == false)
                {
                    throw new Exception("\nCác đề tài kinh tế trong danh sách không có GVHD\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // 4.6 cập nhập kinh phí các đề tài của kinh tế
        public void CapNhapKinhPhi()
        {
            foreach (DTO_KinhTe a in LstKinhTe)
            {
                a.CapNhatKinhPhi();
            }
        }

        //4.9 in ra danh sách có đề tài số câu hỏi khảo sát trên 100
        public void XuatDSDeTaiKinhTeTren100CauHoi()
        {
            bool check = false;
            try
            {
                foreach (DTO_KinhTe a in LstKinhTe)
                {
                    if (a.SoCauHoi > 100)
                    {
                        a.Xuat();  // Hàm xuất đã có sẵn, chỉ cần gọi lại.
                        check = true;
                    }
                }
                if (!check)
                {
                    throw new Exception("Không có đề tài kinh tế nào có số câu hỏi khảo sát trên 100 câu.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //4.10 In ra danh sách có để tài nghiên cứu thời gian thực trên 4 tháng
        //public void XuatDSDeTaiTren4Thang()
        //{
        //    bool check = false; // Biến kiểm tra xem có đề tài nào được tìm thấy không

        //    try
        //    {

        //        foreach (DTO_KinhTe a in LstKinhTe)
        //        {
        //            DateTime ngayBatDau = DateTime.ParseExact(a.NgayBatDau, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //            DateTime ngayKetThuc = DateTime.ParseExact(a.NgayKetThuc, "dd/MM/yyyy", CultureInfo.InvariantCulture);


        //            TimeSpan thoiGianThucHien = ngayKetThuc - ngayBatDau;


        //            if (thoiGianThucHien.TotalDays > 120) // 4 tháng = 120 ngày
        //            {
        //                a.Xuat();
        //                check = true;
        //            }
        //        }
        //        if (!check)
        //        {

        //            throw new Exception("Không có đề tài nào có thời gian thực hiện trên 4 tháng.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}
        public void XuatDSDeTaiTren4Thang()
        {
            bool check = false;

            try
            {

                foreach (DTO_KinhTe a in lstKinhTe)
                {
                    string[] formats = { "dd/MM/yyyy", "d/MM/yyyy", "dd/M/yyyy", "d/M/yyyy" };
                    if (DateTime.TryParseExact(a.NgayBatDau, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngayBatDau) &&
                    DateTime.TryParseExact(a.NgayKetThuc, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngayKetThuc))
                    {
                        // Tính số tháng giữa ngày bắt đầu và kết thúc
                        int Month = ((ngayKetThuc.Year - ngayBatDau.Year) * 12) + ngayKetThuc.Month - ngayBatDau.Month;

                        if (ngayKetThuc.Day < ngayBatDau.Day)
                        {
                            Month--;
                        }

                        // Kiểm tra nếu thời gian thực hiện >= 4 tháng
                        if (Month >= 4)
                        {
                            a.Xuat();
                            check = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Đề tài có mã {a.MaDeTai} có định dạng ngày không hợp lệ.");
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
   

    