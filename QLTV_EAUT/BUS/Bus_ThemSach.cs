using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Bus_ThemSach
    {
        QuanLy quanLy = new QuanLy();
        public bool bus_themSach(Sach sach)
        {
            if (quanLy.themSach(sach)) return true;
            return false;
        }
    }
}
