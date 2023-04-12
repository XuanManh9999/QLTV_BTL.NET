using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Bus_Sua_Sach
    {
        QuanLy quanLy = new QuanLy();
        public bool bus_sua_Sach(Sach sach)
        {
            if (quanLy.suaSach(sach))
            {
                return true;
            }
            return false;
        }
    }
}
