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
    public partial class ThongKeHoaDon : Form
    {
        public ThongKeHoaDon()
        {
            InitializeComponent();
        }

        private void ThongKeHoaDon_Load(object sender, EventArgs e)
        {
            ThemeColor.LoadColos(this);
        }

      
    }
}
