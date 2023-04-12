using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class bus_them_tai_Khoan
    {
        QuanLy quanLy = new QuanLy();
        public bool bus_Them_TK (TaiKhoan taiKhoan)
        {
            if (quanLy.themTaiKhoan(taiKhoan))
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
