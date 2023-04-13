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
    public partial class FormQLTK : Form
    {
        public FormQLTK()
        {
            InitializeComponent();
        }
        public void HienThiTaiKhoan()
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = CommandType.Text;
            sqlCMD.CommandText = "select * from TAIKHOAN";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            lsvHienThi.Items.Clear();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader.GetString(0));
                item.SubItems.Add(reader.GetString(1));
                item.SubItems.Add(reader.GetString(2));
                item.SubItems.Add(reader.GetString(3));
                lsvHienThi.Items.Add(item);
            }
            reader.Close();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoan taiKhoan = new TaiKhoan(txtMaTK.Text, txtTenTK.Text, txtMatKhau.Text, txtMSV.Text);
                bus_Xoa_TaiKhoan xoaTaiKhoan = new bus_Xoa_TaiKhoan();
                if (xoaTaiKhoan.bus_Xoa_Tai_Khoan(taiKhoan))
                {
                    MessageBox.Show("Xóa Tài Khoản Thành Công.");
                    HienThiTaiKhoan();
                }
            }
            catch
            {
                MessageBox.Show("Xóa Tài Khoản Không Thành Công. Hãy đảm bảo rằng, chưa có sinh viên nào có tài khoản đó.");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int x = 0;
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = CommandType.Text;
            sqlCMD.CommandText = $"select * from TAIKHOAN where TENTK like '%{txtTiemKiem.Text}%' or MASV like '%{txtTiemKiem.Text}%'";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            lsvHienThi.Items.Clear();
            while (reader.Read())
            {
                x = 1;
                Bus_Tim_Kiem_Sach busTiemSach = new Bus_Tim_Kiem_Sach();
                busTiemSach.bus_tim_kiem_Sach(x);
                ListViewItem item = new ListViewItem(reader.GetString(0));
                item.SubItems.Add(reader.GetString(1));
                item.SubItems.Add(reader.GetString(2));
                item.SubItems.Add(reader.GetString(3));
                lsvHienThi.Items.Add(item);
            }
            reader.Close();
            if (x == 0)
            {
                Bus_Tim_Kiem_Sach busTiemSach = new Bus_Tim_Kiem_Sach();
                busTiemSach.bus_tim_kiem_Sach(x);
            }
        }

        private void FormQLTK_Load(object sender, EventArgs e)
        {
            HienThiTaiKhoan();
        }
        string s = "";
        private void lsvHienThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvHienThi.SelectedItems.Count == 0) return;
            ListViewItem item = lsvHienThi.SelectedItems[0];
            txtMaTK.Text = item.SubItems[0].Text;
            s = item.SubItems[0].Text;
            txtTenTK.Text = item.SubItems[1].Text;
            txtMatKhau.Text = item.SubItems[2].Text;
            txtMSV.Text = item.SubItems[3].Text;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoan taiKhoan = new TaiKhoan(txtMaTK.Text, txtTenTK.Text, txtMatKhau.Text, txtMSV.Text);
                bus_them_tai_Khoan themTk = new bus_them_tai_Khoan();
                if (themTk.bus_Them_TK(taiKhoan))
                {
                    HienThiTaiKhoan();
                    MessageBox.Show("Thêm Tài Khoản Thành Công.");
                }
            }
            catch
            {
                MessageBox.Show("Thêm Tài Khoản Không Thành Công. Hãy đảm bảo rằng mã sinh viên đó đã tồn tại trong csdl để có thể thêm tài khoản của bạn");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoan taiKhoan = new TaiKhoan(txtMaTK.Text, txtTenTK.Text, txtMatKhau.Text, txtMSV.Text);
                bus_sua_Tai_khoan suaTk = new bus_sua_Tai_khoan();
                if (suaTk.bus_suaTaiKhaon(taiKhoan))
                {
                    HienThiTaiKhoan();
                    MessageBox.Show("Sửa Tài Khoản Thành Công");
                }
                
            }
            catch
            {
                MessageBox.Show("Sửa Tài Khoản Không Thành Công. Hãy đảm bảo rằng mã sinh viên đó đã tồn tại trong csdl để có thể thêm tài khoản của bạn. Và không sửa mã TK");
            }
        }

        private void pickClose_Click(object sender, EventArgs e)
        {
            Form_Quan_LyTV form_Quan_LyTV = new Form_Quan_LyTV();
            this.Hide();
            form_Quan_LyTV.ShowDialog();
        }
    }
}
