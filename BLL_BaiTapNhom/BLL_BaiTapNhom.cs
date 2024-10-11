using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_BaiTapNhom

namespace BLL_BaiTapNhom
{
    internal class BLL_BaiTapNhom
    {
        // 4.5
        public void XuatDSDeTaiCoGVHD(List<DTO_cDeTai> dsDeTai)
        {
            bool checked = false;
            try
            {
                for (int i = 0; i < dsDeTai.Count; i++)
                {
                    if (dsDeTai[i].HoTenGV != null)
                    {
                        XuatDeTai(dsDeTai[i]);  // Ai làm phần xuất danh sách đề tài thì viết tên hàm giống như này
                        checked = true;
                    }
                }
                if (checked == false) {
                    throw new Exception("Các đề tài trong danh sách không có GVHD");
                }
            } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    
        // 4.6
        public void CapNhapKinhPhi(List<DTO_cDeTai> dsDeTai)
        {
            for (int i = 0; i < dsDeTai.Count; i++)
            {
                dsDeTai[i].KinhPhi *= 10 %;
            }
        }
    
        // 4.7
        public void XuatDSDeTaiTren10TR(List<DTO_cDeTai> dsDeTai)
        {
            for (int i = 0; i < dsDeTai.Count; i++)
            {
                if (dsDeTai[i].KinhPhi > 10)
                {
                    XuatDeTai(dsDeTai[i]);
                }
            }
        }

    }
}
