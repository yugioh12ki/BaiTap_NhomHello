using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DTO_BaiTapNhom;

namespace DAL_BaiTapNhom
{
    public class DAL_BaiTapNhom
    {
        List<DTO_cDeTai> _listDetai = new List<DTO_cDeTai>();
        public List<DTO_cDeTai> ListDetai { get => _listDetai; set => _listDetai = value; }
        public List<DTO_cDeTai> readFile(string filename)
        {
            Console.InputEncoding = UnicodeEncoding.Unicode;
            try
            {
                XmlDocument read = new XmlDocument();
                read.Load(filename);
                XmlNodeList nodeList = read.SelectNodes("Danhsachdetai/Detai");
                foreach (XmlNode i in nodeList)
                {
                    /* Tôi coi lại đề thì nếu ông làm giống trên PDF thì ông phải 3 file Xml với loại khác nhau
                     * 
                     */
                    //DTO_cDeTai st = new DTO_cDetai();
                    DTO_NCLT st = new DTO_NCLT();
                    st.MaDeTai = i["Madetai"].InnerText;
                    st.TenDeTai = i["Tendetai"].InnerText;
                    st.KinhPhi = double.Parse(i["Kinhphi"].InnerText);
                    st.TruongNhom = i["Truongnhom"].InnerText;
                    st.NgayBatDau = i["Thoigianbatdau"].InnerText;
                    st.NgayKetThuc = i["Thoigianketthuc"].InnerText;
                    st.HoTenGV = i["HotenGVHD"].InnerText;
                    ListDetai.Add(st);
                }
                return ListDetai;
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi doc File: " + e.Message);
                return null;
            }
        }
    }
}
