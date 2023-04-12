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
    public partial class Form_QLSV : Form
    {
        public Form_QLSV()
        {
            InitializeComponent();
        }
        public void HienThiSinhVien()
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = CommandType.Text;
            sqlCMD.CommandText = "select * from sinhvien";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            lsvHienThi.Items.Clear();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader.GetString(0));
                item.SubItems.Add(reader.GetString(1));
                item.SubItems.Add(reader.GetString(2));
                item.SubItems.Add(reader.GetString(3));
                item.SubItems.Add(reader.GetString(4));
                item.SubItems.Add(reader.GetString(5));
                item.SubItems.Add(reader.GetDouble(6).ToString());
                lsvHienThi.Items.Add(item);
            }
            reader.Close();
        }
        private void Form_QLSV_Load(object sender, EventArgs e)
        {
            HienThiSinhVien();
        }

        private void lsvHienThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvHienThi.SelectedItems.Count == 0) return;
            ListViewItem item = lsvHienThi.SelectedItems[0];
            txtMaSV.Text = item.SubItems[0].Text;
            txtTenSV.Text = item.SubItems[1].Text;
            txtNgaySinh.Text = item.SubItems[2].Text;
            txtDiaChi.Text = item.SubItems[3].Text;
            txtSoDienThoai.Text = item.SubItems[4].Text;
            txtLop.Text = item.SubItems[5].Text;
            txtTien.Text = item.SubItems[6].Text;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVien sinhVien = new SinhVien(txtMaSV.Text.ToString(), txtTenSV.Text.ToString(), txtNgaySinh.Text.ToString(), txtDiaChi.Text.ToString(), txtSoDienThoai.Text.ToString(), txtLop.Text.ToString(), double.Parse(txtTien.Text.ToString()));
                bus_Them_SV themSV = new bus_Them_SV();
                if (themSV.bus_ADD_SV(sinhVien))
                {
                    MessageBox.Show("Thêm Thành Công");
                    HienThiSinhVien();
                }
                else
                {
                    MessageBox.Show("Đã tồn tại sinh viên đó trong hệ thống, vui lòng thao tác lại");
                }
            }
            catch
            {
                MessageBox.Show("Đã tồn tại sinh viên đó trong hệ thống, vui long thao tác lại");
            }
        }

        private void txtTenSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVien sinhVien = new SinhVien(txtMaSV.Text.ToString(), txtTenSV.Text.ToString(), txtNgaySinh.Text.ToString(), txtDiaChi.Text.ToString(), txtSoDienThoai.Text.ToString(), txtLop.Text.ToString(), double.Parse(txtTien.Text.ToString()));
                Bus_Sua_Sinh_Vien suaSV = new Bus_Sua_Sinh_Vien();
                if (suaSV.bus_suaSV(sinhVien))
                {
                    MessageBox.Show("Sửa Thành Công");
                    HienThiSinhVien();
                }
                else
                {
                    MessageBox.Show("Sửa Thất Bại. Vui Lòng Thao Tác Lại");
                }
            }
            catch
            {
                    MessageBox.Show("Sửa Thất Bại. Vui Lòng Thao Tác Lại");

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVien sinhVien = new SinhVien(txtMaSV.Text.ToString(), txtTenSV.Text.ToString(), txtNgaySinh.Text.ToString(), txtDiaChi.Text.ToString(), txtSoDienThoai.Text.ToString(), txtLop.Text.ToString(), double.Parse(txtTien.Text.ToString()));
                Bus_Xoa_Sinh_Vien xoaSv = new Bus_Xoa_Sinh_Vien();
                if (xoaSv.bus_XoaSV(sinhVien))
                {
                    MessageBox.Show("Xóa Thành Công");
                    HienThiSinhVien();
                }
                else
                {
                    MessageBox.Show("Xóa Không Thành Công, vui lòng kiểm tra và thử lại.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Xóa Không Thành Công, vui lòng kiểm tra và thử lại.");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int x = 0;
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = CommandType.Text;
            sqlCMD.CommandText = $"select * from SINHVIEN where TENSV like '%{txtTiemKiem.Text}%' or DIACHI like '%{txtTiemKiem.Text}%' or LOP like '%{txtTiemKiem.Text}%'";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            lsvHienThi.Items.Clear();
            while(reader.Read())
            {
                x = 1;
                bus_Tim_Kiem tim = new bus_Tim_Kiem();
                tim.bus_tim_Kiem(1);
                ListViewItem item = new ListViewItem(reader.GetString(0));
                item.SubItems.Add(reader.GetString(1));
                item.SubItems.Add(reader.GetString(2));
                item.SubItems.Add(reader.GetString(3));
                item.SubItems.Add(reader.GetString(4));
                item.SubItems.Add(reader.GetString(5));
                item.SubItems.Add(reader.GetDouble(6).ToString());
                lsvHienThi.Items.Add(item);
            }
            reader.Close();
            if (x == 0)
            {
                bus_Tim_Kiem tim = new bus_Tim_Kiem();
                tim.bus_tim_Kiem(0);
            }
        }
    }
}
