using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Sach
    {
        private string maSach;
        private string tenSach;
        private float soTien;
        private string loaiSach;
        public string MaSach { get => maSach; set => maSach = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public float SoTien { get => soTien; set => soTien = value; }
        public string LoaiSach { get => loaiSach; set => loaiSach = value; }
        public Sach()
        {

        }
        public Sach (string maSach, string tenSach, float soTien, string loaiSach)
        {
            this.maSach = maSach;
            this.tenSach = tenSach;
            this.soTien = soTien;
            this.loaiSach = loaiSach;
        }
    }
}
