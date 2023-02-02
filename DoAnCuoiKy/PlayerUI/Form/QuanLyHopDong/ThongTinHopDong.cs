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
    public partial class ThongTinHopDong : Form
    {
        public ThongTinHopDong()
        {
            InitializeComponent();
        }

        int coKH = 0;
        public ThongTinHopDong(string MaHopDong)
        {
            InitializeComponent();
            this.HienThi(MaHopDong);
        }

        
        private void ThongTinHopDong_Load(object sender, EventArgs e)
        {
            ThemeColor.LoadColos(this,false);
            labelLoaiHopDong.BackColor = ThemeColor.SecondaryColor;
            labelngayGiaoXe.BackColor = ThemeColor.SecondaryColor;
            labelNgayKy.BackColor = ThemeColor.SecondaryColor;
            labelNgayThuHoi.BackColor = ThemeColor.SecondaryColor;

            this.TextBoxMaNV.Text = Global.GlobalUserId;
        
            
        }

        HopDong hd = new HopDong();
        Xe xe = new Xe();
        XeChoThue chothue = new XeChoThue();
        public bool verif()
        {
            if (this.TextBoxMaHD.Text.Trim() == ""
                || this.TextBoxMaKH.Text.Trim() == ""
                || this.TextBoxGhiChu.Text.Trim() == ""
                || this.TextBoxMaNV.Text.Trim() == ""
                || this.TextBoxMaXe.Text.Trim() ==""
                || this.TextBoxTriGiaHD.Text.Trim() == "")
                return false;
            else
            {
                return true;
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {

            //--------CHUA LAM KIEM TRA MA XE, KIEM TRA MA NV --------------------------------------------------
            try
            {
                if (this.verif())
                {

                    string maHD = this.TextBoxMaHD.Text;
                    string maKH = this.TextBoxMaKH.Text;
                    string ghi = this.TextBoxGhiChu.Text;
                    string maNV = this.TextBoxMaNV.Text;
                    string maXe = this.TextBoxMaXe.Text;
                    int gia = Convert.ToInt32(this.TextBoxTriGiaHD.Text);
                    string loai = this.comboBoxLoaiHD.SelectedItem.ToString();
                    DateTime ngayVao = this.DatepickerNgayVao.Value;
                    DateTime ngayThu = this.DatepickerThu.Value;
                    this.DatepickerNgayKy.Value = DateTime.Now;
                    DateTime ngayKi = this.DatepickerNgayKy.Value;
                    if (!hd.KiemTraHopDong(maHD))
                    {
                        if (xe.KiemTraMaXeConTrongBen(maXe))
                        {
                            int compare = DateTime.Compare(ngayKi, ngayVao);
                            if (compare <= 0)
                            {
                                compare = DateTime.Compare(ngayVao, ngayThu);
                                if (compare <= 0)
                                {
                                    if (hd.ThemHopDong(maHD, maXe, maKH, maNV, loai, gia, ngayKi, ngayVao, ngayThu, ghi))
                                    {
                                        if(loai == "Thuê" && !chothue.checkXeThue(maXe))
                                        { 
                                                chothue.insertXeThue(maXe);
                                        }    
                                        if(loai == "Cho Thuê" && chothue.checkXeThue(maXe))
                                        {
                                            chothue.updateTinhTrang(maXe, 1);
                                        }    
                                        MessageBox.Show("Them hop dong Thanh Cong", "Them Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Loi!!!", "Them Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ngay vao khong the sau ngay thu hoi xe", "Them Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ngay ki khong the sau ngay giao xe", "Them Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hien Tai Xe Khong Co Trong Ben", "Them Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ma Cong Viec Da Ton Tai", "Them Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Chua Dien Day Du Thong Tin!!!", "Them Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Loi", "Them Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


      

        private void BtnSua_Click(object sender, EventArgs e)
        {

            //--------------- CHUA LAM KT MA XE, KIEM TRA MA NV----------------------//
            if (verif())
            {

                string maHD = this.TextBoxMaHD.Text;
                string maKH = this.TextBoxMaKH.Text;
                string ghi = this.TextBoxGhiChu.Text;
                string maNV = this.TextBoxMaNV.Text;
                string maXe = this.TextBoxMaXe.Text;
                int gia = Convert.ToInt32(this.TextBoxTriGiaHD.Text);
                string loai = this.comboBoxLoaiHD.SelectedItem.ToString();
                DateTime ngayVao = this.DatepickerNgayVao.Value;
                DateTime ngayThu = this.DatepickerThu.Value;
                DateTime ngayKi = this.DatepickerNgayKy.Value;
                try
                {
                    if (hd.CapNhatHopDong(maHD, maXe, maKH, maNV, loai, gia, ngayKi, ngayVao, ngayThu, ghi))
                    {
                        if (coKH == 0)
                        {
                            chothue.updateTinhTrang(maXe, 1);
                        }
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
                string maHD = this.TextBoxMaHD.Text;
                if (MessageBox.Show("Ban Chan Chac Muon Xoa Ve Xe Nay ", "Xoa Hop Dong", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (hd.XoaHopDong(maHD))
                    {

                        MessageBox.Show("Xoa Thanh Cong", "Xoa Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.TextBoxMaHD.Text = "";
                        this.TextBoxMaKH.Text = "";
                        this.TextBoxGhiChu.Text = "";
                        this.TextBoxMaNV.Text = "";
                        this.TextBoxMaXe.Text = "";
                        this.TextBoxTriGiaHD.Text = "";
                        this.comboBoxLoaiHD.SelectedItem = null;
                     
                    }
                    else
                    {
                        MessageBox.Show("Khong Thanh Cong", "Xoa Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ban Da Huy Xoa", "Xoa Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                MessageBox.Show("Vui Long Nhap Ma Hop Dong", "Xoa Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void HienThi(string maHD)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM HopDong WHERE MaHD = '" + maHD + "'");
            DataTable table = hd.getHopDong(command);

            
            this.TextBoxMaHD.Text = table.Rows[0][0].ToString().Trim();
            this.TextBoxMaKH.Text = table.Rows[0][2].ToString().Trim();
            this.TextBoxGhiChu.Text = table.Rows[0][9].ToString().Trim();
            this.TextBoxMaNV.Text = table.Rows[0][3].ToString().Trim();
            this.TextBoxMaXe.Text = table.Rows[0][1].ToString().Trim();
            this.TextBoxTriGiaHD.Text = table.Rows[0][5].ToString().Trim();
            this.comboBoxLoaiHD.SelectedItem = table.Rows[0][4].ToString().Trim();
            if (this.TextBoxMaNV.Text != "")
            {
                this.DatepickerNgayKy.Value = (DateTime)table.Rows[0][6];
                this.coKH = 1;  // Dat Truc Tiep
            }
            coKH = 0;
            this.DatepickerNgayVao.Value = (DateTime)table.Rows[0][7];
            this.DatepickerThu.Value = (DateTime)table.Rows[0][8];


        }

        int flag = 0;
        private void buttonChonXe_Click(object sender, EventArgs e)
        {
            if(this.comboBoxLoaiHD.Text == "Thuê")
            {
                ChonXeForm chon = new ChonXeForm();
                chon.HienThi(0, DateTime.Now);
                chon.ShowDialog();
                try
                {
                    if (chon.dataGridViewChonXe.Rows.Count > 0)
                    {
                        string maXe = chon.dataGridViewChonXe.CurrentRow.Cells[0].Value.ToString();
                        this.TextBoxMaXe.Text = maXe;
                    }
                    else
                    {
                        MessageBox.Show("Hiện không có xe ");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi", "Chọn Xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }   
            else if (this.comboBoxLoaiHD.Text == "Cho Thuê")
            {
                if (flag == 0)
                {
                    MessageBox.Show("Bạn nên chọn ngày nhận xe trước để lọc được kết quả chính xác");
                    flag = 1;
                }

                DateTime time = this.DatepickerNgayVao.Value;
                ChonXeForm chon = new ChonXeForm();
                chon.HienThi(1, time);
                chon.ShowDialog();
                try
                {
                    if (chon.dataGridViewChonXe.Rows.Count > 0)
                    {
                        string maXe = chon.dataGridViewChonXe.CurrentRow.Cells[0].Value.ToString();
                        this.TextBoxMaXe.Text = maXe;
                    }
                    else
                    {
                        MessageBox.Show("Hiện không có xe ");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi", "Chọn Xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn loại hợp đồng", "Hợp dồng", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}
