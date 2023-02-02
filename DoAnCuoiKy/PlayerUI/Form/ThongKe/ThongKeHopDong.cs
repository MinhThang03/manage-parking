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
    public partial class ThongKeHopDong : Form
    {
        public ThongKeHopDong()
        {
            InitializeComponent();
        }

        private void ThongKeHopDong_Load(object sender, EventArgs e)
        {
            ThemeColor.LoadColos(this);
        }

        HopDong hd = new HopDong();
        int flagToanBo = 0;
        private object chartLoaiBaoHanh;

        public void ThongKeBieuDoTron()
        {
            flagToanBo = 1;

            this.chartLoaiXe.Series.Clear();
            this.chartLoaiXe.Series.Add("loai");
            this.chartLoaiXe.Series["loai"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            SqlCommand command = new SqlCommand("SELECT * FROM HopDong, Xe Where HopDong.MaXe = Xe.MaXe and LoaiXe = 'O to' ");
            DataTable table = hd.getHopDong(command);
            int Oto = 0;
            if (table.Rows.Count > 0)
                Oto = table.Rows.Count;


            command = new SqlCommand("SELECT * FROM HopDong, Xe Where HopDong.MaXe = Xe.MaXe and LoaiXe = 'Xe May' ");
            table = hd.getHopDong(command);
            int xeMay = 0;
            if (table.Rows.Count > 0)
                xeMay = table.Rows.Count;


            command = new SqlCommand("SELECT * FROM HopDong, Xe Where HopDong.MaXe = Xe.MaXe and LoaiXe = 'Xe May' ");
            table = hd.getHopDong(command);
            int xeDap = 0;
            if (table.Rows.Count > 0)
                xeDap = table.Rows.Count;



            int index = 0;
            if (xeMay != 0)
            {
                this.chartLoaiXe.Series["loai"].Points.Add(xeMay);
                this.chartLoaiXe.Series["loai"].Points[index].Label = "Xe May";
                this.chartLoaiXe.Series["loai"].Points[index].Color = Color.Blue;
                this.chartLoaiXe.Series["loai"].Points[index].AxisLabel = "Xe May";
                index++;
            }

            if (xeDap != 0)
            {
                this.chartLoaiXe.Series["loai"].Points.Add(xeDap);
                this.chartLoaiXe.Series["loai"].Points[index].Label = "Xe Dap";
                this.chartLoaiXe.Series["loai"].Points[index].Color = Color.Red;
                this.chartLoaiXe.Series["loai"].Points[index].AxisLabel = "Xe Dap";
                index++;
            }

            if (Oto != 0)
            {
                this.chartLoaiXe.Series["loai"].Points.Add(Oto);
                this.chartLoaiXe.Series["loai"].Points[index].Label = "O To";
                this.chartLoaiXe.Series["loai"].Points[index].Color = Color.Yellow;
                this.chartLoaiXe.Series["loai"].Points[index].AxisLabel = "O To";
            }
        }


        public void thongKeBieuDoCN()
        {

            this.chartHopDong.Series.Clear();
            this.chartHopDong.Series.Add("Hợp đồng");
            this.chartHopDong.Series.Add("Hợp đồng thuê");
            this.chartHopDong.Series.Add("Hợp đồng cho thuê");

            flagToanBo = 1;
            SqlCommand command = new SqlCommand("SELECT * FROM HopDong Where LoaiHD = 'Thuê'");
            DataTable table = hd.getHopDong(command);
            int thue = 0;
            if (table.Rows.Count > 0)
                thue = table.Rows.Count;


            command = new SqlCommand("SELECT * FROM HopDong Where LoaiHD = 'Cho Thuê'");
            table = hd.getHopDong(command);
            int choThue = 0;
            if (table.Rows.Count > 0)
                choThue = table.Rows.Count;

            int tongTien = thue + choThue;

            if (tongTien != 0)
            {
                this.chartHopDong.Series["Hợp đồng"].Points.AddXY("Tong Tien", 100);
                this.chartHopDong.Series["Hợp đồng thuê"].Points.AddXY("Hợp đồng thuê", (thue * 100 / tongTien) );
                this.chartHopDong.Series["Hợp đồng cho thuê"].Points.AddXY("Hợp đồng cho thuê", (choThue * 100 / tongTien));
            }
        }

        private void buttonThongKeToanBo_Click(object sender, EventArgs e)
        {
            if (flagToanBo == 0)
            {
                this.flagNgay = 0;
                this.ThongKeBieuDoTron();
                this.thongKeBieuDoCN();
            }
        }


        int flagNgay = 0;
        public void thongKeBieuDoTronTheoNgay()
        {

            this.chartLoaiXe.Series.Clear();
            this.chartLoaiXe.Series.Add("loai");
            this.chartLoaiXe.Series["loai"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            flagNgay = 1;
            int yy = Convert.ToInt32(DateTime.Now.Year.ToString());
            int dd = Convert.ToInt32(DateTime.Now.Month.ToString());
            int kk = Convert.ToInt32(DateTime.Now.Day.ToString());


            SqlCommand command = new SqlCommand("SELECT * FROM HopDong, Xe Where HopDong.MaXe = Xe.MaXe and LoaiXe = 'O to' AND (DATEPART(yy, NgayKi) = '" + yy + "' AND    DATEPART(mm, NgayKi) = '" + dd + "' AND    DATEPART(dd, NgayKi) = '" + kk + "')");
            DataTable table = hd.getHopDong(command);
            int Oto = 0;
            if (table.Rows.Count > 0)
                Oto = table.Rows.Count;


            command = new SqlCommand("SELECT * FROM HopDong, Xe Where HopDong.MaXe = Xe.MaXe and LoaiXe = 'Xe May' AND (DATEPART(yy, NgayKi) = '" + yy + "' AND    DATEPART(mm, NgayKi) = '" + dd + "' AND    DATEPART(dd, NgayKi) = '" + kk + "')");
            table = hd.getHopDong(command);
            int xeMay = 0;
            if (table.Rows.Count > 0)
                xeMay = table.Rows.Count;


            command = new SqlCommand("SELECT * FROM HopDong, Xe Where HopDong.MaXe = Xe.MaXe and LoaiXe = 'Xe May' AND (DATEPART(yy, NgayKi) = '" + yy + "' AND    DATEPART(mm, NgayKi) = '" + dd + "' AND    DATEPART(dd, NgayKi) = '" + kk + "')");
            table = hd.getHopDong(command);
            int xeDap = 0;
            if (table.Rows.Count > 0)
                xeDap = table.Rows.Count;



            int index = 0;
            if (xeMay != 0)
            {
                this.chartLoaiXe.Series["loai"].Points.Add(xeMay);
                this.chartLoaiXe.Series["loai"].Points[index].Label = "Xe May";
                this.chartLoaiXe.Series["loai"].Points[index].Color = Color.Blue;
                this.chartLoaiXe.Series["loai"].Points[index].AxisLabel = "Xe May";
                index++;
            }

            if (xeDap != 0)
            {
                this.chartLoaiXe.Series["loai"].Points.Add(xeDap);
                this.chartLoaiXe.Series["loai"].Points[index].Label = "Xe Dap";
                this.chartLoaiXe.Series["loai"].Points[index].Color = Color.Red;
                this.chartLoaiXe.Series["loai"].Points[index].AxisLabel = "Xe Dap";
                index++;
            }

            if (Oto != 0)
            {
                this.chartLoaiXe.Series["loai"].Points.Add(Oto);
                this.chartLoaiXe.Series["loai"].Points[index].Label = "O To";
                this.chartLoaiXe.Series["loai"].Points[index].Color = Color.Yellow;
                this.chartLoaiXe.Series["loai"].Points[index].AxisLabel = "O To";
                index++;
            }

            if (index == 0)
            {
                MessageBox.Show("Hom Nay Chua Co Hop Dong Nao", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void thongKeBieuDoCNNgay()
        {

            this.chartHopDong.Series.Clear();
            this.chartHopDong.Series.Add("Hợp đồng");
            this.chartHopDong.Series.Add("Hợp đồng thuê");
            this.chartHopDong.Series.Add("Hợp đồng cho thuê");

            int yy = Convert.ToInt32(DateTime.Now.Year.ToString());
            int dd = Convert.ToInt32(DateTime.Now.Month.ToString());
            int kk = Convert.ToInt32(DateTime.Now.Day.ToString());

            flagNgay = 1;
            SqlCommand command = new SqlCommand("SELECT * FROM HopDong Where LoaiHD = 'Thuê' AND (DATEPART(yy, NgayKi) = '" + yy + "' AND    DATEPART(mm, NgayKi) = '" + dd + "' AND    DATEPART(dd, NgayKi) = '" + kk + "')");
            DataTable table = hd.getHopDong(command);
            int thue = 0;
            if (table.Rows.Count > 0)
                thue = table.Rows.Count;


            command = new SqlCommand("SELECT * FROM HopDong Where LoaiHD = 'Cho Thuê' AND (DATEPART(yy, NgayKi) = '" + yy + "' AND    DATEPART(mm, NgayKi) = '" + dd + "' AND    DATEPART(dd, NgayKi) = '" + kk + "')");
            table = hd.getHopDong(command);
            int choThue = 0;
            if (table.Rows.Count > 0)
                choThue = table.Rows.Count;

            int tongTien = thue + choThue;

            if (tongTien != 0)
            {
                this.chartHopDong.Series["Hợp đồng"].Points.AddXY("Tong Tien", 100);
                this.chartHopDong.Series["Hợp đồng thuê"].Points.AddXY("Hợp đồng thuê", (thue * 100/ tongTien) );
                this.chartHopDong.Series["Hợp đồng cho thuê"].Points.AddXY("Hợp đồng cho thuê", (choThue *100 / tongTien) );
            }

        }

        private void buttonThongKeTrongNgay_Click(object sender, EventArgs e)
        {
            if (this.flagNgay == 0)
            {
                flagToanBo = 0;
                this.thongKeBieuDoCNNgay();
                this.thongKeBieuDoTronTheoNgay();
            }
        }
    }
}
