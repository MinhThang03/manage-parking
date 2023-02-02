
namespace PlayerUI
{
    partial class CheckInOut
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckInOut));
            this.radioButtonSang = new Bunifu.UI.WinForms.BunifuRadioButton();
            this.radioButtonToi = new Bunifu.UI.WinForms.BunifuRadioButton();
            this.radioButtonTrua = new Bunifu.UI.WinForms.BunifuRadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BaiXeDap = new System.Windows.Forms.Label();
            this.buttonStart = new Bunifu.Framework.UI.BunifuThinButton2();
            this.ButtonStop = new Bunifu.Framework.UI.BunifuThinButton2();
            this.buttonImage_Hover1 = new PlayerUI.ButtonImage_Hover();
            this.timerCheck = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.buttonImage_Hover1)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButtonSang
            // 
            this.radioButtonSang.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioButtonSang.Checked = false;
            this.radioButtonSang.Location = new System.Drawing.Point(99, 154);
            this.radioButtonSang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonSang.Name = "radioButtonSang";
            this.radioButtonSang.OutlineColor = System.Drawing.Color.Purple;
            this.radioButtonSang.RadioColor = System.Drawing.Color.Purple;
            this.radioButtonSang.Size = new System.Drawing.Size(39, 39);
            this.radioButtonSang.TabIndex = 44;
            this.radioButtonSang.Text = null;
            // 
            // radioButtonToi
            // 
            this.radioButtonToi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioButtonToi.Checked = false;
            this.radioButtonToi.Location = new System.Drawing.Point(584, 154);
            this.radioButtonToi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonToi.Name = "radioButtonToi";
            this.radioButtonToi.OutlineColor = System.Drawing.Color.Purple;
            this.radioButtonToi.RadioColor = System.Drawing.Color.Purple;
            this.radioButtonToi.Size = new System.Drawing.Size(39, 39);
            this.radioButtonToi.TabIndex = 43;
            this.radioButtonToi.Text = null;
            // 
            // radioButtonTrua
            // 
            this.radioButtonTrua.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioButtonTrua.Checked = true;
            this.radioButtonTrua.Location = new System.Drawing.Point(340, 154);
            this.radioButtonTrua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonTrua.Name = "radioButtonTrua";
            this.radioButtonTrua.OutlineColor = System.Drawing.Color.Purple;
            this.radioButtonTrua.RadioColor = System.Drawing.Color.Purple;
            this.radioButtonTrua.Size = new System.Drawing.Size(39, 39);
            this.radioButtonTrua.TabIndex = 42;
            this.radioButtonTrua.Text = null;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(542, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 23);
            this.label2.TabIndex = 41;
            this.label2.Text = "Ca tối 18h - 22h";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(289, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 23);
            this.label1.TabIndex = 40;
            this.label1.Text = "Ca chiều 13h - 17h";
            // 
            // BaiXeDap
            // 
            this.BaiXeDap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BaiXeDap.AutoSize = true;
            this.BaiXeDap.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaiXeDap.Location = new System.Drawing.Point(52, 107);
            this.BaiXeDap.Name = "BaiXeDap";
            this.BaiXeDap.Size = new System.Drawing.Size(169, 23);
            this.BaiXeDap.TabIndex = 39;
            this.BaiXeDap.Text = "Ca sáng 7h -11h";
            // 
            // buttonStart
            // 
            this.buttonStart.ActiveBorderThickness = 1;
            this.buttonStart.ActiveCornerRadius = 20;
            this.buttonStart.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.buttonStart.ActiveForecolor = System.Drawing.Color.White;
            this.buttonStart.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.buttonStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonStart.BackColor = System.Drawing.Color.White;
            this.buttonStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonStart.BackgroundImage")));
            this.buttonStart.ButtonText = "Bắt đầu";
            this.buttonStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStart.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.buttonStart.ForeColor = System.Drawing.Color.SeaGreen;
            this.buttonStart.IdleBorderThickness = 1;
            this.buttonStart.IdleCornerRadius = 20;
            this.buttonStart.IdleFillColor = System.Drawing.Color.White;
            this.buttonStart.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.buttonStart.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.buttonStart.Location = new System.Drawing.Point(30, 305);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(245, 64);
            this.buttonStart.TabIndex = 101;
            this.buttonStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // ButtonStop
            // 
            this.ButtonStop.ActiveBorderThickness = 1;
            this.ButtonStop.ActiveCornerRadius = 20;
            this.ButtonStop.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.ButtonStop.ActiveForecolor = System.Drawing.Color.White;
            this.ButtonStop.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.ButtonStop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ButtonStop.BackColor = System.Drawing.Color.White;
            this.ButtonStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonStop.BackgroundImage")));
            this.ButtonStop.ButtonText = "Dừng ";
            this.ButtonStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonStop.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.ButtonStop.ForeColor = System.Drawing.Color.SeaGreen;
            this.ButtonStop.IdleBorderThickness = 1;
            this.ButtonStop.IdleCornerRadius = 20;
            this.ButtonStop.IdleFillColor = System.Drawing.Color.White;
            this.ButtonStop.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.ButtonStop.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.ButtonStop.Location = new System.Drawing.Point(454, 305);
            this.ButtonStop.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(245, 64);
            this.ButtonStop.TabIndex = 102;
            this.ButtonStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // buttonImage_Hover1
            // 
            this.buttonImage_Hover1.Image = ((System.Drawing.Image)(resources.GetObject("buttonImage_Hover1.Image")));
            this.buttonImage_Hover1.ImageHover = ((System.Drawing.Image)(resources.GetObject("buttonImage_Hover1.ImageHover")));
            this.buttonImage_Hover1.ImageNormal = ((System.Drawing.Image)(resources.GetObject("buttonImage_Hover1.ImageNormal")));
            this.buttonImage_Hover1.Location = new System.Drawing.Point(325, 302);
            this.buttonImage_Hover1.Name = "buttonImage_Hover1";
            this.buttonImage_Hover1.Size = new System.Drawing.Size(70, 67);
            this.buttonImage_Hover1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonImage_Hover1.TabIndex = 103;
            this.buttonImage_Hover1.TabStop = false;
            // 
            // timerCheck
            // 
            this.timerCheck.Tick += new System.EventHandler(this.timerCheck_Tick);
            // 
            // CheckInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(736, 442);
            this.Controls.Add(this.buttonImage_Hover1);
            this.Controls.Add(this.ButtonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.radioButtonSang);
            this.Controls.Add(this.radioButtonToi);
            this.Controls.Add(this.radioButtonTrua);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BaiXeDap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CheckInOut";
            this.Text = "CheckInOut";
            this.Load += new System.EventHandler(this.CheckInOut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.buttonImage_Hover1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuRadioButton radioButtonSang;
        private Bunifu.UI.WinForms.BunifuRadioButton radioButtonToi;
        private Bunifu.UI.WinForms.BunifuRadioButton radioButtonTrua;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label BaiXeDap;
        private Bunifu.Framework.UI.BunifuThinButton2 buttonStart;
        private Bunifu.Framework.UI.BunifuThinButton2 ButtonStop;
        private ButtonImage_Hover buttonImage_Hover1;
        private System.Windows.Forms.Timer timerCheck;
    }
}