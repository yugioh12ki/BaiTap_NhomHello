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
        
        BLLBaiTapNhom Bll = new BLLBaiTapNhom();
        DTO_lstNCLT lstNCLT = new DTO_lstNCLT();
        DTO_lstKinhTe lstKinhTe = new DTO_lstKinhTe();
        DTO_lstCongNghe lstCongNghe = new DTO_lstCongNghe();
        int soLuong = 0;
        int loai = 0;
        string path = "../../../File_Xml/";
        string tieuDe = "  Mã Đề Tài \t   Tên Đề Tài  \t   Kinh Phí \t Trưởng Nhóm \t Giảng Viên \t Ngày Bắt Đầu \t Ngày Kết Thúc";


        public void NhapThongTinDeTai(int loai)
        {
            bool check = false;
            switch(loai)
            {
                case 1:
                    do
                    {
                        Console.Write("Nhập Số Lượng Đề Tài Nghiên Cứu Lý Thuyết cần nhập:\n ");
                        check = Int32.TryParse(Console.ReadLine(),out soLuong);
                    } while (!check || soLuong < 0);
                    lstNCLT.NhapDSNCLT(soLuong);
                    break;
                case 2:
                    do
                    {
                        Console.Write("Nhập Số Lượng Đề Tài Kinh Tế cần nhập:\n ");
                        check = Int32.TryParse(Console.ReadLine(), out soLuong);
                    } while (!check || soLuong < 0);
                    
                    lstKinhTe.NhapDSKinhTe(soLuong);
                    break;
                case 3:
                    do
                    {
                        Console.WriteLine("Nhập Số Lượng Đề Tài Nghiên Cứu Lý Thuyết cần nhập:\n ");
                        check = Int32.TryParse(Console.ReadLine(), out soLuong);
                    } while (!check || soLuong < 0);
                    lstKinhTe.NhapDSKinhTe(soLuong);
                    break;
            }    
        }

        public void ShowDeTaiNCLT()
        {
            string filenameNCLT = path + "DSNCLT.xml";
            DTO_lstNCLT lstNCLT = Bll.getNCLTFromFile(filenameNCLT);
            lstNCLT.XuatDSNCLT();
        }
        public void ShowDeTaiKinhTe()
        {
            string filenameKinhTe = path + "DSKinhTe.xml";
            DTO_lstKinhTe lstKinhTe = Bll.getKinhTeFromFile(filenameKinhTe);
            lstKinhTe.XuatDSKinhTe();
        }
        public void ShowDeTaiCongNghe()
        {
            string filenameCongNghe = path + "DSCongNghe.xml";
            DTO_lstCongNghe lstCongNghe = Bll.getCongNgheFromFile(filenameCongNghe);
            lstCongNghe.XuatDSCongNghe();
        }

        public void XuatTatCaDeTaiTheoFile()
        {
            Console.WriteLine("==================================== Danh Sách Các Đề Tài Theo Xml ==================================");
            Console.WriteLine("\n\t\t\t\t Đề Tài Nghiên Cứu Lý Thuyết \n");
            Console.WriteLine(tieuDe + "\t Kiểm Tra Thực Tế");
            ShowDeTaiNCLT();
            Console.WriteLine("\n\t\t\t\t Đề Tài Kinh Tế \n");
            Console.WriteLine(tieuDe + "    Hỗ Trợ Kinh Phí" + "   Số Câu Hỏi");
            ShowDeTaiKinhTe();
            Console.WriteLine("\n\t\t\t\t Đề Tài Công Nghệ \n");
            Console.WriteLine(tieuDe + "    Hỗ Trợ Kinh Phí" + "   Môi Trường");
            ShowDeTaiCongNghe();
            Console.WriteLine("=======================================================================================================");
        }

        public void XuatTatCaDeTai()
        {
            Console.WriteLine("========================================== Danh Sách Các Đề Tài ======================================");
            Console.WriteLine("\n\t\t\t\t Đề Tài Nghiên Cứu Lý Thuyết \n");
            Console.WriteLine(tieuDe + "\t Kiểm Tra Thực Tế");
            lstNCLT.XuatDSNCLT();
            Console.WriteLine("\n\t\t\t\t Đề Tài Kinh Tế \n");
            Console.WriteLine(tieuDe + "    Hỗ Trợ Kinh Phí" + "\t Số Câu Hỏi");
            lstKinhTe.XuatDSKinhTe();
            Console.WriteLine("\n\t\t\t\t Đề Tài Công Nghệ \n");
            Console.WriteLine(tieuDe + "    Hỗ Trợ Kinh Phí" + "   Môi Trường");
            lstCongNghe.XuatDSCongNghe();
            Console.WriteLine("=======================================================================================================");
        }

        public void XuatTatCaDeTaiTren10Trieu()
        {
            Console.WriteLine("================================= Danh Sách Các Đề Tài Trên 10 Triệu ==================================");
            Console.WriteLine("\n\t\t\t\t Đề Tài Nghiên Cứu Lý Thuyết \n");
            Console.WriteLine(tieuDe + "\t Kiểm Tra Thực Tế");
            lstNCLT.XuatDSDeTaiTren10TR();
            Console.WriteLine("\n\t\t\t\t Đề Tài Kinh Tế \n");
            Console.WriteLine(tieuDe + "    Hỗ Trợ Kinh Phí" + "\t Số Câu Hỏi");
            lstKinhTe.XuatDSDeTaiTren10TR();
            Console.WriteLine("\n\t\t\t\t Đề Tài Công Nghệ \n");
            Console.WriteLine(tieuDe + "    Hỗ Trợ Kinh Phí" + "   Môi Trường");
            lstCongNghe.XuatDSDeTaiTren10TR();
            Console.WriteLine("=======================================================================================================");
        }

        public void TimKiemTheoTieuChi()
        {
            Console.WriteLine("Tìm Kiếm Theo Tiêu Chí: ");
            string keyword = Console.ReadLine();
            XuatDeTaiTheoTieuChi(keyword);
        }


        public void XuatDeTaiTheoTieuChi(string key)
        {
            Console.WriteLine($"===================== Danh Sách Các Đề Tài Theo Tìm Kiếm - {key} ====================================");
            Console.WriteLine("\n\t\t\t\t Đề Tài Nghiên Cứu Lý Thuyết \n");
            Console.WriteLine(tieuDe + "\t Kiểm Tra Thực Tế");
            lstNCLT.TimKiemDSTieuChi(key);
            Console.WriteLine("\n\t\t\t\t Đề Tài Kinh Tế \n");
            Console.WriteLine(tieuDe + "    Hỗ Trợ Kinh Phí" + "\t Số Câu Hỏi");
            lstKinhTe.TimKiemDSTieuChi(key);
            Console.WriteLine("\n\t\t\t\t Đề Tài Công Nghệ \n");
            Console.WriteLine(tieuDe + "    Hỗ Trợ Kinh Phí" + "   Môi Trường");
            lstCongNghe.TimKiemDSTieuChi(key);
            Console.WriteLine("=======================================================================================================");
        }

        public void CapNhatThemKinhPhi()
        {
            lstNCLT.CapNhapKinhPhi();
            lstKinhTe.CapNhapKinhPhi();
            lstCongNghe.CapNhapKinhPhi();
            Console.WriteLine("========================================== Danh Sách Các Đề Tài ======================================");
            Console.WriteLine("\n\t\t\t\t Đề Tài Nghiên Cứu Lý Thuyết \n");
            Console.WriteLine(tieuDe + "\t Kiểm Tra Thực Tế");
            lstNCLT.XuatDSNCLT();
            Console.WriteLine("\n\t\t\t\t Đề Tài Kinh Tế \n");
            Console.WriteLine(tieuDe + "    Hỗ Trợ Kinh Phí" + "\t Số Câu Hỏi");
            lstKinhTe.XuatDSKinhTe();
            Console.WriteLine("\n\t\t\t\t Đề Tài Công Nghệ \n");
            Console.WriteLine(tieuDe + "    Hỗ Trợ Kinh Phí" + "   Môi Trường");
            lstCongNghe.XuatDSCongNghe();
            Console.WriteLine("=======================================================================================================");
        }

        public void XuatTatCaDeTaiCoGiangVien()
        {
            Console.WriteLine("================================== Danh Sách Các Đề Tài Có Giảng Viên ==============================");
            Console.WriteLine("\n\t\t\t\t Đề Tài Nghiên Cứu Lý Thuyết \n");
            Console.WriteLine(tieuDe + "\t Kiểm Tra Thực Tế");
            lstNCLT.XuatDSDeTaiCoGVHD();
            Console.WriteLine("\n\t\t\t\t Đề Tài Kinh Tế \n");
            Console.WriteLine(tieuDe + "    Hỗ Trợ Kinh Phí" + "\t Số Câu Hỏi");
            lstKinhTe.XuatDSDeTaiCoGVHD();
            Console.WriteLine("\n\t\t\t\t Đề Tài Công Nghệ \n");
            Console.WriteLine(tieuDe + "    Hỗ Trợ Kinh Phí" + "   Môi Trường");
            lstCongNghe.XuatDSDeTaiCoGVHD();
            Console.WriteLine("=====================================================================================================");
        }

        public void XuatDTaiNCLT_ThucTe()
        {
            Console.WriteLine("========================= Danh Sách Các Đề Tài Nghiên Cứu Lý Thuyết Có Thực Tế ========================\n");
            Console.WriteLine(tieuDe + "\t Kiểm Tra Thực Tế");
            lstNCLT.XuatDSDeTaiLyThuyetApDungThucTe();
            Console.WriteLine("\n=====================================================================================================");
        }

        public void XuatDTaiKinhTe_LonHon100Cau()
        {
            Console.WriteLine("========================== Danh Sách Các Đề Tài Kinh Tế Lớn Hơn 100 Câu ===============================\n");
            Console.WriteLine(tieuDe + "Hỗ Trợ Kinh Phí" + "   Số Câu Hỏi");
            lstKinhTe.XuatDSDeTaiKinhTeTren100CauHoi();
            Console.WriteLine("\n=====================================================================================================");
        }

        public void XuatDTaiThucHien4Thang()
        {
            Console.WriteLine("=============================== Danh Sách Các Đề Tài Thực Hiện Trên 4 Tháng =========================");
            Console.WriteLine("\n\t\t\t\t Đề Tài Nghiên Cứu Lý Thuyết \n");
            Console.WriteLine(tieuDe + "\t Kiểm Tra Thực Tế");
            lstNCLT.XuatDSDeTaiTren4Thang();
            Console.WriteLine("\n\t\t\t\t Đề Tài Kinh Tế \n");
            Console.WriteLine(tieuDe + "    Hỗ Trợ Kinh Phí" + "\t Số Câu Hỏi");
            lstKinhTe.XuatDSDeTaiTren4Thang();
            Console.WriteLine("\n\t\t\t\t Đề Tài Công Nghệ \n");
            Console.WriteLine(tieuDe + "    Hỗ Trợ Kinh Phí" + "   Môi Trường");
            lstCongNghe.XuatDSDeTaiTren4Thang();
            Console.WriteLine("=====================================================================================================");
        }

        public void showThongTinNhom()
        {
            Console.WriteLine("*************************************************************************************************************\n");
            Console.WriteLine("                                      Bài Tập Nhóm Hello");
            Console.WriteLine("\t\tĐược Thực Hiện Bởi: ");
            Console.WriteLine("\t\t2001216022 - Nguyễn Huỳnh Thanh Phát - Nhóm Trưởng");
            Console.WriteLine("\t\t2001231047 - Châu Gia Vinh");
            Console.WriteLine("\t\t2033230178 - Hạ Chí Lực");
            Console.WriteLine("\t\t2033216483 - Đỗ Hoàng Minh");
            Console.WriteLine("\t\t2033230081 - Nguyễn Thị Ngọc Hiểu");
            Console.WriteLine("\n*************************************************************************************************************");
        }
        
        public void showMenu()
        {
            Console.WriteLine("\t\t\t\t Chương Trình Menu Chức Năng");
            Console.WriteLine("\t0. Thoát Chương Trình !!!");
            Console.WriteLine("\t1. Thêm Loại Đề Tài (Xml hoặc bàn phím) ");
            Console.WriteLine("\t2. Xuất danh sách các đề tài"); 
            Console.WriteLine("\t3. Tìm kiếm đề tài khi biết tên đề tài / mã số / tên người hướng dẫn / tên người chủ trì."); 
            Console.WriteLine("\t4. Xuất danh sách các đề tài khi biết tên giảng viên hướng dẫn"); 
            Console.WriteLine("\t5. Cập nhật kinh phí thực hiện của các đề tài tăng lên 10 %");
            Console.WriteLine("\t6. Xuất danh sách các đề tài có kinh phí trên 10 triệu");
            Console.WriteLine("\t7. Xuất danh sách các đề tài thuộc lĩnh vực nghiên cứu lý thuyết và có khả năng triển khai vào thực tế.");
            Console.WriteLine("\t8. In ra danh sách đề tài có số câu hỏi khảo sát trên 100 câu."); 
            Console.WriteLine("\t9. In ra danh sách đề tài có thời gian thực hiện trên 4 tháng.");
            Console.WriteLine("\t10. Xóa dư Thừa");
        }

        public void showUI()
        {
            showMenu();
            Console.WriteLine("Nhập Menu (1->10): ");
            int menu = Int32.Parse(Console.ReadLine());
            switch (menu)
            {
                case 0:
                    Console.Write("\n\n\t\t\t Chương Trình Kết Thúc --- Nhóm Hello");
                    Environment.Exit(0);
                    break;
                case 1:
                    UI_ThemDeTai();
                    //Menu Thêm DS từ File khác
                    break;
                case 2:
                    XuatTatCaDeTai();
                    break;
                case 3:
                    Console.WriteLine("Nhập Từ Khóa Để Tìm Kiếm Đề Tài");
                    string key = Console.ReadLine();
                    XuatDeTaiTheoTieuChi(key);
                    break;
                case 4:
                    XuatTatCaDeTaiCoGiangVien();
                    break;
                case 5:
                    CapNhatThemKinhPhi();
                    break;
                case 6:
                    XuatTatCaDeTaiTren10Trieu();
                    break;
                case 7:
                    XuatDTaiNCLT_ThucTe();
                    break;
                case 8:
                    XuatDTaiKinhTe_LonHon100Cau();
                    break;
                case 9:
                    XuatDTaiThucHien4Thang();
                    break;
                case 10:
                    Console.Clear();
                    break;
            }    
        }

        public void UI_ThemDeTai()
        {
            int menuThem;
            do
            {
                Console.Write("Nhập Bàn Phím Từ (1. Thêm Đề Tài ở File Xml; 2. Thêm Đề Tài Nhập Bài Phím): ");
                menuThem = Int32.Parse(Console.ReadLine());
            } while (menuThem > 3 && menuThem < 0);
            
            switch (menuThem)
            {
                
                case 1:
                    //Nhập DS ở Phía Xml
                    XuatTatCaDeTaiTheoFile();
                  break;
                case 2:
                    do
                    {
                        Console.Write("Đề Tài Loại (1. Nghiên Cứu Lý Thuyết | 2. Kinh Tế | 3. Công Nghệ): ");
                        loai = Int32.Parse(Console.ReadLine());
                    } while (loai >= 3 && loai < 0);   
                    NhapThongTinDeTai(loai);
                  break;
                    
            }
        }

    }
  
}
