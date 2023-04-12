using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class bus_Xoa_TaiKhoan
    {
        QuanLy quanLy = new QuanLy();
        public bool bus_Xoa_Tai_Khoan(TaiKhoan taiKhoan)
        {
            if (quanLy.XoaTaiKhoan(taiKhoan))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
