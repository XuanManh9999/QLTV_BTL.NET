using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class bus_Tim_Sach
    {
       SinhVien sinhVien = new SinhVien();
       public bool bus_Tim(int x)
        {
            if (sinhVien.timSach(x))
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
