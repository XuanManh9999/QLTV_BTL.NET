using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class bus_Tra_Sach
    {
        SinhVien sinhvien = new SinhVien();
        public bool bus_tra_sach(Muon muon)
        {
            if (sinhvien.traSach(muon))
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
