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
    public partial class DangKiTaiKhoanChoKhachHang : Form
    {
        public DangKiTaiKhoanChoKhachHang()
        {
            InitializeComponent();
        }

        TaiKhoan tk = new TaiKhoan();
        KhachHang kh = new KhachHang();

        private void BtnDangKi_Click(object sender, EventArgs e)
        {
            if (verif())
            {

                string mkcu = TextBoxUser.Text;
                string mkmoi1 = TextBoxMatKhauMoi.Text;
                string mkmoi2 = TextBoxMatKhauMoi2.Text;
                if (!(tk.checkUserName(mkcu)))
                {
                    if (mkmoi1 == mkmoi2)
                    {
                        try
                        {
                            if (tk.TaoTaiKhoangKhachHang(mkcu, mkmoi1))
                            {
                           
                                MessageBox.Show("Đăng kí thành công", "Đăng Kí", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                SqlCommand command = new SqlCommand("SELECT * FROM Login WHERE username = '" + mkcu + "'");
                                DataTable table = kh.getKhachHang(command);
                                string maKH = table.Rows[0][3].ToString().Trim();
                                kh.insertKhachHangTaiKhoan(maKH);

                            }
                            else
                            {
                                MessageBox.Show("Loi!!!", "Đăng Kí", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Đăng Kí", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Xác nhận mật khẩu sai", "Đăng Kí", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại", "Đăng Kí", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Chua Dien Day Du Thong Tin", "Đăng Kí", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public bool verif()
        {
            if ((TextBoxUser.Text.Trim() == "")
                    || (TextBoxMatKhauMoi.Text.Trim() == "")
                    || (TextBoxMatKhauMoi2.Text.Trim() == ""))
            {
                return false;
            }
            else return true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBoxMatKhauMoi2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxMatKhauMoi_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxUser_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Logo_Click(object sender, EventArgs e)
        {

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

    
    }
}
