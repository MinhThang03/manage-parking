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
    class LoaiXe
    {

        MY_DB mydb = new MY_DB();
        Xe xe = new Xe();

        public bool ThemLoaiXe(string loaiXe, int gia, int tong)
        {
            SqlCommand command = new SqlCommand("INSERT INTO LoaiXe (LoaiXe, Gia, TongViTri) VALUES (@loai, @gia, @tong)", mydb.getConnection);

            command.Parameters.Add("@loai", SqlDbType.VarChar).Value = loaiXe;
            command.Parameters.Add("@gia", SqlDbType.Int).Value = gia;
            command.Parameters.Add("@tong", SqlDbType.Int).Value = tong;

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


        public DataTable getLoaiXe(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


        public bool XoaLoaiXe(string loaiXe)
        {
            SqlCommand command = new SqlCommand("DELETE FROM LoaiXe WHERE LoaiXe = @loai", mydb.getConnection);
            command.Parameters.Add("@loai", SqlDbType.VarChar).Value = loaiXe;

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

        public bool CapNhatBaiXe(int sum, int gia, string loai)
        {

            SqlCommand command = new SqlCommand("UPDATE LoaiXe SET Gia = @gia, TongViTri = @tong  WHERE  LoaiXe = @loai", mydb.getConnection);

            command.Parameters.Add("@loai", SqlDbType.VarChar).Value = loai;
            command.Parameters.Add("@gia", SqlDbType.Int).Value = gia;
            command.Parameters.Add("@tong", SqlDbType.Int).Value = sum;

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

        public bool CapNhatGiaXe(string loaiXe, int gia)
        {
            SqlCommand command = new SqlCommand("UPDATE LoaiXe SET Gia = @gia WHERE  LoaiXe = @loai", mydb.getConnection);

            command.Parameters.Add("@loai", SqlDbType.VarChar).Value = loaiXe;
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

        public bool CapNhatSoLuongXe(string loaiXe, int tong, int dung, int trong)
        {
            SqlCommand command = new SqlCommand("UPDATE LoaiXe SET TongViTri = @tong, ChoDaDung = @dung, ChoTrong = @trong WHERE  LoaiXe = @loai", mydb.getConnection);

            command.Parameters.Add("@loai", SqlDbType.VarChar).Value = loaiXe;
            command.Parameters.Add("@tong", SqlDbType.Int).Value = tong;
            command.Parameters.Add("@dung", SqlDbType.Int).Value = dung;
            command.Parameters.Add("@trong", SqlDbType.Int).Value = trong;

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

        public bool KiemTraLoaiXe(string loaiXe)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM LoaiXe WHERE LoaiXe = @loai", mydb.getConnection);
            command.Parameters.Add("@loai", SqlDbType.VarChar).Value = loaiXe;

            DataTable table = this.getLoaiXe(command);
            if (table.Rows.Count > 0)
            {
                return true;    //Co xe nay trong du lieu
            }
            else
            {
                return false;
            }
        }

        public void CapNhatSoLieu()
        {
            SqlCommand command = null;
            command = new SqlCommand("SELECT TongViTri FROM LoaiXe WHERE LoaiXe = 'O to'");
            DataTable table = this.getLoaiXe(command);
            int sumOto = int.Parse(table.Rows[0][0].ToString());

            command = new SqlCommand("SELECT TongViTri FROM LoaiXe WHERE LoaiXe = 'Xe May'");
            table = this.getLoaiXe(command);
            int sumXeMay = int.Parse(table.Rows[0][0].ToString());

            command = new SqlCommand("SELECT TongViTri FROM LoaiXe WHERE LoaiXe = 'Xe Dap'");
            table = this.getLoaiXe(command);
            int sumXeDap = int.Parse(table.Rows[0][0].ToString());

            command = new SqlCommand("SELECT count(MaXe) FROM Xe WHERE LoaiXe = 'O to' and NgayXuatBen is null");
            table = xe.getXe(command);
            int oTo = int.Parse(table.Rows[0][0].ToString());

            command = new SqlCommand("SELECT count(MaXe) FROM Xe WHERE LoaiXe = 'Xe May' and NgayXuatBen is null");
            table = xe.getXe(command);
            int xeMay = int.Parse(table.Rows[0][0].ToString());

            command = new SqlCommand("SELECT count(MaXe) FROM Xe WHERE LoaiXe = 'Xe Dap' and NgayXuatBen is null");
            table = xe.getXe(command);
            int xeDap = int.Parse(table.Rows[0][0].ToString());

            int xeDapTrong = sumXeDap - xeDap;
            int xeMayTrong = sumXeMay - xeMay;
            int oToTrong = sumOto - oTo;

            this.CapNhatSoLuongXe("O to", sumOto, oTo, oToTrong);
            this.CapNhatSoLuongXe("Xe May", sumXeMay, xeMay, xeMayTrong);
            this.CapNhatSoLuongXe("Xe Dap", sumXeDap, xeDap, xeDapTrong);


        }

        public bool KiemTraChoTrong(string loai)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM LoaiXe WHERE LoaiXe = '" + loai + "'");
            DataTable table = this.getLoaiXe(command);
            int trong = int.Parse(table.Rows[0][4].ToString());
            if (trong == 0)
                return false;
            else return true;
        }
    }
}
