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
    class Giuxe
    {
        MY_DB mydb = new MY_DB();

        public bool ThemGiuXe(string maXe, string maVe, DateTime ngayVao, DateTime ngayHet, int flag)
        {
            SqlCommand command = new SqlCommand("INSERT INTO GiuXe (MaXe, MaVe, NgayVaoBen, NgayHetHan, Tien)" +
                "VALUES (@maXe, @maVe, @vao, @het, @flag)", mydb.getConnection);

            command.Parameters.Add("@maXe", SqlDbType.VarChar).Value = maXe;
            command.Parameters.Add("@maVe", SqlDbType.VarChar).Value = maVe;
            command.Parameters.Add("@vao", SqlDbType.DateTime).Value = ngayVao;
            command.Parameters.Add("@het", SqlDbType.DateTime).Value = ngayHet;
            command.Parameters.Add("@flag", SqlDbType.Int).Value = flag;

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


        public DataTable getGiuXe(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


        public bool XoaGiuXe(string maXe, string maVe)
        {
            SqlCommand command = new SqlCommand("DELETE FROM GiuXe WHERE MaXe = @maXe and MaVe = @maVe", mydb.getConnection);
            command.Parameters.Add("@maXe", SqlDbType.VarChar).Value = maXe;
            command.Parameters.Add("@maVe", SqlDbType.VarChar).Value = maVe;

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

        public bool XoaGiuXeBangMaXe(string maXe)
        {
            SqlCommand command = new SqlCommand("DELETE FROM GiuXe WHERE MaXe = @maXe ", mydb.getConnection);
            command.Parameters.Add("@maXe", SqlDbType.VarChar).Value = maXe;


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

        public bool CapNhapTien(string maXe, string maVe, int flag)
        {
            SqlCommand command = new SqlCommand("UPDATE GiuXe SET  Tien = @flag WHERE  MaXe = @maXe and MaVe = @maVe", mydb.getConnection);

            command.Parameters.Add("@maXe", SqlDbType.VarChar).Value = maXe;
            command.Parameters.Add("@maVe", SqlDbType.VarChar).Value = maVe;
            command.Parameters.Add("@flag", SqlDbType.Int).Value = flag;

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

        public bool KiemTraGiuXe(string maXe, string maVe)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM GiuXe WHERE MaXe = @maXe and MaVe = @maVe", mydb.getConnection);
            command.Parameters.Add("@maXe", SqlDbType.VarChar).Value = maXe;
            command.Parameters.Add("@maVe", SqlDbType.VarChar).Value = maVe;

            DataTable table = this.getGiuXe(command);
            if (table.Rows.Count > 0)
            {
                return true;    //Co xe va ve nay trong du lieu
            }
            else
            {
                return false;
            }
        }

        public bool KiemTraXe(string maXe)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM GiuXe WHERE MaXe = @maXe ", mydb.getConnection);
            command.Parameters.Add("@maXe", SqlDbType.VarChar).Value = maXe;

            DataTable table = this.getGiuXe(command);
            if (table.Rows.Count > 0)
            {
                return true;    //Co xe va ve nay trong du lieu
            }
            else
            {
                return false;
            }
        }
    }
}
