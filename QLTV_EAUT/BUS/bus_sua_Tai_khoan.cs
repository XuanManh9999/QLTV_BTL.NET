using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class bus_sua_Tai_khoan
    {
        QuanLy quanLy = new QuanLy();
        public bool bus_suaTaiKhaon(TaiKhoan taiKhoan)
        {
            if (quanLy.SuaTaiKhoan(taiKhoan))
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
