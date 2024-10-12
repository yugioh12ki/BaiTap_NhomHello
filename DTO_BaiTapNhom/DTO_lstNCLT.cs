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

        // 4.7
        public void XuatDSDeTaiTren10TR()
        {

            foreach (DTO_NCLT a in lstNCLT)
            {
                if (a.KinhPhi > 10000000)
                {
                    a.xuat();
                }
            }
        }
    }
}
