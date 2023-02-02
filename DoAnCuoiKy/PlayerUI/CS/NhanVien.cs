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
    class NhanVien
    {
        MY_DB myDb = new MY_DB();
        public DataTable getNhanVien(SqlCommand command)
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



        public bool updateNhanVien(string Id, string name, string cmnd, DateTime bdate, string gender, string phone, string address, MemoryStream picture, string maBp)
        {
            SqlCommand command = new SqlCommand("UPDATE NhanVien SET TenNV=@fn, CMND = @cmnd, NgaySinhNV=@bdt, GioiTinhNV=@ge, SDTNV=@pho,DIACHINV=@add, HinhNV=@pic, MaBp = @mabp WHERE Id=@Id", myDb.getConnection);
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
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

        public bool updatePassWord(string Id, string pass)
        {
            SqlCommand command = new SqlCommand("UPDATE NhanVien SET PassWord=@pass WHERE Id=@Id", myDb.getConnection);
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

      

        public bool deleteNhanVien(string id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM NhanVien WHERE Id = @id", myDb.getConnection);
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
        public bool insertNhanVien(string Id, string name, string cmnd, DateTime bdate, string gender, string phone, string address, MemoryStream picture, string maBp)
        {
            SqlCommand command = new SqlCommand("INSERT INTO NhanVien(Id, TenNV, CMND, NgaySinhNV, GioiTinhNV, DiaChiNV, SDTNV, HinhNV, MaBP)" +
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

        public bool insertNhanVienTaiKhoan(string Id)
        {
            SqlCommand command = new SqlCommand("INSERT INTO NhanVien(Id)" + "VALUES (@id)", myDb.getConnection);
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
        public bool checkStaffId(string Id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM NhanVien WHERE Id=@cId", myDb.getConnection);
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
