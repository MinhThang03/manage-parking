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
    public partial class GuiXe : Form
    {
        public GuiXe()
        {
            InitializeComponent();
        }

        private void GuiXe_Load(object sender, EventArgs e)
        {
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
