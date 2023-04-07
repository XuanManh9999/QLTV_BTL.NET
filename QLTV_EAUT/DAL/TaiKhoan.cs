using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TaiKhoan : Sach_Va_TaiKhoan
    {
        private string maTK;
        private string tenTK;
        private string matKhau;
        private string maSV;

        public string MaTK { get => maTK; set => maTK = value; }
        public string TenTK { get => tenTK; set => tenTK = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string MaSV { get => maSV; set => maSV = value; }
        public TaiKhoan() { 
        
        }
        public TaiKhoan(string maTK, string tenTK, string matKhau, string maSV)
        {
            this.maTK = maTK;
            this.tenTK = tenTK;
            this.matKhau = matKhau;
            this.maSV  = maSV;
        }
    }
}
