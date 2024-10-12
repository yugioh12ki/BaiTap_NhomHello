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

        public void getDSDeTai()
        {
            
        }

        public void putDSDeTai()
        {
            
        }


        // 4.7 Xuất danh sách đề tài của NCLT mà kinh phí trên 10 triệu 
        public void XuatDSDeTaiTren10TR()
        {
            foreach (DTO_NCLT a in LstNCLT)
            {
                if (a.KinhPhi > 10000000)
                {
                    a.xuat();
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
                        a.xuat();
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
    }
}
