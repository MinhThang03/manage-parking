using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{

    public delegate void SendMessage(string value);
    public partial class MainFormMenu : Form
    {

        // no bat form moi ne
        private void SetValue(string value)
        {
            //this.TenNV.Text = value;
            showSubMenu(panelQLHD);
            ActivateButton(this.buttonQLHD);
            openChildForm(new ThongTinHopDong(value));
        }


        public void loadHinhanh()
        {
            this.MaNV.Text = "Mã: " + Global.GlobalUserId;

            NhanVien nv = new NhanVien();
            if (Global.GlobalFlag != 1)
            {

                SqlCommand command = new SqlCommand("SELECT * FROM NhanVien WHERE Id = '" + Global.GlobalUserId + "'");
                DataTable table = nv.getNhanVien(command);
                string ten = table.Rows[0]["TenNV"].ToString().Trim();
                if (ten != "")
                {
                    this.TenNV.Text = ten;
                }

                string anh = table.Rows[0]["HinhNV"].ToString().Trim();
                if (anh != "")
                {
                    byte[] pic;
                    pic = (byte[])table.Rows[0]["HinhNV"];
                    MemoryStream picture = new MemoryStream(pic);
                    this.bunifuPictureBoxAnh.Image = Image.FromStream(picture);
                }
            }
            else
            {
                KhachHang kh = new KhachHang();
                SqlCommand command = new SqlCommand("SELECT * FROM KhachHang WHERE MaKH = '" + Global.GlobalUserId + "'");
                DataTable table = nv.getNhanVien(command);
                string ten = table.Rows[0]["TenKH"].ToString().Trim();
                if (ten != "")
                {
                    this.TenNV.Text = ten;
                }

                string anh = table.Rows[0]["Hinh"].ToString().Trim();
                if (anh != "")
                {
                    byte[] pic;
                    pic = (byte[])table.Rows[0]["Hinh"];
                    MemoryStream picture = new MemoryStream(pic);
                    this.bunifuPictureBoxAnh.Image = Image.FromStream(picture);
                }
            }
        }

        private Button currentButton;
        private Random random;
        private int tempIndex;
        //private Form activeForm;
        private Button currentButtonChill;

        //constructor
        public MainFormMenu()
        {
            InitializeComponent();
            hideSubMenu();
            random = new Random();
            this.Text = string.Empty;
            this.ControlBox = false;
        }
        private void MainFormMenu_Load(object sender, EventArgs e)
        {
            XoaHetNut();
            openChildForm(new HomeForm());
            timerNow.Start();
            timerIn.Start();
            labelTime.Text = DateTime.Now.ToLongTimeString();
            labelDate.Text = DateTime.Now.ToLongDateString();

            bunifuPictureBoxAnh.BorderRadius = 25;

            if (Global.GlobalFlag == 1)
            {
                LoadKhachHang();
            }
            else if (Global.GlobalFlag == 2)
            {
                loadNhanVien();
            }
            else
            {

                loadQuanLy();
            }

            this.loadHinhanh();
        }


        private void XoaHetNut()
        {
            buttonHeThong.Visible = false;
            buttonQLNV.Visible = false;
            buttonQLBX.Visible = false;
            buttonQLHD.Visible = false;
            buttonThongKe.Visible = false;
            buttonThongTinKhachHang.Visible = false;
            buttonChucNang.Visible = false;

        }

        private void LoadKhachHang()
        {
            buttonThongTinKhachHang.Visible = true;
            buttonChucNang.Visible = true;
            
        }

        private void loadQuanLy()
        {
            buttonHeThong.Visible = true;
            buttonQLNV.Visible = true;
            buttonQLBX.Visible = true;
            buttonQLHD.Visible = true;
            buttonThongKe.Visible = true;
            BtnNhapXuatBen.Visible = false;
            btnLichLamViec.Visible = false;
            btnDiemDanh.Visible = false;
            panelQLBX.Size = new Size(panelQLBX.Width, panelQLBX.Height - 40 + 2);
            panelHeThong.Size = new Size(panelHeThong.Width, panelHeThong.Height - 80 + 2 );
        }

        private void loadNhanVien()
        {
            buttonHeThong.Visible = true;
            buttonQLBX.Visible = true;
            btnQuanLyXe.Visible = false;
            btnQuanLyVe.Visible = false;
            btnQuanLyCongViec.Visible = false;
            panelQLBX.Size = new Size(panelQLBX.Width, panelQLBX.Height - 120 + 2);
        }



        // Methods

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButtonChill = currentButton;
                    LableTitleButtonCurrent.Text = currentButtonChill.Text;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                   //btnCloseChildForm.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelSideMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }


        // Play UI
        private void hideSubMenu()
        {
            panelHeThong.Visible = false;
            panelQLNV.Visible = false;
            panelQLBX.Visible = false;
            panelQLHD.Visible = false;
            panelThongKe.Visible = false;
            panelThongTinKhachHang.Visible = false;
            panelChucNang.Visible = false; 
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }



        private void btnEqualizer_Click(object sender, EventArgs e)
        {
            //openChildForm(new Form3());
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //openChildForm(new Form5());
            //..
            //your codes
            //..
            hideSubMenu();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null) 
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void buttonHeThong_Click(object sender, EventArgs e)
        {
            showSubMenu(panelHeThong);
            ActivateButton(sender);


        }

        private void buttonQLNV_Click(object sender, EventArgs e)
        {
            showSubMenu(panelQLNV);
            ActivateButton(sender);
        }

        private void buttonQLBX_Click(object sender, EventArgs e)
        {
            showSubMenu(panelQLBX);
            ActivateButton(sender);
        }

        private void buttonQLHD_Click(object sender, EventArgs e)
        {
            showSubMenu(panelQLHD);
            ActivateButton(sender);
        }

        private void buttonThongKe_Click(object sender, EventArgs e)
        {
            showSubMenu(panelThongKe);
            ActivateButton(sender);
        }


     
        private void timerNow_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToLongTimeString();
            timerNow.Start();

        }
        private void CloseBtnImg_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            openChildForm(new ThongTinNV());
            LableTitleButtonCurrent.Text = "HỆ THÔNG / THÔNG TIN";
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            openChildForm(new DoiMatKhau());
            LableTitleButtonCurrent.Text = "HỆ THÔNG / ĐỔI MẬt KHẨU";
        }

        private void btnDanhSachNV_Click(object sender, EventArgs e)
        {
            openChildForm(new ThongTinCacNhanVien());
            LableTitleButtonCurrent.Text = "QUẢN LÝ NHÂN VIÊN / Danh sách nhân viên";
        }

        private void btnQuanLyBoPhan_Click(object sender, EventArgs e)
        {
            openChildForm(new BoPhan());
            LableTitleButtonCurrent.Text = "QUẢN LÝ NHÂN VIÊN / Quản lý bộ phận";
        }

        private void btnQuanLyXe_Click(object sender, EventArgs e)
        {
            openChildForm(new QuanLyXe());
            LableTitleButtonCurrent.Text = "QUẢN LÝ BÃI XE / Quản lý xe";
        }

        private void btnQuanLyBaiXe_Click(object sender, EventArgs e)
        {
            openChildForm(new QuanLyBaiXe());
            LableTitleButtonCurrent.Text = "QUẢN LÝ BÃI XE / Quản lý bãi xe";
        }

        private void BtnNhapXuatBen_Click(object sender, EventArgs e)
        {
            openChildForm(new QuanLyVaoRaBen());
            LableTitleButtonCurrent.Text = "QUẢN LÝ BÃI XE / Quản lý xe vào ra bên";
        }

        private void btnQuanLyVe_Click(object sender, EventArgs e)
        {
            openChildForm(new QuanLyVeXe());
            LableTitleButtonCurrent.Text = "QUẢN LÝ BÃI XE / Quản lý vé xe";
        }

        private void btnQuanLyCongViec_Click(object sender, EventArgs e)
        {
            openChildForm(new QuanLyCongViec());
            LableTitleButtonCurrent.Text = "QUẢN LÝ BÃI XE / Quản lý công việc";
        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            openChildForm(new ThongTinHopDong());
            LableTitleButtonCurrent.Text = "QUẢN LÝ HỢP ĐỒNG / Hợp đồng";
        }

        private void btnDanhSachHD_Click(object sender, EventArgs e)
        {
            openChildForm(new QuanLyHopDong(SetValue));
            LableTitleButtonCurrent.Text = "QUẢN LÝ HỢP ĐỒNG / Danh sách hợp đồng";
        }

        private void btnLichLamViec_Click(object sender, EventArgs e)
        {
            openChildForm(new LichCV());
            LableTitleButtonCurrent.Text = "HỆ THÔNG / Lịch làm việc";
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            openChildForm(new LuongNV());
            LableTitleButtonCurrent.Text = "QUẢN LÝ NHÂN VIÊN / Lương";
        }

        private void btnDiemDanh_Click(object sender, EventArgs e)
        {
            openChildForm(new CheckInOut());
            LableTitleButtonCurrent.Text = "HỆ THÔNG / Điểm danh";
        }

        private void btnTK_HopDong_Click(object sender, EventArgs e)
        {

            openChildForm(new ThongKeHopDong());
            LableTitleButtonCurrent.Text = "THỐNG KÊ / Thống kê hợp đồng";
        }

        private void btnTK_Xe_Click(object sender, EventArgs e)
        {
            openChildForm(new ThongKeXe());
            LableTitleButtonCurrent.Text = "THỐNG KÊ / Thống kê xe";
        }

        private void btnKT_NV_Click(object sender, EventArgs e)
        {
            openChildForm(new ThongKeNhanVien());
            LableTitleButtonCurrent.Text = "THỐNG KÊ / Thống kê nhân viên";
        }

        private void btnTK_DoanhThu_Click(object sender, EventArgs e)
        {
            openChildForm(new ThongKeDoanhThu());
            LableTitleButtonCurrent.Text = "THỐNG KÊ / Thống kê doanh thu";
        }

        private void btnThongKeHoaDon_Click(object sender, EventArgs e)
        {
            openChildForm(new ThongKeHoaDon());
            LableTitleButtonCurrent.Text = "THỐNG KÊ / Thống kê hóa đơn";
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            openChildForm(new ChiaCaNhanVien());
            LableTitleButtonCurrent.Text = "QUẢN LÝ NHÂN VIÊN / Chia ca nhân viên";
        }

        private void btnQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            openChildForm(new QuanLiTaiKhoanForm());
            LableTitleButtonCurrent.Text = "QUẢN LÝ NHÂN VIÊN / Quản lý tài khoản nhân viên";
        }




        //-----------------------------------------------------------------------------///
        //-----------------------------------------------------------------------------///
        //-----------------------------------------------------------------------------///
        //------------------------khach hang---------------------------------------------///
        //-----------------------------------------------------------------------------///
        //-----------------------------------------------------------------------------///
        //-----------------------------------------------------------------------------///
        //-----------------------------------------------------------------------------///

        private void buttonThongTinKhachHang_Click(object sender, EventArgs e)
        {
            showSubMenu(panelThongTinKhachHang);
            ActivateButton(sender);
           
        }

        private void buttonChucNang_Click(object sender, EventArgs e)
        {
            showSubMenu(panelChucNang);
            ActivateButton(sender);
        }

        private void buttonThongTinCuaKhach_Click(object sender, EventArgs e)
        {
            openChildForm(new ThongTinKhachHang());
            LableTitleButtonCurrent.Text = "THÔNG TIN KHÁCH / Thống kê khách hàng";
        }

        private void buttonDanhSachXeCuarKhach_Click(object sender, EventArgs e)
        {
            openChildForm(new DSDatXeForm());
            LableTitleButtonCurrent.Text = "THÔNG TIN KHÁCH / Danh sách xe của khách hàng ";
        }

        private void buttonDatXe_Click(object sender, EventArgs e)
        {
            openChildForm(new DatXeForm());
            LableTitleButtonCurrent.Text = "CHỨC NĂNG / Đặt xe";
        }

        private void buttonThongKeKhachHang_Click(object sender, EventArgs e)
        {
            openChildForm(new ThongKeKhachHangForm());
            LableTitleButtonCurrent.Text = "CHỨC NĂNG / Thông kê khách hàng";
        }

        private void buttonDoiMatKhau_Click(object sender, EventArgs e)
        {
            openChildForm(new DoiMatKhau());
            LableTitleButtonCurrent.Text = "THÔNG TIN KHÁCH / Đổi mật khẩu ";
        }

        private void timerIn_Tick(object sender, EventArgs e)
        {
            if (Global.GlobalUserId.Contains("QL"))
            {
                if (DateTime.Now.Hour.ToString() == "22" && DateTime.Now.Minute.ToString() == "36")
                {
                    timerIn.Stop();
                    DoanhThuTrongNgay dt = new DoanhThuTrongNgay();
                    dt.dateTimePickerNgay.Value = DateTime.Now;
                    dt.locDuLieu();
                    dt.Xuatfile();

                }
            }
        }
    }
}
