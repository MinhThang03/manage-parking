
namespace PlayerUI
{
    partial class LichCV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LichCV));
            this.dataGridViewLichCV = new System.Windows.Forms.DataGridView();
            this.comboBoxMaNV = new System.Windows.Forms.ComboBox();
            this.comboBoxCaLam = new System.Windows.Forms.ComboBox();
            this.buttonGui = new Bunifu.Framework.UI.BunifuThinButton2();
            this.buttonThayCa = new Bunifu.Framework.UI.BunifuThinButton2();
            this.buttonImage_Hover1 = new PlayerUI.ButtonImage_Hover();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLichCV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonImage_Hover1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewLichCV
            // 
            this.dataGridViewLichCV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridViewLichCV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLichCV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLichCV.Location = new System.Drawing.Point(20, 25);
            this.dataGridViewLichCV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewLichCV.Name = "dataGridViewLichCV";
            this.dataGridViewLichCV.RowHeadersWidth = 62;
            this.dataGridViewLichCV.RowTemplate.Height = 28;
            this.dataGridViewLichCV.Size = new System.Drawing.Size(704, 251);
            this.dataGridViewLichCV.TabIndex = 0;
            // 
            // comboBoxMaNV
            // 
            this.comboBoxMaNV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBoxMaNV.FormattingEnabled = true;
            this.comboBoxMaNV.Location = new System.Drawing.Point(456, 309);
            this.comboBoxMaNV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxMaNV.Name = "comboBoxMaNV";
            this.comboBoxMaNV.Size = new System.Drawing.Size(268, 24);
            this.comboBoxMaNV.TabIndex = 109;
            // 
            // comboBoxCaLam
            // 
            this.comboBoxCaLam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBoxCaLam.FormattingEnabled = true;
            this.comboBoxCaLam.Location = new System.Drawing.Point(13, 309);
            this.comboBoxCaLam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxCaLam.Name = "comboBoxCaLam";
            this.comboBoxCaLam.Size = new System.Drawing.Size(262, 24);
            this.comboBoxCaLam.TabIndex = 108;
            this.comboBoxCaLam.SelectedIndexChanged += new System.EventHandler(this.comboBoxCaLam_SelectedIndexChanged);
            // 
            // buttonGui
            // 
            this.buttonGui.ActiveBorderThickness = 1;
            this.buttonGui.ActiveCornerRadius = 20;
            this.buttonGui.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.buttonGui.ActiveForecolor = System.Drawing.Color.White;
            this.buttonGui.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.buttonGui.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonGui.BackColor = System.Drawing.Color.White;
            this.buttonGui.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonGui.BackgroundImage")));
            this.buttonGui.ButtonText = "Gửi tin nhắn";
            this.buttonGui.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGui.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.buttonGui.ForeColor = System.Drawing.Color.SeaGreen;
            this.buttonGui.IdleBorderThickness = 1;
            this.buttonGui.IdleCornerRadius = 20;
            this.buttonGui.IdleFillColor = System.Drawing.Color.White;
            this.buttonGui.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.buttonGui.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.buttonGui.Location = new System.Drawing.Point(523, 364);
            this.buttonGui.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGui.Name = "buttonGui";
            this.buttonGui.Size = new System.Drawing.Size(200, 65);
            this.buttonGui.TabIndex = 107;
            this.buttonGui.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonGui.Click += new System.EventHandler(this.buttonGui_Click);
            // 
            // buttonThayCa
            // 
            this.buttonThayCa.ActiveBorderThickness = 1;
            this.buttonThayCa.ActiveCornerRadius = 20;
            this.buttonThayCa.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.buttonThayCa.ActiveForecolor = System.Drawing.Color.White;
            this.buttonThayCa.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.buttonThayCa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonThayCa.BackColor = System.Drawing.Color.White;
            this.buttonThayCa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonThayCa.BackgroundImage")));
            this.buttonThayCa.ButtonText = "Thay Ca";
            this.buttonThayCa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonThayCa.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.buttonThayCa.ForeColor = System.Drawing.Color.SeaGreen;
            this.buttonThayCa.IdleBorderThickness = 1;
            this.buttonThayCa.IdleCornerRadius = 20;
            this.buttonThayCa.IdleFillColor = System.Drawing.Color.White;
            this.buttonThayCa.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.buttonThayCa.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.buttonThayCa.Location = new System.Drawing.Point(13, 364);
            this.buttonThayCa.Margin = new System.Windows.Forms.Padding(4);
            this.buttonThayCa.Name = "buttonThayCa";
            this.buttonThayCa.Size = new System.Drawing.Size(200, 65);
            this.buttonThayCa.TabIndex = 106;
            this.buttonThayCa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonThayCa.Click += new System.EventHandler(this.buttonThayCa_Click);
            // 
            // buttonImage_Hover1
            // 
            this.buttonImage_Hover1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonImage_Hover1.Image = ((System.Drawing.Image)(resources.GetObject("buttonImage_Hover1.Image")));
            this.buttonImage_Hover1.ImageHover = ((System.Drawing.Image)(resources.GetObject("buttonImage_Hover1.ImageHover")));
            this.buttonImage_Hover1.ImageNormal = ((System.Drawing.Image)(resources.GetObject("buttonImage_Hover1.ImageNormal")));
            this.buttonImage_Hover1.Location = new System.Drawing.Point(324, 299);
            this.buttonImage_Hover1.Name = "buttonImage_Hover1";
            this.buttonImage_Hover1.Size = new System.Drawing.Size(115, 158);
            this.buttonImage_Hover1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonImage_Hover1.TabIndex = 110;
            this.buttonImage_Hover1.TabStop = false;
            // 
            // LichCV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(736, 442);
            this.Controls.Add(this.buttonImage_Hover1);
            this.Controls.Add(this.comboBoxMaNV);
            this.Controls.Add(this.comboBoxCaLam);
            this.Controls.Add(this.buttonGui);
            this.Controls.Add(this.buttonThayCa);
            this.Controls.Add(this.dataGridViewLichCV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LichCV";
            this.Text = "LichCV";
            this.Load += new System.EventHandler(this.LichCV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLichCV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonImage_Hover1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLichCV;
        private System.Windows.Forms.ComboBox comboBoxMaNV;
        private System.Windows.Forms.ComboBox comboBoxCaLam;
        private Bunifu.Framework.UI.BunifuThinButton2 buttonGui;
        private Bunifu.Framework.UI.BunifuThinButton2 buttonThayCa;
        private ButtonImage_Hover buttonImage_Hover1;
    }
}