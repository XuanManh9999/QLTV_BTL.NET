using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form_Dang_Nhap : Form
    {
        public Form_Dang_Nhap()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            Bo_Sung_Thong_Tin boSung = new Bo_Sung_Thong_Tin();
            boSung.ShowDialog();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            TaiKhoan taiKhoan = new TaiKhoan("", txtTenTaiKhoan.Text, txtMatKhau.Text, "");
            Bus_Sinh_Vien_Dang_Nhap sinhVien = new Bus_Sinh_Vien_Dang_Nhap();
            if (sinhVien.dang_Nhap_Bus(taiKhoan))
            {
                MessageBox.Show("Đăng Nhập Thành Công");
            }else
            {
                MessageBox.Show("Đăng Nhập Không Thành Công");
            }
        }

        private void Form_Dang_Nhap_Load(object sender, EventArgs e)
        {

        }
    }
}
