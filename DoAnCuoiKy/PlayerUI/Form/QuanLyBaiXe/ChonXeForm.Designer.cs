
namespace PlayerUI
{
    partial class ChonXeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChonXeForm));
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            this.dataGridViewChonXe = new System.Windows.Forms.DataGridView();
            this.comboBoxLuaChon = new System.Windows.Forms.ComboBox();
            this.TextBoxMaXe = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.panelMagirleft = new System.Windows.Forms.Panel();
            this.panelHeard = new System.Windows.Forms.Panel();
            this.panelZoomClose = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.TitleChiTietBaoHanh = new System.Windows.Forms.Label();
            this.MinimizeBtnImg = new PlayerUI.ButtonImage_Hover();
            this.MaximizeBtnImg = new PlayerUI.ButtonImage_Hover();
            this.CloseBtnImg = new PlayerUI.ButtonImage_Hover();
            this.buttonImage_Hover1 = new PlayerUI.ButtonImage_Hover();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChonXe)).BeginInit();
            this.panelHeard.SuspendLayout();
            this.panelZoomClose.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeBtnImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximizeBtnImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBtnImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonImage_Hover1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewChonXe
            // 
            this.dataGridViewChonXe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewChonXe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewChonXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewChonXe.Location = new System.Drawing.Point(70, 141);
            this.dataGridViewChonXe.Name = "dataGridViewChonXe";
            this.dataGridViewChonXe.RowHeadersWidth = 51;
            this.dataGridViewChonXe.RowTemplate.Height = 24;
            this.dataGridViewChonXe.Size = new System.Drawing.Size(802, 377);
            this.dataGridViewChonXe.TabIndex = 27;
            // 
            // comboBoxLuaChon
            // 
            this.comboBoxLuaChon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBoxLuaChon.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.comboBoxLuaChon.FormattingEnabled = true;
            this.comboBoxLuaChon.Items.AddRange(new object[] {
            "Tất cả",
            "Xe ô tô",
            "Xe máy",
            "Xe đạp"});
            this.comboBoxLuaChon.Location = new System.Drawing.Point(70, 99);
            this.comboBoxLuaChon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxLuaChon.Name = "comboBoxLuaChon";
            this.comboBoxLuaChon.Size = new System.Drawing.Size(252, 29);
            this.comboBoxLuaChon.TabIndex = 118;
            this.comboBoxLuaChon.SelectedIndexChanged += new System.EventHandler(this.comboBoxtinhTrang_SelectedIndexChanged);
            // 
            // TextBoxMaXe
            // 
            this.TextBoxMaXe.AcceptsReturn = false;
            this.TextBoxMaXe.AcceptsTab = false;
            this.TextBoxMaXe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TextBoxMaXe.AnimationSpeed = 200;
            this.TextBoxMaXe.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.TextBoxMaXe.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.TextBoxMaXe.BackColor = System.Drawing.Color.Transparent;
            this.TextBoxMaXe.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TextBoxMaXe.BackgroundImage")));
            this.TextBoxMaXe.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.TextBoxMaXe.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.TextBoxMaXe.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.TextBoxMaXe.BorderColorIdle = System.Drawing.Color.Silver;
            this.TextBoxMaXe.BorderRadius = 1;
            this.TextBoxMaXe.BorderThickness = 1;
            this.TextBoxMaXe.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TextBoxMaXe.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxMaXe.DefaultFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.TextBoxMaXe.DefaultText = "";
            this.TextBoxMaXe.FillColor = System.Drawing.Color.White;
            this.TextBoxMaXe.HideSelection = true;
            this.TextBoxMaXe.IconLeft = null;
            this.TextBoxMaXe.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxMaXe.IconPadding = 10;
            this.TextBoxMaXe.IconRight = null;
            this.TextBoxMaXe.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxMaXe.Lines = new string[0];
            this.TextBoxMaXe.Location = new System.Drawing.Point(647, 100);
            this.TextBoxMaXe.Margin = new System.Windows.Forms.Padding(36, 32, 36, 32);
            this.TextBoxMaXe.MaxLength = 32767;
            this.TextBoxMaXe.MinimumSize = new System.Drawing.Size(107, 28);
            this.TextBoxMaXe.Modified = false;
            this.TextBoxMaXe.Multiline = false;
            this.TextBoxMaXe.Name = "TextBoxMaXe";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.TextBoxMaXe.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.Empty;
            stateProperties2.FillColor = System.Drawing.Color.White;
            stateProperties2.ForeColor = System.Drawing.Color.Empty;
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.TextBoxMaXe.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.TextBoxMaXe.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.TextBoxMaXe.OnIdleState = stateProperties4;
            this.TextBoxMaXe.PasswordChar = '\0';
            this.TextBoxMaXe.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.TextBoxMaXe.PlaceholderText = "Mã Xe";
            this.TextBoxMaXe.ReadOnly = false;
            this.TextBoxMaXe.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxMaXe.SelectedText = "";
            this.TextBoxMaXe.SelectionLength = 0;
            this.TextBoxMaXe.SelectionStart = 0;
            this.TextBoxMaXe.ShortcutsEnabled = true;
            this.TextBoxMaXe.Size = new System.Drawing.Size(225, 28);
            this.TextBoxMaXe.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.TextBoxMaXe.TabIndex = 120;
            this.TextBoxMaXe.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBoxMaXe.TextMarginBottom = 0;
            this.TextBoxMaXe.TextMarginLeft = 5;
            this.TextBoxMaXe.TextMarginTop = 0;
            this.TextBoxMaXe.TextPlaceholder = "Mã Xe";
            this.TextBoxMaXe.UseSystemPasswordChar = false;
            this.TextBoxMaXe.WordWrap = true;
            this.TextBoxMaXe.TextChanged += new System.EventHandler(this.TextBoxMaXe_TextChanged);
            // 
            // panelMagirleft
            // 
            this.panelMagirleft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.panelMagirleft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMagirleft.Location = new System.Drawing.Point(0, 69);
            this.panelMagirleft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelMagirleft.Name = "panelMagirleft";
            this.panelMagirleft.Size = new System.Drawing.Size(58, 461);
            this.panelMagirleft.TabIndex = 122;
            // 
            // panelHeard
            // 
            this.panelHeard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.panelHeard.Controls.Add(this.TitleChiTietBaoHanh);
            this.panelHeard.Controls.Add(this.panelZoomClose);
            this.panelHeard.Controls.Add(this.panelLogo);
            this.panelHeard.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeard.Location = new System.Drawing.Point(0, 0);
            this.panelHeard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelHeard.Name = "panelHeard";
            this.panelHeard.Size = new System.Drawing.Size(884, 69);
            this.panelHeard.TabIndex = 121;
            // 
            // panelZoomClose
            // 
            this.panelZoomClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.panelZoomClose.Controls.Add(this.panel8);
            this.panelZoomClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelZoomClose.Location = new System.Drawing.Point(786, 0);
            this.panelZoomClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelZoomClose.Name = "panelZoomClose";
            this.panelZoomClose.Size = new System.Drawing.Size(98, 69);
            this.panelZoomClose.TabIndex = 13;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Controls.Add(this.panel10);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(98, 20);
            this.panel8.TabIndex = 3;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.MinimizeBtnImg);
            this.panel9.Controls.Add(this.MaximizeBtnImg);
            this.panel9.Controls.Add(this.CloseBtnImg);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 4);
            this.panel9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(98, 16);
            this.panel9.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(98, 4);
            this.panel10.TabIndex = 0;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelLogo.Controls.Add(this.buttonImage_Hover1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(58, 69);
            this.panelLogo.TabIndex = 9;
            // 
            // TitleChiTietBaoHanh
            // 
            this.TitleChiTietBaoHanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleChiTietBaoHanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleChiTietBaoHanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.TitleChiTietBaoHanh.Location = new System.Drawing.Point(58, 0);
            this.TitleChiTietBaoHanh.Name = "TitleChiTietBaoHanh";
            this.TitleChiTietBaoHanh.Size = new System.Drawing.Size(728, 69);
            this.TitleChiTietBaoHanh.TabIndex = 123;
            this.TitleChiTietBaoHanh.Text = "Chọn xe";
            this.TitleChiTietBaoHanh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MinimizeBtnImg
            // 
            this.MinimizeBtnImg.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinimizeBtnImg.Image = ((System.Drawing.Image)(resources.GetObject("MinimizeBtnImg.Image")));
            this.MinimizeBtnImg.ImageHover = ((System.Drawing.Image)(resources.GetObject("MinimizeBtnImg.ImageHover")));
            this.MinimizeBtnImg.ImageNormal = ((System.Drawing.Image)(resources.GetObject("MinimizeBtnImg.ImageNormal")));
            this.MinimizeBtnImg.Location = new System.Drawing.Point(5, 0);
            this.MinimizeBtnImg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimizeBtnImg.Name = "MinimizeBtnImg";
            this.MinimizeBtnImg.Size = new System.Drawing.Size(31, 16);
            this.MinimizeBtnImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MinimizeBtnImg.TabIndex = 9;
            this.MinimizeBtnImg.TabStop = false;
            this.MinimizeBtnImg.Click += new System.EventHandler(this.MinimizeBtnImg_Click);
            // 
            // MaximizeBtnImg
            // 
            this.MaximizeBtnImg.Dock = System.Windows.Forms.DockStyle.Right;
            this.MaximizeBtnImg.Image = ((System.Drawing.Image)(resources.GetObject("MaximizeBtnImg.Image")));
            this.MaximizeBtnImg.ImageHover = ((System.Drawing.Image)(resources.GetObject("MaximizeBtnImg.ImageHover")));
            this.MaximizeBtnImg.ImageNormal = ((System.Drawing.Image)(resources.GetObject("MaximizeBtnImg.ImageNormal")));
            this.MaximizeBtnImg.Location = new System.Drawing.Point(36, 0);
            this.MaximizeBtnImg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBtnImg.Name = "MaximizeBtnImg";
            this.MaximizeBtnImg.Size = new System.Drawing.Size(31, 16);
            this.MaximizeBtnImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MaximizeBtnImg.TabIndex = 7;
            this.MaximizeBtnImg.TabStop = false;
            this.MaximizeBtnImg.Click += new System.EventHandler(this.MaximizeBtnImg_Click);
            // 
            // CloseBtnImg
            // 
            this.CloseBtnImg.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseBtnImg.Image = ((System.Drawing.Image)(resources.GetObject("CloseBtnImg.Image")));
            this.CloseBtnImg.ImageHover = ((System.Drawing.Image)(resources.GetObject("CloseBtnImg.ImageHover")));
            this.CloseBtnImg.ImageNormal = ((System.Drawing.Image)(resources.GetObject("CloseBtnImg.ImageNormal")));
            this.CloseBtnImg.Location = new System.Drawing.Point(67, 0);
            this.CloseBtnImg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CloseBtnImg.Name = "CloseBtnImg";
            this.CloseBtnImg.Size = new System.Drawing.Size(31, 16);
            this.CloseBtnImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CloseBtnImg.TabIndex = 8;
            this.CloseBtnImg.TabStop = false;
            this.CloseBtnImg.Click += new System.EventHandler(this.CloseBtnImg_Click);
            // 
            // buttonImage_Hover1
            // 
            this.buttonImage_Hover1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonImage_Hover1.Image = ((System.Drawing.Image)(resources.GetObject("buttonImage_Hover1.Image")));
            this.buttonImage_Hover1.ImageHover = ((System.Drawing.Image)(resources.GetObject("buttonImage_Hover1.ImageHover")));
            this.buttonImage_Hover1.ImageNormal = ((System.Drawing.Image)(resources.GetObject("buttonImage_Hover1.ImageNormal")));
            this.buttonImage_Hover1.Location = new System.Drawing.Point(0, 0);
            this.buttonImage_Hover1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonImage_Hover1.Name = "buttonImage_Hover1";
            this.buttonImage_Hover1.Size = new System.Drawing.Size(58, 69);
            this.buttonImage_Hover1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonImage_Hover1.TabIndex = 124;
            this.buttonImage_Hover1.TabStop = false;
            // 
            // ChonXeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 530);
            this.Controls.Add(this.panelMagirleft);
            this.Controls.Add(this.panelHeard);
            this.Controls.Add(this.TextBoxMaXe);
            this.Controls.Add(this.comboBoxLuaChon);
            this.Controls.Add(this.dataGridViewChonXe);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChonXeForm";
            this.Text = "ChonXeForm";
            this.Load += new System.EventHandler(this.ChonXeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChonXe)).EndInit();
            this.panelHeard.ResumeLayout(false);
            this.panelZoomClose.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeBtnImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximizeBtnImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBtnImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonImage_Hover1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridViewChonXe;
        private System.Windows.Forms.ComboBox comboBoxLuaChon;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox TextBoxMaXe;
        private System.Windows.Forms.Panel panelMagirleft;
        private System.Windows.Forms.Panel panelHeard;
        private System.Windows.Forms.Panel panelZoomClose;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private ButtonImage_Hover MinimizeBtnImg;
        private ButtonImage_Hover MaximizeBtnImg;
        private ButtonImage_Hover CloseBtnImg;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label TitleChiTietBaoHanh;
        private ButtonImage_Hover buttonImage_Hover1;
    }
}