using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class ChiaCaNhanVien : Form
    {
        public ChiaCaNhanVien()
        {
            InitializeComponent();
        }

        PhanChiaCaLam chiaca = new PhanChiaCaLam();
        NhanVien nv = new NhanVien();
        CheckIn diemDanh = new CheckIn();
        PhatLuong luong = new PhatLuong();

        private void ChiaCaNhanVien_Load(object sender, EventArgs e)
        {
            ThemeColor.LoadColos(this);
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            diemDanh.deleteGioLam();
            chiaca.deleteChiaCa();
            luong.deleteLuong();
            SqlCommand commandCa = new SqlCommand(" SELECT NhanVien.Id, Thu2 as 'Thứ 2', Thu3 as 'Thứ 3', Thu4 as 'Thứ 4', Thu5 as 'Thứ 5', Thu6 as 'Thứ 6', Thu7 as 'Thứ 7', CN as 'Chủ Nhật' FROM ChiaCa RIGHT JOIN NhanVien ON ChiaCa.Id = NhanVien.Id ");
            DataTable tableCa = chiaca.getCaLam(commandCa);

            int n;
            Random rd = new Random();
            n = rd.Next(1, 4);
            for (int i = 0; i < tableCa.Rows.Count; i++)
            {

                if (tableCa.Rows[i]["Id"].ToString().Contains("QL"))
                    continue;
                for (int j = 1; j < tableCa.Columns.Count; j++)
                {
                    tableCa.Rows[i][j] = n;
                    n++;
                    if (n == 4)
                    {
                        n = 1;
                    }
                }

                chiaca.insertCaLam((tableCa.Rows[i]["Id"].ToString()),
                    Convert.ToInt32(tableCa.Rows[i]["Thứ 2"].ToString()),
                    Convert.ToInt32(tableCa.Rows[i]["Thứ 3"].ToString()),
                    Convert.ToInt32(tableCa.Rows[i]["Thứ 4"].ToString()),
                    Convert.ToInt32(tableCa.Rows[i]["Thứ 5"].ToString()),
                    Convert.ToInt32(tableCa.Rows[i]["Thứ 6"].ToString()),
                    Convert.ToInt32(tableCa.Rows[i]["Thứ 7"].ToString()),
                    Convert.ToInt32(tableCa.Rows[i]["Chủ Nhật"].ToString()));

                diemDanh.insertIDLamViec(tableCa.Rows[i]["Id"].ToString());
                luong.insertLuong(tableCa.Rows[i]["Id"].ToString());
            }

            dataGridViewChiaCaNV.DataSource = tableCa;
            for (int i = 0; i < tableCa.Rows.Count; i++)
            {
                if (tableCa.Rows[i]["Id"].ToString().Contains("QL"))
                {
                    this.dataGridViewChiaCaNV.Rows.RemoveAt(i);
                    continue;
                }
                for (int j = 1; j < tableCa.Columns.Count; j++)
                {
                    if (Convert.ToInt32(tableCa.Rows[i][j].ToString()) == 3)
                    {
                        dataGridViewChiaCaNV.Rows[i].Cells[j].Value = "Ca1, Ca2";

                    }
                    else if (Convert.ToInt32(tableCa.Rows[i][j].ToString()) == 2)
                    {
                        dataGridViewChiaCaNV.Rows[i].Cells[j].Value = "Ca1, Ca3";
                    }
                    else
                    {
                        dataGridViewChiaCaNV.Rows[i].Cells[j].Value = "Ca2, Ca3";
                    }
                }
            }
            dataGridViewChiaCaNV.AllowUserToAddRows = false;
            MessageBox.Show("CHIA CA THÀNH CÔNG CHO NHÂN VIÊN!!!");
        }

        
    }
}
