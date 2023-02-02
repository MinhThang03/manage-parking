
namespace PlayerUI
{
    partial class ChiaCaNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChiaCaNhanVien));
            this.BtnSua = new Bunifu.Framework.UI.BunifuThinButton2();
            this.dataGridViewChiaCaNV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChiaCaNV)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSua
            // 
            this.BtnSua.ActiveBorderThickness = 1;
            this.BtnSua.ActiveCornerRadius = 20;
            this.BtnSua.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.BtnSua.ActiveForecolor = System.Drawing.Color.White;
            this.BtnSua.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.BtnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnSua.BackColor = System.Drawing.Color.White;
            this.BtnSua.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnSua.BackgroundImage")));
            this.BtnSua.ButtonText = "Chia ca";
            this.BtnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSua.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSua.ForeColor = System.Drawing.Color.SeaGreen;
            this.BtnSua.IdleBorderThickness = 1;
            this.BtnSua.IdleCornerRadius = 20;
            this.BtnSua.IdleFillColor = System.Drawing.Color.White;
            this.BtnSua.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.BtnSua.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.BtnSua.Location = new System.Drawing.Point(13, 378);
            this.BtnSua.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSua.Name = "BtnSua";
            this.BtnSua.Size = new System.Drawing.Size(189, 51);
            this.BtnSua.TabIndex = 25;
            this.BtnSua.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnSua.Click += new System.EventHandler(this.BtnSua_Click);
            // 
            // dataGridViewChiaCaNV
            // 
            this.dataGridViewChiaCaNV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewChiaCaNV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewChiaCaNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewChiaCaNV.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewChiaCaNV.Name = "dataGridViewChiaCaNV";
            this.dataGridViewChiaCaNV.RowHeadersWidth = 51;
            this.dataGridViewChiaCaNV.RowTemplate.Height = 24;
            this.dataGridViewChiaCaNV.Size = new System.Drawing.Size(712, 359);
            this.dataGridViewChiaCaNV.TabIndex = 26;
            // 
            // ChiaCaNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(736, 442);
            this.Controls.Add(this.dataGridViewChiaCaNV);
            this.Controls.Add(this.BtnSua);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChiaCaNhanVien";
            this.Text = "ChiaCaNhanVien";
            this.Load += new System.EventHandler(this.ChiaCaNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChiaCaNV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuThinButton2 BtnSua;
        private System.Windows.Forms.DataGridView dataGridViewChiaCaNV;
    }
}