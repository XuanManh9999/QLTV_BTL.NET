﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IPERSON
    {
        string hoTen { get; set; }
        string ngaySinh { get; set; }
        string diaChi { get; set; }
        string soDienThoai { get; set; }
    }
    public class Person : IPERSON
    {
        public string hoTen { get; set; }
        public string ngaySinh { get; set; }
        public string diaChi { get; set; }
        public string soDienThoai { get; set; }
        public Person ()
        {

        }
        public Person(string hoten, string ngaySinh, string diaChi, string soDienThoai)
        {
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.diaChi = diaChi;
            this.soDienThoai = soDienThoai;
        }
    }
}
