using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI
{
    class CheckIn
    {
        MY_DB myDb = new MY_DB();
        public bool insertIDLamViec(string Id)
        {
            SqlCommand command = new SqlCommand("INSERT INTO TimeLamViec (id)" +
                " VALUES (@id)", myDb.getConnection);
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

        public DataTable getdata(SqlCommand command)
        {
            command.Connection = myDb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool insertStudent(string Id, string t2, string t3, string t4, string t5, string t6, string t7, string cn)
        {
            SqlCommand command = new SqlCommand("INSERT INTO ChiaCa(Id, Thu2,Thu3,Thu4,Thu5,Thu6,Thu7,CN)" +
                "VALUES (@ID, @t2, @t3, @t4, @t5, @t6, @t7, @cn)", myDb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@t2", SqlDbType.VarChar).Value = t2;
            command.Parameters.Add("@t3", SqlDbType.VarChar).Value = t3;
            command.Parameters.Add("@t4", SqlDbType.VarChar).Value = t4;
            command.Parameters.Add("@t5", SqlDbType.VarChar).Value = t5;
            command.Parameters.Add("@t6", SqlDbType.VarChar).Value = t6;
            command.Parameters.Add("@t7", SqlDbType.VarChar).Value = t7;
            command.Parameters.Add("@cn", SqlDbType.VarChar).Value = cn;
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
        
        public bool updateTimeStartCa1(string Id, DateTime Ts)
        {
            SqlCommand command = new SqlCommand("UPDATE TimeLamViec SET TimeStart1=@t2 WHERE Id=@Id", myDb.getConnection);
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@t2", SqlDbType.DateTime).Value = Ts;
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
        public bool updateTimeStartCa2(string Id, DateTime Ts)
        {
            SqlCommand command = new SqlCommand("UPDATE TimeLamViec SET TimeStart2=@t2 WHERE Id=@Id", myDb.getConnection);
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@t2", SqlDbType.DateTime).Value = Ts;
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
        public bool updateTimeStartCa3(string Id, DateTime Ts)
        {
            SqlCommand command = new SqlCommand("UPDATE TimeLamViec SET TimeStart3=@t2 WHERE Id=@Id", myDb.getConnection);
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@t2", SqlDbType.DateTime).Value = Ts;
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
        public bool updateTimeEndCa1(string Id, DateTime Te)
        {
            SqlCommand command = new SqlCommand("UPDATE TimeLamViec SET TimeEnd1=@t2 WHERE Id=@Id", myDb.getConnection);
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@t2", SqlDbType.DateTime).Value = Te;
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
        public bool updateTimeEndCa2(string Id, DateTime Te)
        {
            SqlCommand command = new SqlCommand("UPDATE TimeLamViec SET TimeEnd2=@t2 WHERE Id=@Id", myDb.getConnection);
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@t2", SqlDbType.DateTime).Value = Te;
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
        public bool updateTimeEndCa3(string Id, DateTime Te)
        {
            SqlCommand command = new SqlCommand("UPDATE TimeLamViec SET TimeEnd3=@t2 WHERE Id=@Id", myDb.getConnection);
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@t2", SqlDbType.DateTime).Value = Te;
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
      
     
        public bool updateTimeDayNew()
        {
            SqlCommand command = new SqlCommand("UPDATE TimeLamViec SET TimeStart1=null,TimeEnd1=null, TimeStart2=null,TimeEnd2=null, TimeStart3=null,TimeEnd3=null ", myDb.getConnection);

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

        public bool deleteGioLam()
        {
            SqlCommand command = new SqlCommand("DELETE FROM TimeLamViec ", myDb.getConnection);
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
