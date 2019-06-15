namespace CameraCapture
{
    partial class CameraCapture
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
            ReleaseData();
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
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.captureButton = new System.Windows.Forms.Button();
			this.flipHorizontalButton = new System.Windows.Forms.Button();
			this.flipVerticalButton = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.captureImageBox = new Emgu.CV.UI.ImageBox();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.captureImageBox)).BeginInit();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.SplitContainer2_Panel2_Paint);
			this.splitContainer2.Size = new System.Drawing.Size(842, 784);
			this.splitContainer2.SplitterDistance = 411;
			this.splitContainer2.TabIndex = 0;
			// 
			// captureButton
			// 
			this.captureButton.Location = new System.Drawing.Point(15, 12);
			this.captureButton.Name = "captureButton";
			this.captureButton.Size = new System.Drawing.Size(102, 23);
			this.captureButton.TabIndex = 0;
			this.captureButton.Text = "Start Capture";
			this.captureButton.UseVisualStyleBackColor = true;
			this.captureButton.Click += new System.EventHandler(this.captureButtonClick);
			// 
			// flipHorizontalButton
			// 
			this.flipHorizontalButton.Location = new System.Drawing.Point(162, 12);
			this.flipHorizontalButton.Name = "flipHorizontalButton";
			this.flipHorizontalButton.Size = new System.Drawing.Size(102, 23);
			this.flipHorizontalButton.TabIndex = 1;
			this.flipHorizontalButton.Text = "Flip Horizontal";
			this.flipHorizontalButton.UseVisualStyleBackColor = true;
			this.flipHorizontalButton.Click += new System.EventHandler(this.FlipHorizontalButtonClick);
			// 
			// flipVerticalButton
			// 
			this.flipVerticalButton.Location = new System.Drawing.Point(305, 12);
			this.flipVerticalButton.Name = "flipVerticalButton";
			this.flipVerticalButton.Size = new System.Drawing.Size(102, 23);
			this.flipVerticalButton.TabIndex = 2;
			this.flipVerticalButton.Text = "Flip Vertical";
			this.flipVerticalButton.UseVisualStyleBackColor = true;
			this.flipVerticalButton.Click += new System.EventHandler(this.FlipVerticalButtonClick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.flipVerticalButton);
			this.splitContainer1.Panel1.Controls.Add(this.flipHorizontalButton);
			this.splitContainer1.Panel1.Controls.Add(this.captureButton);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(842, 832);
			this.splitContainer1.SplitterDistance = 44;
			this.splitContainer1.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(601, 33);
			this.panel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Captured Image:";
			// 
			// captureImageBox
			// 
			this.captureImageBox.Location = new System.Drawing.Point(162, 98);
			this.captureImageBox.Name = "captureImageBox";
			this.captureImageBox.Size = new System.Drawing.Size(480, 345);
			this.captureImageBox.TabIndex = 1;
			this.captureImageBox.TabStop = false;
			// 
			// splitContainer3
			// 
			this.splitContainer3.Location = new System.Drawing.Point(0, 0);
			this.splitContainer3.Name = "splitContainer3";
			this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.captureImageBox);
			this.splitContainer3.Panel1.Controls.Add(this.panel1);
			this.splitContainer3.Size = new System.Drawing.Size(601, 784);
			this.splitContainer3.SplitterDistance = 378;
			this.splitContainer3.TabIndex = 0;
			// 
			// CameraCapture
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(842, 832);
			this.Controls.Add(this.splitContainer1);
			this.Name = "CameraCapture";
			this.Text = "Camera Capture";
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.captureImageBox)).EndInit();
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.ResumeLayout(false);
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private Emgu.CV.UI.ImageBox captureImageBox;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button captureButton;
		private System.Windows.Forms.Button flipHorizontalButton;
		private System.Windows.Forms.Button flipVerticalButton;
		private System.Windows.Forms.SplitContainer splitContainer1;
	}
}

