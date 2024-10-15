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


        public DTO_lstNCLT readFileNCLT(string filename)
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
                        lstNCLT.LstNCLT.Add(st);
                    }  

                }
                
            }
            
            catch (Exception e)
            {
                Console.WriteLine("Loi doc File: " + e.Message);
            }
            return lstNCLT;
        }

        public DTO_lstKinhTe readFileKinhTe(string filename)
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
                    
                    XmlNode is_soCauHoi = i["SoCauHoi"];
                    
                    if (is_soCauHoi != null)
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
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi doc File: " + e.Message);
            }
            return lstKinhTe;
        }
        public DTO_lstCongNghe readFileCongNghe(string filename)
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

                    XmlNode is_MoiTruong = i["Moitruong"];

                    if (is_MoiTruong != null)
                    {
                        DTO_CongNghe st = new DTO_CongNghe();
                        st.MaDeTai = i["Madetai"].InnerText;
                        st.TenDeTai = i["Tendetai"].InnerText;
                        st.KinhPhi = double.Parse(i["Kinhphi"].InnerText);
                        st.TruongNhom = i["Truongnhom"].InnerText;
                        st.NgayBatDau = i["Thoigianbatdau"].InnerText;
                        st.NgayKetThuc = i["Thoigianketthuc"].InnerText;
                        st.HoTenGV = i["HotenGVHD"].InnerText;
                        try
                        {
                            st.MoiTruong = is_MoiTruong.InnerText;
                        }
                        catch (ArgumentException ex) // Bắt lỗi nếu giá trị không hợp lệ
                        {
                            Console.WriteLine($"Lỗi khi gán môi trường cho đề tài {st.MaDeTai}: {ex.Message}");
                            continue; // Bỏ qua đề tài này và tiếp tục với đề tài tiếp theo
                        }
                        
                        lstCongnghe.LstCongNghe.Add(st);
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi doc File: " + e.Message);
            }
            return lstCongnghe;
        }
    }
}
