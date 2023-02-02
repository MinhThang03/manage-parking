using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class QuanLiTaiKhoanForm : Form
    {
        public QuanLiTaiKhoanForm()
        {
            InitializeComponent();
        }

        TaiKhoan tk = new TaiKhoan();
        NhanVien nv = new NhanVien();
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

        private void BtnDangKi_Click(object sender, EventArgs e)
        {
            if (verif())
            {
                string ma = textBoxMaNV.Text;
                string mkcu = TextBoxUser.Text;
                string mkmoi1 = TextBoxMatKhauMoi.Text;
                string mkmoi2 = TextBoxMatKhauMoi2.Text;
                if (!(tk.checkUserName(mkcu)))
                {
                    int flag = tk.checkTaiKhoanNhanVien(mkcu);
                    if (flag == -1)
                    {
                        if (mkmoi1 == mkmoi2)
                        {
                            try
                            {
                                if (tk.ThemTaiKhoan(mkcu, mkmoi1, ma, "Nhân viên"))
                                {
                                    nv.insertNhanVienTaiKhoan(ma);
                                    MessageBox.Show("Đăng kí thành công", "Đăng Kí", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        MessageBox.Show("Nhân viên đã có tài khoản", "Đăng Kí", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = this.textBoxMaNV.Text;
                if (MessageBox.Show("Ban Chan Chac Muon Xoa Tai Khoan Nay ", "Xoa Tai Khoan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int flag = tk.checkTaiKhoanNhanVien(maNV);
                    if (flag != -1)
                    {
                        if (tk.XoaTaiKhoan(flag))
                        {

                            MessageBox.Show("Xoa Thanh Cong", "Xoa Tai Khoan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Khong Thanh Cong", "Xoa Tai Khoan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tài khoảng không tồn tại", "Xoa Tai Khoan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ban Da Huy Xoa", "Xoa Tai Khoan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                MessageBox.Show("Vui Long Nhap Ma Tai Khoan", "Xoa Tai Khoan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
    
}
