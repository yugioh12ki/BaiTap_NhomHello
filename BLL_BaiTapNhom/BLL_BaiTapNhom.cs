using DTO_BaiTapNhom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_BaiTapNhom;

namespace BLL_BaiTapNhom
{
    public class BLL_BaiTapNhom
    {
        // 4.5
        public void XuatDSDeTaiCoGVHD(List<DTO_cDeTai> dsDeTai)
        {
            bool check = false;
            try
            {
                for (int i = 0; i < dsDeTai.Count; i++)
                {
                    if (dsDeTai[i].HoTenGV != null)
                    {
                        xuat(dsDeTai[i]);  // Ai làm phần xuất danh sách đề tài thì viết tên hàm xuất giống như này
                        check = true;
                    }
                }
                if (check == false)
                {
                    throw new Exception("Các đề tài trong danh sách không có GVHD");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // 4.6
        public void CapNhapKinhPhi(List<DTO_cDeTai> dsDeTai)
        {
            for (int i = 0; i < dsDeTai.Count; i++)
            {
                dsDeTai[i].KinhPhi = dsDeTai[i].KinhPhi + (dsDeTai[i].KinhPhi * (10 / 100.0));
            }
        }

        // 4.7
        public void XuatDSDeTaiTren10TR(List<DTO_cDeTai> dsDeTai)
        {
           foreach (DTO_cDeTai a in dsDeTai)
            {
                if (a.KinhPhi > 10)
                {
                    xuat(a);
                }
            }
        } 
        //4.8
       
        public void XuatDSDeTaiLyThuyetApDungThucTe(List<DTO_cDeTai> dsDeTai)
        {
         bool check = false;
         try
         {
             for (int i = 0; i < dsDeTai.Count; i++)
              {
                    if (dsDeTai[i].LoaiLinhVuc == "Lý thuyết" && dsDeTai[i].ApDungThucTe)
                    {
                        xuat(dsDeTai[i]);  // Hàm xuất đã có sẵn, chỉ cần gọi lại.
                        check = true;
                    }
               }
              if (check == false)
               {
            throw new Exception("Không có đề tài nghiên cứu lý thuyết nào có khả năng triển khai vào thực tế.");
               }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //4.9
        public void XuatDSDeTaiKinhTeTren100CauHoi(List<DTO_cDeTai> dsDeTai)
        {
            bool check = false;
            try
            {
                 for (int i = 0; i < dsDeTai.Count; i++)
                  {
                    if (dsDeTai[i].LoaiLinhVuc == "Kinh tế" && dsDeTai[i].SoCauHoiKhaoSat > 100)
                    {
                            xuat(dsDeTai[i]);  // Hàm xuất đã có sẵn, chỉ cần gọi lại.
                            check = true;
                         }
                   }
                   if (check == false)
                   {
                        throw new Exception("Không có đề tài kinh tế nào có số câu hỏi khảo sát trên 100 câu.");
                   }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //4.10
        public void XuatDSDeTaiTren4Thang(List<DTO_cDeTai> dsDeTai)
        {
            bool check = false;
            try
            {
                for (int i = 0; i < dsDeTai.Count; i++)
                {
                    TimeSpan thoiGianThucHien = dsDeTai[i].ThoiGianKetThuc - dsDeTai[i].ThoiGianBatDau;
                    if (thoiGianThucHien.TotalDays > 120) // 4 tháng = 120 ngày
                    {
                        xuat(dsDeTai[i]);  // Hàm xuất đã có sẵn, chỉ cần gọi lại.
                        check = true;
                    }
                }
                if (check == false)
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

