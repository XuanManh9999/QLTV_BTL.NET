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
        string quenMatKhau(TaiKhoan taiKhoan);
        bool muonSach(Muon muon);
        bool timSach(int s);
        bool muaSach(double soTien, string maSV);
        bool traSach(Muon muon);
    }
    public class SinhVien : Person, ISINHVIEN
    {
        private string _maSV;
        private string _lop;
        private double _tien;
        public string MaSV { get => _maSV; set => _maSV = value; }
        public string Lop { get => _lop; set => _lop = value; }
        public double Tien { get => _tien; set => _tien = value; }

        public SinhVien() { 
        
        }
        public SinhVien(string maSV, string hoten, string ngaySinh, string diaChi, string soDienThoai, string lop, double tien) : base(hoten, ngaySinh, diaChi, soDienThoai){
            this.MaSV = maSV;
            this.Lop = lop;
            this.Tien = tien;
        }
        public bool dangNhap(TaiKhoan taiKhoan) {
            List<string> tenTK = new List<string>();
            List<string> matKhau = new List<string>();
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
                    break;
                }
            }
            foreach(string key in matKhau) { 
                if (key == taiKhoan.MatKhau)
                {
                    check += 1;
                    break;
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
            List<string> tenTK = new List<string>();
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = "select TENTK, MATKHAU from TAIKHOAN";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            while (reader.Read())
            {
                tenTK.Add(reader.GetString(0).Trim());
            }
            reader.Close();
            int check = 0;
            foreach (string key in tenTK)
            {
                if (key == taiKhoan.TenTK)
                {
                    check = 1;
                }
            }
            if (check != 1)
            {
                Random random = new Random();
                int x = random.Next(1, 1000);
                SqlCommand sqlCMD1 = new SqlCommand();
                sqlCMD1.CommandType = System.Data.CommandType.Text;
                sqlCMD1.CommandText = $"insert into TAIKHOAN values ('TK00{x}', N'{taiKhoan.TenTK}', '{taiKhoan.MatKhau}', '{taiKhoan.MaSV}')";
                sqlCMD1.Connection = CONNECT.chuoiKetNoi();
                if (sqlCMD1.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
           
        }
        public string quenMatKhau(TaiKhoan taiKhoan)
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"select MATKHAU from TAIKHOAN where MASV = {taiKhoan.MaSV}";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            if (reader.Read())
            {
                return reader.GetString(0);
            }
            return "err";
        }
        public bool muonSach(Muon muon) {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"insert into MUON values ('{muon.MaSV}', '{muon.MaSach}', '{muon.NgayMuon}')";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            if (sqlCMD.ExecuteNonQuery() > 0)
            {
                return true;
            }else
            {
                return false;
            }
        }
        public bool timSach(int s) {
           if (s > 0)
            {
                return true;
            }else
            {
                return false;
            }
        }
        public bool muaSach(double soTien, string maSV) {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"update SINHVIEN set TIEN -= {soTien} where MASV = '{maSV}'";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            if (sqlCMD.ExecuteNonQuery() > 0)
            {
                return true;
            }else
            {
                return false;
            }
        }
        public bool traSach(Muon muon) {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"delete from MUON where MASV = '{muon.MaSV}' and masach = '{muon.MaSach}'";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            if (sqlCMD.ExecuteNonQuery() > 0)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
