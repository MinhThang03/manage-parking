using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI
{
    class HopDong
    {

        MY_DB mydb = new MY_DB();

        public bool ThemHopDong(string maHD, string maXe, string maKH, string maNV, string loaiHD, int gia, DateTime ngayKi, DateTime ngayBanGiao, DateTime ngayThuHoi, string ghiChu)
        {
            SqlCommand command = new SqlCommand("INSERT INTO HopDong (MaHD, MaXe, MaKH, MaNV, LoaiHD, TriGiaHD, NgayKi, NgayBanGiao, NgayThuHoi, GhiChu) VALUES (@maHD, @maXe, @maKH, @maNV, @loaiHD, @gia, @ki, @giao, @thu, @ghi)", mydb.getConnection);

            command.Parameters.Add("@maHD", SqlDbType.VarChar).Value = maHD;
            command.Parameters.Add("@maXe", SqlDbType.VarChar).Value = maXe;
            command.Parameters.Add("@maKH", SqlDbType.VarChar).Value = maKH;
            command.Parameters.Add("@maNV", SqlDbType.VarChar).Value = maNV;
            command.Parameters.Add("@loaiHD", SqlDbType.VarChar).Value = loaiHD;
            command.Parameters.Add("@gia", SqlDbType.Int).Value = gia;
            command.Parameters.Add("@ki", SqlDbType.DateTime).Value = ngayKi;
            command.Parameters.Add("@giao", SqlDbType.DateTime).Value = ngayBanGiao;
            command.Parameters.Add("@thu", SqlDbType.DateTime).Value = ngayThuHoi;
            command.Parameters.Add("@ghi", SqlDbType.NVarChar).Value = ghiChu;

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

        public bool DatXe(string maHD, string maXe, string maKH, int gia, DateTime ngayBanGiao, DateTime ngayThuHoi, string ghiChu)
        {
            SqlCommand command = new SqlCommand("INSERT INTO HopDong (MaHD, MaXe, MaKH, LoaiHD, TriGiaHD,NgayBanGiao, NgayThuHoi, GhiChu) VALUES (@maHD, @maXe, @maKH, @loaiHD, @gia, @giao, @thu, @ghi)", mydb.getConnection);

            command.Parameters.Add("@maHD", SqlDbType.VarChar).Value = maHD;
            command.Parameters.Add("@maXe", SqlDbType.VarChar).Value = maXe;
            command.Parameters.Add("@maKH", SqlDbType.VarChar).Value = maKH;
            command.Parameters.Add("@loaiHD", SqlDbType.VarChar).Value = "Cho Thuê";
            command.Parameters.Add("@gia", SqlDbType.Int).Value = gia;
            command.Parameters.Add("@giao", SqlDbType.DateTime).Value = ngayBanGiao;
            command.Parameters.Add("@thu", SqlDbType.DateTime).Value = ngayThuHoi;
            command.Parameters.Add("@ghi", SqlDbType.NVarChar).Value = ghiChu;

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

        public DataTable getHopDong(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


        public bool XoaHopDong(string maHD)
        {
            SqlCommand command = new SqlCommand("DELETE FROM HopDong WHERE MaHD = @ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maHD;

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

        public bool CapNhatHopDong(string maHD, string maXe, string maKH, string maNV, string loaiHD, int gia, DateTime ngayKi, DateTime ngayBanGiao, DateTime ngayThuHoi, string ghiChu)
        {
            SqlCommand command = new SqlCommand("UPDATE HopDong SET MaXe = @maXe, MaKH = @maKH, MaNV = @maNV, LoaiHD = @loaiHD, TriGiaHD = @gia, NgayKi = @ki, NgayBanGiao = @giao, NgayThuHoi = @thu, GhiChu = @ghi WHERE  MaHD = @maHD", mydb.getConnection);

            command.Parameters.Add("@maHD", SqlDbType.VarChar).Value = maHD;
            command.Parameters.Add("@maXe", SqlDbType.VarChar).Value = maXe;
            command.Parameters.Add("@maKH", SqlDbType.VarChar).Value = maKH;
            command.Parameters.Add("@maNV", SqlDbType.VarChar).Value = maNV;
            command.Parameters.Add("@loaiHD", SqlDbType.VarChar).Value = loaiHD;
            command.Parameters.Add("@gia", SqlDbType.Int).Value = gia;
            command.Parameters.Add("@ki", SqlDbType.DateTime).Value = ngayKi;
            command.Parameters.Add("@giao", SqlDbType.DateTime).Value = ngayBanGiao;
            command.Parameters.Add("@thu", SqlDbType.DateTime).Value = ngayThuHoi;
            command.Parameters.Add("@ghi", SqlDbType.NVarChar).Value = ghiChu;

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


        public bool KiemTraHopDong(string maHD)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM HopDong WHERE MaHD = @maHD");

            command.Parameters.Add("@maHD", SqlDbType.VarChar).Value = maHD;

            DataTable table = this.getHopDong(command);
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
