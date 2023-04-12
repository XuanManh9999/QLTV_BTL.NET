using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Bus_Tim_Kiem_Sach
    {
        QuanLy quanLy = new QuanLy();
        public bool bus_tim_kiem_Sach(int x)
        {
            if (quanLy.timKiemSach(x)) return true;
            return false;
        }
    }
}
