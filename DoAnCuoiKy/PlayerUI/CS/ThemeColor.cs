using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    public static class ThemeColor
    {
        public static Color PrimaryColor { get; set; }
        public static Color SecondaryColor { get; set; }
        public static List<string> ColorList = new List<string>() { "#3F51B5",
                                                                    "#009688",
                                                                    "#FF5722",
                                                                    "#607D8B",
                                                                    "#FF9800",
                                                                    "#9C27B0",
                                                                    "#2196F3",
                                                                    "#EA676C",
                                                                    "#E41A4A",
                                                                    "#5978BB",
                                                                    "#018790",
                                                                    "#0E3441",
                                                                    "#00B0AD",
                                                                    "#721D47",
                                                                    "#EA4833",
                                                                    "#EF937E",
                                                                    "#F37521",
                                                                    "#A12059",
                                                                    "#126881",
                                                                    "#8BC240",
                                                                    "#364D5B",
                                                                    "#C7DC5B",
                                                                    "#0094BC",
                                                                    "#E4126B",
                                                                    "#43B76E",
                                                                    "#7BCFE9",
                                                                    "#B71C46"};
        public static Color ChangeColorBrightness(Color color, double correctionFactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;
            //If correction factor is less than 0, darken color.
            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            //If correction factor is greater than zero, lighten color.
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }
            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }

        public static void LoadColos(Form A,bool laybel)
        {
            foreach (Control X in A.Controls)
            {
                //text box có khung
                if (X.GetType().ToString() == "Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox")
                {
                    Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox TB = (Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox)X;
                    TB.BackColor = Color.White;
                    TB.ForeColor = Color.Black;
                    //TB.LineFocusedColor = ThemeColor.PrimaryColor;
                    //TB.LineMouseHoverColor = ThemeColor.PrimaryColor;
                    TB.BorderColorActive = ThemeColor.PrimaryColor;
                    TB.BorderColorHover = ThemeColor.PrimaryColor;
                }

                //text box 1 đường kẻ
                if (X.GetType().ToString() == "Bunifu.Framework.UI.BunifuMaterialTextbox")
                {
                    Bunifu.Framework.UI.BunifuMaterialTextbox TB = (Bunifu.Framework.UI.BunifuMaterialTextbox)X;
                    TB.LineFocusedColor = ThemeColor.PrimaryColor;
                    TB.LineMouseHoverColor = ThemeColor.PrimaryColor;
                    TB.LineIdleColor = ThemeColor.SecondaryColor;
                }


                // dateTimePicker
                if (X.GetType().ToString() == "Bunifu.Framework.UI.BunifuDatepicker")
                {
                    Bunifu.Framework.UI.BunifuDatepicker Date = (Bunifu.Framework.UI.BunifuDatepicker)X;
                    Date.BackColor = ThemeColor.PrimaryColor;
                }

                // button xanh nhỏ dài như cái tải hình
                if (X.GetType().ToString() == "Bunifu.Framework.UI.BunifuTileButton")
                {
                    Bunifu.Framework.UI.BunifuTileButton btn = (Bunifu.Framework.UI.BunifuTileButton)X;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.color = ThemeColor.PrimaryColor;
                    btn.colorActive = ThemeColor.SecondaryColor;
                }

                //button xanh nhỏ ngắn như nút thêm sữa xóa
                if (X.GetType().ToString() == "Bunifu.UI.WinForms.BunifuButton.BunifuButton")
                {
                    Bunifu.UI.WinForms.BunifuButton.BunifuButton btn = (Bunifu.UI.WinForms.BunifuButton.BunifuButton)X;
                    btn.IdleBorderColor = ThemeColor.SecondaryColor;
                    btn.IdleFillColor = ThemeColor.PrimaryColor;
                }

                // button có viền ngoài bên trong trắng
                if (X.GetType().ToString() == "Bunifu.Framework.UI.BunifuThinButton2")
                {
                    Bunifu.Framework.UI.BunifuThinButton2 btn = (Bunifu.Framework.UI.BunifuThinButton2)X;
                    btn.ActiveFillColor = ThemeColor.PrimaryColor;
                    btn.ActiveLineColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = ThemeColor.PrimaryColor;
                    btn.IdleForecolor = ThemeColor.PrimaryColor;
                    btn.IdleLineColor = ThemeColor.PrimaryColor;
                }

                // button radio 
                if (X.GetType().ToString() == "Bunifu.UI.WinForms.BunifuRadioButton")
                {
                    Bunifu.UI.WinForms.BunifuRadioButton btnr = (Bunifu.UI.WinForms.BunifuRadioButton)X;
                    btnr.OutlineColor = ThemeColor.PrimaryColor;
                    btnr.RadioColor = ThemeColor.PrimaryColor;
                }

                // data gird view
                if (X.GetType() == typeof(DataGridView))
                {
                    DataGridView DGV = (DataGridView)X;
                    DGV.BackgroundColor = ThemeColor.SecondaryColor;
                }

                // pictur box
                if (X.GetType() == typeof(PictureBox))
                {
                    PictureBox PT = (PictureBox)X;
                    PT.BackColor = ThemeColor.SecondaryColor;
                }

                //laybel
                if (X.GetType() == typeof(Label) && laybel == true)
                {
                    Label LB = (Label)X;
                    X.ForeColor = ThemeColor.SecondaryColor;
                }

            }
        }
        public static void LoadColos(Form A)
        {
            LoadColos(A, true);
        }
    }
}
