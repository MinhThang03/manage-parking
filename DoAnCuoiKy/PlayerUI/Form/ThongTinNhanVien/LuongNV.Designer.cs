
namespace PlayerUI
{
    partial class LuongNV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LuongNV));
            this.dataGridViewLuong = new System.Windows.Forms.DataGridView();
            this.buttonPhat = new Bunifu.Framework.UI.BunifuThinButton2();
            this.buttonTinhLuong = new Bunifu.Framework.UI.BunifuThinButton2();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewLuong
            // 
            this.dataGridViewLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLuong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLuong.Location = new System.Drawing.Point(21, 22);
            this.dataGridViewLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewLuong.Name = "dataGridViewLuong";
            this.dataGridViewLuong.RowHeadersWidth = 62;
            this.dataGridViewLuong.RowTemplate.Height = 28;
            this.dataGridViewLuong.Size = new System.Drawing.Size(693, 354);
            this.dataGridViewLuong.TabIndex = 0;
            // 
            // buttonPhat
            // 
            this.buttonPhat.ActiveBorderThickness = 1;
            this.buttonPhat.ActiveCornerRadius = 20;
            this.buttonPhat.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.buttonPhat.ActiveForecolor = System.Drawing.Color.White;
            this.buttonPhat.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.buttonPhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPhat.BackColor = System.Drawing.Color.White;
            this.buttonPhat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPhat.BackgroundImage")));
            this.buttonPhat.ButtonText = "Phát Lương";
            this.buttonPhat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPhat.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.buttonPhat.ForeColor = System.Drawing.Color.SeaGreen;
            this.buttonPhat.IdleBorderThickness = 1;
            this.buttonPhat.IdleCornerRadius = 20;
            this.buttonPhat.IdleFillColor = System.Drawing.Color.White;
            this.buttonPhat.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.buttonPhat.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.buttonPhat.Location = new System.Drawing.Point(21, 390);
            this.buttonPhat.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPhat.Name = "buttonPhat";
            this.buttonPhat.Size = new System.Drawing.Size(200, 41);
            this.buttonPhat.TabIndex = 102;
            this.buttonPhat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonPhat.Click += new System.EventHandler(this.buttonPhat_Click);
            // 
            // buttonTinhLuong
            // 
            this.buttonTinhLuong.ActiveBorderThickness = 1;
            this.buttonTinhLuong.ActiveCornerRadius = 20;
            this.buttonTinhLuong.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.buttonTinhLuong.ActiveForecolor = System.Drawing.Color.White;
            this.buttonTinhLuong.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.buttonTinhLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTinhLuong.BackColor = System.Drawing.Color.White;
            this.buttonTinhLuong.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTinhLuong.BackgroundImage")));
            this.buttonTinhLuong.ButtonText = "Tính Lương";
            this.buttonTinhLuong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTinhLuong.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.buttonTinhLuong.ForeColor = System.Drawing.Color.SeaGreen;
            this.buttonTinhLuong.IdleBorderThickness = 1;
            this.buttonTinhLuong.IdleCornerRadius = 20;
            this.buttonTinhLuong.IdleFillColor = System.Drawing.Color.White;
            this.buttonTinhLuong.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.buttonTinhLuong.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.buttonTinhLuong.Location = new System.Drawing.Point(588, 390);
            this.buttonTinhLuong.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTinhLuong.Name = "buttonTinhLuong";
            this.buttonTinhLuong.Size = new System.Drawing.Size(127, 41);
            this.buttonTinhLuong.TabIndex = 103;
            this.buttonTinhLuong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonTinhLuong.Click += new System.EventHandler(this.buttonTinhLuong_Click);
            // 
            // LuongNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(736, 442);
            this.Controls.Add(this.buttonTinhLuong);
            this.Controls.Add(this.buttonPhat);
            this.Controls.Add(this.dataGridViewLuong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LuongNV";
            this.Text = "LichCV";
            this.Load += new System.EventHandler(this.LuongNV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLuong;
        private Bunifu.Framework.UI.BunifuThinButton2 buttonPhat;
        private Bunifu.Framework.UI.BunifuThinButton2 buttonTinhLuong;
    }
}