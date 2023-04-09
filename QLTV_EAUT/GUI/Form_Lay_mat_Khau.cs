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
    public partial class Form_Lay_mat_Khau : Form
    {
        public Form_Lay_mat_Khau()
        {
            InitializeComponent();
        }

        private void btnLayLaiMatKhau_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoan taiKhoan = new TaiKhoan("", "", "", txtMaSinhVien.Text);
                bus_Quen_MK quenmk = new bus_Quen_MK();
                if (quenmk.bus_quenMK(taiKhoan) != "err")
                {
                    txtHienThiMK.Text = quenmk.bus_quenMK(taiKhoan);
                }
                else
                {
                    MessageBox.Show("Thao Tác Sai, hoặc không tồn tại tài khoản đó.");
                }
            }
            catch {
                MessageBox.Show("Thao Tác Sai, hoặc không tồn tại tài khoản đó.");
            }
        }

        private void pickClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
