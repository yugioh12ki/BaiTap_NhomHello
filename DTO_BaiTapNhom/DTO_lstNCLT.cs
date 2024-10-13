using System;
using System.Collections.Generic;
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
                a.KinhPhi = a.KinhPhi + (a.KinhPhi * (10 / 100.0));
            }
        }
<<<<<<< HEAD

        
=======
        //4.8 xuất danh sách có đề tài thuộc lĩnh vực nghiên cứu lí thuyết có khả năng triển khai vào thực tế
        public void XuatDSDeTaiLyThuyetApDungThucTe()
        {
            bool check = false;
            try
            {
                foreach (DTO_NCLT a in LstNCLT)
                {
                    if (a.MaDeTai == "Lý thuyết" && a.thucTe)
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
        //4.9 in ra danh sách có đề tài số câu hỏi khảo sát trên 100
        public void XuatDSDeTaiKinhTeTren100CauHoi()
        {
            bool check = false;
            try
            {
                foreach (DTO_NCLT a in LstNCLT)
                {
                    if (a.MaDeTai == "Kinh tế" && a.SoCauHoiKhaoSat > 100)
                    {
                        a.Xuat(); 
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
        public void XuatDSDeTaiTren4Thang()
        {
            bool check = false;
            try
            {
                foreach (DTO_NCLT a in LstNCLT)
                {
                    TimeSpan thoiGianThucHien = a.NgayKetThuc - a.NgayBatDau;
                    if (thoiGianThucHien.TotalDays > 120) // 4 tháng = 120 ngày
                    {
                        a.Xuat(); ; 
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

>>>>>>> 3d3e23658a4ea2dbebf091a82131f4e102898645
    }
}
