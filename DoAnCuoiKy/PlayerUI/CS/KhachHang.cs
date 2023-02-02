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
    class KhachHang
    {
        MY_DB myDb = new MY_DB();
        public DataTable getKhachHang(SqlCommand command)
        {
            command.Connection = myDb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


       

        public bool updateKhachHang(string Id, string name, string cmnd, DateTime bdate, string gender,  string address, string phone,  MemoryStream picture, string email )
        {
            SqlCommand command = new SqlCommand("UPDATE KhachHang SET TenKH=@fn, CMND = @cmnd, NgaySinh=@bdt, GioiTinh=@ge, SDT=@pho, DIACHI=@add, Hinh=@pic, Email = @mabp WHERE MaKH=@Id", myDb.getConnection);
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = name;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@ge", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@pho", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@add", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            command.Parameters.Add("@cmnd", SqlDbType.VarChar).Value = cmnd;
            command.Parameters.Add("@mabp", SqlDbType.VarChar).Value = email;
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

        public bool updatePassWord(string Id, string pass)
        {
            SqlCommand command = new SqlCommand("UPDATE KhachHang SET PassWord=@pass WHERE Id=@Id", myDb.getConnection);
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
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



        public bool deleteKhachHang(string id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM KhachHang WHERE Id = @id", myDb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
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
        public bool insertKhachHang(string Id, string name, string cmnd, DateTime bdate, string gender, string phone, string address, MemoryStream picture, string maBp)
        {
            SqlCommand command = new SqlCommand("INSERT INTO KhachHang(Id, TenKH , CMND, NgaySinh, GioiTinh, DiaChi, SDT, Hinh, Email)" +
                "VALUES (@id, @fn, @cmnd, @bdt, @ge, @pho, @add, @pic, @mabp)", myDb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = name;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@ge", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@pho", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@add", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            command.Parameters.Add("@cmnd", SqlDbType.VarChar).Value = cmnd;
            command.Parameters.Add("@mabp", SqlDbType.VarChar).Value = maBp;
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

        public bool insertKhachHangTaiKhoan(string Id)
        {
            SqlCommand command = new SqlCommand("INSERT INTO KhachHang(MaKH)" + "VALUES (@id)", myDb.getConnection);
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
        public bool checkId(string Id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM KhachHang WHERE Id=@cId", myDb.getConnection);
            command.Parameters.Add("@cId", SqlDbType.VarChar).Value = Id;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if ((table.Rows.Count > 0))
            {
                return false;               // Da ton tai
            }
            else
            {
                return true;                // Khong ton tai
            }
        }
    }
}
