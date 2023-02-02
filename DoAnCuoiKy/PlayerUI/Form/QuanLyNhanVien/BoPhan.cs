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
    public partial class BoPhan : Form
    {
        public BoPhan()
        {
            InitializeComponent();
            ThemeColor.LoadColos(this);
            LabelSoNhanVien.ForeColor = ThemeColor.PrimaryColor;

            this.loadData();
        }

        ChuyenMon bp = new ChuyenMon();

        public bool verif()
        {
            if ((this.TextBoxMaPB.Text.Trim() == "")
                || (this.TextBoxTenPB.Text.Trim() == ""))
                return false;
            return true;
        }

        public void loadData()
        {
            this.dataGridViewPhongBan.ReadOnly = true;
            this.dataGridViewPhongBan.AllowUserToAddRows = false;
            SqlCommand command = new SqlCommand("SELECT MaBP as 'Mã Bộ Phận', TenBP as 'Tên Bộ Phận' FROM BoPhan");
            this.dataGridViewPhongBan.DataSource = bp.getBoPhan(command);
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.verif())
                {

                    string maBP = this.TextBoxMaPB.Text;
                    string ten = this.TextBoxTenPB.Text;

                    if (!bp.KiemTraBoPhan(maBP))
                    {
                        if (bp.ThemBoPhan(maBP,ten))
                        {
                            MessageBox.Show("Thêm bộ phận thành công", "Thêm bộ phận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Lỗi ", "Thêm bộ phận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã bộ phận đã tồn tại", "Thêm bộ phận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Chưa điền đầy đủ thông tin", "Thêm bộ phận", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thêm bộ phận", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (verif())
            {

                string maBP = this.TextBoxMaPB.Text;
                string ten = this.TextBoxTenPB.Text;
                try
                {
                    if (bp.CapNhatBoPhan(maBP,ten))
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
                MessageBox.Show("Chua Dien Day Du Thong Tin", "Chinh Sua", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maBP = this.TextBoxMaPB.Text;
                if (MessageBox.Show("Ban Chan Chac Muon Xoa Bo Phan Nay ", "Xoa Bo Phan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (bp.XoaBoPhan(maBP))
                    {

                        MessageBox.Show("Xoa Thanh Cong", "Xoa Bo Phan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.TextBoxMaPB.Text = "";
                        this.TextBoxTenPB.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Khong Thanh Cong", "Xoa Bo Phan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ban Da Huy Xoa", "Xoa Bo Phan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                MessageBox.Show("Vui Long Nhap Ma Bo Phan", "Xoa Bo Phan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewPhongBan_Click(object sender, EventArgs e)
        {
            this.TextBoxMaPB.Text = this.dataGridViewPhongBan.CurrentRow.Cells[0].Value.ToString().Trim();
            this.TextBoxTenPB.Text = this.dataGridViewPhongBan.CurrentRow.Cells[1].Value.ToString().Trim();

            string maBP = this.TextBoxMaPB.Text;
           
            SqlCommand command = new SqlCommand("SELECT * FROM NhanVien WHERE MaBP = '" + maBP + "'");
            DataTable table = bp.getBoPhan(command);

            int sum = table.Rows.Count;
            this.LabelSoNhanVien.Text = "Số lượng nhân viên: " + sum.ToString();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            this.loadData();
        }
    }
}
