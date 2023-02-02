
namespace PlayerUI
{
    partial class ThongKeKhachHangForm
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
            this.chartLoaiXe = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartLoaiXe)).BeginInit();
            this.SuspendLayout();
            // 
            // chartLoaiXe
            // 
            this.chartLoaiXe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartLoaiXe.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartLoaiXe.Legends.Add(legend1);
            this.chartLoaiXe.Location = new System.Drawing.Point(31, 40);
            this.chartLoaiXe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartLoaiXe.Name = "chartLoaiXe";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "loai";
            this.chartLoaiXe.Series.Add(series1);
            this.chartLoaiXe.Size = new System.Drawing.Size(670, 368);
            this.chartLoaiXe.TabIndex = 109;
            this.chartLoaiXe.Text = "chart2";
            this.chartLoaiXe.Click += new System.EventHandler(this.chartLoaiXe_Click);
            // 
            // ThongKeKhachHangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(736, 442);
            this.Controls.Add(this.chartLoaiXe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ThongKeKhachHangForm";
            this.Text = "ThongKeKhachHangForm";
            this.Load += new System.EventHandler(this.ThongKeKhachHangForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartLoaiXe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartLoaiXe;
    }
}