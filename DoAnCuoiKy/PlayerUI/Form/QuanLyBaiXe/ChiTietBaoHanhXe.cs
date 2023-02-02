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
    public partial class ChiTietBaoHanhXe : Form
    {
        public ChiTietBaoHanhXe()
        {
            InitializeComponent();
        }

        BaoHanh bh = new BaoHanh();

        public void HienThi(string maXe)
        {
            this.dataGridViewListCV.ReadOnly = true;
            this.dataGridViewListCV.AllowUserToAddRows = false;
            SqlCommand command = new SqlCommand("SELECT MaXe as 'Mã Xe', BaoHanh.MaCV as 'Mã Công Việc', TenCV as 'Tên Công Việc', Gia as 'Giá' FROM BaoHanh, CongViec WHERE BaoHanh.MaCV = CongViec.MaCV and MaXe = '" + maXe + "'");
            this.dataGridViewListCV.DataSource = bh.getBaoHanh(command);

            command = new SqlCommand("SELECT sum(Gia) FROM BaoHanh WHERE MaXe = '" + maXe + "'");
            DataTable table = bh.getBaoHanh(command);
            string tongTien = table.Rows[0][0].ToString();
            this.labelTongTien.Text = tongTien;
        }

        public void HienThiCV(string maCV)
        {
            this.dataGridViewListCV.ReadOnly = true;
            this.dataGridViewListCV.AllowUserToAddRows = false;
            SqlCommand command = new SqlCommand("SELECT MaXe as 'Mã Xe', BaoHanh.MaCV as 'Mã Công Việc', TenCV as 'Tên Công Việc', Gia as 'Giá' FROM BaoHanh, CongViec WHERE BaoHanh.MaCV = CongViec.MaCV and BaoHanh.MaCV = '" + maCV + "'");
            this.dataGridViewListCV.DataSource = bh.getBaoHanh(command);

            command = new SqlCommand("SELECT sum(Gia) FROM BaoHanh WHERE MaCV = '" + maCV + "'");
            DataTable table = bh.getBaoHanh(command);
            string tongTien = table.Rows[0][0].ToString();
            this.labelTongTien.Text = tongTien;
        }

        private void DangKyBaoHanh_Load(object sender, EventArgs e)
        {
            ThemeColor.LoadColos(this);
            panelHeard.BackColor = ThemeColor.PrimaryColor;
            panelLogo.BackColor = ThemeColor.SecondaryColor;
            panelMagirleft.BackColor = ThemeColor.PrimaryColor;
            panelZoomClose.BackColor = ThemeColor.PrimaryColor;
            panelTitle.BackColor = ThemeColor.PrimaryColor;
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

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maXe = this.dataGridViewListCV.CurrentRow.Cells[0].Value.ToString();
                string maVe = this.dataGridViewListCV.CurrentRow.Cells[1].Value.ToString();

                if (MessageBox.Show("Ban Chan Chac Muon Xoa Dang Ki Bao Hanh ", "Huy Dang Ki Bao Hanh", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (bh.XoaBaoHanh(maXe, maVe))
                    {

                        MessageBox.Show("Xoa Thanh Cong", "Huy Dang Ki Bao Hanh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.HienThi(maXe);
                    }
                    else
                    {
                        MessageBox.Show("Ban Da Huy Xoa", "Huy Dang Ki Bao Hanh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


            }
            catch
            {
                MessageBox.Show("Loi !!!", "Huy Dang Ki Bao Hanh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

}
