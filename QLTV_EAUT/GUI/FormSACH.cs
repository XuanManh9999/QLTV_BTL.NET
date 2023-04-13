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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace GUI
{
    public partial class FormSACH : Form
    {
        public string tenTK;
        public string maSach;
        public FormSACH()
        {
            InitializeComponent();
        }
        public FormSACH(string tenTK)
        {
            InitializeComponent();
            this.tenTK = tenTK;
        }
        private void comboLoaiSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiSach(comboLoaiSach.SelectedItem.ToString().Trim());
        }

        private void FormSACH_Load(object sender, EventArgs e)
        {
            txtThemSach.Text = "";
            SqlCommand sqlCon = new SqlCommand();
            sqlCon.CommandType = CommandType.Text;
            sqlCon.CommandText = "select DISTINCT LOAISACH from SACH";
            sqlCon.Connection = CONNECT.chuoiKetNoi();
            SqlDataReader reader = sqlCon.ExecuteReader();
            while(reader.Read())
            {
                comboLoaiSach.Items.Add(reader.GetString(0));
            }
            comboLoaiSach.SelectedIndex = 0;
            reader.Close();
            
        }
        public void HienThiSach(string s)
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = CommandType.Text;
            sqlCMD.CommandText = $"select * from SACH where LOAISACH = N'{s}'";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            SqlDataReader reader1 = sqlCMD.ExecuteReader();
            lsvHienThiSach.Items.Clear();
            while (reader1.Read())
            {
                ListViewItem item = new ListViewItem(reader1.GetString(0));
                item.SubItems.Add(reader1.GetString(1));
                item.SubItems.Add(reader1.GetDouble(2).ToString());
                item.SubItems.Add(reader1.GetString(3));
                lsvHienThiSach.Items.Add(item);
            }
            reader1.Close();
        }

        private void lsvHienThiSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (lsvHienThiSach.SelectedItems.Count == 0)
            {
            txtThemSach.Text = "";
                return;
            }
            ListViewItem listViewItem = lsvHienThiSach.SelectedItems[0];
            string s1 = listViewItem.SubItems[0].Text;
            string s2 = listViewItem.SubItems[1].Text;
            string s3 = listViewItem.SubItems[2].Text;
            string s4 = listViewItem.SubItems[3].Text;
            string s = s1 + "  |  " + s2 + "  |  " + s3 + "  |  " + s4;
            maSach = s1;
            txtThemSach.Text = s;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            string s = txtTimSach.Text.Trim();
            sqlCMD.CommandText = $"select * from SACH where TENSACH like '%{s}%'";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            lsvHienThiSach.Items.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader.GetString(0));
                    item.SubItems.Add(reader.GetString(1));
                    item.SubItems.Add(reader.GetDouble(2).ToString());
                    item.SubItems.Add(reader.GetString(3));
                    lsvHienThiSach.Items.Add(item);
                }
                reader.Close();
                bus_Tim_Sach tim = new bus_Tim_Sach();
                tim.bus_Tim(1);
                MessageBox.Show("Tìm Thành Công");
            }
            else
            {
                MessageBox.Show("Không Tìm Thấy");
                bus_Tim_Sach tim = new bus_Tim_Sach();
                tim.bus_Tim(0);
            }
           
        }
        public string layMaSV()
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = CommandType.Text;
            sqlCMD.CommandText = $"select MASV from TAIKHOAN where TAIKHOAN.TENTK = '{tenTK}'";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            if (reader.Read() ) { 
                return reader.GetString(0);
            }
            return "err";
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                Muon muonSach = new Muon(layMaSV(), maSach, DateTime.Now.ToString("dd/MM/yyyy"));
                Muon_Sach muon_Sach = new Muon_Sach();
                if (muon_Sach.bus_muonSach(muonSach))
                {
                    MessageBox.Show("Mượn Thành Công. Thơi gian mượn sách của bạn là 7 ngày, sau thời gian này nếu muốn mượn lại hãy đến đăng ký lại.",
                        "Thông Báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Mượn Sách Thất Bại");
                }
            } catch
            {
                MessageBox.Show("Sách Đã Có Trong Giỏ Sách. Vui lòng thêm cuốn khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pickClose_Click(object sender, EventArgs e)
        {
            Form_Trang_Chu trangChu = new Form_Trang_Chu(tenTK);
            this.Hide();
            trangChu.ShowDialog();
        }
    }
}
