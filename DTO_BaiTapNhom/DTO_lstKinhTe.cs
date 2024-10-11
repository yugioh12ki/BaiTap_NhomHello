using System;
using System.Collections.Generic;
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

        }

        public void getDSKinhTe(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Encoding encoding = Encoding.UTF8;
                Console.WriteLine($"Nhập Thông Tin của Đề Tài Kinh Te {i + 1}");
                DTO_KinhTe kinhte = new DTO_KinhTe();
                kinhte.nhap();
                lstKinhTe.Add(kinhte);
            }
        }

        public void putDSKinhTe()
        {
            foreach (DTO_KinhTe kinhte in LstKinhTe)
            {
                kinhte.xuat();
            }
        }
    }
}
