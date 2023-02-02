using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI
{
    class BaoHanh
    {
        MY_DB mydb = new MY_DB();

        public bool ThemBaoHanh(string maXe, string maCV, int gia)
        {
            SqlCommand command = new SqlCommand("INSERT INTO BaoHanh (MaXe, MaCV, Gia) VALUES (@maXe, @maCV, @tien)", mydb.getConnection);

            command.Parameters.Add("@maXe", SqlDbType.VarChar).Value = maXe;
            command.Parameters.Add("@maCV", SqlDbType.VarChar).Value = maCV;
            command.Parameters.Add("@tien", SqlDbType.Int).Value = gia;


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


        public DataTable getBaoHanh(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


        public bool XoaBaoHanh(string maXe, string maCV)
        {
            SqlCommand command = new SqlCommand("DELETE FROM BaoHanh WHERE MaXe = @maXe and MaCV  = @maCV", mydb.getConnection);
            command.Parameters.Add("@maXe", SqlDbType.VarChar).Value = maXe;
            command.Parameters.Add("@maCV", SqlDbType.VarChar).Value = maCV;

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

        public bool CapNhatBaoHanh(string maXe, string maCV, int gia)
        {
            SqlCommand command = new SqlCommand("UPDATE BaoHanh SET Gia = @gia WHERE MaXe = @maXe and MaCV = @maCV", mydb.getConnection);

            command.Parameters.Add("@maXe", SqlDbType.VarChar).Value = maXe;
            command.Parameters.Add("@maCV", SqlDbType.VarChar).Value = maCV;
            command.Parameters.Add("@gia", SqlDbType.Int).Value = gia;

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

        public bool KiemTraBaoHanh(string maXe, string maCV)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM BaoHanh WHERE MaXe = @maXe and maCV = @maCV", mydb.getConnection);
            command.Parameters.Add("@maXe", SqlDbType.VarChar).Value = maXe;
            command.Parameters.Add("@maCV", SqlDbType.VarChar).Value = maCV;

            DataTable table = this.getBaoHanh(command);
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
