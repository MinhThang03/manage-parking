using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI
{
    class TaiKhoan
    {

        MY_DB mydb = new MY_DB();

        public int setIDTaiKhoan()
        {
            SqlCommand command = new SqlCommand("SELECT max(Id) FROM Login");
            DataTable table = this.getTaiKhoan(command);
            if (table.Rows[0][0].ToString().Trim() != "")
                return Convert.ToInt32(table.Rows[0][0]) + 1;
            else return 1;
        }

        public bool ThemTaiKhoan(string usename, string password, string maNV, string chucVu)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Login (Id, username, password, MaNV, VaiTro) VALUES (@id, @user, @pass, @ma, @vai)", mydb.getConnection);

            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maNV;
            command.Parameters.Add("@vai", SqlDbType.VarChar).Value = chucVu;
            command.Parameters.Add("@user", SqlDbType.VarChar).Value = usename;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            command.Parameters.Add("@id", SqlDbType.Int).Value = this.setIDTaiKhoan();

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

        public bool TaoTaiKhoangKhachHang(string usename, string password)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Login (Id, username, password, MaNV, VaiTro) VALUES (@id, @user, @pass, @ma, @vai)", mydb.getConnection);

            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = "KH" + this.setIDTaiKhoan().ToString();
            command.Parameters.Add("@vai", SqlDbType.VarChar).Value = "Khách Hàng";
            command.Parameters.Add("@user", SqlDbType.VarChar).Value = usename;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            command.Parameters.Add("@id", SqlDbType.Int).Value = this.setIDTaiKhoan();

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



        public DataTable getTaiKhoan(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


        public bool XoaTaiKhoan(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Login WHERE Id  = @ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.Int).Value = id;

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

        public bool CapNhatTaiKhoan(int id, string usename, string password, string maNV, string chucVu)
        {
            SqlCommand command = new SqlCommand("UPDATE Login SET  username = @user, password = @pass, MaNV = @ma, VaiTro = @vai WHERE  Id = @id", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maNV;
            command.Parameters.Add("@vai", SqlDbType.VarChar).Value = chucVu;
            command.Parameters.Add("@user", SqlDbType.VarChar).Value = usename;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

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

        public bool DoiMatKhau(int id,  string password)
        {

            SqlCommand command = new SqlCommand("UPDATE Login SET  password = @pass WHERE  Id = @id", mydb.getConnection);
           
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

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

        public bool checkMatKhau(int id, string password)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Login WHERE Id = @id and password = @pass");
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            DataTable table = this.getTaiKhoan(command);
            if (table.Rows.Count > 0)
                return true; // ton tai
            else
                return false;
        }

        public int checkTaiKhoanNhanVien(string maNV)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Login WHERE MaNV = @ma and VaiTro = 'Nhân viên'");
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maNV;

            DataTable table = this.getTaiKhoan(command);
            if (table.Rows.Count > 0)
                return Convert.ToInt32(table.Rows[0][0]);
            else
                return -1;
        }

        public bool checkUserName(string use)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Login WHERE username = @use");
            command.Parameters.Add("@use", SqlDbType.VarChar).Value = use;
            DataTable table = this.getTaiKhoan(command);
            if (table.Rows.Count > 0)
                return true; // ton tai
            else
                return false;

        }

    }
}
