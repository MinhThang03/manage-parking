using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class QuanLyVaoRaBen : Form
    {
        public QuanLyVaoRaBen()
        {
            InitializeComponent();
        }

        LoaiXe loaiXe = new LoaiXe();
        Xe xe = new Xe();
        VeXe ve = new VeXe();
        PhieuThu pt = new PhieuThu();

        bool verifXeVao()
        {
            if (this.comboBoxLoaiXe.SelectedValue == null)
                return false;
            else
            {
                if ((this.textBoxMaXe.Text.Trim() == "")
                        || (this.pictureBoxImg1XeVao.Image == null)
                        || (this.pictureBoxImg2XeVao.Image == null))
                {
                    return false;
                }
                else return true;
            }
        }

        bool verifXeRa()
        {
            if (this.comboBoxLoaiXe.SelectedValue == null)
                return false;
            else
            {
                return true;
            }
        }


        private void QuanLyVaoRaBen_Load(object sender, EventArgs e)
        {
            ThemeColor.LoadColos(this, false);
            LableLoaiXe.BackColor = ThemeColor.SecondaryColor;

            SqlCommand commandLoai = new SqlCommand("SELECT * FROM LoaiXe");
            this.comboBoxLoaiXe.DataSource = loaiXe.getLoaiXe(commandLoai);
            this.comboBoxLoaiXe.DisplayMember = "LoaiXe";
            this.comboBoxLoaiXe.ValueMember = "LoaiXe";
            this.panelmidle.BackColor = ThemeColor.SecondaryColor;
        }
    
        private void BtnDangKyGui_Click(object sender, EventArgs e)
        {
            string maXe = this.textBoxMaXe.Text;
            GuiXe giu = new GuiXe();
            giu.LoadMaXe(maXe);
            giu.ShowDialog();
        }

        private void BtnDangKyChamSoc_Click(object sender, EventArgs e)
        {
            string maXe = this.textBoxMaXe.Text;
            DangKyBaoHanh bh = new DangKyBaoHanh();
            bh.LoadMaXe(maXe);
            bh.ShowDialog();
        }

        private void BtnDangKyHopDong_Click(object sender, EventArgs e)
        {
            //MainFormMenu.openChildForm(new ThongTinHopDong());

        }

        private void buttonLoadImg1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image (*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                this.pictureBoxImg1XeVao.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonLoadImg2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image (*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                this.pictureBoxImg2XeVao.Image = Image.FromFile(opf.FileName);
            }
        }

        private void comboBoxLoaiXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loai = this.comboBoxLoaiXe.SelectedValue.ToString().Trim();
            if (loai == "Xe May")
            {
                this.labelImg1XeVao.Text = "Bang So";
                this.labelImg2XeVao.Text = "Nguoi Gui";
            }
            else if (loai == "Xe Dap")
            {
                this.labelImg1XeVao.Text = "Hinh Xe";
                this.labelImg2XeVao.Text = "Nguoi Gui";
            }
            else
            {
                this.labelImg1XeVao.Text = "Bang So";
                this.labelImg2XeVao.Text = "Hieu Xe";

            }
        }

        private void buttonVao_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.verifXeVao())
                {

                    string maXe = this.textBoxMaXe.Text;
                    string loai = this.comboBoxLoaiXe.SelectedValue.ToString();
                    MemoryStream img1 = new MemoryStream();
                    this.pictureBoxImg1XeVao.Image.Save(img1, this.pictureBoxImg1XeVao.Image.RawFormat);
                    MemoryStream img2 = new MemoryStream();
                    this.pictureBoxImg2XeVao.Image.Save(img2, this.pictureBoxImg2XeVao.Image.RawFormat);
                    DateTime ngayVao = DateTime.Now;

                    if (loaiXe.KiemTraChoTrong(loai))
                    {
                        if (!xe.KiemTraMaXe(maXe))
                        {
                            if (xe.ThemXe(maXe, loai, ngayVao, img1, img2))
                            {
                                loaiXe.CapNhatSoLieu();
                                MessageBox.Show("Them Xe Thanh Cong", "Vao Ben", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Error", "Vao Ben", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ma Xe Da Ton Tai", "Vao Ben", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bai Xe Da Het Cho", "Vao Ben", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Chua Dien Day Du Thong Tin!!!", "Vao Ben", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Loi!!!", "Vao Ben", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonXuatBen_Click(object sender, EventArgs e)
        {
            /*try
            {*/
                if (this.verifXeRa())
                {

                    string maXe = this.textBoxMaXeRa.Text;
                    DateTime ngayRa = DateTime.Now;

                    if (xe.KiemTraMaXe(maXe))
                    {
                        if (xe.KiemTraXeNgayXuat(maXe) && xe.KiemTraNgayThue(DateTime.Now, maXe))
                        {
                           /* if (xe.ThemNgayXuatBen(maXe, ngayRa))
                            {
*/
                                loaiXe.CapNhatSoLieu();
                                //CHUA LAM 

                                //HIEN THI HOA DOn va Dien Gia Tien Vao Giu Xe
                                HoaDon hd = new HoaDon();
                                hd.loadData(maXe);
                                hd.Show();
                                this.textBoxMaXeRa.Text = "";
                                this.pictureBoxImg1XeRa.Image = null;
                                this.pictureBoxImg2XeRa.Image = null;
                                
                         
                        /*    }
                            else
                            {
                                MessageBox.Show("Error", "Xuat Ben", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }*/
                        }
                        else
                        {
                            MessageBox.Show("Xe Nay Hien Khong Co Trong Ben", "Xuat Ben", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nhap Sai Ma Xe", "Xuat Ben", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Chua Dien Day Du Thong Tin", "Xuat Ben", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
        /*    }
            catch
            {
                MessageBox.Show("Error", "Xuat Ben", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void textBoxMaXeRa_TextChanged(object sender, EventArgs e)
        {
            string maXe = this.textBoxMaXeRa.Text;
            if (xe.KiemTraMaXe(maXe))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Xe WHERE MaXe = '" + maXe + "'");
                DataTable table = xe.getXe(command);

                byte[] picImg1;
                picImg1 = (byte[])table.Rows[0][4];
                MemoryStream pictureImg1 = new MemoryStream(picImg1);
                this.pictureBoxImg1XeRa.Image = Image.FromStream(pictureImg1);

                byte[] picImg2;
                picImg2 = (byte[])table.Rows[0][5];
                MemoryStream pictureImg2 = new MemoryStream(picImg2);
                this.pictureBoxImg2XeRa.Image = Image.FromStream(pictureImg2);

                string loai = table.Rows[0][1].ToString().Trim();
                if (loai == "O to")
                {
                    this.labelImg1XeRa.Text = "Bang So";
                    this.labelImg2XeRa.Text = "Hieu Xe";
                }
                else if (loai == "Xe May")
                {
                    this.labelImg1XeRa.Text = "Bang So";
                    this.labelImg2XeRa.Text = "Nguoi Gui";
                }
                if (loai == "Xe Dap")
                {
                    this.labelImg1XeRa.Text = "Hinh Xe";
                    this.labelImg2XeRa.Text = "Nguoi Gui";
                }
            }
        }
    }
}
