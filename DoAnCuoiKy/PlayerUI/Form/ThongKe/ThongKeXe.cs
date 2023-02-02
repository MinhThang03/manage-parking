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
    public partial class ThongKeXe : Form
    {
        public ThongKeXe()
        {
            InitializeComponent();
        }

        Xe xe = new Xe();
        int flagtoanbo = 0;
        public void ThongKe()
        {
            
            flagtoanbo = 1;
            this.chartLoaiXe.Series.Clear();
            this.chartLoaiXe.Series.Add("loai");
            this.chartLoaiXe.Series["loai"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            SqlCommand command = new SqlCommand("SELECT *  FROM Xe ");
            DataTable table = xe.getXe(command);
            int sum = table.Rows.Count;

            command = new SqlCommand("SELECT * FROM Xe WHERE LoaiXe = 'Xe May'");
            table = xe.getXe(command);
            int xeMay = table.Rows.Count;

            command = new SqlCommand("SELECT * FROM Xe WHERE LoaiXe = 'Xe Dap'");
            table = xe.getXe(command);
            int xeDap = table.Rows.Count;

            command = new SqlCommand("SELECT * FROM Xe WHERE LoaiXe = 'O to'");
            table = xe.getXe(command);
            int oTo = table.Rows.Count;

            sum = oTo + xeDap + xeMay;
            int index = 0;
            if (xeMay != 0)
            {
                
                this.chartLoaiXe.Series["loai"].Points.Add(xeMay);
                this.chartLoaiXe.Series["loai"].Points[index].Label = String.Format("Xe May: {0:0.00}%", xeMay * 100 / sum);
                this.chartLoaiXe.Series["loai"].Points[index].Color = Color.Blue;
                this.chartLoaiXe.Series["loai"].Points[index].AxisLabel = "Xe May";
                index++;
            }

            if (xeDap != 0)
            {
                this.chartLoaiXe.Series["loai"].Points.Add(xeDap);
                this.chartLoaiXe.Series["loai"].Points[index].Label = String.Format("Xe Dap: {0:0.00}%", xeDap * 100 / sum);
                this.chartLoaiXe.Series["loai"].Points[index].Color = Color.Red;
                this.chartLoaiXe.Series["loai"].Points[index].AxisLabel = "Xe Dap";
                index++;
            }

            if (oTo!= 0)
            {
                this.chartLoaiXe.Series["loai"].Points.Add(oTo);
                this.chartLoaiXe.Series["loai"].Points[index].Label = String.Format("O to: {0:0.00}%", oTo * 100 / sum);
                this.chartLoaiXe.Series["loai"].Points[index].Color = Color.Yellow;
                this.chartLoaiXe.Series["loai"].Points[index].AxisLabel = "O To";
            }
        }

        int flagngay = 0;
        public void ThongKeNgay()
        {
            flagngay  = 1;

            this.chartLoaiXe.Series.Clear();
            this.chartLoaiXe.Series.Add("loai");
            this.chartLoaiXe.Series["loai"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            SqlCommand command = new SqlCommand("SELECT MaXe, LoaiXe, Image1, Image2 FROM Xe WHERE  MaXe  not in (SELECT MaXe FROM HopDong WHERE LoaiHD = 'Cho Thuê'  and NgayThuHoi > @time)  and LoaiXe = 'Xe May' and NgayXuatBen is  null");
            command.Parameters.Add("@time", SqlDbType.DateTime).Value = DateTime.Now;
            DataTable table = xe.getXe(command);
            int xeMay = table.Rows.Count;

            command = new SqlCommand("SELECT MaXe, LoaiXe, Image1, Image2 FROM Xe WHERE  MaXe  not in (SELECT MaXe FROM HopDong WHERE LoaiHD = 'Cho Thuê'  and NgayThuHoi > @time ) and LoaiXe = 'Xe Dap'  and NgayXuatBen is  null ");
            command.Parameters.Add("@time", SqlDbType.DateTime).Value = DateTime.Now;
            table = xe.getXe(command);
            int xeDap = table.Rows.Count;

            command = new SqlCommand("SELECT MaXe, LoaiXe, Image1, Image2 FROM Xe WHERE  MaXe  not in (SELECT MaXe FROM HopDong WHERE LoaiHD = 'Cho Thuê'  and NgayThuHoi > @time)  and LoaiXe = 'O to'  and NgayXuatBen is null");
            command.Parameters.Add("@time", SqlDbType.DateTime).Value = DateTime.Now;
            table = xe.getXe(command);
            int oTo = table.Rows.Count;

            int sum = xeDap + xeMay + oTo;

            int index = 0;
            if (xeMay != 0)
            {

                this.chartLoaiXe.Series["loai"].Points.Add(xeMay);
                this.chartLoaiXe.Series["loai"].Points[index].Label = String.Format("Xe May: {0:0.00}%", xeMay * 100 / sum);
                this.chartLoaiXe.Series["loai"].Points[index].Color = Color.Blue;
                this.chartLoaiXe.Series["loai"].Points[index].AxisLabel = "Xe May";
                index++;
            }

            if (xeDap != 0)
            {
                this.chartLoaiXe.Series["loai"].Points.Add(xeDap);
                this.chartLoaiXe.Series["loai"].Points[index].Label = String.Format("Xe Dap: {0:0.00}%", xeDap * 100 / sum);
                this.chartLoaiXe.Series["loai"].Points[index].Color = Color.Red;
                this.chartLoaiXe.Series["loai"].Points[index].AxisLabel = "Xe Dap";
                index++;
            }

            if (oTo != 0)
            {
                this.chartLoaiXe.Series["loai"].Points.Add(oTo);
                this.chartLoaiXe.Series["loai"].Points[index].Label = String.Format("O to: {0:0.00}%", oTo * 100 / sum);
                this.chartLoaiXe.Series["loai"].Points[index].Color = Color.Yellow;
                this.chartLoaiXe.Series["loai"].Points[index].AxisLabel = "O To";
                index++;
            }
            if (index == 0)
            {
                MessageBox.Show("Hiện không có xe trong bến");
            }
        }
        private void ThongKeXe_Load(object sender, EventArgs e)
        {
            ThemeColor.LoadColos(this);
        }

        private void buttonThongKeToanBo_Click(object sender, EventArgs e)
        {
            if (flagtoanbo == 0)
            {
                flagngay = 0;
                this.ThongKe();
            }
        }

        private void buttonThongKeTrongNgay_Click(object sender, EventArgs e)
        {
            if (flagngay == 0)
            {
                flagtoanbo = 0;
                this.ThongKeNgay();
            }
        }
    }
}
