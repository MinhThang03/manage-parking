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
    public partial class DatXeForm : Form
    {
        public DatXeForm()
        {
            InitializeComponent();
        }

        private void DatXeForm_Load(object sender, EventArgs e)
        {
            ThemeColor.LoadColos(this,false);
            labelTienCoc.BackColor = ThemeColor.SecondaryColor;
            labelngayGiaoXe.BackColor = ThemeColor.SecondaryColor;
            labelNgayThuHoi.BackColor = ThemeColor.SecondaryColor;
            this.TextBoxMaKH.Text = Global.GlobalUserId;
        }

        HopDong hd = new HopDong();
        Xe xe = new Xe();
        XeChoThue chothue = new XeChoThue();
        public bool verif()
        {
            if (this.TextBoxMaHD.Text.Trim() == ""
                || this.TextBoxMaKH.Text.Trim() == ""
                || this.TextBoxGhiChu.Text.Trim() == ""
                || this.TextBoxMaXe.Text.Trim() == "")
                return false;
            else
            {
                return true;
            }
        }

      

        int flag = 0;
        
        private void TextBoxMaXe_TextChanged(object sender, EventArgs e)
        {
            string key = this.TextBoxMaXe.Text;
            SqlCommand command = new SqlCommand("SELECT Gia FROM Xe, LoaiXe WHERE Xe.LoaiXe = LoaiXe.LoaiXe and MaXe = '" + key + "'");
            DataTable table = xe.getXe(command);
            if (table.Rows.Count > 0)
                this.bunifuTextBoxTriGia.Text = (Convert.ToInt32(table.Rows[0][0]) * 5).ToString();


        }

        private void buttonChonXe_Click(object sender, EventArgs e)
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

        private void BtnThem_Click(object sender, EventArgs e)
        {
            //--------CHUA LAM KIEM TRA MA XE, KIEM TRA MA NV --------------------------------------------------
         /*   try
            {*/
                if (this.verif())
                {

                    string maHD = this.TextBoxMaHD.Text;
                    string maKH = this.TextBoxMaKH.Text;
                    string ghi = this.TextBoxGhiChu.Text;
                    string maXe = this.TextBoxMaXe.Text;
                    int gia = Convert.ToInt32(this.bunifuTextBoxTriGia.Text);
                    DateTime ngayVao = this.DatepickerNgayVao.Value;
                    DateTime ngayThu = this.DatepickerThu.Value;
                    if (!hd.KiemTraHopDong(maHD))
                    {
                    if (xe.KiemTraMaXeConTrongBen(maXe))
                    {

                        int compare = DateTime.Compare(DateTime.Now, ngayVao);
                        if (compare <= 0)
                        {
                            compare = DateTime.Compare(ngayVao, ngayThu);
                            if (compare <= 0)
                            {
                                if (hd.DatXe(maHD, maXe, maKH, gia, ngayVao, ngayThu, ghi))
                                {
                                    MessageBox.Show("Đặt xe thành công", "Them Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Loi!!!", "Them Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ngay thu hoi khong the sau ngay giao xe", "Them Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Loi ngay dat xe", "Them Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hien Tai Xe Khong Co Trong Ben", "Them Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    }
                    else
                    {
                        MessageBox.Show("Ma Hop Dong Da Ton Tai", "Them Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Chua Dien Day Du Thong Tin!!!", "Them Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
     /*       }
            catch
            {
                MessageBox.Show("Loi", "Them Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }
    }
}
