using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI
{
    class CaLam
    {
        MY_DB myDb = new MY_DB();
        public bool updateLamHo2(string Id, int Thu2)
        {
            SqlCommand command = new SqlCommand("UPDATE ChiaCa SET Thu2=@t2 WHERE Id=@Id", myDb.getConnection);
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@t2", SqlDbType.Int).Value = Thu2;
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
        public bool updateLamHo3(string Id, int Thu2)
        {
            SqlCommand command = new SqlCommand("UPDATE ChiaCa SET Thu3=@t2 WHERE Id=@Id", myDb.getConnection);
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@t2", SqlDbType.Int).Value = Thu2;
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
        public bool updateLamHo4(string Id, int Thu2)
        {
            SqlCommand command = new SqlCommand("UPDATE ChiaCa SET Thu4=@t2 WHERE Id=@Id", myDb.getConnection);
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@t2", SqlDbType.Int).Value = Thu2;
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
        public bool updateLamHo5(string Id, int Thu2)
        {
            SqlCommand command = new SqlCommand("UPDATE ChiaCa SET Thu5=@t2 WHERE Id=@Id", myDb.getConnection);
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@t2", SqlDbType.Int).Value = Thu2;
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
        public bool updateLamHo6(string Id, int Thu2)
        {
            SqlCommand command = new SqlCommand("UPDATE ChiaCa SET Thu6=@t2 WHERE Id=@Id", myDb.getConnection);
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@t2", SqlDbType.Int).Value = Thu2;
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
        public bool updateLamHo7(string Id, int Thu2)
        {
            SqlCommand command = new SqlCommand("UPDATE ChiaCa SET Thu7=@t2 WHERE Id=@Id", myDb.getConnection);
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@t2", SqlDbType.Int).Value = Thu2;
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
        public bool updateLamHoCN(string Id, int Thu2)
        {
            SqlCommand command = new SqlCommand("UPDATE ChiaCa SET CN=@t2 WHERE Id=@Id", myDb.getConnection);
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@t2", SqlDbType.Int).Value = Thu2;
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
