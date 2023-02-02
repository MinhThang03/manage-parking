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
    public partial class GuiXe : Form
    {
        public GuiXe()
        {
            InitializeComponent();
        }

        VeXe ve = new VeXe();
        Xe xe = new Xe();
        Giuxe giuXe = new Giuxe();

        private void GuiXe_Load(object sender, EventArgs e)
        {
            ThemeColor.LoadColos(this);
            panelHeard.BackColor = ThemeColor.PrimaryColor;
            panelLogo.BackColor = ThemeColor.SecondaryColor;
            panelMagirleft.BackColor = ThemeColor.PrimaryColor;
            panelZoomClose.BackColor = ThemeColor.PrimaryColor;
            panelTitle.BackColor = ThemeColor.PrimaryColor;

            this.LoadNgayThang();
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

        public void LoadMaXe(string maXe)
        {
            this.labelMaXe.Text = maXe;
        }

        public void LoadDataMaVe(SqlCommand command)
        {
            this.comboBoxMaVe.DataSource = ve.getVe(command);
            this.comboBoxMaVe.DisplayMember = "MaVe";
            this.comboBoxMaVe.ValueMember = "MaVe";
        }

        private void radioButtonGio_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonGio.Checked == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM VeXe WHERE LoaiVe = 'Gio' and MaVe not in (SELECT MaVe FROM GiuXe WHERE Tien = 0)");
                this.LoadDataMaVe(command);
                DateTime hetHan;
                hetHan = this.dateTimePickerVao.Value.AddHours(24);
                this.dateTimePickerHetHan.Value = hetHan;
            }
        }

        private void radioButtonNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonNgay.Checked == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM VeXe WHERE LoaiVe = 'Ngay' and MaVe not in (SELECT MaVe FROM GiuXe WHERE Tien = 0)");
                this.LoadDataMaVe(command);
                DateTime hetHan;
                hetHan = this.dateTimePickerVao.Value.AddHours(48);
                this.dateTimePickerHetHan.Value = hetHan;
            }
        }

        private void radioButtonTuan_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonTuan.Checked == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM VeXe WHERE LoaiVe = 'Tuan' and MaVe not in (SELECT MaVe FROM GiuXe WHERE Tien = 0)");
                this.LoadDataMaVe(command);
                DateTime hetHan;
                hetHan = this.dateTimePickerVao.Value.AddDays(10);
                this.dateTimePickerHetHan.Value = hetHan;
            }
        }

        private void radioButtonThang_Click(object sender, EventArgs e)
        {
            if (this.radioButtonThang.Checked == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM VeXe WHERE LoaiVe = 'Thang' and MaVe not in (SELECT MaVe FROM GiuXe WHERE Tien = 0)");
                this.LoadDataMaVe(command);
                DateTime hetHan;
                hetHan = this.dateTimePickerVao.Value.AddDays(40);
                this.dateTimePickerHetHan.Value = hetHan;
            }
        }

        public void LoadNgayThang()
        {
            try
            {
                string maXe = this.labelMaXe.Text;
                SqlCommand command = new SqlCommand("SELECT NgayVaoBen FROM Xe WHERE MaXe = '" + maXe + "'");
                DataTable table = xe.getXe(command);
                this.dateTimePickerVao.Value = (DateTime)table.Rows[0][0];
            }
            catch
            {
                MessageBox.Show("Khong Co Ma Xe Nay", "Dang Ki Giu Xe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.verif())
                {
                    string maXe = this.labelMaXe.Text;
                    string maVe = this.comboBoxMaVe.SelectedValue.ToString();
                    DateTime ngayVao = this.dateTimePickerVao.Value;
                    DateTime ngayHet = this.dateTimePickerHetHan.Value;
                    int tien = 0;

                    if (xe.KiemTraMaXe(maXe))
                    {
                        if (xe.KiemTraMaXeConTrongBen(maXe))
                        {
                            if (!giuXe.KiemTraGiuXe(maXe, maVe))
                            {
                                if (!giuXe.KiemTraXe(maXe))
                                {
                                    if (giuXe.ThemGiuXe(maXe, maVe, ngayVao, ngayHet, tien))
                                    {
                                        MessageBox.Show("Dang Ki Giu Xe Thanh Cong", "Dang Ki Giu Xe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Loi", "Dang Ki Giu Xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    if (MessageBox.Show("Xe Nay Da Dang Ky Giu Xe, Ban Chac Chan Muon Tiep Tuc ", "Dang Ki Giu Xe", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        if (giuXe.ThemGiuXe(maXe, maVe, ngayVao, ngayHet, tien))
                                        {
                                            MessageBox.Show("Dang Ki Giu Xe Thanh Cong", "Dang Ki Giu Xe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Loi", "Dang Ki Giu Xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("Ban Da Huy Dang Ki Giu Xe", "Dang Ki Giu Xe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                }
                            }
                            else
                            {
                                MessageBox.Show("Ma Xe va Ma Ve Da Ton Tai", "Dang Ki Giu Xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Chua Dien Day Du Thong Tin!!!", "Dang Ki Giu Xe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Loi", "Dang Ki Giu Xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool verif()
        {
            if (this.radioButtonGio.Checked == false && this.radioButtonNgay.Checked == false && this.radioButtonTuan.Checked == false && this.radioButtonThang.Checked == false)
                return false;
            else
            {
                if (this.comboBoxMaVe.SelectedValue == null)
                {
                    return false;
                }
                else return true;
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maXe = this.labelMaXe.Text;
                string maVe = this.comboBoxMaVe.SelectedValue.ToString().Trim();

                if (MessageBox.Show("Ban Chan Chac Muon Xoa Dang Ki Giu Xe ", "Huy Dang Ki Giu Xe", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (giuXe.XoaGiuXe(maXe, maVe))
                    {

                        MessageBox.Show("Xoa Thanh Cong", "Huy Dang Ki Giu Xe", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.labelMaXe.Text = "";
                        this.dateTimePickerVao.Value = DateTime.Now;
                        this.dateTimePickerHetHan.Value = DateTime.Now;
                    }
                    else
                    {
                        MessageBox.Show("Ban Da Huy Xoa", "Huy Dang Ki Giu Xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


            }
            catch
            {
                MessageBox.Show("Vui Long Chon Ma Ve", "Huy Dang Ki Giu Xe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void HienThi(string maXe, string maVe)
        {

            SqlCommand command = new SqlCommand("SELECT MaXe, GiuXe.MaVe, NgayVaoBen, NgayHetHan, Tien, LoaiVe FROM GiuXe, VeXe WHERE GiuXe.MaVe = VeXe.MaVe and MaXe = @maXe and VeXe.MaVe = @maVe");

            command.Parameters.Add("@maXe", SqlDbType.VarChar).Value = maXe;
            command.Parameters.Add("@maVe", SqlDbType.VarChar).Value = maVe;

            
            DataTable table = giuXe.getGiuXe(command);


            string loai = table.Rows[0][5].ToString().Trim();

            if (loai == "Gio")
            {
                this.radioButtonGio.Checked = true;
           
                SqlCommand command1 = new SqlCommand("SELECT * FROM VeXe WHERE LoaiVe = 'Gio' and MaVe not in (SELECT MaVe FROM GiuXe WHERE Tien = 0)");
                this.LoadDataMaVe(command1);
            }
            else if (loai == "Ngay")
            {
                this.radioButtonNgay.Checked = true;
                this.radioButtonGio.Checked = false;
                SqlCommand command1 = new SqlCommand("SELECT * FROM VeXe WHERE LoaiVe = 'Ngay' and MaVe not in (SELECT MaVe FROM GiuXe WHERE Tien = 0)");
                this.LoadDataMaVe(command1);
            }
            else if (loai == "Tuan")
            {
                this.radioButtonTuan.Checked = true;
                this.radioButtonGio.Checked = false;
                SqlCommand command1 = new SqlCommand("SELECT * FROM VeXe WHERE LoaiVe = 'Tuan' and MaVe not in (SELECT MaVe FROM GiuXe WHERE Tien = 0)");
                this.LoadDataMaVe(command1);
            }
            else
            {
                this.radioButtonThang.Checked = true;
                this.radioButtonGio.Checked = false;
                SqlCommand command1 = new SqlCommand("SELECT * FROM VeXe WHERE LoaiVe = 'Thang' and MaVe not in (SELECT MaVe FROM GiuXe WHERE Tien = 0)");
                this.LoadDataMaVe(command1);
            }
            this.labelMaXe.Text = table.Rows[0][0].ToString();
            this.comboBoxMaVe.Text = table.Rows[0][1].ToString();
            this.dateTimePickerVao.Value = (DateTime)table.Rows[0][2];
            this.dateTimePickerHetHan.Value = (DateTime)table.Rows[0][3];

        }
    }
}
