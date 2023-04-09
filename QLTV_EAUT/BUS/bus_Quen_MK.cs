using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class bus_Quen_MK
    {
        SinhVien sinhVien = new SinhVien();
        public string bus_quenMK(TaiKhoan taiKhoan)
        {
           if (sinhVien.quenMatKhau(taiKhoan) != "err")
            {
                return sinhVien.quenMatKhau(taiKhoan);
            }else
            {
                return "err";
            }
        }
    }
}
