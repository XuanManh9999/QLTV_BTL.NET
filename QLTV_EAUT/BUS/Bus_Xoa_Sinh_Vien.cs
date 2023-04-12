using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Bus_Xoa_Sinh_Vien
    {
        QuanLy quanLy = new QuanLy();
        public bool bus_XoaSV(SinhVien sinhVien)
        {
            if (quanLy.xoaSinhVien(sinhVien)) return true;
            else return false;
        }
    }
}
