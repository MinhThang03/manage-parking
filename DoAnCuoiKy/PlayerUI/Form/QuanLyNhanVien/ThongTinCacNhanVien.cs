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
    public partial class ThongTinCacNhanVien : Form
    {
        public ThongTinCacNhanVien()
        {
            InitializeComponent();
        }

        private void ThongTinCacNhanVien_Load(object sender, EventArgs e)
        {
            ThemeColor.LoadColos(this,false);
            NgaySinh.BackColor = ThemeColor.PrimaryColor;

            SqlCommand command = new SqlCommand("SELECT Id as 'Mã Nhân Viên', TenNV as 'Tên Nhân Viên', CMND as 'CMND', NgaySinhNV as 'Ngày Sinh', GioiTinhNV as 'Giới Tính', DiaChiNV as 'Địa Chỉ', SDTNV as 'Số Điện Thoại', HinhNV as 'Hình Ảnh', MaBP as 'Mã Bộ Phận' FROM NhanVien");
            this.loadDataGridView(command);
        }

        NhanVien nv = new NhanVien();
        ChuyenMon bp = new ChuyenMon();

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

        private void BtnThem_Click(object sender, EventArgs e)
        {
         /*   try
            {*/
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
                    
                    if (nv.checkStaffId(maNV))
                    {
                        if (bp.KiemTraBoPhan(maBP))
                        {
                            if (((this_year - born_year) < 18) || ((this_year - born_year) > 100))
                            {
                                MessageBox.Show("Nhân viên chưa đủ 18 tuổi, hoặc số tuổi không hợp lệ", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                Avatar.Image.Save(pic, Avatar.Image.RawFormat);
                                if (nv.insertNhanVien(maNV, tenNV, cmnd, bdate, gender, sdt, diaChi, pic, maBP))
                                {
                                    MessageBox.Show("Thêm nhân viên thành công", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Lỗi", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mã bộ phận không tồn tại", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Chưa điền đầy đủ thông tin", "Add student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
          /*  }
            catch
            {
                MessageBox.Show("Loi", "Them nhan vien", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }*/
        }

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
                        MessageBox.Show("Mã bộ phân không tồn tại", "Chỉnh sửa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
               
            }
            else
            {
                MessageBox.Show("Chưa điền đầy đủ thông tin", "Chỉnh sửa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = this.TextBoxMaNV.Text.Trim();
                if (MessageBox.Show("Bạn chắc chắn muốn xóa nhân viên này ", "Xóa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (nv.deleteNhanVien(maNV))
                    {
                        MessageBox.Show("Xóa thành công", "Xóa nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.TextBoxMaNV.Text = "";
                        this.bunifuTextBoxCMND.Text = "";
                        this.TextBoxTenNV.Text = "";
                        this.TextBoxMaBoPhan.Text = "";
                        this.TextBoxDiaChi.Text = "";
                        this.TextBoxSoDienThoai.Text = "";
                        this.DatepickerNgaySinh.Value = DateTime.Now;
                        Avatar.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa", "Xóa nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Mã nhân viên không tồn tại", "Xóa Nhân Viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void loadDataGridView(SqlCommand command)
        {
            this.dataGridViewNV.ReadOnly = true;
            this.dataGridViewNV.AllowUserToAddRows = false;
            this.dataGridViewNV.DataSource = nv.getNhanVien(command);


            DataGridViewImageColumn picol = new DataGridViewImageColumn();

            this.dataGridViewNV.RowTemplate.Height = 80;
            this.dataGridViewNV.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            picol = (DataGridViewImageColumn)dataGridViewNV.Columns[7];
            picol.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void dataGridViewNV_Click(object sender, EventArgs e)
        {
            this.HienThiText();
        }

        public void HienThiText()
        {
            try
            {
                this.TextBoxMaNV.Text = dataGridViewNV.CurrentRow.Cells[0].Value.ToString();
                this.TextBoxTenNV.Text = dataGridViewNV.CurrentRow.Cells[1].Value.ToString();
                this.bunifuTextBoxCMND.Text = dataGridViewNV.CurrentRow.Cells[2].Value.ToString();
                this.DatepickerNgaySinh.Value = (DateTime)dataGridViewNV.CurrentRow.Cells[3].Value;

                if (dataGridViewNV.CurrentRow.Cells[4].Value.ToString().Trim() == "Female")
                {
                    this.BtnRadioNu.Checked = true;
                }
                else
                {
                    this.BtnRadioNam.Checked = true;
                }

                this.TextBoxDiaChi.Text = dataGridViewNV.CurrentRow.Cells[5].Value.ToString();
                this.TextBoxSoDienThoai.Text = dataGridViewNV.CurrentRow.Cells[6].Value.ToString();

                byte[] pic;
                pic = (byte[])dataGridViewNV.CurrentRow.Cells[7].Value;
                MemoryStream picture = new MemoryStream(pic);
                this.Avatar.Image = Image.FromStream(picture);

                this.TextBoxMaBoPhan.Text = dataGridViewNV.CurrentRow.Cells[8].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Loi");
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT Id as 'Mã Nhân Viên', TenNV as 'Tên Nhân Viên', CMND as 'CMND', NgaySinhNV as 'Ngày Sinh', GioiTinhNV as 'Giới Tính', DiaChiNV as 'Địa Chỉ', SDTNV as 'Số Điện Thoại', HinhNV as 'Hình Ảnh', MaBP as 'Mã Bộ Phận' FROM NhanVien");
            this.loadDataGridView(command);
        }

        private void bunifuTextBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            string key = this.bunifuTextBoxTimKiem.Text.Trim();
            if (key == "")
            {
                SqlCommand command = new SqlCommand("SELECT Id as 'Mã Nhân Viên', TenNV as 'Tên Nhân Viên', CMND as 'CMND', NgaySinhNV as 'Ngày Sinh', GioiTinhNV as 'Giới Tính', DiaChiNV as 'Địa Chỉ', SDTNV as 'Số Điện Thoại', HinhNV as 'Hình Ảnh', MaBP as 'Mã Bộ Phận' FROM NhanVien");
                this.loadDataGridView(command);
            }
            else
            {
                SqlCommand command = new SqlCommand("SELECT Id as 'Mã Nhân Viên', TenNV as 'Tên Nhân Viên', CMND as 'CMND', NgaySinhNV as 'Ngày Sinh', GioiTinhNV as 'Giới Tính', DiaChiNV as 'Địa Chỉ', SDTNV as 'Số Điện Thoại', HinhNV as 'Hình Ảnh', MaBP as 'Mã Bộ Phận' FROM NhanVien WHERE CONCAT(Id, TenNV, DiaChiNV) Like '%" + key + "%'");
                this.loadDataGridView(command);
            }

        }
    }

}
