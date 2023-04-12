using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Bus_Sua_Sinh_Vien
    {
        QuanLy quanLy = new QuanLy();
        public bool bus_suaSV(SinhVien sv)
        {
            if (quanLy.suaSinhVien(sv)) return true;
            else return false;
        }
    }
}
