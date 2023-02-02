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
    class Xe
    {

        MY_DB mydb = new MY_DB();
        HopDong hd = new HopDong();

        public bool ThemXe(string maXe, string loaiXe, DateTime ngayVao, MemoryStream image1, MemoryStream image2)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Xe (MaXe, LoaiXe, NgayVaoBen, Image1, Image2)" +
                "VALUES (@ma, @loai, @vao, @img1, @img2)", mydb.getConnection);

            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maXe;
            command.Parameters.Add("@loai", SqlDbType.VarChar).Value = loaiXe;
            command.Parameters.Add("@vao", SqlDbType.DateTime).Value = ngayVao;
            command.Parameters.Add("@img1", SqlDbType.Image).Value = image1.ToArray();
            command.Parameters.Add("@img2", SqlDbType.Image).Value = image2.ToArray();

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

        public bool ThemNgayXuatBen(string maXe, DateTime ngayXuatBen)
        {
            SqlCommand command = new SqlCommand("UPDATE Xe SET  NgayXuatBen = @ra WHERE  MaXe = @ma", mydb.getConnection);

            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maXe;
            command.Parameters.Add("@ra", SqlDbType.DateTime).Value = ngayXuatBen;

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


        public DataTable getXe(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


        public bool XoaXe(string maXe)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Xe WHERE MaXe = @ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maXe;

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

        public bool CapNhatXe(string maXe, string loaiXe, DateTime ngayVao, MemoryStream image1, MemoryStream image2)
        {
            SqlCommand command = new SqlCommand("UPDATE Xe SET  LoaiXe = @loai, NgayVaoBen = @vao, Image1 = @img1, "
                + "Image2 = @img2 WHERE  MaXe = @ma", mydb.getConnection);

            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maXe;
            command.Parameters.Add("@loai", SqlDbType.VarChar).Value = loaiXe;
            command.Parameters.Add("@vao", SqlDbType.DateTime).Value = ngayVao;
            command.Parameters.Add("@img1", SqlDbType.Image).Value = image1.ToArray();
            command.Parameters.Add("@img2", SqlDbType.Image).Value = image2.ToArray();

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

        public bool KiemTraMaXe(string maXe)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Xe WHERE MaXe = @ma");
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maXe;

            DataTable table = this.getXe(command);
            if (table.Rows.Count > 0)
            {
                return true;    //Co xe nay trong du lieu
            }
            else
            {
                return false;
            }
        }


        public bool KiemTraXeNgayXuat(string maXe)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Xe WHERE MaXe = @ma and NgayXuatBen is Null");
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maXe;
            DataTable table = this.getXe(command);

            if (table.Rows.Count > 0)
            {
                return true;         // Xe chua xuat ben
            }
            else
                return false;

        }


        public bool KiemTraNgayThue(DateTime time, string maXe)
        {
            DateTime temp = time.AddDays(-1);
            string gio = temp.ToString("MM/dd/yyyy");
            SqlCommand command = new SqlCommand("SELECT * FROM HopDong WHERE LoaiHD = 'Cho Thue' and MaXe = @ma and NgayThuHoi > @ngay");
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maXe;
            command.Parameters.Add("@ngay", SqlDbType.DateTime).Value = temp;
            DataTable table = this.getXe(command);
            if (table.Rows.Count > 0)
                return false;            //khong xe trong ben
            else
                return true;

        }

        public bool KiemTraMaXeConTrongBen(string maXe)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Xe WHERE MaXe = @ma");
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maXe;

            DataTable table = this.getXe(command);
            if (table.Rows.Count > 0)
            {
                string flag = table.Rows[0][3].ToString().Trim();
                if (flag == "")
                {
                    command = new SqlCommand("SELECT * FROM HopDong WHERE LoaiHD = 'Cho Thue' and MaXe = '" + maXe + "'");
                    table = hd.getHopDong(command);

                    if (table.Rows.Count > 0)
                    {
                        DateTime date = DateTime.Now;
                        foreach (DataRow row in table.Rows)
                        {
                            DateTime thu = (DateTime)row[8];
                            int compare = DateTime.Compare(date, thu);
                            if (compare < 0)
                                return false;
                        }
                    }

                    return true;    // Co xe trong ben

                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }
    }
}
