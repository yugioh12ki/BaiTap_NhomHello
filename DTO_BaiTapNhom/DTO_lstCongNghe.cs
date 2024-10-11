using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_BaiTapNhom
{
    public class DTO_lstCongNghe
    {
        private List<DTO_CongNghe> lstCongNghe = new List<DTO_CongNghe>();

        public List<DTO_CongNghe> LstCongNghe { get => lstCongNghe; set => lstCongNghe = value; }

        public DTO_lstCongNghe()
        {

        }

        public void getDSKinhTe(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Encoding encoding = Encoding.UTF8;
                Console.WriteLine($"Nhập Thông Tin của Đề Tài Kinh Te {i + 1}");
                DTO_CongNghe congnghe = new DTO_CongNghe();
                congnghe.nhap();
                lstCongNghe.Add(congnghe);
            }
        }

        public void putDSKinhTe()
        {
            foreach (DTO_CongNghe congnghe in lstCongNghe)
            {
                congnghe.xuat();
            }
        }
    }
}
