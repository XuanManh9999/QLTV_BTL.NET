using BUS;
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
    public partial class Form_Mua_Sach : Form
    {
        public string masv;
        public string tenTk;
        public double gia = 0;
        public Form_Mua_Sach()
        {
            InitializeComponent();
        }
        public Form_Mua_Sach(string masv, string tenTk)
        {
            InitializeComponent();
            this.masv = masv;
            this.tenTk = tenTk;
        }
        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
        public void HienThi()
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = CommandType.Text;
            sqlCMD.CommandText = $"select TENSV, TIEN from SINHVIEN where MASV = '{masv}'";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();

            if (reader.Read())
            {
                string s = $"Xin Chào: {reader.GetString(0)} | Số Tiền Hiện Có: {reader.GetDouble(1)}";
                lblThongTin.Text = s;
            }
            reader.Close();
        }
        private void Form_Mua_Sach_Load(object sender, EventArgs e)
        {
            HienThi();
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = CommandType.Text;
            sqlCMD.CommandText = $"select TENSACH, SOTIEN from SACH, MUON where SACH.MASACH = MUON.MASACH and MUON.MASV = (select MASV from TAIKHOAN where TAIKHOAN.TENTK = '{tenTk}')";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            string s = "";
            while (reader.Read())
            {
                s += $"| {reader.GetString(0)} |";
                gia += reader.GetDouble(1);
            }
            lblTenSach.Text = s;
            lblGiaSach.Text = gia.ToString() + " VNĐ";
            reader.Close();

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (txtNhanHang.Text != "" && txtSoDienThoai.Text != "")
            {
                Bus_Mua_Sach mua_Sach = new Bus_Mua_Sach();
                if (mua_Sach.bus_mua_Sach(gia, masv))
                {
                    MessageBox.Show("Mua Thành Công, Hãy Chú Ý Điện Thoại Của Em Trong Một Vài Ngày Tới.",
                    "Thông Báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    HienThi();
                }
                else
                {
                    MessageBox.Show("Mua Không Thành Công.",
                   "Thông Báo",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }else
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin",
                    "Thông Báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            
        }

        private void lblGiaSach_Click(object sender, EventArgs e)
        {

        }
    }
}
