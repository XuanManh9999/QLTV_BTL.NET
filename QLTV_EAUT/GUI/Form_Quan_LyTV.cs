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
    public partial class Form_Quan_LyTV : Form
    {
        public Form_Quan_LyTV()
        {
            InitializeComponent();
        }

        private void btnXemSach_Click(object sender, EventArgs e)
        {
            Form_QLSV sinhVien = new Form_QLSV();
            sinhVien.ShowDialog();
        }

        private void btnThemSachMuon_Click(object sender, EventArgs e)
        {
            FormQLS formQLS = new FormQLS();
            formQLS.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FormQLTK formQLTK = new FormQLTK();
            formQLTK.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            From_Xem_So_Sinh_VienMuonSach from_Xem_So_Sinh_VienMuonSach = new From_Xem_So_Sinh_VienMuonSach();
            from_Xem_So_Sinh_VienMuonSach.ShowDialog();
        }
    }
}
