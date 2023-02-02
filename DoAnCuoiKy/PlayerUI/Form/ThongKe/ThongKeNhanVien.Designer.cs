
namespace PlayerUI
{
    partial class ThongKeNhanVien
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartBP = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartLoaiXe = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartBP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLoaiXe)).BeginInit();
            this.SuspendLayout();
            // 
            // chartBP
            // 
            this.chartBP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            chartArea1.Name = "ChartArea1";
            this.chartBP.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartBP.Legends.Add(legend1);
            this.chartBP.Location = new System.Drawing.Point(371, 70);
            this.chartBP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartBP.Name = "chartBP";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "%";
            this.chartBP.Series.Add(series1);
            this.chartBP.Size = new System.Drawing.Size(322, 294);
            this.chartBP.TabIndex = 106;
            this.chartBP.Text = "chart1";
            // 
            // chartLoaiXe
            // 
            this.chartLoaiXe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            chartArea2.Name = "ChartArea1";
            this.chartLoaiXe.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartLoaiXe.Legends.Add(legend2);
            this.chartLoaiXe.Location = new System.Drawing.Point(31, 82);
            this.chartLoaiXe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartLoaiXe.Name = "chartLoaiXe";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "loai";
            this.chartLoaiXe.Series.Add(series2);
            this.chartLoaiXe.Size = new System.Drawing.Size(306, 282);
            this.chartLoaiXe.TabIndex = 109;
            this.chartLoaiXe.Text = "chart2";
            // 
            // ThongKeNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(736, 442);
            this.Controls.Add(this.chartLoaiXe);
            this.Controls.Add(this.chartBP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ThongKeNhanVien";
            this.Text = "LichCV";
            this.Load += new System.EventHandler(this.ThongKeNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartBP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLoaiXe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBP;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLoaiXe;
    }
}