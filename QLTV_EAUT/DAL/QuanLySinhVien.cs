using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuanLySinhVien
    {
        private string maSV;
        private string maQL;
        public string MaSV { get => maSV; set => maSV = value; }
        public string MaQL { get => maQL; set => maQL = value; }
        public QuanLySinhVien() { }
        public QuanLySinhVien(string maSV, string maQL) {
            this.MaSV = maSV;
            this.MaQL = maQL;
        }

    }
}
