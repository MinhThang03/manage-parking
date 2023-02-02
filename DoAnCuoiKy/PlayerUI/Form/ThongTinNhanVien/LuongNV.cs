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
    public partial class LuongNV : Form
    {
        public LuongNV()
        {
            InitializeComponent();
        }

        CheckIn diemDanh = new CheckIn();
        PhatLuong luong = new PhatLuong();
        private void LuongNV_Load(object sender, EventArgs e)
        {
            ThemeColor.LoadColos(this);
            
        }

        int flag = 0;
        public void LuongToanBoNV()
        {
            SqlCommand command = new SqlCommand("SELECT Id as 'Mã Nhân Viên', Luong as 'Lương' FROM LuongNV");
            DataTable table = luong.getdata(command);

            foreach(DataRow row in table.Rows)
            {
                string maNV = row[0].ToString().Trim();
                this.UpdateLuong(maNV);
            }
        }

        public double TotalTimeLamViec(string name)
        {
            SqlCommand command = new SqlCommand(" SELECT * FROM TimeLamViec WHERE Id = '" + name + "'");
            DataTable table = diemDanh.getdata(command);
            Double TotalTime1 = 0;
            Double TotalTime2 = 0;
            Double TotalTime3 = 0;

            if (table.Rows[0]["TimeStart1"].ToString().Trim() != "" && table.Rows[0]["TimeEnd1"].ToString().Trim() != "")
            {
                DateTime t1 = Convert.ToDateTime(table.Rows[0]["TimeStart1"].ToString().Trim());
                DateTime t2 = Convert.ToDateTime(table.Rows[0]["TimeEnd1"].ToString().Trim());
                TimeSpan ts = t1.Subtract(t2);
                TotalTime1 = Math.Abs(Convert.ToDouble(ts.TotalHours.ToString()));
            }
            if (table.Rows[0]["TimeStart2"].ToString().Trim() != "" && table.Rows[0]["TimeEnd2"].ToString().Trim() != "")
            {
                DateTime t1 = Convert.ToDateTime(table.Rows[0]["TimeStart2"].ToString().Trim());
                DateTime t2 = Convert.ToDateTime(table.Rows[0]["TimeEnd2"].ToString().Trim());
                TimeSpan ts = t1.Subtract(t2);
                TotalTime2 = Math.Abs(Convert.ToDouble(ts.TotalHours.ToString()));
            }
            if (table.Rows[0]["TimeStart3"].ToString().Trim() != "" && table.Rows[0]["TimeEnd3"].ToString().Trim() != "")
            {
                DateTime t1 = Convert.ToDateTime(table.Rows[0]["TimeStart3"].ToString().Trim());
                DateTime t2 = Convert.ToDateTime(table.Rows[0]["TimeEnd3"].ToString().Trim());
                TimeSpan ts = t1.Subtract(t2);
                TotalTime3 = Math.Abs(Convert.ToDouble(ts.TotalHours.ToString()));
            }
            return TotalTime1 + TotalTime2 + TotalTime3;
        }

        public int TinhTien(string maNV)
        {

            int LuongMacDinh = 0;
            int i = Convert.ToInt32(TotalTimeLamViec(maNV));
            if (i >=  8)
            {
                LuongMacDinh = 50000 * i;
            }
            else if (i < 8)
            {
                int temp = 8 - i;
                LuongMacDinh = 50000 * i - temp * 100000;
            }
            
            if (LuongMacDinh < 0)
                LuongMacDinh = 0;
            return LuongMacDinh;
        }

        public void UpdateLuong(string maNV)
        {
            
            int tien = this.TinhTien(maNV);
            luong.updateLuong(maNV, tien);
        }

        private void buttonTinhLuong_Click(object sender, EventArgs e)
        {
            int HourInt = Convert.ToInt32(DateTime.Now.Hour.ToString());
            if (HourInt >= 22)
            {
                this.LuongToanBoNV();
                SqlCommand command = new SqlCommand("SELECT Id as 'Mã Nhân Viên', Luong as 'Lương' FROM LuongNV");
                DataTable table = luong.getdata(command);
                this.loadDataGrid(table);
                this.flag = 1;
            }
            else
            {
                MessageBox.Show("Chưa hết thời gian làm việc, không thể tính lương", "Tính Luong", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void loadDataGrid(DataTable table)
        {
            this.dataGridViewLuong.DataSource = table;
            this.dataGridViewLuong.AllowUserToAddRows = false;
            this.dataGridViewLuong.ReadOnly = true;
        }
        private void buttonPhat_Click(object sender, EventArgs e)
        {
            if (this.flag != 0)
            {

                MessageBox.Show("Phát thành công", "Phát lương", MessageBoxButtons.OK, MessageBoxIcon.Information);
                luong.resetLuong();
                diemDanh.updateTimeDayNew();
                SqlCommand command = new SqlCommand("SELECT Id as 'Mã Nhân Viên', Luong as 'Lương' FROM LuongNV");
                DataTable table = luong.getdata(command);
                this.loadDataGrid(table);
            }
            else
            {
                MessageBox.Show("Chưa tính lương ", "Phát lương", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
