﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_BaiTapNhom;
using DTO_BaiTapNhom;


namespace BaiTap_Nhom
{
    public class GUIBaiTapNhom
    {
        private BLLBaiTapNhom _BLLBaiTapNhom;
        DTO_lstNCLT lstNCLT = new DTO_lstNCLT();
        DTO_lstKinhTe lstKinhTe = new DTO_lstKinhTe();
        DTO_lstCongNghe lstCongNghe = new DTO_lstCongNghe();
        int soLuong = 0;
        

        public GUIBaiTapNhom()
        {
            _BLLBaiTapNhom = new BLLBaiTapNhom();
        }

        public void NhapThongTinDeTai(int loai)
        {
            bool check = false;
            switch(loai)
            {
                case 1:
                    do
                    {
                        Console.WriteLine("Nhập Số Lượng Đề Tài Nghiên Cứu Lý Thuyết cần nhập:\n ");
                        soLuong = Int32.Parse(Console.ReadLine());
                    } while (!check || soLuong < 0);
                    lstNCLT.NhapDSNCLT(soLuong);
                    break;
                case 2:
                    do
                    {
                        Console.WriteLine("Nhập Số Lượng Đề Tài Kinh Tế cần nhập:\n ");
                        soLuong = Int32.Parse(Console.ReadLine());
                    } while (!check || soLuong < 0);
                    
                    lstKinhTe.NhapDSKinhTe(soLuong);
                    break;
                case 3:
                    do
                    {
                        Console.WriteLine("Nhập Số Lượng Đề Tài Nghiên Cứu Lý Thuyết cần nhập:\n ");
                        soLuong = Int32.Parse(Console.ReadLine());
                    } while (!check || soLuong < 0);
                    lstKinhTe.NhapDSKinhTe(soLuong);
                    break;
            }    
        }

        public void XuatTatCaDeTai()
        {
            Console.WriteLine("======================= Danh Sách Các Đề Tài =============================");
            Console.WriteLine("\n\t\t Đề Tài Nghiên Cứu Lý Thuyết ");
            lstNCLT.XuatDSNCLT();
            Console.WriteLine("\n\t\t Đề Tài Kinh Tế");
            lstKinhTe.XuatDSKinhTe();
            Console.WriteLine("\n\t\t Đề Tài Công Nghệ");
            lstCongNghe.XuatDSCongNghe();
            Console.WriteLine("==========================================================================");
        }

        public void XuatTatCaDeTaiTren10Trieu()
        {
            Console.WriteLine("=================== Danh Sách Các Đề Tài Trên 10 Triệu ===================");
            Console.WriteLine("\n\t\t Đề Tài Nghiên Cứu Lý Thuyết ");
            lstNCLT.XuatDSDeTaiTren10TR();
            Console.WriteLine("\n\t\t Đề Tài Kinh Tế");
            lstKinhTe.XuatDSDeTaiTren10TR();
            Console.WriteLine("\n\t\t Đề Tài Công Nghệ");
            lstCongNghe.XuatDSDeTaiTren10TR();
            Console.WriteLine("==========================================================================");
        }

        public void CapNhatThemKinhPhi()
        {
            lstNCLT.CapNhapKinhPhi();
            lstKinhTe.CapNhapKinhPhi();
            lstCongNghe.CapNhapKinhPhi();
        }

        public void XuatTatCaDeTaiCoGiangVien()
        {
            Console.WriteLine("=================== Danh Sách Các Đề Tài Có Giảng Viên ===================");
            Console.WriteLine("\n\t\t Đề Tài Nghiên Cứu Lý Thuyết ");
            lstNCLT.XuatDSDeTaiCoGVHD();
            Console.WriteLine("\n\t\t Đề Tài Kinh Tế");
            lstKinhTe.XuatDSDeTaiCoGVHD();
            Console.WriteLine("\n\t\t Đề Tài Công Nghệ");
            lstCongNghe.XuatDSDeTaiCoGVHD();
            Console.WriteLine("==========================================================================");
        }

        public void XuatDTaiNCLT_ThucTe()
        {
            Console.WriteLine("========= Danh Sách Các Đề Tài Nghiên Cứu Lý Thuyết Có Thực Tế ===========");
            lstNCLT.XuatDSDeTaiLyThuyetApDungThucTe();
            Console.WriteLine("==========================================================================");
        }

        public void XuatDTaiKinhTe_LonHon100Cau()
        {
            Console.WriteLine("============== Danh Sách Các Đề Tài Kinh Tế Lớn Hơn 100 Câu ==============");
            lstKinhTe.XuatDSDeTaiKinhTeTren100CauHoi();
            Console.WriteLine("==========================================================================");
        }

        public void XuatDTaiThucHien4Thang()
        {
            Console.WriteLine("=================== Danh Sách Các Đề Tài Thực Hiện Trên 4 Tháng ===================");
            Console.WriteLine("\n\t\t Đề Tài Nghiên Cứu Lý Thuyết ");
            lstNCLT.XuatDSNCLT();
            Console.WriteLine("\n\t\t Đề Tài Kinh Tế");
            lstKinhTe.XuatDSKinhTe();
            Console.WriteLine("\n\t\t Đề Tài Công Nghệ");
            lstCongNghe.XuatDSCongNghe();
            Console.WriteLine("==========================================================================");
        }

        public void showThongTinNhom()
        {
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("                      Bài Tập Nhóm Hello");
            Console.WriteLine("Được Thực Hiện Bởi: ");
            Console.WriteLine("2001216022 - Nguyễn Huỳnh Thanh Phát - Nhóm Trưởng");
            Console.WriteLine("2001231047 - Châu Gia Vinh");
            Console.WriteLine("2033230178 - Hạ Chí Lực");
            Console.WriteLine("2033216483 - Đỗ Hoàng Minh");
            Console.WriteLine("2033230081 - Nguyễn Thị Ngọc Hiểu");
            Console.WriteLine("*************************************************************************");
        }

        public void TimKiemTheoTieuChi()
        {
            Console.WriteLine("Tìm Kiếm Theo Tiêu Chí: ");
            string keyword = Console.ReadLine();
            
        }

        public void showUI()
        {
            int menu;
        }

        
    }
  
}
