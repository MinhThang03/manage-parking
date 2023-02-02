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
    public partial class DangKyBaoHanh : Form
    {
        public DangKyBaoHanh()
        {
            InitializeComponent();
        }

        CongViec cv = new CongViec();
        BaoHanh bh = new BaoHanh();
        Xe xe = new Xe();

        public void LoadMaXe(string maXe)
        {
            this.labelMaXe.Text = maXe;
        }

        public void LoadDataDSCV()
        {
            this.dataGridViewDSCV.ReadOnly = true;
            this.dataGridViewDSCV.AllowUserToAddRows = false;
            SqlCommand command = new SqlCommand("SELECT MaCV as 'Mã Công Việc', TenCV as 'Tên Công Viêc'  FROM CongViec");
            this.dataGridViewDSCV.DataSource = cv.getCongViec(command);
        }

        public void LoadDataCVChon()
        {
            this.dataGridViewCVChon.ReadOnly = true;
            this.dataGridViewCVChon.AllowUserToAddRows = false;
            string maXe = this.labelMaXe.Text;
            SqlCommand command = new SqlCommand("SELECT MaXe as 'Mã Xe', BaoHanh.MaCV as 'Mã Công Việc', TenCV as 'Tên Công Việc', Gia as 'Giá' FROM BaoHanh, CongViec WHERE BaoHanh.MaCV = CongViec.MaCV and MaXe = '" + maXe + "'");
            this.dataGridViewCVChon.DataSource = bh.getBaoHanh(command);

            command = new SqlCommand("SELECT sum(Gia) FROM BaoHanh WHERE MaXe = '" + maXe + "'");
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

            this.labelTongTien.Text = "0";
            this.LoadDataDSCV();
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
          
        }

        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (this.textBoxTien.Text != "")
                {
                    string maXe = this.labelMaXe.Text.Trim();
                    int tien = Convert.ToInt32(this.textBoxTien.Text);
                    string maCV = this.dataGridViewDSCV.CurrentRow.Cells[0].Value.ToString().Trim();

                    if (xe.KiemTraMaXe(maXe))
                    {
                        if (xe.KiemTraMaXeConTrongBen(maXe))
                        {
                            if (!bh.KiemTraBaoHanh(maXe, maCV))
                            {
                                if (bh.ThemBaoHanh(maXe, maCV, tien))

                                {
                                    MessageBox.Show("Dang Ki Bao Hanh Thanh Cong", "Dang Ki Bao Hanh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.LoadDataCVChon();
                                }
                                else
                                {
                                    MessageBox.Show("Loi", "Dang Ki Bao Hanh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                            else
                            {
                                MessageBox.Show("Da Ton Tai", "Dang Ki Bao Hanh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hien Khong Co Xe Nay Trong Ben", "Dang Ki Bao Hanh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Khong Co Ma Xe Nay", "Dang Ki Bao Hanh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Chua Dien Gia Tien!!!", "Dang Ki Bao Hanh", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Loi", "Dang Ki Bao Hanh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonXoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                string maXe = this.dataGridViewCVChon.CurrentRow.Cells[0].Value.ToString();
                string maVe = this.dataGridViewCVChon.CurrentRow.Cells[1].Value.ToString();

                if (MessageBox.Show("Ban Chan Chac Muon Xoa Dang Ki Bao Hanh ", "Huy Dang Ki Bao Hanh", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (bh.XoaBaoHanh(maXe, maVe))
                    {

                        MessageBox.Show("Xoa Thanh Cong", "Huy Dang Ki Bao Hanh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LoadDataCVChon();
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
