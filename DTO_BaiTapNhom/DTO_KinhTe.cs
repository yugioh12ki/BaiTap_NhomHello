using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_BaiTapNhom
{
    public class DTO_KinhTe : DTO_cDeTai, IHoTroKinhPhi
    {
        #region ThuocTinh

        private int soCauHoi;

        

        public int SoCauHoi { get => soCauHoi; set => soCauHoi = value; }

        #endregion ThuocTinh
        #region method

        public DTO_KinhTe(string maDeTai, string tenDeTai, int kinhPhi, string truongNhom, string ngayBatDau, string ngayKetThuc, string hoTenGV, int soCauHoi) : base(maDeTai, tenDeTai, kinhPhi, truongNhom, ngayBatDau, ngayKetThuc, hoTenGV)
        {
            this.soCauHoi = soCauHoi;
        }

        public DTO_KinhTe()
        {
            soCauHoi = 0;
        }

        public override double TinhKinhPhi()
        {
            if (soCauHoi > 100) KinhPhi = 12000000;
            else KinhPhi = 7000000;
            return KinhPhi;
            throw new NotImplementedException();
        }

        public int ITinhHoTro()
        {
            if (soCauHoi > 100)
                return soCauHoi * 550;
            else
                return soCauHoi * 450;
            throw new NotImplementedException();
        }

        public void xuat()
        {
            throw new NotImplementedException();
        }

        public void nhap()
        {
            throw new NotImplementedException();
        }


        #endregion method
    }
}
