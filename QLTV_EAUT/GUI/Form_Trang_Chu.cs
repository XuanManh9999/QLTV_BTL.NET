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
    public partial class Form_Trang_Chu : Form
    {
        public string s;
        public Form_Trang_Chu()
        {
            InitializeComponent();
        }
        public Form_Trang_Chu(string tenTaiKhoan)
        {
            InitializeComponent();
            s = tenTaiKhoan;
        }
        private void btnXemSach_Click(object sender, EventArgs e)
        {
            FormSACH formSach = new FormSACH(s);
            formSach.ShowDialog();
        }

        private void Form_Trang_Chu_Load(object sender, EventArgs e)
        {
            
        }
        private void btnThemSachMuon_Click(object sender, EventArgs e)
        {
            Gio_Sach gio_Sach = new Gio_Sach(s);
            gio_Sach.ShowDialog();

        }
    }
}
