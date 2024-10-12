﻿using System;
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

        public void getDSKinhTe()
        {
            
        }

        public void putDSKinhTe()
        {
            
        }

        // 4.7 Xuất danh sách đề tài của kinh tế mà kinh phí trên 10 triệu 
        public void XuatDSDeTaiTren10TR()
        {
            foreach (DTO_KinhTe a in LstKinhTe)
            {
                if (a.KinhPhi > 10000000)
                {
                    a.xuat();
                }
            }
        }

        // 4.5 Xuất danh sách đề tài của kinh tế có GVHD
        public void XuatDSDeTaiCoGVHD()
        {
            bool check = false;
            try
            {
                foreach (DTO_KinhTe a in LstKinhTe)
                {
                    if (a.HoTenGV != null)
                    {
                        a.xuat();
                        check = true;
                    }
                }
                if (check == false)
                {
                    throw new Exception("\nCác đề tài kinh tế trong danh sách không có GVHD\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // 4.6 cập nhập kinh phí các đề tài của kinh tế
        public void CapNhapKinhPhi()
        {
            foreach (DTO_KinhTe a in LstKinhTe)
            {
                a.KinhPhi = a.KinhPhi + (a.KinhPhi * (10 / 100.0));
            }
        }
    }
}
