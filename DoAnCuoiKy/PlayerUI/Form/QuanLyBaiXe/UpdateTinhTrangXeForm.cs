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
    public partial class UpdateTinhTrangXeForm : Form
    {
        public UpdateTinhTrangXeForm()
        {
            InitializeComponent();
        }

        XeChoThue chothue = new XeChoThue();
        public void hienthi(string MaXe)
        {
            this.comboBoxtinhTrang.Text = "Đầy";
            this.labelMaXe.Text = MaXe;
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int flag = 0;
                if (this.comboBoxtinhTrang.Text == "Đầy")
                    flag = 1;
                else
                    flag = 0;
                if (chothue.updateTinhTrang(this.labelMaXe.Text, flag))
                {
                    MessageBox.Show("Đã câp nhật", "Chỉnh sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }   
                else
                {
                    MessageBox.Show("Lỗi", "Chỉnh sửa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
               
            }
            catch
            {
                MessageBox.Show("Lỗi", "Chỉnh sửa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTinhTrangXeForm_Load(object sender, EventArgs e)
        {
            ThemeColor.LoadColos(this);
            panelHeard.BackColor = ThemeColor.PrimaryColor;
            panelLogo.BackColor = ThemeColor.SecondaryColor;
            panelMagirleft.BackColor = ThemeColor.PrimaryColor;
            panelZoomClose.BackColor = ThemeColor.PrimaryColor;
            panelTitle.BackColor = ThemeColor.PrimaryColor;
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
