using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DTO_BaiTapNhom;

namespace DAL_BaiTapNhom
{
    public class DALBaiTapNhom
    {
        DTO_lstNCLT lstNCLT = new DTO_lstNCLT();
        DTO_lstKinhTe lstKinhTe = new DTO_lstKinhTe();
        DTO_lstCongNghe lstCongnghe = new DTO_lstCongNghe(); 


        public void readFile(string filename)
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
                    XmlNode is_ThucTe = i["ThucTe"];
                    XmlNode is_soCauHoi = i["soCauHoi"];
                    XmlNode is_moiTruong = i["ThucTe"];
                    if(is_ThucTe != null)
                    {
                        DTO_NCLT st = new DTO_NCLT();
                        st.MaDeTai = i["Madetai"].InnerText;
                        st.TenDeTai = i["Tendetai"].InnerText;
                        st.KinhPhi = double.Parse(i["Kinhphi"].InnerText);
                        st.TruongNhom = i["Truongnhom"].InnerText;
                        st.NgayBatDau = i["Thoigianbatdau"].InnerText;
                        st.NgayKetThuc = i["Thoigianketthuc"].InnerText;
                        st.HoTenGV = i["HotenGVHD"].InnerText;
                        st.Is_thucTe = Boolean.Parse(i["ThucTe"].InnerText);
                        lstNCLT.LstNCLT.AddRange(st);
                    }  
                    else if (is_soCauHoi != null)
                    {
                        DTO_KinhTe st = new DTO_KinhTe();
                        st.MaDeTai = i["Madetai"].InnerText;
                        st.TenDeTai = i["Tendetai"].InnerText;
                        st.KinhPhi = double.Parse(i["Kinhphi"].InnerText);
                        st.TruongNhom = i["Truongnhom"].InnerText;
                        st.NgayBatDau = i["Thoigianbatdau"].InnerText;
                        st.NgayKetThuc = i["Thoigianketthuc"].InnerText;
                        st.HoTenGV = i["HotenGVHD"].InnerText;
                        st.SoCauHoi = Int32.Parse(i["SoCauHoi"].InnerText);
                        lstKinhTe.LstKinhTe.Add(st);
                    }
                    else if (is_moiTruong != null)
                    {
                        DTO_CongNghe st = new DTO_CongNghe();
                        st.MaDeTai = i["Madetai"].InnerText;
                        st.TenDeTai = i["Tendetai"].InnerText;
                        st.KinhPhi = double.Parse(i["Kinhphi"].InnerText);
                        st.TruongNhom = i["Truongnhom"].InnerText;
                        st.NgayBatDau = i["Thoigianbatdau"].InnerText;
                        st.NgayKetThuc = i["Thoigianketthuc"].InnerText;
                        st.HoTenGV = i["HotenGVHD"].InnerText;
                        st.MoiTruong = i["Moitruong"].InnerText;
                        lstCongnghe.LstCongNghe.Add(st);
                    }
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi doc File: " + e.Message);
            }
        }
    }
}
