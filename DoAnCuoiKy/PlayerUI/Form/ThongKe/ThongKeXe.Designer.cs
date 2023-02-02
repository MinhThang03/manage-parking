
namespace PlayerUI
{
    partial class ThongKeXe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThongKeXe));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.buttonThongKeTrongNgay = new Bunifu.Framework.UI.BunifuThinButton2();
            this.buttonThongKeToanBo = new Bunifu.Framework.UI.BunifuThinButton2();
            this.chartLoaiXe = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartLoaiXe)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonThongKeTrongNgay
            // 
            this.buttonThongKeTrongNgay.ActiveBorderThickness = 1;
            this.buttonThongKeTrongNgay.ActiveCornerRadius = 20;
            this.buttonThongKeTrongNgay.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.buttonThongKeTrongNgay.ActiveForecolor = System.Drawing.Color.White;
            this.buttonThongKeTrongNgay.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.buttonThongKeTrongNgay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonThongKeTrongNgay.BackColor = System.Drawing.Color.White;
            this.buttonThongKeTrongNgay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonThongKeTrongNgay.BackgroundImage")));
            this.buttonThongKeTrongNgay.ButtonText = "Thống kê xe hiện có trong bến";
            this.buttonThongKeTrongNgay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonThongKeTrongNgay.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.buttonThongKeTrongNgay.ForeColor = System.Drawing.Color.SeaGreen;
            this.buttonThongKeTrongNgay.IdleBorderThickness = 1;
            this.buttonThongKeTrongNgay.IdleCornerRadius = 20;
            this.buttonThongKeTrongNgay.IdleFillColor = System.Drawing.Color.White;
            this.buttonThongKeTrongNgay.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.buttonThongKeTrongNgay.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.buttonThongKeTrongNgay.Location = new System.Drawing.Point(55, 358);
            this.buttonThongKeTrongNgay.Margin = new System.Windows.Forms.Padding(4);
            this.buttonThongKeTrongNgay.Name = "buttonThongKeTrongNgay";
            this.buttonThongKeTrongNgay.Size = new System.Drawing.Size(200, 64);
            this.buttonThongKeTrongNgay.TabIndex = 102;
            this.buttonThongKeTrongNgay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonThongKeTrongNgay.Click += new System.EventHandler(this.buttonThongKeTrongNgay_Click);
            // 
            // buttonThongKeToanBo
            // 
            this.buttonThongKeToanBo.ActiveBorderThickness = 1;
            this.buttonThongKeToanBo.ActiveCornerRadius = 20;
            this.buttonThongKeToanBo.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.buttonThongKeToanBo.ActiveForecolor = System.Drawing.Color.White;
            this.buttonThongKeToanBo.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.buttonThongKeToanBo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonThongKeToanBo.BackColor = System.Drawing.Color.White;
            this.buttonThongKeToanBo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonThongKeToanBo.BackgroundImage")));
            this.buttonThongKeToanBo.ButtonText = "Thống kê toàn bộ";
            this.buttonThongKeToanBo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonThongKeToanBo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.buttonThongKeToanBo.ForeColor = System.Drawing.Color.SeaGreen;
            this.buttonThongKeToanBo.IdleBorderThickness = 1;
            this.buttonThongKeToanBo.IdleCornerRadius = 20;
            this.buttonThongKeToanBo.IdleFillColor = System.Drawing.Color.White;
            this.buttonThongKeToanBo.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.buttonThongKeToanBo.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.buttonThongKeToanBo.Location = new System.Drawing.Point(438, 358);
            this.buttonThongKeToanBo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonThongKeToanBo.Name = "buttonThongKeToanBo";
            this.buttonThongKeToanBo.Size = new System.Drawing.Size(200, 64);
            this.buttonThongKeToanBo.TabIndex = 103;
            this.buttonThongKeToanBo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonThongKeToanBo.Click += new System.EventHandler(this.buttonThongKeToanBo_Click);
            // 
            // chartLoaiXe
            // 
            this.chartLoaiXe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            chartArea1.Name = "ChartArea1";
            this.chartLoaiXe.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartLoaiXe.Legends.Add(legend1);
            this.chartLoaiXe.Location = new System.Drawing.Point(55, 74);
            this.chartLoaiXe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartLoaiXe.Name = "chartLoaiXe";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "loai";
            this.chartLoaiXe.Series.Add(series1);
            this.chartLoaiXe.Size = new System.Drawing.Size(409, 254);
            this.chartLoaiXe.TabIndex = 105;
            this.chartLoaiXe.Text = "chart2";
            // 
            // ThongKeXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(736, 442);
            this.Controls.Add(this.chartLoaiXe);
            this.Controls.Add(this.buttonThongKeToanBo);
            this.Controls.Add(this.buttonThongKeTrongNgay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ThongKeXe";
            this.Text = "LichCV";
            this.Load += new System.EventHandler(this.ThongKeXe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartLoaiXe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuThinButton2 buttonThongKeTrongNgay;
        private Bunifu.Framework.UI.BunifuThinButton2 buttonThongKeToanBo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLoaiXe;
    }
}