using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class bus_Them_SV
    {
        QuanLy quanLy = new QuanLy();
        public bool bus_ADD_SV(SinhVien sinhVien)
        {
            if (quanLy.themSinhVien(sinhVien))
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
