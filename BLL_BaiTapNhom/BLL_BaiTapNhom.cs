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
        static int phiTangThem;
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
                        XuatDeTai(dsDeTai[i]);  // Ai làm phần xuất danh sách đề tài thì viết tên hàm giống như này
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
