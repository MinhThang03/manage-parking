using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI
{
    class CongViec
    {

        MY_DB mydb = new MY_DB();

        public bool ThemCongViec(string maCV, string tenCV)
        {
            SqlCommand command = new SqlCommand("INSERT INTO CongViec (MaCV, TenCV) VALUES (@ma, @ten)", mydb.getConnection);

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


        public DataTable getCongViec(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


        public bool XoaCongViec(string maCV)
        {
            SqlCommand command = new SqlCommand("DELETE FROM CongViec WHERE MaCV  = @ma", mydb.getConnection);
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

        public bool CapNhatCongViec(string maCV, string tenCV)
        {
            SqlCommand command = new SqlCommand("UPDATE CongVIec SET tenCV = @ten WHERE  MaCV = @ma", mydb.getConnection);

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

        public bool KiemTraCongViec(string maCV)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM CongViec WHERE MaCV = @ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maCV;

            DataTable table = this.getCongViec(command);
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
