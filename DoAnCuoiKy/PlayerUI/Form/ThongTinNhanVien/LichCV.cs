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
    public partial class LichCV : Form
    {
        public LichCV()
        {
            InitializeComponent();
        }

        NhanVien nv = new NhanVien();
        CaLam calam = new CaLam();

        private void LichCV_Load(object sender, EventArgs e)
        {
            ThemeColor.LoadColos(this);
            this.loadDataGridView();

            DateTime dt = DateTime.Now;
            string Thu = dt.DayOfWeek.ToString().Trim();
            string name = Global.GlobalUserId;

            // Check xem có lời mời làm hộ nào không.
            SqlCommand commandCa = new SqlCommand(" SELECT Id AS N'Mã NV', Thu2 AS N'Thứ 2', Thu3 AS N'Thứ 3', Thu4 AS N'Thứ 4', Thu5 AS N'Thứ 5', Thu6 AS N'Thứ 6', Thu7 AS N'Thứ 7', CN AS N'Chủ Nhật' FROM ChiaCa WHERE Id = '" + name + "'");
            DataTable tableCa = nv.getNhanVien(commandCa);
            this.loadDataGridView();
            try
            {
                if (Thu == "Monday")
                {
                    if (Convert.ToInt32(tableCa.Rows[0]["Thứ 2"].ToString()) < 0)
                    {
                        if ((MessageBox.Show("Hôm nay bạn có một lời đề nghị làm thay ca. Bạn có đồng ý ", "Làm Thay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            calam.updateLamHo2(name, 0);
                        }
                    }
                }
                if (Thu == "Tuesday")
                {
                    if (Convert.ToInt32(tableCa.Rows[0]["Thứ 3"].ToString()) < 0)
                    {
                        if ((MessageBox.Show("Hôm nay bạn có một lời đề nghị làm thay ca. Bạn có đồng ý ", "Làm Thay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            calam.updateLamHo3(name, 0);
                        }
                    }
                }
                if (Thu == "Wednesday")
                {
                    if (Convert.ToInt32(tableCa.Rows[0]["Thứ 4"].ToString()) < 0)
                    {
                        if ((MessageBox.Show("Hôm nay bạn có một lời đề nghị làm thay ca. Bạn có đồng ý ", "Làm Thay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            calam.updateLamHo4(name, 0);
                        }
                    }
                }
                if (Thu == "Thursday")
                {
                    if (Convert.ToInt32(tableCa.Rows[0]["Thứ 5"].ToString()) < 0)
                    {
                        if ((MessageBox.Show("Hôm nay bạn có một lời đề nghị làm thay ca. Bạn có đồng ý ", "Làm Thay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            calam.updateLamHo5(name, 0);
                        }
                    }
                }
                if (Thu == "Friday")
                {
                    if (Convert.ToInt32(tableCa.Rows[0]["Thứ 6"].ToString()) < 0)
                    {
                        if ((MessageBox.Show("Hôm nay bạn có một lời đề nghị làm thay ca. Bạn có đồng ý ", "Làm Thay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            calam.updateLamHo6(name, 0);
                        }
                    }
                }
                if (Thu == "Saturday")
                {
                    if (Convert.ToInt32(tableCa.Rows[0]["Thứ 7"].ToString()) < 0)
                    {
                        if ((MessageBox.Show("Hôm nay bạn có một lời đề nghị làm thay ca. Bạn có đồng ý ", "Làm Thay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            calam.updateLamHo7(name, 0);
                        }
                    }
                }
                if (Thu == "Sunday")
                {
                    if (Convert.ToInt32(tableCa.Rows[0]["Chủ Nhật"].ToString()) < 0)
                    {
                        if ((MessageBox.Show("Hôm nay bạn có một lời đề nghị làm thay ca. Bạn có đồng ý ", "Làm Thay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            calam.updateLamHoCN(name, 0);
                        }
                    }
                }

                this.loadDataGridView();
            }
            catch
            {
                MessageBox.Show("Bạn chưa được chia ca");
            }


        }

        private void loadDataGridView()
        {
            SqlCommand command = new SqlCommand(" SELECT Id AS N'Mã NV', Thu2 AS N'Thứ 2', Thu3 AS N'Thứ 3', Thu4 AS N'Thứ 4', Thu5 AS N'Thứ 5', Thu6 AS N'Thứ 6', Thu7 AS N'Thứ 7', CN AS N'Chủ Nhật' FROM ChiaCa WHERE Id = '" + Global.GlobalUserId + "'");

            DataTable tableCa = nv.getNhanVien(command);
            this.dataGridViewLichCV.AllowUserToAddRows = false;
            this.dataGridViewLichCV.ReadOnly = true;

            this.dataGridViewLichCV.DataSource = tableCa;
            for (int i = 0; i < tableCa.Rows.Count; i++)
            {
                for (int j = 1; j < tableCa.Columns.Count; j++)
                {
                    if (Convert.ToInt32(tableCa.Rows[i][j].ToString()) == 3)
                    {
                        dataGridViewLichCV.Rows[i].Cells[j].Value = "Ca1, Ca2";

                    }
                    else if (Convert.ToInt32(tableCa.Rows[i][j].ToString()) == 2)
                    {
                        dataGridViewLichCV.Rows[i].Cells[j].Value = "Ca1, Ca3";
                    }
                    else if (Convert.ToInt32(tableCa.Rows[i][j].ToString()) == 1)
                    {
                        dataGridViewLichCV.Rows[i].Cells[j].Value = "Ca2, Ca3";
                    }
                    else
                    {
                        dataGridViewLichCV.Rows[i].Cells[j].Value = "Ca1, Ca2, Ca3";
                    }
                }
            }

        }

        public void loadComboboxCaLam(int flag)
        {
            this.comboBoxCaLam.Items.Clear();

            if (flag == 3)
            {
                this.comboBoxCaLam.Items.Add("Ca 1");
                this.comboBoxCaLam.Items.Add("Ca 2");

            }
            else if (flag == 2)
            {
                this.comboBoxCaLam.Items.Add("Ca 1");
                this.comboBoxCaLam.Items.Add("Ca 3");
            }
            else if (flag == 1)
            {
                this.comboBoxCaLam.Items.Add("Ca 2");
                this.comboBoxCaLam.Items.Add("Ca 3");
            }
            else
            {
                this.comboBoxCaLam.Items.Add("Ca 1");
                this.comboBoxCaLam.Items.Add("Ca 2");
                this.comboBoxCaLam.Items.Add("Ca 3");
            }
        }


        public void loadComboboxMaNV(int flag)
        {
            DateTime dt = DateTime.Now;
            string thu = dt.DayOfWeek.ToString().Trim();

            SqlCommand command = null;

            if (thu == "Monday")
            {
                command = new SqlCommand("SELECT  NhanVien.Id as DongNghiep, Thu2, Thu3, Thu4, Thu5, Thu6, Thu7, CN FROM (SELECT Id, MaBP FROM NhanVien WHERE Id = @id) as NhanVienGoc, NhanVien, ChiaCa " +
                    "WHERE NhanVien.MaBP = NhanVienGoc.MaBP and NhanVien.Id = ChiaCa.Id and NhanVienGoc.Id <> NhanVien.Id and Thu2 = " + flag);
                command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Global.GlobalUserId;

                this.comboBoxMaNV.DataSource = nv.getNhanVien(command);
                this.comboBoxMaNV.DisplayMember = "DongNghiep";
                this.comboBoxMaNV.ValueMember = "Thu2";
            }
            if (thu == "Tuesday")
            {
                command = new SqlCommand("SELECT  NhanVien.Id as DongNghiep, Thu2, Thu3, Thu4, Thu5, Thu6, Thu7, CN FROM (SELECT Id, MaBP FROM NhanVien WHERE Id = @id) as NhanVienGoc, NhanVien, ChiaCa " +
                    "WHERE NhanVien.MaBP = NhanVienGoc.MaBP and NhanVien.Id = ChiaCa.Id and NhanVienGoc.Id <> NhanVien.Id and Thu3 = " + flag);
                command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Global.GlobalUserId;

                this.comboBoxMaNV.DataSource = nv.getNhanVien(command);
                this.comboBoxMaNV.DisplayMember = "DongNghiep";
                this.comboBoxMaNV.ValueMember = "Thu3";
            }
            if (thu == "Wednesday")
            {
                command = new SqlCommand("SELECT  NhanVien.Id as DongNghiep, Thu2, Thu3, Thu4, Thu5, Thu6, Thu7, CN FROM (SELECT Id, MaBP FROM NhanVien WHERE Id = @id) as NhanVienGoc, NhanVien, ChiaCa " +
                    "WHERE NhanVien.MaBP = NhanVienGoc.MaBP and NhanVien.Id = ChiaCa.Id and NhanVienGoc.Id <> NhanVien.Id and Thu4 = " + flag);
                command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Global.GlobalUserId;

                this.comboBoxMaNV.DataSource = nv.getNhanVien(command);
                this.comboBoxMaNV.DisplayMember = "DongNghiep";
                this.comboBoxMaNV.ValueMember = "Thu4";
            }
            if (thu == "Thursday")
            {
                command = new SqlCommand("SELECT  NhanVien.Id as DongNghiep, Thu2, Thu3, Thu4, Thu5, Thu6, Thu7, CN FROM (SELECT Id, MaBP FROM NhanVien WHERE Id = @id) as NhanVienGoc, NhanVien, ChiaCa " +
                    "WHERE NhanVien.MaBP = NhanVienGoc.MaBP and NhanVien.Id = ChiaCa.Id and NhanVienGoc.Id <> NhanVien.Id and Thu5 = " + flag);
                command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Global.GlobalUserId;

                this.comboBoxMaNV.DataSource = nv.getNhanVien(command);
                this.comboBoxMaNV.DisplayMember = "DongNghiep";
                this.comboBoxMaNV.ValueMember = "Thu5";
            }
            if (thu == "Friday")
            {
                command = new SqlCommand("SELECT  NhanVien.Id as DongNghiep, Thu2, Thu3, Thu4, Thu5, Thu6, Thu7, CN FROM (SELECT Id, MaBP FROM NhanVien WHERE Id = @id) as NhanVienGoc, NhanVien, ChiaCa " +
                    "WHERE NhanVien.MaBP = NhanVienGoc.MaBP and NhanVien.Id = ChiaCa.Id and NhanVienGoc.Id <> NhanVien.Id and Thu6 = " + flag);
                command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Global.GlobalUserId;

                this.comboBoxMaNV.DataSource = nv.getNhanVien(command);
                this.comboBoxMaNV.DisplayMember = "DongNghiep";
                this.comboBoxMaNV.ValueMember = "Thu6";
            }
            if (thu == "Saturday")
            {
                command = new SqlCommand("SELECT  NhanVien.Id as DongNghiep, Thu2, Thu3, Thu4, Thu5, Thu6, Thu7, CN FROM (SELECT Id, MaBP FROM NhanVien WHERE Id = @id) as NhanVienGoc, NhanVien, ChiaCa " +
                    "WHERE NhanVien.MaBP = NhanVienGoc.MaBP and NhanVien.Id = ChiaCa.Id and NhanVienGoc.Id <> NhanVien.Id and Thu7 = " + flag);
                command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Global.GlobalUserId;

                this.comboBoxMaNV.DataSource = nv.getNhanVien(command);
                this.comboBoxMaNV.DisplayMember = "DongNghiep";
                this.comboBoxMaNV.ValueMember = "Thu7";
            }
            if (thu == "Sunday")
            {
                command = new SqlCommand("SELECT  NhanVien.Id as DongNghiep, Thu2, Thu3, Thu4, Thu5, Thu6, Thu7, CN FROM (SELECT Id, MaBP FROM NhanVien WHERE Id = @id) as NhanVienGoc, NhanVien, ChiaCa " +
                    "WHERE NhanVien.MaBP = NhanVienGoc.MaBP and NhanVien.Id = ChiaCa.Id and NhanVienGoc.Id <> NhanVien.Id and CN = " + flag);
                command.Parameters.Add("@Id", SqlDbType.VarChar).Value = Global.GlobalUserId;

                this.comboBoxMaNV.DataSource = nv.getNhanVien(command);
                this.comboBoxMaNV.DisplayMember = "DongNghiep";
                this.comboBoxMaNV.ValueMember = "CN";
            }


        }

        private void buttonThayCa_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string Thu = dt.DayOfWeek.ToString().Trim();
            SqlCommand command = new SqlCommand(" Select Id AS N'Mã NV', Thu2 AS N'Thứ 2', Thu3 AS N'Thứ 3', Thu4 AS N'Thứ 4', Thu5 AS N'Thứ 5', Thu6 AS N'Thứ 6', Thu7 AS N'Thứ 7', CN AS N'Chủ Nhật' FROM ChiaCa WHERE Id = '" + Global.GlobalUserId +"'");
            DataTable tableCa = nv.getNhanVien(command);
            if (tableCa.Rows.Count > 0)
            {
                if (Thu == "Monday")
                {
                    int flag = Convert.ToInt32(tableCa.Rows[0]["Thứ 2"].ToString());
                    this.loadComboboxCaLam(flag);
                }
                if (Thu == "Tuesday")
                {
                    int flag = Convert.ToInt32(tableCa.Rows[0]["Thứ 3"].ToString());
                    this.loadComboboxCaLam(flag);
                }
                if (Thu == "Wednesday")
                {
                    int flag = Convert.ToInt32(tableCa.Rows[0]["Thứ 4"].ToString());
                    this.loadComboboxCaLam(flag);
                }
                if (Thu == "Thursday")
                {
                    int flag = Convert.ToInt32(tableCa.Rows[0]["Thứ 5"].ToString());
                    this.loadComboboxCaLam(flag);
                }
                if (Thu == "Friday")
                {
                    int flag = Convert.ToInt32(tableCa.Rows[0]["Thứ 6"].ToString());
                    this.loadComboboxCaLam(flag);
                }
                if (Thu == "Saturday")
                {
                    int flag = Convert.ToInt32(tableCa.Rows[0]["Thứ 7"].ToString());
                    this.loadComboboxCaLam(flag);
                }
                if (Thu == "Sunday")
                {
                    int flag = Convert.ToInt32(tableCa.Rows[0]["Chủ Nhật"].ToString());
                    this.loadComboboxCaLam(flag);
                }
            }
        }

        private void comboBoxCaLam_SelectedIndexChanged(object sender, EventArgs e)
        {
            int flag;
            if (this.comboBoxCaLam.Text == "Ca 1")
            {
                flag = 1;
            }
            else if (this.comboBoxCaLam.Text == "Ca 2")
            {
                flag = 2;
            }
            else
            {
                flag = 3;
            }
            this.loadComboboxMaNV(flag);
        }

        private void buttonGui_Click(object sender, EventArgs e)
        {
            if (this.comboBoxMaNV.Text.Trim() != "")
            {
                int flag = Convert.ToInt32(this.comboBoxMaNV.SelectedValue.ToString());
                string maNV = this.comboBoxMaNV.Text.Trim();
                DateTime dt = DateTime.Now;
                string thu = dt.DayOfWeek.ToString().Trim();
                if (thu == "Monday")
                {
                    calam.updateLamHo2(maNV, -1 * flag);
                }
                if (thu == "Tuesday")
                {
                    calam.updateLamHo3(maNV, -1 * flag);
                }
                if (thu == "Wednesday")
                {
                    calam.updateLamHo4(maNV, -1 * flag);
                }
                if (thu == "Thursday")
                {
                    calam.updateLamHo5(maNV, -1 * flag);
                }
                if (thu == "Friday")
                {
                    calam.updateLamHo6(maNV, -1 * flag);
                }
                if (thu == "Saturday")
                {
                    calam.updateLamHo7(maNV, -1 * flag);
                }
                if (thu == "Sunday")
                {
                    calam.updateLamHoCN(maNV, -1 * flag);
                }
                MessageBox.Show("Đã Gửi Làm Mời");
            }
            else
            {
                MessageBox.Show("Chưa chọn mã nv");
            }
        }
    }
}
