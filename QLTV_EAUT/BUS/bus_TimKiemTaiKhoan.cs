using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class bus_TimKiemTaiKhoan
    {
        QuanLy quanLy = new QuanLy();
        public bool bus_Quan_LyTK(int x)
        {
            if (quanLy.TimKiemTk(x))
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
