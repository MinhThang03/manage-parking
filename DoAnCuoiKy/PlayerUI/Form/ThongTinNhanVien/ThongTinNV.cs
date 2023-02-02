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
    public partial class ThongTinNV : Form
    {
        public ThongTinNV()
        {
            InitializeComponent();
        }

        private void ThongTinNV_Load(object sender, EventArgs e)
        {
            TextBoxDiaChi.Size = new Size(300, 149);
            ThemeColor.LoadColos(this,false);
           NgaySinh.BackColor = ThemeColor.PrimaryColor;

            this.hienThi();
        }

        NhanVien nv = new NhanVien();
        public void hienThi()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM NhanVien Where Id = '" + Global.GlobalUserId +"'");
            DataTable table = nv.getNhanVien(command);
            if (table.Rows.Count > 0)
            {
                this.TextBoxMaNV.Text = table.Rows[0][0].ToString().Trim();
                this.TextBoxTenNV.Text = table.Rows[0][1].ToString().Trim();
                if (TextBoxTenNV.Text.Trim() != "")
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
                    this.TextBoxMaBoPhan.Text = table.Rows[0][8].ToString();

                    byte[] pic;
                    pic = (byte[])table.Rows[0][7];
                    MemoryStream picture = new MemoryStream(pic);
                    this.Avatar.Image = Image.FromStream(picture);
                }
            }
        }

        ChuyenMon bp = new ChuyenMon();

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (verif())
            {
                string maNV = this.TextBoxMaNV.Text.Trim();
                string cmnd = this.bunifuTextBoxCMND.Text.Trim();
                string tenNV = this.TextBoxTenNV.Text.Trim();
                string maBP = this.TextBoxMaBoPhan.Text.Trim();
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

                if ((this_year - born_year) < 18 || (this_year - born_year) > 100)
                {
                    MessageBox.Show("Nhân viên chưa đủ 18 tuổi, hoặc số tuổi không hợp lệ", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    if (bp.KiemTraBoPhan(maBP))
                    {
                        try
                        {

                            Avatar.Image.Save(pic, Avatar.Image.RawFormat);
                            if (nv.updateNhanVien(maNV, tenNV, cmnd, bdate, gender, sdt, diaChi, pic, maBP))
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
                    else
                    {
                        MessageBox.Show("Mã bộ phận không tồn tại", "Chỉnh sửa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
            else
            {
                MessageBox.Show("Chưa điền đầy đủ thông tin", "Chỉnh sửa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public bool verif()
        {
            if ((TextBoxMaNV.Text.Trim() == "")
                    || (TextBoxDiaChi.Text.Trim() == "")
                    || (TextBoxMaBoPhan.Text.Trim() == "")
                    || (TextBoxSoDienThoai.Text.Trim() == "")
                    || (Avatar.Image == null)
                    || (bunifuTextBoxCMND.Text.Trim() == "")
                    || (TextBoxTenNV.Text.Trim() == "")
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
    }

    
}
