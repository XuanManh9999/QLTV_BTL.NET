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
    public partial class Form_DangKY : Form
    {
        public Form_DangKY()
        {
            InitializeComponent();
        }
        string maSV = "";
        public Form_DangKY(string s)
        {
            InitializeComponent();
            maSV = s;
        }
        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form_DangKY_Load(object sender, EventArgs e)
        {

        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
           
                if ((txtTenTaiKhoan.Text != "" && txtMatKhau.Text != "" && txtNhapLaiMatKhau.Text != "" && checkBox.Checked == true && txtMatKhau.Text == txtNhapLaiMatKhau.Text)) {
                    TaiKhoan taiKhoan = new TaiKhoan("", txtTenTaiKhoan.Text, txtMatKhau.Text, maSV);
                    Bus_Dang_ky dangKy = new Bus_Dang_ky();
                    if (dangKy.bus_dktk(taiKhoan))
                    {
                        MessageBox.Show("Đăng Ký Tài Khoản Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Đăng Ký Tài Khoản Không Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }else
            {
                MessageBox.Show("Vui Lòng Nhập Đúng Các Thông Tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
