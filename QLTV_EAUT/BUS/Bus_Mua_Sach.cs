using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Bus_Mua_Sach
    {
        SinhVien sinhVien = new SinhVien();
        public bool bus_mua_Sach(double giaTien, string masv)
        {
            if (sinhVien.muaSach(giaTien, masv))
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
