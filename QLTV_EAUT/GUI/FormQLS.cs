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
    public partial class FormQLS : Form
    {
        public FormQLS()
        {
            InitializeComponent();
        }
        public void HienThiSach()
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = CommandType.Text;
            sqlCMD.CommandText = "select * from SACH";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            lsvHienThi.Items.Clear();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader.GetString(0));
                item.SubItems.Add(reader.GetString(1));
                item.SubItems.Add(reader.GetDouble(2).ToString());
                item.SubItems.Add(reader.GetString(3));
                lsvHienThi.Items.Add(item);
            }
            reader.Close();
        }
        private void FormQLS_Load(object sender, EventArgs e)
        {
            HienThiSach();
        }

        private void lsvHienThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvHienThi.SelectedItems.Count == 0) return;
            ListViewItem item = lsvHienThi.SelectedItems[0];
            txtMaSach.Text = item.SubItems[0].Text;
            txtTenSach.Text = item.SubItems[1].Text;
            txtSoTien.Text = item.SubItems[2].Text;
            txtLoaiSach.Text = item.SubItems[3].Text;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                Sach sach = new Sach(txtMaSach.Text, txtTenSach.Text, float.Parse(txtSoTien.Text), txtLoaiSach.Text);
                Bus_ThemSach themSach = new Bus_ThemSach();
                if (themSach.bus_themSach(sach))
                {
                    MessageBox.Show("Thêm Thành Công");
                    HienThiSach();
                }
                else
                {
                    MessageBox.Show("Thêm Không Thành Công, Vui lòng kiểm tra mã, và thao tác lại");
                }
            }
            catch
            {
                MessageBox.Show("Thêm Không Thành Công, Vui lòng kiểm tra mã, và thao tác lại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Sach sach = new Sach(txtMaSach.Text, txtTenSach.Text, float.Parse(txtSoTien.Text), txtLoaiSach.Text);
                Bus_Sua_Sach suaSach = new Bus_Sua_Sach();
                if (suaSach.bus_sua_Sach(sach))
                {
                    MessageBox.Show("Sửa Thành Công");
                    HienThiSach();
                }
                else
                {
                    MessageBox.Show("Sửa Không Thành Công, nhớ là mã sách không được thay đổi. Hãy kiểm tra và thao tác lại");
                }
            }
            catch
            {
                MessageBox.Show("Sửa Không Thành Công, nhớ là mã sách không được thay đổi. Hãy kiểm tra và thao tác lại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                Sach sach = new Sach(txtMaSach.Text, txtTenSach.Text, float.Parse(txtSoTien.Text), txtLoaiSach.Text);
                Bus_Xoa_Sach xoaSach = new Bus_Xoa_Sach();
                if (xoaSach.bus_xoa_Sach(sach))
                {
                    MessageBox.Show("Xóa Thành Công");
                    HienThiSach();
                }
                else
                {
                    MessageBox.Show("Xóa Không Thành Công, không thể xóa đi sách khi đã có sinh viên mượn");
                    HienThiSach();
                }
            }
            catch
            {
                    MessageBox.Show("Xóa Không Thành Công, không thể xóa đi sách khi đã có sinh viên mượn");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int x = 0;
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = CommandType.Text;
            sqlCMD.CommandText = $"select * from SACH where TENSACH like '%{txtTiemKiem.Text}%' or LOAISACH like '%{txtTiemKiem.Text}%'";
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
                item.SubItems.Add(reader.GetDouble(2).ToString());
                item.SubItems.Add(reader.GetString(3));
                lsvHienThi.Items.Add(item);
            }
            reader.Close();
            reader.Close();
            if (x == 0)
            {
                Bus_Tim_Kiem_Sach busTiemSach = new Bus_Tim_Kiem_Sach();
                busTiemSach.bus_tim_kiem_Sach(x);
            }
        }
    }
}
