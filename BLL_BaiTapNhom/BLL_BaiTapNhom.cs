using DTO_BaiTapNhom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_BaiTapNhom;

namespace BLL_BaiTapNhom
{
    public class BLL_BaiTapNhom
    {
            4.2
            public void ThemDeTaiMoi(List<DTO_cDeTai> dsDeTai)
        {
            DTO_cDeTai deTaiMoi = null;
            Console.WriteLine("nhap ma so de tai:");
            deTaiMoi.maDeTai = Console.ReadLine();
            Console.WriteLine("nhap ten de tai:");
            deTaiMoi.tenDeTai = Console.ReadLine();
            Console.WriteLine("nhap ten trương nhom:");
            deTaiMoi.truongNhom = Console.ReadLine();
            Console.WriteLine("nhap giang vien huong dan:");
            deTaiMoi.hoTenGV = Console.ReadLine();
            Console.WriteLine("nhap ngay bat dau:");
            deTaiMoi.ngayBatDau = Console.ReadLine();
            Console.WriteLine("nhap ngay ket thuc:");
            deTaiMoi.ngayKetThuc = Console.ReadLine();
            Console.WriteLine("Chon linh vuc de tai(1: Nghiên cứu lý thuyết, 2: Kinh tế, 3: Cong nghe):");
            int loaiDeTai = int.Parse(Console.ReadLine());
            switch (loaiDeTai)
            {
                case 1: // Nghiên cứu lý thuyết
                    Console.WriteLine("Có áp dụng thực tế không (true/false)?");
                    bool is_thucTe = bool.Parse(Console.ReadLine());
                    deTaiMoi = new DTO_NCLT(maDeTai, tenDeTai, truongNhom, hoTenGV, ngayBatDau, ngayKetThuc, is_thucTe);
                    break;
                case 2: // Kinh tế
                    Console.WriteLine("Nhập số câu hỏi khảo sát:");
                    int soCauHoi = int.Parse(Console.ReadLine());
                    deTaiMoi = new DTO_KinhTe(maDeTai, tenDeTai, truongNhom, hoTenGV, ngayBatDau, ngayKetThuc, soCauHoi);
                    break;
                case 3: // Công nghệ
                    Console.WriteLine("Chọn môi trường triển khai (web/mobile/window):");
                    string MoiTruong = Console.ReadLine();
                    deTaiMoi = new DTO_CongNghe(maDeTai, tenDeTai, truongNhom, hoTenGV, ngayBatDau, ngayKetThuc, MoiTruong);
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    return;
            }
            // Tính kinh phí
            deTaiMoi.KinhPhi = deTaiMoi.TinhKinhPhi();
            // Thêm vào danh sách
            dsDeTai.Add(deTaiMoi);


            // 4.3     hàm xuất đã có sẵn trong các DTO nên phần logic viết ở DTO   
            /*
            public void xuat(DTO_cDeTai dsDeTai)
            {
                Console.WriteLine($"ma de tai: {dsDeTai.maDeTai}, Ten De Tai: {dsDeTai.tenDeTai}, Kinh phi: {dsDeTai.KinhPhi}, Truong nhom la: {dsDeTai.truongNhom}, Giao Vien hướng dẫn: {dsDeTai.hoTenGV}, Ngay bat dau:{dsDeTai.ngayBatDau}, Ngay ket thuc: {dsDeTai.ngayKetThuc}");
            }
            */

            //4.4
            public void TimKiemVaXuatKetQua(List<DTO_cDeTai> dsDeTai) {
                // nhap từ khóa tìm kiếm từ người dùng
                Console.WriteLine("nhap tu khoa tiem kiem :");
                string tuKhoa = Console.ReadLine();
                List<DTO_cDeTai> ketQua = new List<DTO_cDeTai>();
                foreach (DTO_cDeTai deTai in dsDeTai) {
                    if (deTai.maDeTai.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase) || deTai.tenDeTai.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase) || deTai.truongNhom.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase) || deTai.hoTenGV.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase)) {
                        ketQua.Add(deTai);
                    }
                }
                if (ketQua.Count > 0) {
                    Console.WriteLine($"Tìm thấy {ketQua.Count} đề tài khớp với từ khóa:");
                }
                else {
                    Console.WriteLine("khong tim thay tu khoa nay.");
                }
            }


            // 4.5 Di chuyển sang lớp DTO
            /*
            public void XuatDSDeTaiCoGVHD(List<DTO_cDeTai> dsDeTai)
            {
                bool check = false;
                try
                {
                    for (int i = 0; i < dsDeTai.Count; i++)
                    {
                        if (dsDeTai[i].HoTenGV != null)
                        {
                            xuat(dsDeTai[i]);  // Ai làm phần xuất danh sách đề tài thì viết tên hàm xuất giống như này
                            check = true;
                        }
                    }
                    if (check == false)
                    {
                        throw new Exception("Các đề tài trong danh sách không có GVHD");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            */
            
            
            // 4.6 chuyển qua lớp DTO
            /*
            public void CapNhapKinhPhi(List<DTO_cDeTai> dsDeTai)
            {
                for (int i = 0; i < dsDeTai.Count; i++)
                {
                    dsDeTai[i].KinhPhi = dsDeTai[i].KinhPhi + (dsDeTai[i].KinhPhi * (10 / 100.0));
                }
            }
            */

            // 4.7 Di chuyển hàm sang lớp DTO
            /*
            public void XuatDSDeTaiTren10TR(List<DTO_cDeTai> dsDeTai)
            {
                foreach (DTO_cDeTai a in dsDeTai)
                {
                    if (a.KinhPhi > 10)
                    {
                        xuat(a);
                    }
                }
            }
            */
                
            //4.8
            public void XuatDSDeTaiLyThuyetApDungThucTe(List<DTO_cDeTai> dsDeTai)
            {
                bool check = false;
                try
                {
                    for (int i = 0; i < dsDeTai.Count; i++)
                    {
                        if (dsDeTai[i].LoaiLinhVuc == "Lý thuyết" && dsDeTai[i].ApDungThucTe)
                        {
                            xuat(dsDeTai[i]);  // Hàm xuất đã có sẵn, chỉ cần gọi lại.
                            check = true;
                        }
                    }
                    if (check == false)
                    {
                        throw new Exception("Không có đề tài nghiên cứu lý thuyết nào có khả năng triển khai vào thực tế.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            //4.9
            public void XuatDSDeTaiKinhTeTren100CauHoi(List<DTO_cDeTai> dsDeTai)
            {
                bool check = false;
                try
                {
                    for (int i = 0; i < dsDeTai.Count; i++)
                    {
                        if (dsDeTai[i].LoaiLinhVuc == "Kinh tế" && dsDeTai[i].SoCauHoiKhaoSat > 100)
                        {
                            xuat(dsDeTai[i]);  // Hàm xuất đã có sẵn, chỉ cần gọi lại.
                            check = true;
                        }
                    }
                    if (check == false)
                    {
                        throw new Exception("Không có đề tài kinh tế nào có số câu hỏi khảo sát trên 100 câu.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            //4.10
            public void XuatDSDeTaiTren4Thang(List<DTO_cDeTai> dsDeTai)
            {
                bool check = false;
                try
                {
                    for (int i = 0; i < dsDeTai.Count; i++)
                    {
                        TimeSpan thoiGianThucHien = dsDeTai[i].ThoiGianKetThuc - dsDeTai[i].ThoiGianBatDau;
                        if (thoiGianThucHien.TotalDays > 120) // 4 tháng = 120 ngày
                        {
                            xuat(dsDeTai[i]);  // Hàm xuất đã có sẵn, chỉ cần gọi lại.
                            check = true;
                        }
                    }
                    if (check == false)
                    {
                        throw new Exception("Không có đề tài nào có thời gian thực hiện trên 4 tháng.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

    }
}

