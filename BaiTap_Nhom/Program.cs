using BaiTap_Nhom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap_NhomHello
{
    public class Program
    {
        static void Main(string[] args)
        {
            GUIBaiTapNhom UI = new GUIBaiTapNhom();
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            UI.showThongTinNhom();
            do
            {
                UI.showUI();
            } while (true);
        }
    }
}
