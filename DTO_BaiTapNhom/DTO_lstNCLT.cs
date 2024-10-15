using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_BaiTapNhom
{
    public class DTO_lstNCLT
    {
        private List<DTO_NCLT> lstNCLT = new List<DTO_NCLT>();

        public List<DTO_NCLT> LstNCLT { get => lstNCLT; set => lstNCLT = value; }

        public DTO_lstNCLT()
        {
            lstNCLT = new List<DTO_NCLT>();
        }

        public void NhapDSNCLT(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Nhập Thông Tin của Đề Tài NCLT {i +1 }");
                DTO_NCLT nclt = new DTO_NCLT();
                nclt.nhapNCLT();
                lstNCLT.Add(nclt);
            }
        }

        public void XuatDSNCLT()
        {
            foreach (DTO_NCLT a in LstNCLT)
            {
                a.Xuat();
            }
        }

        // 4.4 Xuất Danh Sách Tìm Các Tiêu Chí => Tên Đề Tài,Mã Số, GVHD, Tên Chủ Trì

        public void TimKiemDSTieuChi(string key)
        {
            foreach(var nclt in lstNCLT)
            {
                if(nclt.MaDeTai.ToLower().Contains(key.ToLower()) || nclt.TenDeTai.ToLower().Contains(key.ToLower()) 
                    || nclt.HoTenGV.ToLower().Contains(key.ToLower()) || nclt.TruongNhom.Contains(key.ToLower()))
                {
                    nclt.Xuat();
                }    
            }    
        }


        // 4.7 Xuất danh sách đề tài của NCLT mà kinh phí trên 10 triệu 
        public void XuatDSDeTaiTren10TR()
        {
            foreach (DTO_NCLT a in LstNCLT)
            {
                if (a.KinhPhi > 10000000)
                {
                    a.Xuat();
                }
            }
        }

        // 4.5 Xuất danh sách đề tài của NCLT có GVHD
        public void XuatDSDeTaiCoGVHD()
        {
            bool check = false;
            try
            {
                foreach (DTO_NCLT a in LstNCLT){
                    if (a.HoTenGV !=  null)
                    {
                        a.Xuat();
                        check = true;
                    }
                }
                if (check == false)
                {
                    throw new Exception("\nCác đề tài Nghiên cứu lý thuyết trong danh sách không có GVHD\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        // 4.6 cập nhập kinh phí các đề tài của NCLT --> (OK) Gia Vinh Xong 4.5 -> 4.7
        public void CapNhapKinhPhi()
        {
            foreach (DTO_NCLT a in LstNCLT)
            {
                a.CapNhatKinhPhi();
            }
        }


        //4.8 xuất danh sách có đề tài thuộc lĩnh vực nghiên cứu lí thuyết có khả năng triển khai vào thực tế
        public void XuatDSDeTaiLyThuyetApDungThucTe()
        {
            bool check = false;
            try
            {
                foreach (DTO_NCLT a in LstNCLT)
                {
                    if (a.Is_thucTe)
                    {
                        a.Xuat();   // Hàm xuất đã có sẵn, chỉ cần gọi lại.
                        check = true;
                    }
                }
                if (!check)
                {
                    throw new Exception("Không có đề tài nghiên cứu lý thuyết nào có khả năng triển khai vào thực tế.");
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
        //    bool check = false; 

        //    try
        //    {

        //        foreach (DTO_NCLT a in LstNCLT)
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

                foreach (DTO_NCLT a in LstNCLT)
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
