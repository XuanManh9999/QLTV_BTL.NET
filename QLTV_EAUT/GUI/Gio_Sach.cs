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
    public partial class Gio_Sach : Form
    {
        public string tenTK;
        public string maSV;
        public string maSach;
        public string tenSach;
        public double gia;
        public Gio_Sach()
        {
            InitializeComponent();
        }
        public Gio_Sach(string tenTK)
        {
            InitializeComponent();
            this.tenTK = tenTK;
        }
        public void hienThiDachSachMuon()
        {
            DateTime date = DateTime.Now;
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = CommandType.Text;
            sqlCMD.CommandText = $"select SACH.MASACH, TENSACH, SOTIEN, LOAISACH, NGAYMUON, MASV from SACH, MUON where SACH.MASACH = MUON.MASACH and MUON.MASV = (select MASV from TAIKHOAN where TAIKHOAN.TENTK = '{tenTK}')";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            int year = date.Year; // lấy ra năm hiện tại
            int month = date.Month; // lấy ra tháng hiện tại
            int day = date.Day; // lấy ra ngày hiện tại
            string s = (day + 7) + "/" + month + "/" + year;
            lsvHienThiSach.Items.Clear();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader.GetString(0));
                item.SubItems.Add(reader.GetString(1));
                item.SubItems.Add(reader.GetDouble(2).ToString());
                item.SubItems.Add(reader.GetString(3));
                item.SubItems.Add(reader.GetString(4));
                maSV = reader.GetString(5);
                item.SubItems.Add(s);
                lsvHienThiSach.Items.Add(item);
            }
            reader.Close();

        }
        private void Gio_Sach_Load(object sender, EventArgs e)
        {
            hienThiDachSachMuon();
        }

        private void lsvHienThiSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lsvHienThiSach.SelectedItems.Count == 0)
            {
                return;
            }
            ListViewItem item = lsvHienThiSach.SelectedItems[0];
            maSach = item.SubItems[0].Text;
            tenSach = item.SubItems[1].Text;
            gia = double.Parse(item.SubItems[2].Text);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Muon muon = new Muon(maSV, maSach, "");
            bus_Tra_Sach traSach = new bus_Tra_Sach();
            if (traSach.bus_tra_sach(muon))
            {
                hienThiDachSachMuon();
                MessageBox.Show("Trả Sách Thành Công!");
            }else
            {
                MessageBox.Show("Bạn Phải Chọn Sách Cần Trả Để Có Thể Trả Sách");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form_Mua_Sach muaSach = new Form_Mua_Sach(maSV, tenTK);
            muaSach.ShowDialog();   
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form_Trang_Chu trangChu = new Form_Trang_Chu();
            this.Hide();
            trangChu.ShowDialog();
        }
    }
}
