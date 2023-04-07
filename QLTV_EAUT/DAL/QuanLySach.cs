using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuanLySach
    {
        private string maQL;
        private string maSach;
        public string MaQL { get => maQL; set => maQL = value; }
        public string MaSach { get => maSach; set => maSach = value; }
        public QuanLySach()
        {

        }
        public QuanLySach(string maQL, string maSach)
        {
            this.MaQL = maQL;
            this.MaSach = maSach;
        }

    }
}
