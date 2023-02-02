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
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }

        PhieuThu pt = new PhieuThu();
        Giuxe giu = new Giuxe();
        LoaiXe loai = new LoaiXe();
        Xe xe = new Xe();

        private void HoaDon_Load(object sender, EventArgs e)
        {
            ThemeColor.LoadColos(this,false);

            //panel setting color
            panelHeard.BackColor = ThemeColor.PrimaryColor;
            panelLogo.BackColor = ThemeColor.SecondaryColor;
            panelMagirleft.BackColor = ThemeColor.PrimaryColor;
            panelZoomClose.BackColor = ThemeColor.PrimaryColor;
            panelTitle.BackColor = ThemeColor.PrimaryColor;

            //label setting color
            labelTitleBaoHanh.ForeColor = ThemeColor.PrimaryColor;
            labelTitleGuiXe.ForeColor = ThemeColor.PrimaryColor;
   
            labelTitleMaXe.ForeColor = ThemeColor.PrimaryColor;
            labelTitleTongTien.ForeColor = ThemeColor.PrimaryColor;
            labelMaXe.ForeColor = ThemeColor.SecondaryColor;
            labelValueTienBaoHanh.ForeColor = ThemeColor.SecondaryColor;
            labelValueTienGuiXe.ForeColor = ThemeColor.SecondaryColor;
            labelValueTienPhatXe.ForeColor = ThemeColor.SecondaryColor;
            labelValueTongTien.ForeColor = ThemeColor.SecondaryColor;
            labelNgayVaoBen.BackColor = ThemeColor.SecondaryColor;
            labelNgayThanhToan.BackColor = ThemeColor.SecondaryColor;

            this.bunifuTextBoxMaNV.Text = Global.GlobalUserId;
            this.bunifuTextBoxMaPT.Text = this.setIDPhieuThu();

        }

        public string setIDPhieuThu()
        {
            string gio = DateTime.Now.Hour.ToString(); 
            string giay = DateTime.Now.Second.ToString();
            string nam = DateTime.Now.Year.ToString();
            return "PT" + gio + giay + nam;
        }

        private void CloseBtnImg_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MaximizeBtnImg_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void MinimizeBtnImg_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void loadData(string maXe)
        {
            this.labelMaXe.Text = maXe;
            this.DatepickerNgayThanhToan.Value = Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss"));
            this.labelValueTienGuiXe.Text = this.TinhTienGui().ToString();
            this.labelValueTienPhatXe.Text = this.TinhTienPhat().ToString();
            this.labelValueTienBaoHanh.Text = this.TinhTienBaoHanh().ToString();
            this.labelValueTongTien.Text = this.TinhTongTien().ToString();

            SqlCommand command = new SqlCommand("SELECT * FROM Xe WHERE MaXe = '" + maXe + "'");
            DataTable table = pt.getPhieuThu(command);

            this.DatepickerNgayVaoBen.Value = (DateTime)table.Rows[0][2];
           
            
        }

        public int TinhTienGui()
        {
             
            string maXe = this.labelMaXe.Text;
            SqlCommand commmand = new SqlCommand("SELECT Xe.MaXe, Xe.LoaiXe, VeXe.MaVe, VeXe.LoaiVe, LoaiXe.Gia, Xe.NgayVaoBen FROM Xe, GiuXe, VeXe, LoaiXe WHERE Xe.MaXe = GiuXe.MaXe And GiuXe.MaVe = VeXe.MaVe And Xe.LoaiXe = LoaiXe.LoaiXe and Xe.MaXe = '" + maXe + "'");
            DataTable table = pt.getPhieuThu(commmand);
            
           
            if (table.Rows.Count > 0)
            {
                string loai = table.Rows[0][3].ToString().Trim();
                int giaCoBan = Convert.ToInt32(table.Rows[0][4].ToString());
                if (loai == "Gio")
                {
                    DateTime vao = (DateTime)table.Rows[0][5];
                    DateTime hien = DateTime.Now;

                    TimeSpan kc = hien.Subtract(vao);
                    int ngay = kc.Days;
                    int gio = kc.Hours;
                    int sum = ngay * 24 + gio;

                    return Math.Abs(sum * giaCoBan);
                }
                else if (loai == "Ngay")
                {
                    return Math.Abs(giaCoBan * 8);
                }
                else if (loai == "Tuan")
                {
                    return Math.Abs(giaCoBan * 8 * 3);
                }
                else
                {
                    return Math.Abs(giaCoBan * 8 * 3 * 2);
                }
            }
            else
            {
                return 0;
            }

        }

        public int TinhTienPhat()
        {

            string maXe = this.labelMaXe.Text;
            SqlCommand commmand = new SqlCommand("SELECT Xe.MaXe, Xe.LoaiXe, VeXe.MaVe, VeXe.LoaiVe, LoaiXe.Gia, Xe.NgayVaoBen, GiuXe.NgayHetHan FROM Xe, GiuXe, VeXe, LoaiXe WHERE Xe.MaXe = GiuXe.MaXe And GiuXe.MaVe = VeXe.MaVe And Xe.LoaiXe = LoaiXe.LoaiXe and Xe.MaXe = '" + maXe + "'");
            DataTable table = pt.getPhieuThu(commmand);

         

            if (table.Rows.Count > 0)
            {
                string loai = table.Rows[0][3].ToString().Trim();
                int giaCoBan = Convert.ToInt32(table.Rows[0][4].ToString());

                DateTime vao = (DateTime)table.Rows[0][5];
                DateTime hien = DateTime.Now;
                DateTime het = (DateTime)table.Rows[0][6];

                int compare = DateTime.Compare(hien, het);
                if (compare > 0)
                {
                    if (loai == "Gio")
                    {
                        return giaCoBan * 8 * 2;

                    }
                    else if (loai == "Ngay")
                    {
                        return giaCoBan * 8 * 3;
                    }
                    else if (loai == "Tuan")
                    {
                        DateTime giaHan = het.AddDays(20);
                        compare = DateTime.Compare(hien, giaHan);
                        if (compare < 0)
                            return giaCoBan * 8 * 3 * 2;
                        else
                            return giaCoBan * 8 * 3 * 2 * 2;
                    }
                    else
                    {
                        return giaCoBan * 8 * 3 * 2 * 2;
                    }
                }
                else
                {
                    return 0;
                }
            }
            else return 0;

        }
        public int TinhTienBaoHanh()
        {
            string maXe = this.labelMaXe.Text;
            SqlCommand command = new SqlCommand("SELECT sum(Gia) FROM BaoHanh WHERE MaXe = '" + maXe + "'");
            DataTable table = pt.getPhieuThu(command);
            if (table.Rows[0][0].ToString().Trim() == "")
                table.Rows[0][0] = 0;
            int tienBaoHanh = Convert.ToInt32(table.Rows[0][0].ToString());
            return tienBaoHanh;
        }

        public int TinhTongTien()
        {
            int gui = this.TinhTienGui();
            int phat = this.TinhTienPhat();
            int bh = this.TinhTienBaoHanh();

            return gui + phat + bh;
        }

        public bool verif()
        {
            if (this.bunifuTextBoxMaNV.Text.Trim() == ""
                || this.bunifuTextBoxMaPT.Text.Trim() == "")
                return false;
            return true;
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {


            try
            {
                if (this.verif())
                {

                    string maXe = this.labelMaXe.Text;
                    string maPT = this.bunifuTextBoxMaPT.Text;
                    DateTime ngayVao = this.DatepickerNgayVaoBen.Value;
                    DateTime ngayThu = this.DatepickerNgayThanhToan.Value;
                    int gui = Convert.ToInt32(this.labelValueTienGuiXe.Text);
                    int phat = Convert.ToInt32(this.labelValueTienPhatXe.Text);
                    int bh = Convert.ToInt32(this.labelValueTienBaoHanh.Text);
                    int tong = Convert.ToInt32(this.labelValueTongTien.Text);
                    

                    SqlCommand command = new SqlCommand("SELECT MaVe FROM GiuXe WHERE MaXe = '" + maXe + "'");
                    DataTable table = pt.getPhieuThu(command);
                string maVe = "";
                if (table.Rows.Count > 0)
                {
                    maVe = table.Rows[0][0].ToString();
                }

                    if (!pt.KiemTraPhieuThu(maPT))
                    {
                        if (pt.ThemPhieuThu(maPT, maXe, tong, gui  + phat, bh, DateTime.Now))
                        {
                        if (maVe != "")
                        {
                            giu.CapNhapTien(maXe, maVe, phat + gui);
                        }
                            loai.CapNhatSoLieu();
                            xe.ThemNgayXuatBen(maXe, DateTime.Now);
                            MessageBox.Show("Thanh Toan Thanh Cong", "Them Phieu Thu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Loi!!!", "Them Phieu Thu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ma Cong Viec Da Ton Tai", "Them Phieu Thu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Chua Dien Day Du Thong Tin!!!", "Them Phieu Thu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Loi", "Them Phieu Thu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
    
}
