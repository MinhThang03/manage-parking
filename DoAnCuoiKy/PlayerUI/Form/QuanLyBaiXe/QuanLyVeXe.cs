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
    public partial class QuanLyVeXe : Form
    {
        public QuanLyVeXe()
        {
            InitializeComponent();
        }

        VeXe ve = new VeXe();

        public void loadData(SqlCommand command)
        {
            this.dataGridViewListVe.DataSource = ve.getVe(command);
            this.dataGridViewListVe.ReadOnly = true;
            this.dataGridViewListVe.AllowUserToAddRows = false;
        }
        private void QuanLyVeXe_Load(object sender, EventArgs e)
        {
            ThemeColor.LoadColos(this,false);
            LableLoaiVe.BackColor = ThemeColor.SecondaryColor;

            SqlCommand command = new SqlCommand("SELECT MaVe as 'Mã Vé', LoaiVe as 'Loại Vé' FROM VeXe");
            this.loadData(command);   
        }

        bool verif()
        {
            if (this.comboBoxLoaiVe.SelectedItem == null)
                return false;
            else
            {
                if (this.textBoxMaVe.Text.Trim() == "")
                {
                    return false;
                }
                else return true;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.verif())
                {

                    string maVe = this.textBoxMaVe.Text;
                    string loaiVe = this.comboBoxLoaiVe.SelectedItem.ToString();

                    if (!ve.KiemTraMaVeXe(maVe))
                    {
                        if (ve.ThemVeXe(maVe, loaiVe))
                        {
                            MessageBox.Show("Them Ve Thanh Cong", "Them Ve", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Loi!!!", "Them Ve", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ma Ve Da Ton Tai", "Them Ve", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Chua Dien Day Du Thong Tin!!!", "Them Ve", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Loi", "Them Ve", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (verif())
            {

                string maVe = this.textBoxMaVe.Text;
                string loaiVe = this.comboBoxLoaiVe.SelectedItem.ToString();
                try
                {
                    if (ve.CapNhatVeXe(maVe, loaiVe))
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string maVe = this.textBoxMaVe.Text;
                if (MessageBox.Show("Ban Chan Chac Muon Xoa Ve Xe Nay ", "Xoa Ve", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (ve.XoaVe(maVe))
                    {

                        MessageBox.Show("Xoa Thanh Cong", "Xoa Ve", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.textBoxMaVe.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Khong Thanh Cong", "Xoa Ve", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ban Da Huy Xoa", "Xoa Ve", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                MessageBox.Show("Vui Long Nhap Ma Ve", "Xoa Ve", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT MaVe as 'Mã Vé', LoaiVe as 'Loại Vé' FROM VeXe");
            this.textBoxMaVe.Text = "";
            this.loadData(command);
            this.TextBoxTimKiem.Text = "";
            this.LoaiThongTin.SelectedItem = null;
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            string key = this.TextBoxTimKiem.Text;
            if (key != "")
            {
                if (this.LoaiThongTin.SelectedItem.ToString() == "Mã Vé")
                {
                    SqlCommand command = new SqlCommand("SELECT MaVe as 'Mã Vé', LoaiVe as 'Loại Vé' FROM VeXe WHERE MaVe = '" + key + "'");
                    this.loadData(command);
                }
                else if (this.LoaiThongTin.SelectedItem.ToString() == "Loại Vé")
                {
                    SqlCommand command = new SqlCommand("SELECT MaVe as 'Mã Vé', LoaiVe as 'Loại Vé' FROM VeXe WHERE  LoaiVe = '" + key + "'");
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

        private void dataGridViewListVe_Click(object sender, EventArgs e)
        {
            this.textBoxMaVe.Text = this.dataGridViewListVe.CurrentRow.Cells[0].Value.ToString().Trim();
            this.comboBoxLoaiVe.SelectedItem = this.dataGridViewListVe.CurrentRow.Cells[1].Value.ToString().Trim();
        }
    }
}
