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
    public partial class QuanLyXe : Form
    {
        public QuanLyXe()
        {
            InitializeComponent();   
        }

        Xe xe = new Xe();
        VeXe ve = new VeXe();
        Giuxe giuXe = new Giuxe();
        LoaiXe loaiXe = new LoaiXe();

        private int flag = 1;

        public void loadData(SqlCommand command)
        {
            DataGridViewImageColumn picolImg1 = new DataGridViewImageColumn();

            this.dataGridViewListXe.RowTemplate.Height = 80;
            this.dataGridViewListXe.DataSource = xe.getXe(command);
            picolImg1 = (DataGridViewImageColumn)this.dataGridViewListXe.Columns[4];
            picolImg1.ImageLayout = DataGridViewImageCellLayout.Zoom;

            DataGridViewImageColumn picolImg2 = new DataGridViewImageColumn();
            picolImg2 = (DataGridViewImageColumn)this.dataGridViewListXe.Columns[5];
            picolImg2.ImageLayout = DataGridViewImageCellLayout.Zoom;

            this.dataGridViewListXe.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            this.dataGridViewListXe.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            this.dataGridViewListXe.ReadOnly = true;
            this.dataGridViewListXe.AllowUserToAddRows = false;

            this.dataGridViewListXe.DataSource = xe.getXe(command);
        }

        public void showData(int flag)
        {
            SqlCommand command = null;
            if (flag == 1) // show DS Xe Da Vao Ben
            {
                command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe");
            }
            else if (flag == 2) // show DS Xe hien tai
            {
                command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE  MaXe  not in (SELECT MaXe FROM HopDong WHERE LoaiHD = 'Cho Thuê'  and NgayThuHoi > @time)   and NgayXuatBen is null");
                command.Parameters.Add("@time", SqlDbType.DateTime).Value = DateTime.Now;
            }
            else if (flag == 3) // show DS GiuXe
            {
                command = new SqlCommand("SELECT Xe.MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', Xe.NgayVaoBen as 'Ngày Vào Bến', Xe.NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2', MaVe as 'Mã Vé' FROM Xe, GiuXe WHERE Xe.MaXe = GiuXe.MaXe");
            }
            else if (flag == 4) // show DS Sua Xe
            {
                command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE MaXe in (SELECT distinct MaXe FROM BaoHanh)");
            }
            else if (flag == 5) // show DS cty thue
            {
                command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE MaXe in (SELECT distinct MaXe FROM XeChoThue)");
            }
            else
            {
                command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE MaXe in (SELECT distinct MaXe From XeChoThue WHERE TinhTrang = @flag)" );
                command.Parameters.Add("@flag", SqlDbType.Int).Value = 1;
            }    

            this.loadData(command);
        }


        private void QuanLyXe_Load(object sender, EventArgs e)
        {
            ThemeColor.LoadColos(this, false);
            NgayVaoBen.BackColor = ThemeColor.PrimaryColor;
            LableLoaiXe.BackColor = ThemeColor.SecondaryColor;

            this.showData(1);
            SqlCommand commandLoai = new SqlCommand("SELECT * FROM LoaiXe");
            this.comboBoxLoaiXe.DataSource = loaiXe.getLoaiXe(commandLoai);
            this.comboBoxLoaiXe.DisplayMember = "LoaiXe";
            this.comboBoxLoaiXe.ValueMember = "LoaiXe";
        }

        private void buttonDSHienTai_Click(object sender, EventArgs e)
        {
            this.flag = 2;
            this.showData(2);
        }

        private void buttonDSGiu_Click(object sender, EventArgs e)
        {
            this.flag = 3;
            this.showData(3);
        }

        private void buttonDSChamSoc_Click(object sender, EventArgs e)
        {
            this.flag = 4;
            this.showData(4);
        }

        private void buttonHopDong_Click(object sender, EventArgs e)
        {
            this.flag = 5;
            this.showData(5);
        }

        private void buttonDsDaVaoBen_Click(object sender, EventArgs e)
        {
            this.flag = 1;
            this.showData(1);

        }

        bool verif()
        {
            if (this.comboBoxLoaiXe.SelectedValue == null)
                return false;
            else
            {
                if ((this.textBoxMaXe.Text.Trim() == "")
                        || (this.pictureBoxImg1.Image == null)
                        || (this.pictureBoxImg2.Image == null))
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

                    string maXe = this.textBoxMaXe.Text;
                    string loaiXe = this.comboBoxLoaiXe.SelectedValue.ToString();
                    MemoryStream img1 = new MemoryStream();
                    this.pictureBoxImg1.Image.Save(img1, this.pictureBoxImg1.Image.RawFormat);
                    MemoryStream img2 = new MemoryStream();
                    this.pictureBoxImg2.Image.Save(img2, this.pictureBoxImg2.Image.RawFormat);
                    DateTime ngayVao = this.dateTimePickerNgayVao.Value;

                    if (!xe.KiemTraMaXe(maXe))
                    {
                        if (xe.ThemXe(maXe, loaiXe, ngayVao, img1, img2))
                        {
                            this.showData(1);
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
                    MessageBox.Show("Chua Dien Day Du Thong Tin!!!", "Vao Ben", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Loi", "Vao Ben", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLoadImg1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image (*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                this.pictureBoxImg1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonLoadImg2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image (*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                this.pictureBoxImg2.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (verif())
            {

                string maXe = this.textBoxMaXe.Text;
                string loaiXe = this.comboBoxLoaiXe.SelectedValue.ToString();
                MemoryStream img1 = new MemoryStream();
                this.pictureBoxImg1.Image.Save(img1, this.pictureBoxImg1.Image.RawFormat);
                MemoryStream img2 = new MemoryStream();
                this.pictureBoxImg2.Image.Save(img2, this.pictureBoxImg2.Image.RawFormat);
                DateTime ngayVao = this.dateTimePickerNgayVao.Value;
                try
                {
                    if (xe.CapNhatXe(maXe, loaiXe, ngayVao, img1, img2))
                    {
                        this.showData(1);
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
                string maXe = this.textBoxMaXe.Text;
                if (MessageBox.Show("Ban Chan Chac Muon Xoa Xe Nay ", "Xoa Xe", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (xe.XoaXe(maXe))
                    {

                        SqlCommand command = new SqlCommand("SELECT * FROM GiuXe WHERE MaXe = '" + maXe + "'");
                        DataTable table = giuXe.getGiuXe(command);
                        if (table.Rows.Count > 0)
                        {
                            giuXe.XoaGiuXeBangMaXe(maXe);
                        }
                        this.showData(1);

                        MessageBox.Show("Xoa Thanh Cong", "Xoa Xe", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.textBoxMaXe.Text = "";
                        this.dateTimePickerNgayVao.Value = DateTime.Now;
                        this.pictureBoxImg2.Image = null;
                        this.pictureBoxImg1.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("Ban Da Huy Xoa", "Xoa Xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Vui Long Nhap Ma Xe", "Xoa Xe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewListXe_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewListXe.Rows.Count > 0)
            {
                string maXe = this.dataGridViewListXe.CurrentRow.Cells[0].Value.ToString();
                string loai = this.dataGridViewListXe.CurrentRow.Cells[1].Value.ToString().Trim();

                if (loai == "Xe May")
                {
                    this.labelImg1.Text = "Bang So";
                    this.labelImg2.Text = "Nguoi Gui";
                }
                else if (loai == "Xe Dap")
                {
                    this.labelImg1.Text = "Hinh Xe";
                    this.labelImg2.Text = "Nguoi Gui";
                }
                else
                {
                    this.labelImg1.Text = "Bang So";
                    this.labelImg2.Text = "Hieu Xe";
                }


                this.textBoxMaXe.Text = maXe;
                this.comboBoxLoaiXe.SelectedValue = this.dataGridViewListXe.CurrentRow.Cells[1].Value.ToString();
                this.dateTimePickerNgayVao.Value = (DateTime)this.dataGridViewListXe.CurrentRow.Cells[2].Value;


                byte[] pic1;
                pic1 = (byte[])this.dataGridViewListXe.CurrentRow.Cells[4].Value;
                MemoryStream picture1 = new MemoryStream(pic1);
                this.pictureBoxImg1.Image = Image.FromStream(picture1);


                byte[] pic2;
                pic2 = (byte[])this.dataGridViewListXe.CurrentRow.Cells[5].Value;
                MemoryStream picture2 = new MemoryStream(pic2);
                this.pictureBoxImg2.Image = Image.FromStream(picture2);
            }
        }

        private void dataGridViewListXe_DoubleClick(object sender, EventArgs e)
        {
            if (this.dataGridViewListXe.Rows.Count > 0)
            {
                string maXe = this.dataGridViewListXe.CurrentRow.Cells[0].Value.ToString();

                if (this.flag == 3)
                {
                    string maVe = this.dataGridViewListXe.CurrentRow.Cells[6].Value.ToString();

                    GuiXe giu = new GuiXe();
                    giu.HienThi(maXe, maVe);
                    giu.ShowDialog();
                }

                else if (this.flag == 4)
                {
                    ChiTietBaoHanhXe ct = new ChiTietBaoHanhXe();
                    ct.HienThi(maXe);
                    ct.ShowDialog();
                }

                else if (this.flag == 6)
                {
                    UpdateTinhTrangXeForm up = new UpdateTinhTrangXeForm();
                    up.hienthi(maXe);
                    up.ShowDialog();
                }
                else
                {

                }
            }
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {

            string key = this.TextBoxTimKiem.Text;
            if (key != "")
            {
                if (this.LoaiThongTin.SelectedItem != null)
                {
                    if (this.LoaiThongTin.SelectedItem.ToString().Trim() == "Mã Xe")
                    {
                        SqlCommand command = null;
                        if (flag == 1) // show DS Xe Da Vao Ben
                        {
                            command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE MaXe = '" + key + "'");
                        }
                        else if (flag == 2) // show DS Xe hien tai
                        {
                            command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE NgayXuatBen is NULL and MaXe = '" + key + "'");
                        }
                        else if (flag == 3) // show DS GiuXe
                        {
                            command = new SqlCommand("SELECT Xe.MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', Xe.NgayVaoBen as 'Ngày Vào Bến', Xe.NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2', MaVe as 'Mã Vé' FROM Xe, GiuXe WHERE Xe.MaXe = GiuXe.MaXe and Xe.MaXe = '" + key + "'");
                        }
                        else if (flag == 4) // show DS Sua Xe
                        {
                            command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE MaXe in (SELECT distinct MaXe FROM BaoHanh) and MaXe = '" + key + "'");
                        }
                        else if (flag == 5) //se thue
                        {
                            command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE MaXe in (SELECT distinct MaXe FROM XeChoThue) and MaXe = '" + key + "'");
                        }
                        else // show DS Xe Co HOp DOng
                        {
                            command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE MaXe in (SELECT distinct MaXe From XeChoThue WHERE TinhTrang = @flag) and MaXe = '" + key + "'");
                            command.Parameters.Add("@flag", SqlDbType.Int).Value = 1;
                        }

                        this.loadData(command);
                    }
                    else if (this.LoaiThongTin.SelectedItem.ToString().Trim() == "Loại Xe")
                    {
                        SqlCommand command = null;
                        if (flag == 1) // show DS Xe Da Vao Ben
                        {
                            command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE LoaiXe = '" + key + "'");
                        }
                        else if (flag == 2) // show DS Xe hien tai
                        {
                            command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE NgayXuatBen is NULL and LoaiXe = '" + key + "'");
                        }
                        else if (flag == 3) // show DS GiuXe
                        {
                            command = new SqlCommand("SELECT Xe.MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', Xe.NgayVaoBen as 'Ngày Vào Bến', Xe.NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2', MaVe as 'Mã Vé' FROM Xe, GiuXe WHERE Xe.MaXe = GiuXe.MaXe and LoaiXe = '" + key + "'");
                        }
                        else if (flag == 4) // show DS Sua Xe
                        {
                            command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE MaXe in (SELECT distinct MaXe FROM BaoHanh) and LoaiXe = '" + key + "'");
                        }
                        else if (flag ==5 )// xe thue
                        {
                            command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE MaXe in (SELECT distinct MaXe FROM XeChoThue)  and LoaiXe = '" + key + "'");
                        }
                        else // show DS Xe Co HOp DOng
                        {
                            command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE MaXe in (SELECT distinct MaXe From XeChoThue WHERE TinhTrang = @flag) and LoaiXe = '" + key + "'");
                            command.Parameters.Add("@flag", SqlDbType.Int).Value = 1;
                        }

                        this.loadData(command);
                    }
                    else if (this.LoaiThongTin.SelectedItem.ToString().Trim() == "Ngày Vào Bến")
                    {
                        SqlCommand command = null;
                        if (flag == 1) // show DS Xe Da Vao Ben
                        {
                            command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE NgayVaoBen Like '%" + key + "%'");
                        }
                        else if (flag == 2) // show DS Xe hien tai
                        {
                            command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE NgayXuatBen is NULL and NgayVaoBen Like '%" + key + "%'");
                        }
                        else if (flag == 3) // show DS GiuXe
                        {
                            command = new SqlCommand("SELECT Xe.MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', Xe.NgayVaoBen as 'Ngày Vào Bến', Xe.NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2', MaVe as 'Mã Vé' FROM Xe, GiuXe WHERE Xe.MaXe = GiuXe.MaXe and Xe.NgayVaoBen Like '%" + key + "%'");
                        }
                        else if (flag == 4) // show DS Sua Xe
                        {
                            command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE MaXe in (SELECT distinct MaXe FROM BaoHanh) and NgayVaoBen Like '%" + key + "%'");
                        }
                        else if (flag == 5)// xe thue
                        {
                            command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE MaXe in (SELECT distinct MaXe FROM XeChoThue)  and NgayVaoBen Like '%" + key + "%'");
                        }
                        else // show DS Xe Co HOp DOng
                        {
                            command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE MaXe in (SELECT distinct MaXe From XeChoThue WHERE TinhTrang = @flag) NgayVaoBen Like '%" + key + "%'");
                            command.Parameters.Add("@flag", SqlDbType.Int).Value = 1;
                        }

                        this.loadData(command);

                    }
                    else if (this.LoaiThongTin.SelectedItem.ToString().Trim() == "Ngày Xuất Bến")
                    {
                        SqlCommand command = null;
                        if (flag == 1) // show DS Xe Da Vao Ben
                        {
                            command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE NgayXuatBen Like '%" + key + "%'");
                        }
                        else if (flag == 2) // show DS Xe hien tai
                        {
                            command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE NgayXuatBen = NULL and NgayXuatBen Like '%" + key + "%'");
                        }
                        else if (flag == 3) // show DS GiuXe
                        {
                            command = new SqlCommand("SELECT Xe.MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', Xe.NgayVaoBen as 'Ngày Vào Bến', Xe.NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2', MaVe as 'Mã Vé' FROM Xe, GiuXe WHERE Xe.MaXe = GiuXe.MaXe and NgayXuatBen Like '%" + key + "%'");
                        }
                        else if (flag == 4) // show DS Sua Xe
                        {
                            command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE MaXe in (SELECT distinct MaXe FROM BaoHanh) and NgayXuatBen Like '%" + key + "%'");
                        }
                        else if (flag == 5)// xe thue
                        {
                            command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE MaXe in (SELECT distinct MaXe FROM XeChoThue) and NgayXuatBen Like '%" + key + "%'");
                        }
                        else // show DS Xe Co HOp DOng
                        {
                            command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', NgayVaoBen as 'Ngày Vào Bến', NgayXuatBen as 'Ngày Xuất Bến', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE MaXe in (SELECT distinct MaXe From XeChoThue WHERE TinhTrang = @flag) and and NgayXuatBen Like '%" + key + "%'");
                            command.Parameters.Add("@flag", SqlDbType.Int).Value = 1;
                        }

                        this.loadData(command);
                    }
                    else
                    {
                        MessageBox.Show("Chua Chon Loai Tim Kiem!!!", "Tim Kiem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
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

        private void BtnDSThue_Click(object sender, EventArgs e)
        {
            this.flag = 6;
            this.showData(6);
        }
    }
}
