using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IQUANLY
    {
        bool themSach(Sach sach);
        bool suaSach(Sach sach);
        bool xoaSach(Sach xoaSach);
        bool timKiemSach(int x);
        bool themSinhVien(SinhVien sinhVien);
        bool suaSinhVien(SinhVien sinhvien);
        bool xoaSinhVien(SinhVien sinhVien);
        bool timKiemSinhVien(int x);
        void kiemTraMuonSach();
        bool themTaiKhoan(TaiKhoan taiKhoan);
        bool SuaTaiKhoan(TaiKhoan taiKhoan);
        bool XoaTaiKhoan(TaiKhoan taiKhoan);
        bool TimKiemTk(int x);
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
       public bool themSach(Sach sach) {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"insert into SACH values('{sach.MaSach}', N'{sach.TenSach}', {sach.SoTien}, N'{sach.LoaiSach}')";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            if (sqlCMD.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       public bool suaSach(Sach sach) {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"update SACH set MASACH = '{sach.MaSach}', TENSACH = N'{sach.TenSach}', SOTIEN = {sach.SoTien}, LOAISACH = N'{sach.LoaiSach}' where MASACH = '{sach.MaSach}'";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            if (sqlCMD.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       public bool xoaSach(Sach sach) {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"delete from SACH where MASACH = '{sach.MaSach}'";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            if (sqlCMD.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool timKiemSach(int x) {
            if (x == 1) return true;
            return false;
        }
       public bool themSinhVien(SinhVien sinhVien) {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"INSERT INTO SINHVIEN VALUES('{sinhVien.MaSV}', N'{sinhVien.hoTen}', '{sinhVien.ngaySinh}', N'{sinhVien.diaChi}', '{sinhVien.soDienThoai}', '{sinhVien.Lop}', {sinhVien.Tien});";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            if (sqlCMD.ExecuteNonQuery() > 0)
            {
                return true;
            }else
            {
                return false;
            }
        }
        public bool suaSinhVien(SinhVien sinhVien)
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"update SINHVIEN set MASV = '{sinhVien.MaSV}', TENSV = N'{sinhVien.hoTen}', NGAYSINH = N'{sinhVien.ngaySinh}', DIACHI = N'{sinhVien.diaChi}', SDT = '{sinhVien.soDienThoai}', LOP = '{sinhVien.Lop}', TIEN = {sinhVien.Tien} where MASV = '{sinhVien.MaSV}'";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            if (sqlCMD.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<string> laySVcoTK()
        {
            List<string> list = new List<string>();
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = "select MASV from TAIKHOAN";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            while(reader.Read())
            {
                list.Add(reader.GetString(0));
            }
            return list;
        }
       
        public bool checkTonTai(List<string> s)
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = "select MASV from SINHVIEN";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            int check = 0;
            while (reader.Read())
            {
                foreach(string s1 in s)
                {
                    if (s1 == reader.GetString(0))
                    {
                        check = 1;
                        return true;
                    }
                }
            }
            if (check == 0)
            {
                return false;
            }else
            {
                return true;
            }
        }
       public bool xoaSinhVien(SinhVien sinhVien) {
           if (checkTonTai(laySVcoTK()))
            {
                SqlCommand sqlCMD = new SqlCommand();
                sqlCMD.CommandType = System.Data.CommandType.Text;
                sqlCMD.CommandText = $"delete from TAIKHOAN where MASV = '{sinhVien.MaSV}'";
                sqlCMD.Connection = CONNECT.chuoiKetNoi();
                int x = sqlCMD.ExecuteNonQuery();
                if (x > 0)
                {
                    sqlCMD.CommandText = $"delete from SINHVIEN where MASV = '{sinhVien.MaSV}' ";
                    sqlCMD.Connection = CONNECT.chuoiKetNoi();

                    if (sqlCMD.ExecuteNonQuery() > 0)
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
            }else
            {
                SqlCommand sqlCMD = new SqlCommand();
                sqlCMD.CommandType = System.Data.CommandType.Text;
                sqlCMD.CommandText = $"delete from SINHVIEN where MASV = '{sinhVien.MaSV}' ";
                sqlCMD.Connection = CONNECT.chuoiKetNoi();

                if (sqlCMD.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
       public bool timKiemSinhVien(int x) {
            if (x == 1) return true;
            else return false;
       }
        public bool themTaiKhoan(TaiKhoan taiKhoan)
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"insert into TAIKHOAN values ('{taiKhoan.MaTK}', '{taiKhoan.TenTK}', '{taiKhoan.MatKhau}', '{taiKhoan.MaSV}')";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            if (sqlCMD.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SuaTaiKhoan(TaiKhoan taiKhoan)
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"update TAIKHOAN set MATK = '{taiKhoan.MaTK}', TENTK = N'{taiKhoan.TenTK}', MATKHAU = '{taiKhoan.MatKhau}', MASV = '{taiKhoan.MaSV}' where MATK = '{taiKhoan.MaTK}'";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            if (sqlCMD.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool XoaTaiKhoan(TaiKhoan taiKhoan)
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"delete from TAIKHOAN where MATK = '{taiKhoan.MaTK}'";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            if (sqlCMD.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool TimKiemTk(int x)
        {
            if (x == 1) return true;
            else return false;
        }
        public void kiemTraMuonSach() {
        }
    }
}
