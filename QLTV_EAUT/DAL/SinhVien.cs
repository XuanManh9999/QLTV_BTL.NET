using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface ISINHVIEN
    {
        bool dangNhap(TaiKhoan taiKhoan);
        bool dangKy(TaiKhoan taiKhoan);
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
        public bool dangNhap(TaiKhoan taiKhoan) {
            List<string> tenTK = new List<string>();
            List<string> matKhau = new List<string>();
            List<string> maSV = new List<string>();
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = "select TENTK, MATKHAU from TAIKHOAN";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            while(reader.Read()) { 
                tenTK.Add(reader.GetString(0).Trim());
                matKhau.Add(reader.GetString(1).Trim());
            }
            reader.Close();
            int check = 0;
            foreach(string key in tenTK) {
                if (key == taiKhoan.TenTK)
                {
                    check += 1;
  
                }
            }
            foreach(string key in matKhau) { 
                if (key == taiKhoan.MatKhau)
                {
                    check += 1;
                }
            }
            if (check == 2)
            {
                return true;
            }else
            {
                return false;
            }
        }
        public List<int> layMaTK()
        {
            List<int> list = new List<int>();
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = "select MATK from TAIKHOAN";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            while(reader.Read())
            {
                list.Add(reader.GetString(0)[reader.GetString(0).Length - 1]);
            }
            reader.Close();
            return list;
        }
        public bool dangKy(TaiKhoan taiKhoan) {
            Random random = new Random();
            int x = random.Next(1, 1000);
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"insert into TAIKHOAN values ('TK00{x}', N'{taiKhoan.TenTK}', '{taiKhoan.MatKhau}', '{taiKhoan.MaSV}')";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            if (sqlCMD.ExecuteNonQuery() > 0)
            {
                return true;
            }else
            {
                return false;
            }
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
