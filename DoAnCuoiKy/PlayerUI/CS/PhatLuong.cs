using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI
{
    class PhatLuong
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

        public bool insertLuong(string Id)
        {
            SqlCommand command = new SqlCommand("INSERT INTO LuongNV(Id)" +
                "VALUES (@ID)", myDb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
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
        public bool updateLuong(string Id, int Te)
        {
            SqlCommand command = new SqlCommand("UPDATE LuongNV SET Luong=@t2 WHERE Id=@Id", myDb.getConnection);
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@t2", SqlDbType.Int).Value = Te;
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

        public bool resetLuong()
        {
            SqlCommand command = new SqlCommand("UPDATE LuongNV SET Luong = null", myDb.getConnection);

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

        public bool deleteLuong()
        {
            SqlCommand command = new SqlCommand("DELETE FROM LuongNV ", myDb.getConnection);
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

    }
}
