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
    public partial class ThongKeDoanhThu : Form
    {
        public ThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void ThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            ThemeColor.LoadColos(this);
        }

        private void buttonThongKeTrongNgay_Click(object sender, EventArgs e)
        {
            if (this.flagNgay ==0 )
            {
                flagToanBo = 0;
                this.thongKeBieuDoCNNgay();
                this.thongKeBieuDoTronTheoNgay();
            }
        }

        Xe xe = new Xe();

        int flagToanBo = 0;
        public void ThongKeBieuDoTron()
        {
            flagToanBo = 1;
            this.chartLoaiXe.Series.Clear();
            this.chartLoaiXe.Series.Add("loai");
            this.chartLoaiXe.Series["loai"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            SqlCommand command = new SqlCommand("SELECT SUM(TongTien)  FROM PhieuThu, Xe  WHERE PhieuThu.MaXe = Xe.MaXe and LoaiXe = 'O to' ");
            DataTable table = xe.getXe(command);
            int tienOto = 0;
            if (table.Rows[0][0].ToString().Trim() != "")
                tienOto = Convert.ToInt32(table.Rows[0][0]);


            command = new SqlCommand("SELECT SUM(TongTien)  FROM PhieuThu, Xe  WHERE PhieuThu.MaXe = Xe.MaXe and LoaiXe = 'Xe Dap' ");
            table = xe.getXe(command);
            int tienXeDap = 0;
            if (table.Rows[0][0].ToString().Trim() != "")
                tienXeDap = Convert.ToInt32(table.Rows[0][0]);


            command = new SqlCommand("SELECT SUM(TongTien)  FROM PhieuThu, Xe  WHERE PhieuThu.MaXe = Xe.MaXe and LoaiXe = 'Xe May' ");
            table = xe.getXe(command);
            int tienXeMay = 0;
            if (table.Rows[0][0].ToString().Trim() != "")
                tienXeMay = Convert.ToInt32(table.Rows[0][0]);

            

            int index = 0;
            if (tienXeMay != 0)
            {
                this.chartLoaiXe.Series["loai"].Points.Add(tienXeMay);
                this.chartLoaiXe.Series["loai"].Points[index].Label = "Xe May";
                this.chartLoaiXe.Series["loai"].Points[index].Color = Color.Blue;
                this.chartLoaiXe.Series["loai"].Points[index].AxisLabel = "Xe May";
                index++;
            }

            if (tienXeDap != 0)
            {
                this.chartLoaiXe.Series["loai"].Points.Add(tienXeDap);
                this.chartLoaiXe.Series["loai"].Points[index].Label = "Xe Dap";
                this.chartLoaiXe.Series["loai"].Points[index].Color = Color.Red;
                this.chartLoaiXe.Series["loai"].Points[index].AxisLabel = "Xe Dap";
                index++;
            }

            if (tienOto != 0)
            {
                this.chartLoaiXe.Series["loai"].Points.Add(tienOto);
                this.chartLoaiXe.Series["loai"].Points[index].Label = "O To";
                this.chartLoaiXe.Series["loai"].Points[index].Color = Color.Yellow;
                this.chartLoaiXe.Series["loai"].Points[index].AxisLabel = "O To";
            }
        }

      
        public void thongKeBieuDoCN()
        {
            flagToanBo = 1;
            this.chartLoaiBaoHanh.Series.Clear();
            this.chartLoaiBaoHanh.Series.Add("Tong Tien");
            this.chartLoaiBaoHanh.Series.Add("Phi Gui Xe");
            this.chartLoaiBaoHanh.Series.Add("Phi Cham Soc");


            SqlCommand command = new SqlCommand("SELECT SUM(TienBaoHanh)  FROM PhieuThu ");
            DataTable table = xe.getXe(command);
            int tienBaoHanh = 0;
            if (table.Rows[0][0].ToString().Trim() != "")
                tienBaoHanh = Convert.ToInt32(table.Rows[0][0]);


            command = new SqlCommand("SELECT SUM(TienGuiXe)  FROM PhieuThu ");
            table = xe.getXe(command);
            int tienGuiXe = 0;
            if (table.Rows[0][0].ToString().Trim() != "")
                tienGuiXe = Convert.ToInt32(table.Rows[0][0]);

            int tongTien = tienBaoHanh + tienGuiXe;

            if (tongTien != 0)
            {
                this.chartLoaiBaoHanh.Series["Tong Tien"].Points.AddXY("Tong Tien", 100);
                this.chartLoaiBaoHanh.Series["Phi Gui Xe"].Points.AddXY("Phi Gui Xe", (tienGuiXe * 100 / tongTien));
                this.chartLoaiBaoHanh.Series["Phi Cham Soc"].Points.AddXY("Phi Cham Soc", (tienBaoHanh * 100 / tongTien));
            }
        }

        int flagNgay = 0;
        public void thongKeBieuDoTronTheoNgay()
        {
            flagNgay = 1;
            this.chartLoaiXe.Series.Clear();
            this.chartLoaiXe.Series.Add("loai");
            this.chartLoaiXe.Series["loai"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            int yy = Convert.ToInt32(DateTime.Now.Year.ToString());
            int dd = Convert.ToInt32(DateTime.Now.Month.ToString());
            int kk = Convert.ToInt32(DateTime.Now.Day.ToString());


            SqlCommand command = new SqlCommand("SELECT SUM(TongTien)  FROM PhieuThu, Xe  WHERE PhieuThu.MaXe = Xe.MaXe and LoaiXe = 'O to' AND (DATEPART(yy, NgayThu) = '" + yy + "' AND    DATEPART(mm, NgayThu) = '" + dd + "' AND    DATEPART(dd, NgayThu) = '" + kk + "')");
            DataTable table = xe.getXe(command);
            int tienOto = 0;
            if (table.Rows[0][0].ToString().Trim() != "")
                tienOto = Convert.ToInt32(table.Rows[0][0]);


            command = new SqlCommand("SELECT SUM(TongTien)  FROM PhieuThu, Xe  WHERE PhieuThu.MaXe = Xe.MaXe and LoaiXe = 'Xe Dap' and (DATEPART(yy, NgayThu) = '" + yy + "' AND    DATEPART(mm, NgayThu) = '" + dd + "' AND    DATEPART(dd, NgayThu) = '" + kk + "') ");
            table = xe.getXe(command);
            int tienXeDap = 0;
            if (table.Rows[0][0].ToString().Trim() != "")
                tienXeDap = Convert.ToInt32(table.Rows[0][0]);


            command = new SqlCommand("SELECT SUM(TongTien)  FROM PhieuThu, Xe  WHERE PhieuThu.MaXe = Xe.MaXe and LoaiXe = 'Xe May' and (DATEPART(yy, NgayThu) = '" + yy + "' AND    DATEPART(mm, NgayThu) = '" + dd + "' AND    DATEPART(dd, NgayThu) = '" + kk + "')");
            table = xe.getXe(command);
            int tienXeMay = 0;
            if (table.Rows[0][0].ToString().Trim() != "")
                tienXeMay = Convert.ToInt32(table.Rows[0][0]);



            int index = 0;
            if (tienXeMay != 0)
            {
                this.chartLoaiXe.Series["loai"].Points.Add(tienXeMay);
                this.chartLoaiXe.Series["loai"].Points[index].Label = "Xe May";
                this.chartLoaiXe.Series["loai"].Points[index].Color = Color.Blue;
                this.chartLoaiXe.Series["loai"].Points[index].AxisLabel = "Xe May";
                index++;
            }

            if (tienXeDap != 0)
            {
                this.chartLoaiXe.Series["loai"].Points.Add(tienXeDap);
                this.chartLoaiXe.Series["loai"].Points[index].Label = "Xe Dap";
                this.chartLoaiXe.Series["loai"].Points[index].Color = Color.Red;
                this.chartLoaiXe.Series["loai"].Points[index].AxisLabel = "Xe Dap";
                index++;
            }

            if (tienOto != 0)
            {
                this.chartLoaiXe.Series["loai"].Points.Add(tienOto);
                this.chartLoaiXe.Series["loai"].Points[index].Label = "O To";
                this.chartLoaiXe.Series["loai"].Points[index].Color = Color.Yellow;
                this.chartLoaiXe.Series["loai"].Points[index].AxisLabel = "O To";
                index++;
            }

            if (index == 0)
            {
                MessageBox.Show("Hom Nay Khong Co Xe Nao Gui Xe Va Bao Hanh", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void thongKeBieuDoCNNgay()
        {

            int yy = Convert.ToInt32(DateTime.Now.Year.ToString());
            int dd = Convert.ToInt32(DateTime.Now.Month.ToString());
            int kk = Convert.ToInt32(DateTime.Now.Day.ToString());

            this.chartLoaiBaoHanh.Series.Clear();
            this.chartLoaiBaoHanh.Series.Add("Tong Tien");
            this.chartLoaiBaoHanh.Series.Add("Phi Gui Xe");
            this.chartLoaiBaoHanh.Series.Add("Phi Cham Soc");


            flagNgay = 1;
            SqlCommand command = new SqlCommand("SELECT SUM(TienBaoHanh)  FROM PhieuThu WHERE(DATEPART(yy, NgayThu) = '" + yy + "' AND    DATEPART(mm, NgayThu) = '" + dd + "' AND    DATEPART(dd, NgayThu) = '" + kk + "') ");
            DataTable table = xe.getXe(command);
            int tienBaoHanh = 0;
            if (table.Rows[0][0].ToString().Trim() != "")
                tienBaoHanh = Convert.ToInt32(table.Rows[0][0]);


            command = new SqlCommand("SELECT SUM(TienGuiXe)  FROM PhieuThu   WHERE(DATEPART(yy, NgayThu) = '" + yy + "' AND    DATEPART(mm, NgayThu) = '" + dd + "' AND    DATEPART(dd, NgayThu) = '" + kk + "')");
            table = xe.getXe(command);
            int tienGuiXe = 0;
            if (table.Rows[0][0].ToString().Trim() != "")
                tienGuiXe = Convert.ToInt32(table.Rows[0][0]);

            int tongTien = tienBaoHanh + tienGuiXe;

            if (tongTien != 0)
            {
                this.chartLoaiBaoHanh.Series["Tong Tien"].Points.AddXY("Tong Tien", 100);
                this.chartLoaiBaoHanh.Series["Phi Gui Xe"].Points.AddXY("Phi Gui Xe", (tienGuiXe * 100 / tongTien) );
                this.chartLoaiBaoHanh.Series["Phi Cham Soc"].Points.AddXY("Phi Cham Soc", (tienBaoHanh * 100 / tongTien) );
            }
            

        }

        private void buttonThongKeToanBo_Click(object sender, EventArgs e)
        {
            if (flagToanBo == 0)
            {
                flagNgay = 0;
                this.ThongKeBieuDoTron();
                this.thongKeBieuDoCN();
            }
        }

        private void buttonXemChiTiet_Click(object sender, EventArgs e)
        {
            DoanhThuTrongNgay dt = new DoanhThuTrongNgay();
            dt.Show();
        }
    }
}
