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
            if ((txtTenTaiKhoan.Text == "ADMIN" && txtMatKhau.Text == "123") || (txtTenTaiKhoan.Text == "admin" && txtMatKhau.Text == "123"))
            {
                Form_Quan_LyTV form_Quan_LyTV = new Form_Quan_LyTV();
                this.Hide();
                form_Quan_LyTV.ShowDialog();
            }else
            {
                TaiKhoan taiKhoan = new TaiKhoan("", txtTenTaiKhoan.Text, txtMatKhau.Text, "");
                Bus_Sinh_Vien_Dang_Nhap sinhVien = new Bus_Sinh_Vien_Dang_Nhap();
                if (sinhVien.dang_Nhap_Bus(taiKhoan))
                {
                    MessageBox.Show("Đăng Nhập Thành Công");
                    Form_Trang_Chu trangChuNguoiDung = new Form_Trang_Chu(txtTenTaiKhoan.Text);
                    this.Hide();
                    trangChuNguoiDung.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Đăng Nhập Không Thành Công");
                }
            }
        }

        private void Form_Dang_Nhap_Load(object sender, EventArgs e)
        {

        }

        private void btnQuenMatKhau_Click(object sender, EventArgs e)
        {
            Form_Lay_mat_Khau quenmk = new Form_Lay_mat_Khau();
            quenmk.ShowDialog();
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtTenTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
