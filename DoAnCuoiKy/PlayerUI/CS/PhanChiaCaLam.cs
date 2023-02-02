using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI
{
    class PhanChiaCaLam
    {

        MY_DB myDb = new MY_DB();
        public DataTable getCaLam(SqlCommand command)
        {
            command.Connection = myDb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool updateCaLam(string Id, int Thu2, int Thu3, int Thu4, int Thu5, int Thu6, int Thu7, int CN)
        {
            SqlCommand command = new SqlCommand("UPDATE ChiaCa SET Thu2=@t2, Thu3=@t3, Thu4=@t4, Thu5=@t5, Thu6=@t6, Thu7=@t7, CN=@cn WHERE Id=@Id", myDb.getConnection);
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@t2", SqlDbType.Int).Value = Thu2;
            command.Parameters.Add("@t3", SqlDbType.Int).Value = Thu3;
            command.Parameters.Add("@t4", SqlDbType.Int).Value = Thu4;
            command.Parameters.Add("@t5", SqlDbType.Int).Value = Thu5;
            command.Parameters.Add("@t6", SqlDbType.Int).Value = Thu6;
            command.Parameters.Add("@t7", SqlDbType.Int).Value = Thu7;
            command.Parameters.Add("@cn", SqlDbType.Int).Value = CN;
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

        public bool insertCaLam(string Id, int Thu2, int Thu3, int Thu4, int Thu5, int Thu6, int Thu7, int CN)
        {
            SqlCommand command = new SqlCommand("INSERT INTO ChiaCa (Thu2, Thu3, Thu4, Thu5, Thu6, Thu7, CN, Id)" +
                "VALUES(@t2, @t3, @t4, @t5, @t6, @t7, @cn, @Id)", myDb.getConnection);
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@t2", SqlDbType.Int).Value = Thu2;
            command.Parameters.Add("@t3", SqlDbType.Int).Value = Thu3;
            command.Parameters.Add("@t4", SqlDbType.Int).Value = Thu4;
            command.Parameters.Add("@t5", SqlDbType.Int).Value = Thu5;
            command.Parameters.Add("@t6", SqlDbType.Int).Value = Thu6;
            command.Parameters.Add("@t7", SqlDbType.Int).Value = Thu7;
            command.Parameters.Add("@cn", SqlDbType.Int).Value = CN;
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

        public bool deleteChiaCa()
        {
            SqlCommand command = new SqlCommand("DELETE FROM ChiaCa ", myDb.getConnection);
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
