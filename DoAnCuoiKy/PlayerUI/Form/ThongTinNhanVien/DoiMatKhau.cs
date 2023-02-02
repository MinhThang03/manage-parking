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
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
            ThemeColor.LoadColos(this);
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            
        }

        public bool verif()
        {
            if ((TextBoxMaKhauCu.Text.Trim() == "")
                    || (TextBoxMatKhauMoi.Text.Trim() == "")
                    || (TextBoxMatKhauMoi2.Text.Trim() == ""))
            {
                return false;
            }
            else return true;
        }

        TaiKhoan tk = new TaiKhoan();

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (verif())
            {

                string mkcu = TextBoxMaKhauCu.Text;
                string mkmoi1 = TextBoxMatKhauMoi.Text;
                string mkmoi2 = TextBoxMatKhauMoi2.Text;
                if (tk.checkMatKhau(Global.GlobalId, mkcu))
                    {
                    if (mkmoi1 == mkmoi2)
                    {
                        try
                        {
                            if (tk.DoiMatKhau(Global.GlobalId,mkmoi1))
                            {
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
                        MessageBox.Show("Xác nhận mật khẩu sai", "Chinh Sua", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu không đúng", "Chinh Sua", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Chua Dien Day Du Thong Tin", "Chinh Sua", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
