using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI
{
    class PhieuThu
    {

        MY_DB mydb = new MY_DB();

        public bool ThemPhieuThu(string maPT, string maXe, int sum, int guiXe, int baoHanh, DateTime date)
        {
            SqlCommand command = new SqlCommand("INSERT INTO PhieuThu (MaPT, MaXe, TongTien, TienGuiXe,TienBaoHanh, NgayThu) VALUES (@maPT, @maXe, @sum, @gui, @bh, @date)", mydb.getConnection);

            command.Parameters.Add("@maPT", SqlDbType.VarChar).Value = maPT;
            command.Parameters.Add("@maXe", SqlDbType.VarChar).Value = maXe;
            command.Parameters.Add("@sum", SqlDbType.Int).Value = sum;
            command.Parameters.Add("@gui", SqlDbType.Int).Value = guiXe;
            command.Parameters.Add("@bh", SqlDbType.Int).Value = baoHanh;
            command.Parameters.Add("@date", SqlDbType.DateTime).Value = date;


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


        public DataTable getPhieuThu(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


        public bool XoaPhieuThu(string maPT)
        {
            SqlCommand command = new SqlCommand("DELETE FROM PhieuThu WHERE MaPT = @ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maPT;

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

        public bool CapNhatPhieuThu(string maPT, string maXe, int sum, int guiXe, int baoHanh, DateTime date)
        {
            SqlCommand command = new SqlCommand("UPDATE PhieuThu SET MaXe = @maXe, TongTien = @sum, TienGuiXe = @gui, TienBaoHanh = @bh, NgayThu = @date WHERE  MaPT = @maPT", mydb.getConnection);

            command.Parameters.Add("@maPT", SqlDbType.VarChar).Value = maPT;
            command.Parameters.Add("@maXe", SqlDbType.VarChar).Value = maXe;
            command.Parameters.Add("@sum", SqlDbType.Int).Value = sum;
            command.Parameters.Add("@gui", SqlDbType.Int).Value = guiXe;
            command.Parameters.Add("@bh", SqlDbType.Int).Value = baoHanh;
            command.Parameters.Add("@date", SqlDbType.DateTime).Value = date;

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


        public bool KiemTraPhieuThu(string maHD)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM HopDong WHERE MaHD = @maHD");

            command.Parameters.Add("@maHD", SqlDbType.VarChar).Value = maHD;

            DataTable table = this.getPhieuThu(command);
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
