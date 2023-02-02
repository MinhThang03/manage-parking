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
    public partial class QuanLyCongViec : Form
    {
        public QuanLyCongViec()
        {
            InitializeComponent();
        }

        CongViec cv = new CongViec();

        public void loadData( SqlCommand command)
        {
            this.dataGridViewCongViec.ReadOnly = true;
            this.dataGridViewCongViec.AllowUserToAddRows = false;
            this.dataGridViewCongViec.DataSource = cv.getCongViec(command);

            DataTable table = cv.getCongViec(command);
            int sum = table.Rows.Count;
            this.TongSoLuong.Text = "Tổng số lượng: " + sum.ToString();
        }

        public bool verif()
        {
            if ((this.TextBoxMaCongViec.Text.Trim() == "")
                || (this.TextBoxNoiDungCV.Text.Trim() == ""))
                return false;
            return true;
        }

        private void QuanLyCongViec_Load(object sender, EventArgs e)
        {
            TextBoxMaCongViec.Size = new Size(480, 60);
            TextBoxNoiDungCV.Size = new Size(480, 120);
            ThemeColor.LoadColos(this);

            SqlCommand command = new SqlCommand("SELECT MaCV as 'Mã Công Việc', TenCV as 'Tên Công Viêc'  FROM CongViec");
            this.loadData(command);
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.verif())
                {

                    string maCV = this.TextBoxMaCongViec.Text;
                    string nd = this.TextBoxNoiDungCV.Text;

                    if (!cv.KiemTraCongViec(maCV))
                    {
                        if (cv.ThemCongViec(maCV,nd))
                        {
                            MessageBox.Show("Them Cong Viec Thanh Cong", "Them Cong Viec", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Loi!!!", "Them Cong Viec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ma Cong Viec Da Ton Tai", "Them Cong Viec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Chua Dien Day Du Thong Tin!!!", "Them Cong Viec", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Loi", "Them Cong Viec", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (verif())
            {

                string maCV = this.TextBoxMaCongViec.Text;
                string nd = this.TextBoxNoiDungCV.Text;
                try
                {
                    if (cv.CapNhatCongViec(maCV,nd))
                    {
                        MessageBox.Show("Cap Nhat Thanh Cong", "Chinh Sua", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Loi!!!", "Chinh Sua", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Chinh Sua", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Chua Dien Day Du Thong Tin", "Chinh Sua", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maCV = this.TextBoxMaCongViec.Text;
                if (MessageBox.Show("Ban Chan Chac Muon Xoa Cong Viec Nay ", "Xoa Cong Viec", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (cv.XoaCongViec(maCV))
                    {

                        MessageBox.Show("Xoa Thanh Cong", "Xoa Cong Viec", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SqlCommand command = new SqlCommand("SELECT MaCV as 'Mã Công Việc', TenCV as 'Tên Công Viêc'  FROM CongViec");
                        this.loadData(command);

                        this.TextBoxMaCongViec.Text = "";
                        this.TextBoxNoiDungCV.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Khong Thanh Cong", "Xoa Cong Viec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ban Da Huy Xoa", "Xoa Cong Viec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                MessageBox.Show("Vui Long Nhap Ma Cong Viec", "Xoa Cong Viec", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDatlai_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT MaCV as 'Mã Công Việc', TenCV as 'Tên Công Viêc'  FROM CongViec");
            this.loadData(command);
            this.TextBoxMaCongViec.Text = "";
            this.TextBoxNoiDungCV.Text = "";
            this.TextBoxTimKiem.Text = "";
            this.LoaiThongTin.SelectedItem = null;

        }

        private void dataGridViewCongViec_Click(object sender, EventArgs e)
        {
            this.TextBoxMaCongViec.Text = this.dataGridViewCongViec.CurrentRow.Cells[0].Value.ToString().Trim();
            this.TextBoxNoiDungCV.Text = this.dataGridViewCongViec.CurrentRow.Cells[1].Value.ToString().Trim();
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            string key = this.TextBoxTimKiem.Text;
            if (key.Trim() != "")
            {
                if (this.LoaiThongTin.SelectedItem.ToString() == "Ma Cong Viec")
                {
                    SqlCommand command = new SqlCommand("SELECT MaCV as 'Mã Công Việc', TenCV as 'Tên Công Viêc'  FROM CongViec WHERE MaCV = '" + key + "'");
                    this.loadData(command);
                }
                else if (this.LoaiThongTin.SelectedItem.ToString() == "Noi Dung Cong Viec")
                {
                    SqlCommand command = new SqlCommand("SELECT MaCV as 'Mã Công Việc', TenCV as 'Tên Công Viêc'  FROM CongViec WHERE TenCV LIKE '%" + key + "%'");
                    this.loadData(command);
                }
                else
                {
                    MessageBox.Show("Chua Chon Loai Tim Kiem!!!", "Tim Kiem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Chua Dien Thong Tin Tim Kiem!!!", "Tim Kiem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridViewCongViec_DoubleClick(object sender, EventArgs e)
        {
            string maCV = this.dataGridViewCongViec.CurrentRow.Cells[0].Value.ToString().Trim();
            ChiTietBaoHanhXe ct = new ChiTietBaoHanhXe();
            ct.HienThiCV(maCV);
            ct.ShowDialog();
        }
    }
}
