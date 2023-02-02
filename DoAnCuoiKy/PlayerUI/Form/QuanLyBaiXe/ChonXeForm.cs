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
    public partial class ChonXeForm : Form
    {
        public ChonXeForm()
        {
            InitializeComponent();
        }

        Xe xe = new Xe();

        int co = -1;
        DateTime gio = DateTime.Now;
        public void HienThi(int flag, DateTime time)
        {
            if (flag == 1) // cho thue
            {
                co = 1;
                gio = time;

                if (Global.GlobalUserId.Contains("KH"))
                {
                    ThongKeKhachHangForm tk = new ThongKeKhachHangForm();
                    tk.ThongKeBieuDoTron();
                    this.comboBoxLuaChon.Text = tk.label;

                    SqlCommand command = null;
                    if (this.comboBoxLuaChon.Text == "Xe ô tô")
                    {
                        command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE  MaXe in (SELECT MaXe From XeChoThue Where MaXe not in (SELECT MaXe FROM HopDong WHERE LoaiHD = 'Cho Thuê'  and NgayThuHoi > @time) ) and LoaiXe = 'O to'");
                        command.Parameters.Add("@time", SqlDbType.DateTime).Value = gio.AddDays(-1);
                    }
                    else if (this.comboBoxLuaChon.Text == "Xe máy")
                    {
                        command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE  MaXe in (SELECT MaXe From XeChoThue Where MaXe not in (SELECT MaXe FROM HopDong WHERE LoaiHD = 'Cho Thuê'  and NgayThuHoi > @time) )  and LoaiXe = 'Xe May'");
                        command.Parameters.Add("@time", SqlDbType.DateTime).Value = gio.AddDays(-1);
                    }
                    else if (this.comboBoxLuaChon.Text == "Xe đạp")
                    {
                        command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE  MaXe in (SELECT MaXe From XeChoThue Where MaXe not in (SELECT MaXe FROM HopDong WHERE LoaiHD = 'Cho Thuê'  and NgayThuHoi > @time) ) and LoaiXe = 'Xe Dap'");
                        command.Parameters.Add("@time", SqlDbType.DateTime).Value = gio.AddDays(-1);
                    }
                    else
                    {
                        command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE  MaXe in (SELECT MaXe From XeChoThue Where MaXe not in (SELECT MaXe FROM HopDong WHERE LoaiHD = 'Cho Thuê'  and NgayThuHoi > @time) )");
                        command.Parameters.Add("@time", SqlDbType.DateTime).Value = gio.AddDays(-1);
                    }
                    this.loadDataGridView(command);
                }
                else
                {
                    this.comboBoxLuaChon.Text = "Tất cả";
                    this.loadXeChoThue(time);
                }
            }

            else // Xe thue
            {
                this.loadXeThue();
                co = 0;
                this.comboBoxLuaChon.Text = "Tất cả";
            }
        }

        public void loadDataGridView(SqlCommand command)
        {
            this.dataGridViewChonXe.DataSource = xe.getXe(command);
            this.dataGridViewChonXe.AllowUserToAddRows = false;
            this.dataGridViewChonXe.ReadOnly = true;

            DataGridViewImageColumn picolImg1 = new DataGridViewImageColumn();

            this.dataGridViewChonXe.RowTemplate.Height = 80;
            picolImg1 = (DataGridViewImageColumn)this.dataGridViewChonXe.Columns[2];
            picolImg1.ImageLayout = DataGridViewImageCellLayout.Zoom;

            DataGridViewImageColumn picolImg2 = new DataGridViewImageColumn();
            picolImg2 = (DataGridViewImageColumn)this.dataGridViewChonXe.Columns[3];
            picolImg2.ImageLayout = DataGridViewImageCellLayout.Zoom;

        }
        public void loadXeThue()
        {
            SqlCommand command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE NgayXuatBen is Null and MaXe not in (SELECT MaXe From HopDong WHERE LoaiHD = 'Thuê')");
            this.loadDataGridView(command);
        }

        public void loadXeChoThue(DateTime time)
        {
            SqlCommand command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE  MaXe in (SELECT MaXe From XeChoThue Where MaXe not in (SELECT MaXe FROM HopDong WHERE LoaiHD = 'Cho Thuê'  and NgayThuHoi > @time) or TinhTrang = 0)");
            command.Parameters.Add("@time", SqlDbType.DateTime).Value = time;

            this.loadDataGridView(command);
        }

        private void comboBoxtinhTrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand command = null;
            if (co == 0)
            {
                if (this.comboBoxLuaChon.Text == "Xe ô tô")
                {
                    command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE NgayXuatBen is Null and MaXe not in (SELECT MaXe From HopDong WHERE LoaiHD = 'Thuê') and LoaiXe = 'O to'");
                }
                else if (this.comboBoxLuaChon.Text == "Xe máy")
                {
                    command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE NgayXuatBen is Null and MaXe not in (SELECT MaXe From HopDong WHERE LoaiHD = 'Thuê') and LoaiXe = 'Xe May'");
                }
                else if (this.comboBoxLuaChon.Text == "Xe đạp")
                {
                    command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE NgayXuatBen is Null and MaXe not in (SELECT MaXe From HopDong WHERE LoaiHD = 'Thuê') and LoaiXe = 'Xe Dap'");
                }
                else
                {
                    command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE NgayXuatBen is Null and MaXe not in (SELECT MaXe From HopDong WHERE LoaiHD = 'Thuê') ");
                }
            }
            else
            {
                if (this.comboBoxLuaChon.Text == "Xe ô tô")
                {
                    command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE  MaXe in (SELECT MaXe From XeChoThue Where MaXe not in (SELECT MaXe FROM HopDong WHERE LoaiHD = 'Cho Thuê'  and NgayThuHoi > @time) or TinhTrang = 0) and LoaiXe = 'O to'");
                    command.Parameters.Add("@time", SqlDbType.DateTime).Value = gio.AddDays(-1);
                }
                else if (this.comboBoxLuaChon.Text == "Xe máy")
                {
                    command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE  MaXe in (SELECT MaXe From XeChoThue Where MaXe not in (SELECT MaXe FROM HopDong WHERE LoaiHD = 'Cho Thuê'  and NgayThuHoi > @time) or TinhTrang = 0)  and LoaiXe = 'Xe May'");
                    command.Parameters.Add("@time", SqlDbType.DateTime).Value = gio.AddDays(-1);
                }
                else if (this.comboBoxLuaChon.Text == "Xe đạp")
                {
                    command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE  MaXe in (SELECT MaXe From XeChoThue Where MaXe not in (SELECT MaXe FROM HopDong WHERE LoaiHD = 'Cho Thuê'  and NgayThuHoi > @time) or TinhTrang = 0) and LoaiXe = 'Xe Dap'");
                    command.Parameters.Add("@time", SqlDbType.DateTime).Value = gio.AddDays(-1);
                }
                else
                {
                    command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE  MaXe in (SELECT MaXe From XeChoThue Where MaXe not in (SELECT MaXe FROM HopDong WHERE LoaiHD = 'Cho Thuê'  and NgayThuHoi > @time) or TinhTrang = 0)");
                    command.Parameters.Add("@time", SqlDbType.DateTime).Value = gio.AddDays(-1);
                }
            }

            this.loadDataGridView(command);
        }

        private void ChonXeForm_Load(object sender, EventArgs e)
        {
            ThemeColor.LoadColos(this);
            panelHeard.BackColor = ThemeColor.PrimaryColor;
            panelLogo.BackColor = ThemeColor.SecondaryColor;
            panelMagirleft.BackColor = ThemeColor.PrimaryColor;
            panelZoomClose.BackColor = ThemeColor.PrimaryColor;
        }

        private void TextBoxMaXe_TextChanged(object sender, EventArgs e)
        {
            string key = this.TextBoxMaXe.Text;
            SqlCommand command = null;
            if (co == 0)
            {
                command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE NgayXuatBen is Null and MaXe not in (SELECT MaXe From HopDong WHERE LoaiHD = 'Thuê') and MaXe = '" + key + "'");
            }
            else
            {
                command = new SqlCommand("SELECT MaXe as 'Mã Xe', LoaiXe as 'Loại Xe', Image1 as 'Ảnh 1', Image2 as 'Ảnh 2' FROM Xe WHERE  MaXe in (SELECT MaXe From XeChoThue Where MaXe not in (SELECT MaXe FROM HopDong WHERE LoaiHD = 'Cho Thuê'  and NgayThuHoi > @time) or TinhTrang = 0 ) and MaXe = '" + key + "'");
                command.Parameters.Add("@time", SqlDbType.DateTime).Value = gio;
            }

            DataTable table = xe.getXe(command);
            if (table.Rows.Count > 0)
            {
                this.loadDataGridView(command);
            }
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
