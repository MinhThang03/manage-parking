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
    public partial class QuanLyBaiXe : Form
    {
        public QuanLyBaiXe()
        {
            InitializeComponent();
        }

        LoaiXe loaiXe = new LoaiXe();
        Xe xe = new Xe();

        private void QuanLyBaiXe_Load(object sender, EventArgs e)
        {
            ThemeColor.LoadColos(this,false);
            BaiXeDap.ForeColor = ThemeColor.PrimaryColor;
            BaiXeMay.ForeColor = ThemeColor.PrimaryColor;
            BaiXeOto.ForeColor = ThemeColor.PrimaryColor;
            GiaCoBanMoiLoaiXe.ForeColor = ThemeColor.SecondaryColor;

            loaiXe.CapNhatSoLieu();
            this.soLieu();

            if (Global.GlobalUserId.Contains("NV"))
            {
                this.buttonEdit.Enabled = false;
            }
        }

        public void soLieu()
        {
            loaiXe.CapNhatSoLieu();
            SqlCommand command = null;
            command = new SqlCommand("SELECT * FROM LoaiXe WHERE LoaiXe = 'O to'");
            DataTable table = loaiXe.getLoaiXe(command);

            int sumOto = int.Parse(table.Rows[0][2].ToString());
            int oTo = int.Parse(table.Rows[0][3].ToString());
            int oToTrong = int.Parse(table.Rows[0][4].ToString());
            int giaOTo = int.Parse(table.Rows[0][1].ToString());

            command = new SqlCommand("SELECT * FROM LoaiXe WHERE LoaiXe = 'Xe May'");
            table = loaiXe.getLoaiXe(command);
            int sumXeMay = int.Parse(table.Rows[0][2].ToString());
            int xeMay = int.Parse(table.Rows[0][3].ToString());
            int xeMayTrong = int.Parse(table.Rows[0][4].ToString());
            int giaXeMay = int.Parse(table.Rows[0][1].ToString());


            command = new SqlCommand("SELECT * FROM LoaiXe WHERE LoaiXe = 'Xe Dap'");
            table = loaiXe.getLoaiXe(command);
            int sumXeDap = int.Parse(table.Rows[0][2].ToString());
            int xeDap = int.Parse(table.Rows[0][3].ToString());
            int xeDapTrong = int.Parse(table.Rows[0][4].ToString());
            int giaXeDap = int.Parse(table.Rows[0][1].ToString());


            this.labelTongOTo.Text = "Tổng Vị Trí: " + sumOto.ToString();
            this.labelTrongOTo.Text = "Số Vị Trí Đang Trống: " + oToTrong.ToString();
            this.labelDungOTo.Text = "Số Vị Trí Đã Dùng: " + oTo.ToString();
            this.labelGiaXeOTo.Text = "Gia Xe O To: " + giaOTo.ToString();

            this.labelTongXeMay.Text = "Tổng Vị Trí: " + sumXeMay.ToString();
            this.labelTrongXeMay.Text = "Số Vị Trí Đang Trống: " + xeMayTrong.ToString();
            this.labelDungXeMay.Text = "Số Vị Trí Đã Dùng: " + xeMay.ToString();
            this.labelGiaXeMay.Text = "Gia Xe May:  " + giaXeMay.ToString();

            this.labelTongXeDap.Text = "Tổng Vị Trí: " + sumXeDap.ToString();
            this.labelTrongXeDap.Text = "Số Vị Trí Đang Trống: " + xeDapTrong.ToString();
            this.labelDungXeDap.Text = "Số Vị Trí Đã Dùng: " + xeDap.ToString();
            this.labelGiaXeDap.Text = "Gia Xe Dap:  " + giaXeDap.ToString();

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ThayDoiThongTinBaiGuiXe editbai = new ThayDoiThongTinBaiGuiXe();
            if (editbai.ShowDialog() == DialogResult.OK)
            {
                this.soLieu();
            }
        }
    }
}
