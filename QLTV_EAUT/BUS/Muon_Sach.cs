using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Muon_Sach
    {
        SinhVien sinhVien = new SinhVien();
        public bool bus_muonSach(Muon muon)
        {
            if (sinhVien.muonSach(muon)) {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
