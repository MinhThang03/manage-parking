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
    class VeXe
    {
        MY_DB mydb = new MY_DB();

        Giuxe giuXe = new Giuxe();
        public bool ThemVeXe(string maVe, string loaiVe)
        {
            SqlCommand command = new SqlCommand("INSERT INTO VeXe (MaVe, LoaiVe) VALUES (@ma, @loai)", mydb.getConnection);

            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maVe;
            command.Parameters.Add("@loai", SqlDbType.VarChar).Value = loaiVe;

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


        public DataTable getVe(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


        public bool XoaVe(string maVe)
        {
            SqlCommand command = new SqlCommand("DELETE FROM VeXe WHERE MaVe = @ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maVe;

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


        public bool CapNhatVeXe(string maVe, string loaiVe)
        {
            SqlCommand command = new SqlCommand("UPDATE VeXe SET LoaiVe = @loai WHERE  MaVe = @ma", mydb.getConnection);

            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maVe;
            command.Parameters.Add("@loai", SqlDbType.VarChar).Value = loaiVe;

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

        public bool KiemTraMaVeXe(string maVe)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM VeXe WHERE MaVe = @ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maVe;

            DataTable table = this.getVe(command);
            if (table.Rows.Count > 0)
            {
                return true;    //Co xe nay trong du lieu
            }
            else
            {
                return false;
            }
        }

        public bool KiemTraVeCoTrong(string maVe)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM GiuXe WHERE MaVe in (SELECT MaVe FROM VeXe WHERE MaVe = @ma)");
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maVe;

            DataTable table = giuXe.getGiuXe(command);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (row["Tien"].ToString().Trim() == "0")
                    {
                        return true; // Ve Da Co Xe
                    }
                }
                return false;
            }
            else
            {
                return false; // Ve Trong
            }
        }
    }
}
