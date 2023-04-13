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
    public partial class From_Xem_So_Sinh_VienMuonSach : Form
    {
        public From_Xem_So_Sinh_VienMuonSach()
        {
            InitializeComponent();
        }

        private void From_Xem_So_Sinh_VienMuonSach_Load(object sender, EventArgs e)
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = CommandType.Text;
            sqlCMD.CommandText = "select DISTINCT SINHVIEN.MASV, SINHVIEN.TENSV, SINHVIEN.LOP, SACH.TENSACH, SACH.LOAISACH, MUON.NGAYMUON from SINHVIEN, SACH, MUON where SINHVIEN.MASV = MUON.MASV and SACH.MASACH = MUON.MASACH";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            listView1.Items.Clear();
            while(reader.Read())
            {
                ListViewItem item = new ListViewItem(reader.GetString(0));
                item.SubItems.Add(reader.GetString(1));
                item.SubItems.Add(reader.GetString(2));
                item.SubItems.Add(reader.GetString(3));
                item.SubItems.Add(reader.GetString(4));
                item.SubItems.Add(reader.GetString(5));
                listView1.Items.Add(item);
            }
            reader.Close();
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            // Kết Xuất Nguồn Dữ Liệu Cho RePort
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = CommandType.Text;
            sqlCMD.CommandText = "select DISTINCT SINHVIEN.MASV, SINHVIEN.TENSV, SINHVIEN.SDT,  SINHVIEN.LOP, SACH.TENSACH, MUON.NGAYMUON from SINHVIEN, SACH, MUON where SINHVIEN.MASV = MUON.MASV and SACH.MASACH = MUON.MASACH";
            sqlCMD.Connection = CONNECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            DataTable dt = new DataTable("Bảng Sinh Viên Mượn Sách");
            dt.Load(reader);
            // Gán nguồn dữ liệu cho crirty report
            rptSVMUONSACH baoCaoSVMuonSach = new rptSVMUONSACH();
            baoCaoSVMuonSach.SetDataSource(dt);
            // Hiển thị báo cáo
            Thong_Ke_Sinh_Vien_Muon_Sach f = new Thong_Ke_Sinh_Vien_Muon_Sach();
            f.crystalReportViewer1.ReportSource = baoCaoSVMuonSach;
            f.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form_Quan_LyTV form_Quan_LyTV = new Form_Quan_LyTV();
            this.Hide();
            form_Quan_LyTV.ShowDialog();
        }
    }
}
