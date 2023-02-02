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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
            SeePass(false);

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

    

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxTenNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelDangKyTaiKhoanKhach_Click(object sender, EventArgs e)
        {
            if (BtnRadioKhachHang.Checked == true)
            {
                DangKiTaiKhoanChoKhachHang x = new DangKiTaiKhoanChoKhachHang();
                x.Show();
            }
            else
            {
                MessageBox.Show("Chức năng này chỉ dành cho khách hàng", "Đăng kí tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        private void pictureBoxSeePassWord_Click(object sender, EventArgs e)
        {

            SeePass(true);
        }

        private void pictureBoxHidePassWord_Click(object sender, EventArgs e)
        {
            SeePass(false);
            
        }

        private void SeePass(bool x)
        {
            if(x)
            {
                this.TextBoxMatKhau.UseSystemPasswordChar = false;
                this.pictureBoxHidePassWord.Visible = true;
                this.pictureBoxSeePassWord.Visible = false;
            }
            else
            {
                this.TextBoxMatKhau.UseSystemPasswordChar = true;
                this.pictureBoxHidePassWord.Visible = false;
                this.pictureBoxSeePassWord.Visible = true;

            }
        }
        MY_DB db = new MY_DB();

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            if (this.BtnRadioKhachHang.Checked == true)
            {
                this.DangNhap("Khách Hàng");
                Global.SetGlabelfalg(1);
            }
            else if (this.BtnRadioNhanVien.Checked == true)
            {
                this.DangNhap("Nhân Viên");
                Global.SetGlabelfalg(2);
            }
            else
            {
                this.DangNhap("Quan Li");
                Global.SetGlabelfalg(3);
            }    
        }

        public void DangNhap(string vaitro)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand("SELECT * FROM Login WHERE username = @User AND password = @Pass And VaiTro = @vai", db.getConnection);

            command.Parameters.Add("@User", SqlDbType.VarChar).Value = TextBoxTenDangNhap.Text;
            command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = TextBoxMatKhau.Text;
            command.Parameters.Add("@vai", SqlDbType.VarChar).Value = vaitro;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                string userid = table.Rows[0]["MaNV"].ToString();
                int id = Convert.ToInt32(table.Rows[0]["Id"].ToString());
                Global.SetGlabelUserId(userid, id);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
