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
    public partial class ThongTinKhachHang : Form
    {
        public ThongTinKhachHang()
        {
            InitializeComponent();
        }

        private void ThongTinKhachHang_Load(object sender, EventArgs e)
        {
            ThemeColor.LoadColos(this,false);
            LabelNgaySinh.BackColor = ThemeColor.SecondaryColor;

            this.hienThi();
        }

        KhachHang kh = new KhachHang();
        public void hienThi()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM KhachHang Where MaKH = '" + Global.GlobalUserId + "'");
            DataTable table = kh.getKhachHang(command);
            if (table.Rows.Count > 0)
            {
                this.TextBoxMaKhachHang.Text = table.Rows[0][0].ToString().Trim();
                this.TextBoxTenKhachHang.Text = table.Rows[0][1].ToString().Trim();
                if (TextBoxTenKhachHang.Text.Trim() != "")
                {
                    this.bunifuTextBoxCMND.Text = table.Rows[0][2].ToString();
                    this.DatepickerNgaySinh.Value = (DateTime)table.Rows[0][3];

                    if (table.Rows[0][4].ToString().Trim() == "Female")
                    {
                        this.BtnRadioNu.Checked = true;
                    }
                    else
                    {
                        this.BtnRadioNam.Checked = true;
                    }

                    this.TextBoxDiaChi.Text = table.Rows[0][5].ToString();
                    this.TextBoxSoDienThoai.Text = table.Rows[0][6].ToString();
                    this.TextBoxEmail.Text = table.Rows[0][8].ToString();

                    byte[] pic;
                    pic = (byte[])table.Rows[0][7];
                    MemoryStream picture = new MemoryStream(pic);
                    this.Avatar.Image = Image.FromStream(picture);
                }
            }
        }

        public bool verif()
        {
            if ((TextBoxMaKhachHang.Text.Trim() == "")
                    || (TextBoxDiaChi.Text.Trim() == "")
                    || (TextBoxTenKhachHang.Text.Trim() == "")
                    || (TextBoxSoDienThoai.Text.Trim() == "")
                    || (Avatar.Image == null)
                    || (bunifuTextBoxCMND.Text.Trim() == "")
                    || (TextBoxEmail.Text.Trim() == "")
                    || (DatepickerNgaySinh.Value == null))
            {
                return false;
            }
            else return true;
        }

        private void BtnTaiAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image (*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                Avatar.Image = Image.FromFile(opf.FileName);
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (verif())
            {
                string maNV = this.TextBoxMaKhachHang.Text.Trim();
                string cmnd = this.bunifuTextBoxCMND.Text.Trim();
                string tenNV = this.TextBoxTenKhachHang.Text.Trim();
                string maBP = this.TextBoxEmail.Text.Trim();
                string diaChi = this.TextBoxDiaChi.Text.Trim();
                string sdt = this.TextBoxSoDienThoai.Text.Trim();
                DateTime bdate = this.DatepickerNgaySinh.Value;
                string gender = "Male";

                if (BtnRadioNu.Checked)
                {
                    gender = "Female";
                }

                MemoryStream pic = new MemoryStream();
                int born_year = DatepickerNgaySinh.Value.Year;
                int this_year = DateTime.Now.Year;

                if ((this_year - born_year) <= 0 || (this_year - born_year) > 100)
                {
                    MessageBox.Show("Số tuổi không hợp lệ", "Chỉnh sửa", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                 
                        try
                        {

                            Avatar.Image.Save(pic, Avatar.Image.RawFormat);
                            if (kh.updateKhachHang(maNV, tenNV, cmnd, bdate, gender, diaChi, sdt, pic, maBP))
                            {
                                MessageBox.Show("Cập nhật thông tin thành công", "Chỉnh sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Lỗi", "Chỉnh sửa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Chỉnh sửa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                }

            }
            else
            {
                MessageBox.Show("Chưa điền đầy đủ thông tin", "Chỉnh sửa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
