using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CONNECT
    {
        public static SqlConnection chuoiKetNoi()
        {
            string strCon = @"Data Source=DESKTOP-LNJ99RH\SQLEXPRESS;Initial Catalog=QUANLYTHUVIEN;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            return sqlCon;
        }
    }
}
