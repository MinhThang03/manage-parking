
namespace PlayerUI
{
    partial class HomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.buttonImage_Hover1 = new PlayerUI.ButtonImage_Hover();
            ((System.ComponentModel.ISupportInitialize)(this.buttonImage_Hover1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonImage_Hover1
            // 
            this.buttonImage_Hover1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonImage_Hover1.Image = ((System.Drawing.Image)(resources.GetObject("buttonImage_Hover1.Image")));
            this.buttonImage_Hover1.ImageHover = ((System.Drawing.Image)(resources.GetObject("buttonImage_Hover1.ImageHover")));
            this.buttonImage_Hover1.ImageNormal = ((System.Drawing.Image)(resources.GetObject("buttonImage_Hover1.ImageNormal")));
            this.buttonImage_Hover1.Location = new System.Drawing.Point(124, 61);
            this.buttonImage_Hover1.Name = "buttonImage_Hover1";
            this.buttonImage_Hover1.Size = new System.Drawing.Size(494, 312);
            this.buttonImage_Hover1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonImage_Hover1.TabIndex = 0;
            this.buttonImage_Hover1.TabStop = false;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(736, 442);
            this.Controls.Add(this.buttonImage_Hover1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "HomeForm";
            this.Text = "HomeForm";
            ((System.ComponentModel.ISupportInitialize)(this.buttonImage_Hover1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ButtonImage_Hover buttonImage_Hover1;
    }
}