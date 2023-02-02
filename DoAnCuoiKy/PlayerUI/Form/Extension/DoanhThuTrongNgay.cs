using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace PlayerUI
{
    public partial class DoanhThuTrongNgay : Form
    {
        public DoanhThuTrongNgay()
        {
            InitializeComponent();
        }

        private void DoanhThuTrongNgay_Load(object sender, EventArgs e)
        {
            ThemeColor.LoadColos(this);
            panelHeard.BackColor = ThemeColor.PrimaryColor;
            panelLogo.BackColor = ThemeColor.SecondaryColor;
            panelMagirleft.BackColor = ThemeColor.PrimaryColor;
            panelZoomClose.BackColor = ThemeColor.PrimaryColor;
            panelTitle.BackColor = ThemeColor.PrimaryColor;

            SqlCommand command = new SqlCommand("SELECT MaPT as 'Mã Phiếu Thu', MaXe as 'Mã Xe', TongTien as 'Tổng Tiền', TienGuiXe as 'Tiền Gửi Xe', TienBaoHanh as 'Tiền Bảo Hành', NgayThu as 'Ngày Thu' FROM PhieuThu");
            System.Data.DataTable table = pt.getPhieuThu(command);

            this.dataGridViewDoanhThu.DataSource = table;
            this.dataGridViewDoanhThu.ReadOnly = true;
            this.dataGridViewDoanhThu.AllowUserToAddRows = false;
            this.dataGridViewDoanhThu.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
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

        PhieuThu pt = new PhieuThu();
        public void locDuLieu()
        {
            DateTime ngay = dateTimePickerNgay.Value;
            int yy = Convert.ToInt32(ngay.Year.ToString());
            int dd = Convert.ToInt32(ngay.Month.ToString());
            int kk = Convert.ToInt32(ngay.Day.ToString());

            SqlCommand command = new SqlCommand("SELECT MaPT as 'Mã Phiếu Thu', MaXe as 'Mã Xe', TongTien as 'Tổng Tiền', TienGuiXe as 'Tiền Gửi Xe', TienBaoHanh as 'Tiền Bảo Hành', NgayThu as 'Ngày Thu' FROM PhieuThu WHERE (DATEPART(yy, NgayThu) = '" + yy + "' AND    DATEPART(mm, NgayThu) = '" + dd + "' AND  DATEPART(dd, NgayThu) = '" + kk + "')");
            System.Data.DataTable table = pt.getPhieuThu(command);

            this.dataGridViewDoanhThu.DataSource = table;
            this.dataGridViewDoanhThu.ReadOnly = true;
            this.dataGridViewDoanhThu.AllowUserToAddRows = false;
            this.dataGridViewDoanhThu.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        public void Xuatfile()
        {
            string time = DateTime.Now.ToString("dd/MM/yyyy");
            string name = DateTime.Now.ToString("dd_MM_yyyy");
            if (this.dataGridViewDoanhThu.Rows.Count > 0)
            {
                // Tạo đường dẫn đến word
                _Application oWord = new Microsoft.Office.Interop.Word.Application();
                //Tạo một Document
                _Document wordDoc = oWord.Documents.Add();
                int ColumnCount = this.dataGridViewDoanhThu.Columns.Count;
                object missing = System.Reflection.Missing.Value;
                Paragraph para = wordDoc.Content.Paragraphs.Add(ref missing);
                para.Range.Text = "\t\t   TRƯỜNG ĐẠI HỌC SƯ PHẠM KĨ THUẬT TP HỒ CHÍ MINH";
                para.Range.Font.Size = 14;
                para.Range.Bold = 0;
                para.Range.InsertParagraphAfter();

                para.Range.Text = "PHÒNG ĐÀO TẠO";
                para.CharacterUnitFirstLineIndent = 0;
                para.Range.Underline = (WdUnderline)1;
                para.Range.Font.Size = 14;
                para.Range.Bold = 0;
                para.Range.InsertParagraphAfter();

                para.Range.Text = "\t\t\t\tHỌC KÌ 2 - NĂM HỌC 2020-2021";
                para.Range.Font.Size = 14;
                para.Range.Bold = 0;
                para.Range.Underline = 0;
                para.Range.InsertParagraphAfter();

                para.Range.Text = "Người thực hiện:";
                para.Range.Font.Size = 14;
                para.Range.Bold = 0;
                para.Range.Underline = 0;
                para.Range.InsertParagraphAfter();

                para.Range.Text = "Họ và tên: Hoàng Minh Thắng";
                para.Range.Font.Size = 14;
                para.Range.Bold = 0;
                para.Range.Underline = 0;
                para.Range.InsertParagraphAfter();

                para.Range.Text = "MSSV: 19110462";
                para.Range.Font.Size = 14;
                para.Range.Bold = 0;
                para.Range.Underline = 0;
                para.Range.InsertParagraphAfter();

                para.Range.Text = "Môn học: Lập trình windowns";
                para.Range.Font.Size = 14;
                para.Range.Bold = 0;
                para.Range.Underline = 0;
                para.Range.InsertParagraphAfter();


                para.Range.Text = "\t\t\tDANH SÁCH DOANH THU NGÀY " + time;
                para.Range.Font.Size = 16;
                para.Range.Bold = 1;
                para.Range.Underline = 0;
                para.Range.InsertParagraphAfter();

                // Tạo bảng danh sách sinh viên
                Paragraph para1 = wordDoc.Content.Paragraphs.Add(ref missing);
                Table tableST = wordDoc.Tables.Add(para1.Range, this.dataGridViewDoanhThu.Rows.Count + 1, this.dataGridViewDoanhThu.Columns.Count, ref missing, ref missing);
                //Xuất hiện khung table
                tableST.Borders.Enable = 1;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    tableST.Rows[1].Cells[c + 1].Range.Text = this.dataGridViewDoanhThu.Columns[c].HeaderText;
                }

                for (int i = 2; i <= tableST.Rows.Count; i++)
                {
                    for (int j = 1; j < tableST.Columns.Count + 1; j++)
                    {

                        //Lưu text
                        if (j != tableST.Columns.Count)
                        {
                            tableST.Rows[i].Cells[j].Range.Text = this.dataGridViewDoanhThu.Rows[i - 2].Cells[j - 1].Value.ToString();
                        }
                        else
                        {
                            tableST.Rows[i].Cells[j].Range.Text = ((DateTime)this.dataGridViewDoanhThu.Rows[i - 2].Cells[j - 1].Value).ToString("dd/MM/yyyy");
                        }
                        tableST.Rows[i].Cells[j].Range.Font.Bold = 0;
                        tableST.Rows[i].Cells[j].Range.Font.Size = 12;
                        tableST.Rows[i].Cells[j].Range.Font.Name = "Times New Roman";
                    }
                }
                // Lưu thông tin 
                object filename = @"D:\DoanhThu" +name+ ".docx";
                wordDoc.SaveAs2(ref filename);
                wordDoc.Close();
                oWord.Quit();
                MessageBox.Show("Data is Saved", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Hôm nay không có doanh thu", "Xuat file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void bunifuButtonLoc_Click(object sender, EventArgs e)
        {
            this.locDuLieu();
        }

        private void buttonXuatFIle_Click(object sender, EventArgs e)
        {
            this.Xuatfile();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            PrintDialog pDlg = new PrintDialog();
            PrintDocument pDoc = new PrintDocument();
            pDoc.DocumentName = "Print Document";
            pDlg.Document = pDoc;
            pDlg.AllowSelection = true;
            pDlg.AllowSomePages = true;
            pDoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            if (pDlg.ShowDialog() == DialogResult.OK)
            {
                printPreviewDialog1.Document = pDoc;
                printPreviewDialog1.ShowDialog();
                pDoc.Print();
            }
            else
            {
                MessageBox.Show("Ðã hủy in");
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string str = "";
            int row = dataGridViewDoanhThu.Rows.Count;
            int cell = dataGridViewDoanhThu.Rows[1].Cells.Count;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < cell; j++)
                {
                    if (dataGridViewDoanhThu.Rows[i].Cells[j].Value == null)
                    {
                        dataGridViewDoanhThu.Rows[i].Cells[j].Value = "null";
                    }
                    str += dataGridViewDoanhThu.Rows[i].Cells[j].Value.ToString().Trim() + " , ";
                }
                str += "\n";
            }

            e.Graphics.DrawString(str, new System.Drawing.Font("Arial", 30), Brushes.Black, new System.Drawing.Point(10, 10));
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
