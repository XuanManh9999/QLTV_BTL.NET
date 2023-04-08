using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Bus_Sinh_Vien_Dang_Nhap
    {
        SinhVien sinhVien = new SinhVien();
        public bool dang_Nhap_Bus(TaiKhoan taiKhoan)
        {
            if (sinhVien.dangNhap(taiKhoan))
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
