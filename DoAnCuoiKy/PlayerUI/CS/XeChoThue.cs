using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI
{
    class XeChoThue
    {
        MY_DB myDb = new MY_DB();

        public DataTable getdata(SqlCommand command)
        {
            command.Connection = myDb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool insertXeThue(string Id)
        {
            SqlCommand command = new SqlCommand("INSERT INTO XeChoThue(MaXe, TinhTrang)" +
                "VALUES (@ID, @flag)", myDb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@flag", SqlDbType.Int).Value = 0;
            myDb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                myDb.closeConnection();
                return true;
            }
            else
            {
                myDb.closeConnection();
                return false;
            }
        }
        public bool updateTinhTrang(string Id, int flag)
        {
            SqlCommand command = new SqlCommand("UPDATE XeChoThue SET TinhTrang=@flag WHERE MaXe=@Id", myDb.getConnection);
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@flag", SqlDbType.Int).Value = flag;
            myDb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                myDb.closeConnection();
                return true;
            }
            else
            {
                myDb.closeConnection();
                return false;
            }
        }


        public bool deleteXeThue(string maxe)
        {
            SqlCommand command = new SqlCommand("DELETE FROM XeChoThue WHERE MaXe = @ma", myDb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maxe;
            myDb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                myDb.closeConnection();
                return true;
            }
            else
            {
                myDb.closeConnection();
                return false;
            }
        }

        public bool checkXeThue(string maxe)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM XeChoThue WHERE MaXe = @ma", myDb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maxe;

            DataTable table = this.getdata(command);
            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }
}
