using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Bus_Dang_ky
    {
        SinhVien sinhVien = new SinhVien();
        public bool bus_dktk(TaiKhoan taiKhoan)
        {
            if (sinhVien.dangKy(taiKhoan))
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
