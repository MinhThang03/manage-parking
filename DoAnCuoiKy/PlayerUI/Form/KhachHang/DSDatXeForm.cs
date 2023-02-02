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
    public partial class DSDatXeForm : Form
    {
        public DSDatXeForm()
        {
            InitializeComponent();
        }

        HopDong hd = new HopDong();

        public void loadData(SqlCommand command)
        {
            ThemeColor.LoadColos(this);
            this.dataGridViewHopDong.ReadOnly = true;
            this.dataGridViewHopDong.AllowUserToAddRows = false;
            this.dataGridViewHopDong.DataSource = hd.getHopDong(command);
            this.dataGridViewHopDong.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy";
            this.dataGridViewHopDong.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy";
            this.dataGridViewHopDong.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";

            DataTable table = hd.getHopDong(command);
        }

        private void DSDatXeForm_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT MaHD as 'Mã Hợp Đồng', MaXe as 'Mã Xe', MaKH as 'Mã Khách Hàng', LoaiHD as 'Loại Hợp Đồng', TriGiaHD as 'Trị Giá', NgayKi as 'Ngày Kí',NgayBanGiao as'Ngày Nhận Xe', NgayThuHoi as 'Ngày Thu Hồi', GhiChu as 'Ghi Chú' FROM HopDong Where LoaiHD = 'Cho Thuê' and MaKH = '" + Global.GlobalUserId +"'");
            this.loadData(command);
            this.comboBoxLuaChon.Text = "Tất cả";
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string key = this.TextBoxMaXe.Text;
            if (key != "")
            {
                    SqlCommand command = new SqlCommand("SELECT MaHD as 'Mã Hợp Đồng', MaXe as 'Mã Xe', MaKH as 'Mã Khách Hàng', LoaiHD as 'Loại Hợp Đồng', TriGiaHD as 'Trị Giá', NgayKi as 'Ngày Kí',NgayBanGiao as'Ngày Nhận Xe', NgayThuHoi as 'Ngày Thu Hồi', GhiChu as 'Ghi Chú' FROM HopDong WHERE LoaiHD = 'Cho Thuê' and MaKH ='" + Global.GlobalUserId + "' MaXe = '" + key + "'");
                    this.loadData(command);
            }
            else
            {
                MessageBox.Show("Chua Dien Thong Tin Tim Kiem!!!", "Tim Kiem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maHD = this.TextBoxMaXe.Text;
               

                if (MessageBox.Show("Ban Chan Chac Muon Huy Dat Xe ", "Xoa Hop Dong", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCommand command = new SqlCommand("SELECT NgayBanGiao FROM HopDong  WHERE MaHD  = '" + maHD +"'");
                    DataTable table = hd.getHopDong(command);
                    DateTime time1 = ((DateTime)table.Rows[0][0]).AddDays(-1);
                    DateTime time2 = DateTime.Now;

                    int compare = DateTime.Compare(time2, time1);
                    if (compare < 0)
                    {

                        if (hd.XoaHopDong(maHD))
                        {

                            MessageBox.Show("Xoa Thanh Cong", "Xoa Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.TextBoxMaXe.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Khong Thanh Cong", "Xoa Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đã quá hạn hủy đặt xe", "Xoa Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Ban Da Huy Xoa", "Xoa Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                MessageBox.Show("Vui Long Nhap Ma HD", "Xoa Hop Dong", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewHopDong_Click(object sender, EventArgs e)
        {
            this.TextBoxMaXe.Text = this.dataGridViewHopDong.CurrentRow.Cells[0].Value.ToString().Trim();
        }

        private void BtnTaiLen_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT MaHD as 'Mã Hợp Đồng', MaXe as 'Mã Xe', MaKH as 'Mã Khách Hàng', LoaiHD as 'Loại Hợp Đồng', TriGiaHD as 'Trị Giá', NgayKi as 'Ngày Kí',NgayBanGiao as'Ngày Nhận Xe', NgayThuHoi as 'Ngày Thu Hồi', GhiChu as 'Ghi Chú' FROM HopDong Where LoaiHD = 'Cho Thuê' and MaKH = '" + Global.GlobalUserId +"'");
            this.loadData(command);
        }

        private void comboBoxLuaChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand command = null;
            if (this.comboBoxLuaChon.Text == "Đang đặt")
            {
                command = new SqlCommand("SELECT MaHD as 'Mã Hợp Đồng', MaXe as 'Mã Xe', MaKH as 'Mã Khách Hàng', LoaiHD as 'Loại Hợp Đồng', TriGiaHD as 'Trị Giá', NgayKi as 'Ngày Kí',NgayBanGiao as'Ngày Nhận Xe', NgayThuHoi as 'Ngày Thu Hồi', GhiChu as 'Ghi Chú' FROM HopDong Where MaNV is null and LoaiHD = 'Cho Thuê' and MaKH = '" + Global.GlobalUserId +"'");
            }
            else if (this.comboBoxLuaChon.Text == "Đã nhận")
            {
                command = new SqlCommand("SELECT MaHD as 'Mã Hợp Đồng', MaXe as 'Mã Xe', MaKH as 'Mã Khách Hàng', LoaiHD as 'Loại Hợp Đồng', TriGiaHD as 'Trị Giá', NgayKi as 'Ngày Kí',NgayBanGiao as'Ngày Nhận Xe', NgayThuHoi as 'Ngày Thu Hồi', GhiChu as 'Ghi Chú' FROM HopDong Where MaNV is not null and LoaiHD = 'Cho Thuê' and MaKH = '" + Global.GlobalUserId + "'");
            }
            else
            {
                command = new SqlCommand("SELECT MaHD as 'Mã Hợp Đồng', MaXe as 'Mã Xe', MaKH as 'Mã Khách Hàng', LoaiHD as 'Loại Hợp Đồng', TriGiaHD as 'Trị Giá', NgayKi as 'Ngày Kí',NgayBanGiao as'Ngày Nhận Xe', NgayThuHoi as 'Ngày Thu Hồi', GhiChu as 'Ghi Chú' FROM HopDong Where LoaiHD = 'Cho Thuê' and MaKH = '" + Global.GlobalUserId +"'");
                
            }
            this.loadData(command);
        }
    }
}


