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
    public partial class ThayDoiThongTinBaiGuiXe : Form
    {
        public ThayDoiThongTinBaiGuiXe()
        {
            InitializeComponent();
        }

        LoaiXe loai = new LoaiXe();

        private void ThayDoiThongTinBaiGuiXe_Load(object sender, EventArgs e)
        {
            ThemeColor.LoadColos(this);
            panelHeard.BackColor = ThemeColor.PrimaryColor;
            panelLogo.BackColor = ThemeColor.SecondaryColor;
            panelMagirleft.BackColor = ThemeColor.PrimaryColor;
            panelZoomClose.BackColor = ThemeColor.PrimaryColor;
            panelTitle.BackColor = ThemeColor.PrimaryColor;
            
            this.HienThi();
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

        public void HienThi()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM LoaiXe");
            DataTable table = loai.getLoaiXe(command);
            this.textBoxViTriXeDap.Text = table.Rows[1][2].ToString().Trim();
            this.textBoxViTriXeMay.Text = table.Rows[2][2].ToString().Trim();
            this.textBoxViTriXeOTo.Text = table.Rows[0][2].ToString().Trim();
            this.textBoxGiaXeDap.Text = table.Rows[1][1].ToString().Trim();
            this.textBoxGiaXeMay.Text = table.Rows[2][1].ToString().Trim();
            this.textBoxGiaXeOTo.Text = table.Rows[0][1].ToString().Trim();
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool verif()
        {
            if (this.textBoxGiaXeDap.Text.ToString().Trim() == ""
                || this.textBoxGiaXeMay.Text.ToString().Trim() == ""
                || this.textBoxGiaXeOTo.Text.ToString().Trim() == ""
                || this.textBoxViTriXeDap.Text.ToString().Trim() == ""
                || this.textBoxViTriXeMay.Text.ToString().Trim() == ""
                || this.textBoxViTriXeOTo.Text.ToString().Trim() == "")
                return false;
            else return true;

        }

        private void BtLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.verif())
                {

                    int sumXeDap = Convert.ToInt32(this.textBoxViTriXeDap.Text.Trim());
                    int sumXeMay = Convert.ToInt32(this.textBoxViTriXeMay.Text.Trim());
                    int sumOto = Convert.ToInt32(this.textBoxViTriXeOTo.Text.Trim());
                    int giaXeDap = Convert.ToInt32(this.textBoxGiaXeDap.Text.Trim());
                    int giaXeMay = Convert.ToInt32(this.textBoxGiaXeMay.Text.Trim());
                    int giaXeOto = Convert.ToInt32(this.textBoxGiaXeOTo.Text.Trim());

                     if (loai.CapNhatBaiXe(sumOto,giaXeOto,"O to") && loai.CapNhatBaiXe(sumXeMay,giaXeMay,"Xe May") && loai.CapNhatBaiXe(sumXeDap, giaXeDap,"Xe Dap"))
                        {
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Chinh Sua Thanh Cong", "Thay Doi Thong Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Loi!!!", "Thay Doi Thong Tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                
                }
                else
                {
                    MessageBox.Show("Chua Dien Day Du Thong Tin!!!", "Thay Doi Thong Tin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Loi", "Thay Doi Thong Tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
