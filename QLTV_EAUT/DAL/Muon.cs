using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Muon
    {
        private string maSV;
        private string maSach;
        private string ngayMuon;

        public string MaSV { get => maSV; set => maSV = value; }
        public string MaSach { get => maSach; set => maSach = value; }
        public string NgayMuon { get => ngayMuon; set => ngayMuon = value; }
        public Muon()
        {

        }
        public Muon(string maSV, string maSach, string ngayMuon)
        {
            this.maSV = maSV;
            this.maSach = maSach;
            this.ngayMuon = ngayMuon;
        }
    }
}
