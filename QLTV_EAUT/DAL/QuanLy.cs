using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IQUANLY
    {
        void themSach();
        void suaSach();
        void xoaSach();
        void timKiemSach();
        void themSinhVien();
        void xoaSinhVien();
        void timKiemSinhVien();
        void kiemTraMuonSach();
    }
    public class QuanLy : Person, IQUANLY
    {
        private string _maQl;

        public string MaQl { get => _maQl; set => _maQl = value; }
        public QuanLy (string maQl, string hoten, string ngaySinh, string diaChi, string soDienThoai) : base(hoten, ngaySinh, diaChi, soDienThoai)
        {
            this.MaQl = maQl;
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.diaChi = diaChi;
            this.soDienThoai = soDienThoai;
        }
        public QuanLy()
        {

        }
       public void themSach() { 

       }
       public void suaSach() {
        }
       public void xoaSach() {
        }
       public void timKiemSach() {
        }
       public void themSinhVien() {
        }
       public void xoaSinhVien() {
        }
       public void timKiemSinhVien() {
        }
       public void kiemTraMuonSach() {
        }
    }
}
