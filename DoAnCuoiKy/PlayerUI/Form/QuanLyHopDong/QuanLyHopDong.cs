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
    public partial class QuanLyHopDong : Form
    {
        public SendMessage send;
        public QuanLyHopDong()
        {
            InitializeComponent();
        }

        HopDong hd = new HopDong();

        public QuanLyHopDong(SendMessage send)
        {
            InitializeComponent();
            this.send = send;
        }
        public void loadData(SqlCommand command)
        {
            this.dataGridViewHopDong.ReadOnly = true;
            this.dataGridViewHopDong.AllowUserToAddRows = false;
           this.dataGridViewHopDong.DataSource = hd.getHopDong(command);
            this.dataGridViewHopDong.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy";
            this.dataGridViewHopDong.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy";
            this.dataGridViewHopDong.Columns[8].DefaultCellStyle.Format = "dd/MM/yyyy";

            DataTable table = hd.getHopDong(command);  
        }

        private void QuanLyHopDong_Load(object sender, EventArgs e)
        {
            ThemeColor.LoadColos(this, false);
            LableNgayBatDau.BackColor = ThemeColor.SecondaryColor;
            labelNgayKetThuc.BackColor = ThemeColor.SecondaryColor;
            panelNen1.BackColor = ThemeColor.PrimaryColor;
            panelNen2.BackColor = ThemeColor.PrimaryColor;
            panelNen1.Visible = false;
            panelNen2.Visible = false;

            SqlCommand command = new SqlCommand("SELECT MaHD as 'Mã Hợp Đồng', MaXe as 'Mã Xe', MaKH as 'Mã Khách Hàng', MaNV as 'Mã Nhân Viên', LoaiHD as 'Loại Hợp Đồng', TriGiaHD as 'Trị Giá', NgayKi as 'Ngày Kí', NgayBanGiao as 'Ngày Nhận Xe', NgayThuHoi as 'Ngày Thu Hồi', GhiChu as 'Ghi Chú' FROM HopDong");
            this.loadData(command);
            this.comboBoxLoaiDanhSach.Text = "Danh Sách Hợp Đồng";

        }

   
        private void BtnTaiLen_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT MaHD as 'Mã Hợp Đồng', MaXe as 'Mã Xe', MaKH as 'Mã Khách Hàng', MaNV as 'Mã Nhân Viên', LoaiHD as 'Loại Hợp Đồng', TriGiaHD as 'Trị Giá', NgayKi as 'Ngày Kí', NgayBanGiao as 'Ngày Nhận Xe', NgayThuHoi as 'Ngày Thu Hồi', GhiChu as 'Ghi Chú' FROM HopDong");
            this.loadData(command);
            this.TextBoxMaXe.Text = "";
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string key = this.TextBoxMaXe.Text;
            if (key != "")
            {
                DataTable table= new DataTable();
                SqlCommand command = null;
                if (this.BtnRadioKhong.Checked == true)
                {
                    command = new SqlCommand("SELECT MaHD as 'Mã Hợp Đồng', MaXe as 'Mã Xe', MaKH as 'Mã Khách Hàng', MaNV as 'Mã Nhân Viên', LoaiHD as 'Loại Hợp Đồng', TriGiaHD as 'Trị Giá', NgayKi as 'Ngày Kí', NgayBanGiao as 'Ngày Nhận Xe', NgayThuHoi as 'Ngày Thu Hồi', GhiChu as 'Ghi Chú' FROM HopDong WHERE MaXe = '" + key + "'");
                  
                    table = hd.getHopDong(command);

                }
                else
                {
                    command = new SqlCommand("SELECT MaHD as 'Mã Hợp Đồng', MaXe as 'Mã Xe', MaKH as 'Mã Khách Hàng', MaNV as 'Mã Nhân Viên', LoaiHD as 'Loại Hợp Đồng', TriGiaHD as 'Trị Giá', NgayKi as 'Ngày Kí', NgayBanGiao as 'Ngày Nhận Xe', NgayThuHoi as 'Ngày Thu Hồi', GhiChu as 'Ghi Chú' FROM HopDong WHERE MaXe = @maXe and NgayKi between @vao and @ket");
                    command.Parameters.Add("@vao", SqlDbType.DateTime).Value = this.DatepickerNgayVao.Value;
                    command.Parameters.Add("@ket", SqlDbType.DateTime).Value = this.DatepickerNgayKet.Value;
                    command.Parameters.Add("@maXe", SqlDbType.VarChar).Value = key;

                    table = hd.getHopDong(command);
                }
                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy");
                }
                else
                {
                    this.loadData(command);
                }
            }
            else
            {
                MessageBox.Show("Chua Dien Thong Tin Tim Kiem!!!", "Tim Kiem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

           
        }

        private void dataGridViewHopDong_Click(object sender, EventArgs e)
        {
            this.TextBoxMaXe.Text = this.dataGridViewHopDong.CurrentRow.Cells[1].Value.ToString();
        }

        private void BtnXemChiTiet_Click(object sender, EventArgs e)
        {
            this.send(this.dataGridViewHopDong.CurrentRow.Cells[0].Value.ToString());
        }

        private void comboBoxLoaiDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand command = null;
            if (this.comboBoxLoaiDanhSach.Text == "Danh Sách Đặt Xe")
            {
                command = new SqlCommand("SELECT MaHD as 'Mã Hợp Đồng', MaXe as 'Mã Xe', MaKH as 'Mã Khách Hàng', MaNV as 'Mã Nhân Viên', LoaiHD as 'Loại Hợp Đồng', TriGiaHD as 'Trị Giá', NgayKi as 'Ngày Kí', NgayBanGiao as 'Ngày Nhận Xe', NgayThuHoi as 'Ngày Thu Hồi', GhiChu as 'Ghi Chú' FROM HopDong WHERE MaNV is null"); 
            }   
            else
            {
                command = new SqlCommand("SELECT MaHD as 'Mã Hợp Đồng', MaXe as 'Mã Xe', MaKH as 'Mã Khách Hàng', MaNV as 'Mã Nhân Viên', LoaiHD as 'Loại Hợp Đồng', TriGiaHD as 'Trị Giá', NgayKi as 'Ngày Kí', NgayBanGiao as 'Ngày Nhận Xe', NgayThuHoi as 'Ngày Thu Hồi', GhiChu as 'Ghi Chú' FROM HopDong WHERE MaNV is not null");
            }
            this.loadData(command);
        }

        private void BtnRadioCo_Click(object sender, EventArgs e)
        {
            this.DatepickerNgayKet.Enabled = true;
            this.DatepickerNgayVao.Enabled = true;
            panelNen1.Visible = false;
            panelNen2.Visible = false;
        }

        private void BtnRadioKhong_Click(object sender, EventArgs e)
        {
            this.DatepickerNgayKet.Enabled = false;
            this.DatepickerNgayVao.Enabled = false;
            panelNen1.Visible = true;
            panelNen2.Visible = true;
            

        }
    }
}
