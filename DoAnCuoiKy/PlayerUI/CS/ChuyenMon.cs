using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI
{
    class ChuyenMon
    {
        MY_DB mydb = new MY_DB();

        public bool ThemBoPhan(string maCV, string tenCV)
        {
            SqlCommand command = new SqlCommand("INSERT INTO BoPhan (MaBP, TenBP) VALUES (@ma, @ten)", mydb.getConnection);

            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maCV;
            command.Parameters.Add("@ten", SqlDbType.VarChar).Value = tenCV;

            mydb.openConnection();

            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }

        }


        public DataTable getBoPhan(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


        public bool XoaBoPhan(string maCV)
        {
            SqlCommand command = new SqlCommand("DELETE FROM BoPhan WHERE MaBP  = @ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maCV;

            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }

        public bool CapNhatBoPhan(string maCV, string tenCV)
        {
            SqlCommand command = new SqlCommand("UPDATE BoPhan SET tenBP = @ten WHERE  MaBP = @ma", mydb.getConnection);

            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maCV;
            command.Parameters.Add("@ten", SqlDbType.VarChar).Value = tenCV;

            mydb.openConnection();

            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }

        }

        public bool KiemTraBoPhan(string maCV)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM BoPhan WHERE MaBP = @ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maCV;

            DataTable table = this.getBoPhan(command);
            if (table.Rows.Count > 0)
            {
                return true;    //Co xe nay trong du lieu
            }
            else
            {
                return false;
            }
        }
    }
}
