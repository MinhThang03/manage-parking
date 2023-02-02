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
    public partial class ThongKeNhanVien : Form
    {
        public ThongKeNhanVien()
        {
            InitializeComponent();
        }

        NhanVien nv = new NhanVien();

        int sum = 0;
        public void ThongKeBieuDoTron()
        {
           
            SqlCommand command = new SqlCommand("SELECT *  FROM NhanVien WHERE GioiTinhNV = 'Male' ");
            DataTable table = nv.getNhanVien(command);
            int nam = 0;
            if (table.Rows.Count > 0)
                nam = table.Rows.Count;


            command = new SqlCommand("SELECT *  FROM NhanVien WHERE GioiTinhNV = 'Female' ");
            table = nv.getNhanVien(command);
            int nu = 0;
            if (table.Rows.Count > 0)
                nu = table.Rows.Count;

            this.sum = nam + nu;

            if (sum != 0)
            {
                int index = 0;
                if (nam != 0)
                {
                    this.chartLoaiXe.Series["loai"].Points.Add(nam);
                    this.chartLoaiXe.Series["loai"].Points[index].Label = String.Format("Nam: {0:0.00}%", nam * 100/ this.sum );
                    this.chartLoaiXe.Series["loai"].Points[index].Color = Color.Blue;
                    this.chartLoaiXe.Series["loai"].Points[index].AxisLabel = "Nam";
                    index++;
                }

                if (nu != 0)
                {
                    this.chartLoaiXe.Series["loai"].Points.Add(nu);
                    this.chartLoaiXe.Series["loai"].Points[index].Label = String.Format("Nu: {0:0.00}%", nu * 100 / this.sum );
                    this.chartLoaiXe.Series["loai"].Points[index].Color = Color.Red;
                    this.chartLoaiXe.Series["loai"].Points[index].AxisLabel = "Nu";
                    index++;
                }
                
            }
        }

        private void ThongKeNhanVien_Load(object sender, EventArgs e)
        {
            this.ThongKeBieuDoTron();
            this.ThongKeBieuDoCN();
        }

        public void ThongKeBieuDoCN()
        {
            if (sum != 0)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM BoPhan");
                DataTable table = nv.getNhanVien(command);

                foreach (DataRow row in table.Rows)
                {
                    string id = row[0].ToString().Trim();
                    string name = row[1].ToString().Trim();

                    SqlCommand commandNV = new SqlCommand("SELECT * FROM NhanVien WHERE MaBP = '" + id + "'");
                    DataTable tableNV = nv.getNhanVien(commandNV);
                    int tmp = tableNV.Rows.Count;
                    double kq = Convert.ToDouble( tmp * 100/ this.sum);
                    chartBP.Series["%"].Points.AddXY(name, kq);

                }
            }
            else
            {
                MessageBox.Show("Hiện không có nhân viên", "Thống kê", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
