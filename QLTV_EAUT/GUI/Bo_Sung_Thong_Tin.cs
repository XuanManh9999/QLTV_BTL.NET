using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Bo_Sung_Thong_Tin : Form
    {
        public Bo_Sung_Thong_Tin()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtmaSV.Text != "" && txtLop.Text != "" && txtDiaChi.Text != "" && txtSoDienThoai.Text != "" && txtTenSinhVien.Text != "")
            {
                try
                {
                    SqlCommand sqlCMD = new SqlCommand();
                    sqlCMD.CommandType = CommandType.Text;
                    sqlCMD.CommandText = $"INSERT INTO SINHVIEN VALUES('{txtmaSV.Text}', N'{txtTenSinhVien.Text}', '{dateTimePicker1.Value.ToString("dd/MM/yyyy")}', N'{txtDiaChi.Text}', '{txtSoDienThoai.Text}', '{txtLop.Text}', 0);";
                    sqlCMD.Connection = CONNECT.chuoiKetNoi();

                    if (sqlCMD.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập Nhật Không Thành Công!");
                    }
                    Form_DangKY dangKy = new Form_DangKY(txtmaSV.Text);
                    dangKy.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bạn Đã Thao Tác Sai, hoặc mã hiện tại trùng với mã trong hệ thống");
                }
            }else
            {
                MessageBox.Show("Các Thông Tin Không Được Rỗng",
                "Thông Báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void Bo_Sung_Thong_Tin_Load(object sender, EventArgs e)
        {

        }

        private void pickClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
