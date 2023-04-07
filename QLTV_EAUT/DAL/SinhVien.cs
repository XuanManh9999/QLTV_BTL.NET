using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface ISINHVIEN
    {
        void dangNhap();
        void dangKy();
        void muonSach();
        void timSach();
        void muaSach();
        void traSach();
    }
    public class SinhVien : Person, ISINHVIEN
    {
        private string _maSV;
        private string _lop;
        private float _tien;
        public string MaSV { get => _maSV; set => _maSV = value; }
        public string Lop { get => _lop; set => _lop = value; }
        public float Tien { get => _tien; set => _tien = value; }

        public SinhVien() { 
        
        }
        public SinhVien(string maSV, string hoten, string ngaySinh, string diaChi, string soDienThoai, string lop, float tien) : base(hoten, ngaySinh, diaChi, soDienThoai){
        
        }
        public void dangNhap() { 
        
        }
        public void dangKy() {
        
        }
        public void muonSach() {
        
        }
        public void timSach() {
        
        }
        public void muaSach() {
        
        }
        public void traSach() {
        
        }
    }
}
