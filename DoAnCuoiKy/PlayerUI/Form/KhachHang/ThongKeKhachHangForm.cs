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
    public partial class ThongKeKhachHangForm : Form
    {
        public ThongKeKhachHangForm()
        {
            InitializeComponent();
            ThongKeBieuDoTron();
        }

        HopDong hd = new HopDong();

        public string label = "Tất cả";
        int index = 0;
        public void ThongKeBieuDoTron()
        {

            SqlCommand command = new SqlCommand("SELECT * FROM HopDong, Xe Where LoaiHD = 'Cho Thuê'  and Xe.MaXe = HopDong.MaXe and LoaiXe = 'O to' and MaKH = '" + Global.GlobalUserId +"'");
            DataTable table = hd.getHopDong(command);
            int Oto = 0;
            if (table.Rows.Count > 0)
                Oto = table.Rows.Count;


            command = new SqlCommand("SELECT * FROM HopDong, Xe Where LoaiHD = 'Cho Thuê'  and Xe.MaXe = HopDong.MaXe and LoaiXe = 'Xe May' and MaKH = '" + Global.GlobalUserId +"'");
            table = hd.getHopDong(command);
            int xeMay = 0;
            if (table.Rows.Count > 0)
                xeMay = table.Rows.Count;


            command = new SqlCommand("SELECT * FROM HopDong, Xe Where LoaiHD = 'Cho Thuê'  and Xe.MaXe = HopDong.MaXe and LoaiXe = 'Xe Dap' and MaKH = '" + Global.GlobalUserId +"'");
            table = hd.getHopDong(command);
            int xeDap = 0;
            if (table.Rows.Count > 0)
                xeDap = table.Rows.Count;



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

            if (Oto!= 0)
            {
                this.chartLoaiXe.Series["loai"].Points.Add(Oto);
                this.chartLoaiXe.Series["loai"].Points[index].Label = "O To";
                this.chartLoaiXe.Series["loai"].Points[index].Color = Color.Yellow;
                this.chartLoaiXe.Series["loai"].Points[index].AxisLabel = "O To";
                index++;
            }
          

            if (Oto + xeDap + xeMay != 0)
            {
                int max = Oto;
                this.label = "Xe ô tô";
                if (max < xeDap)
                {
                    max = xeDap;
                    this.label = "Xe đạp";
                }
                if (max < xeMay)
                {
                    max = xeMay;
                    this.label = "Xe máy";
                }
            }
        }

        private void chartLoaiXe_Click(object sender, EventArgs e)
        {
          
        }

        private void ThongKeKhachHangForm_Load(object sender, EventArgs e)
        {
            if (index == 0)
            {
                MessageBox.Show("Bạn chưa sử dụng dịch vụ đặt xe của công ty", "Xin chào", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
