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

        public void getDSDeTai(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Encoding encoding = Encoding.UTF8;
                Console.WriteLine($"Nhập Thông Tin của Đề Tài {i + 1}");
                DTO_NCLT nclt = new DTO_NCLT();
                nclt.nhap();
                lstNCLT.Add(nclt);
            }
        }

        public void putDSDeTai()
        {
            foreach(DTO_NCLT nclt in lstNCLT)
            {
                nclt.xuat();
            }
        }
    }
}
