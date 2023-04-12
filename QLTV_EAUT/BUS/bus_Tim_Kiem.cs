using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class bus_Tim_Kiem
    {
        QuanLy quanly = new QuanLy();
        public bool bus_tim_Kiem(int x)
        {
            if(quanly.timKiemSinhVien(x)) return true;
            return false;
        }
    }
}
