using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Bus_Xoa_Sach
    {
        QuanLy quanLy = new QuanLy();
        public bool bus_xoa_Sach(Sach sach)
        {
            if (quanLy.xoaSach(sach))
            {
                return true;
            }
            return false;
        }
    }
}
