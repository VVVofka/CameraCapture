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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.txMinObjectSize = new System.Windows.Forms.TextBox();
			this.lbMinObjectSize = new System.Windows.Forms.Label();
			this.txMinNeighbors = new System.Windows.Forms.TextBox();
			this.lbMinNeighbors = new System.Windows.Forms.Label();
			this.lbScaleFactor = new System.Windows.Forms.Label();
			this.txScaleFactor = new System.Windows.Forms.TextBox();
			this.flipVerticalButton = new System.Windows.Forms.Button();
			this.flipHorizontalButton = new System.Windows.Forms.Button();
			this.captureButton = new System.Windows.Forms.Button();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.captureImageBox = new Emgu.CV.UI.ImageBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.smoothedGrayscaleImageBox = new Emgu.CV.UI.ImageBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.splitContainer4 = new System.Windows.Forms.SplitContainer();
			this.grayscaleImageBox = new Emgu.CV.UI.ImageBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.cannyImageBox = new Emgu.CV.UI.ImageBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.lbDbgTimers = new System.Windows.Forms.Label();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.captureImageBox)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.smoothedGrayscaleImageBox)).BeginInit();
			this.panel3.SuspendLayout();
			this.splitContainer4.Panel1.SuspendLayout();
			this.splitContainer4.Panel2.SuspendLayout();
			this.splitContainer4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grayscaleImageBox)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cannyImageBox)).BeginInit();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
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
			this.splitContainer1.Panel1.Controls.Add(this.txMinObjectSize);
			this.splitContainer1.Panel1.Controls.Add(this.lbMinObjectSize);
			this.splitContainer1.Panel1.Controls.Add(this.txMinNeighbors);
			this.splitContainer1.Panel1.Controls.Add(this.lbMinNeighbors);
			this.splitContainer1.Panel1.Controls.Add(this.lbScaleFactor);
			this.splitContainer1.Panel1.Controls.Add(this.txScaleFactor);
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
			// txMinObjectSize
			// 
			this.txMinObjectSize.Location = new System.Drawing.Point(759, 13);
			this.txMinObjectSize.Name = "txMinObjectSize";
			this.txMinObjectSize.Size = new System.Drawing.Size(62, 20);
			this.txMinObjectSize.TabIndex = 8;
			this.txMinObjectSize.Text = "130";
			// 
			// lbMinObjectSize
			// 
			this.lbMinObjectSize.AutoSize = true;
			this.lbMinObjectSize.Location = new System.Drawing.Point(672, 17);
			this.lbMinObjectSize.Name = "lbMinObjectSize";
			this.lbMinObjectSize.Size = new System.Drawing.Size(81, 13);
			this.lbMinObjectSize.TabIndex = 7;
			this.lbMinObjectSize.Text = "Min Object Size";
			// 
			// txMinNeighbors
			// 
			this.txMinNeighbors.Location = new System.Drawing.Point(608, 12);
			this.txMinNeighbors.Name = "txMinNeighbors";
			this.txMinNeighbors.Size = new System.Drawing.Size(37, 20);
			this.txMinNeighbors.TabIndex = 6;
			this.txMinNeighbors.Text = "9";
			this.txMinNeighbors.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbMinNeighbors
			// 
			this.lbMinNeighbors.AutoSize = true;
			this.lbMinNeighbors.Location = new System.Drawing.Point(538, 16);
			this.lbMinNeighbors.Name = "lbMinNeighbors";
			this.lbMinNeighbors.Size = new System.Drawing.Size(75, 13);
			this.lbMinNeighbors.TabIndex = 5;
			this.lbMinNeighbors.Text = "Min Neighbors";
			this.lbMinNeighbors.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbScaleFactor
			// 
			this.lbScaleFactor.AutoSize = true;
			this.lbScaleFactor.Location = new System.Drawing.Point(419, 16);
			this.lbScaleFactor.Name = "lbScaleFactor";
			this.lbScaleFactor.Size = new System.Drawing.Size(64, 13);
			this.lbScaleFactor.TabIndex = 4;
			this.lbScaleFactor.Text = "ScaleFactor";
			this.lbScaleFactor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txScaleFactor
			// 
			this.txScaleFactor.Location = new System.Drawing.Point(485, 13);
			this.txScaleFactor.Name = "txScaleFactor";
			this.txScaleFactor.Size = new System.Drawing.Size(38, 20);
			this.txScaleFactor.TabIndex = 3;
			this.txScaleFactor.Text = "1.01";
			this.txScaleFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
			this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
			this.splitContainer2.Size = new System.Drawing.Size(842, 784);
			this.splitContainer2.SplitterDistance = 411;
			this.splitContainer2.TabIndex = 0;
			// 
			// splitContainer3
			// 
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.Location = new System.Drawing.Point(0, 0);
			this.splitContainer3.Name = "splitContainer3";
			this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.captureImageBox);
			this.splitContainer3.Panel1.Controls.Add(this.panel1);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.smoothedGrayscaleImageBox);
			this.splitContainer3.Panel2.Controls.Add(this.panel3);
			this.splitContainer3.Size = new System.Drawing.Size(411, 784);
			this.splitContainer3.SplitterDistance = 378;
			this.splitContainer3.TabIndex = 0;
			// 
			// captureImageBox
			// 
			this.captureImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.captureImageBox.Location = new System.Drawing.Point(0, 33);
			this.captureImageBox.Name = "captureImageBox";
			this.captureImageBox.Size = new System.Drawing.Size(411, 345);
			this.captureImageBox.TabIndex = 1;
			this.captureImageBox.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lbDbgTimers);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(411, 33);
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
			// smoothedGrayscaleImageBox
			// 
			this.smoothedGrayscaleImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.smoothedGrayscaleImageBox.Location = new System.Drawing.Point(0, 36);
			this.smoothedGrayscaleImageBox.Name = "smoothedGrayscaleImageBox";
			this.smoothedGrayscaleImageBox.Size = new System.Drawing.Size(411, 366);
			this.smoothedGrayscaleImageBox.TabIndex = 1;
			this.smoothedGrayscaleImageBox.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.label3);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(411, 36);
			this.panel3.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(108, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Smoothed Grayscale:";
			// 
			// splitContainer4
			// 
			this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer4.Location = new System.Drawing.Point(0, 0);
			this.splitContainer4.Name = "splitContainer4";
			this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer4.Panel1
			// 
			this.splitContainer4.Panel1.Controls.Add(this.grayscaleImageBox);
			this.splitContainer4.Panel1.Controls.Add(this.panel2);
			// 
			// splitContainer4.Panel2
			// 
			this.splitContainer4.Panel2.Controls.Add(this.cannyImageBox);
			this.splitContainer4.Panel2.Controls.Add(this.panel4);
			this.splitContainer4.Size = new System.Drawing.Size(427, 784);
			this.splitContainer4.SplitterDistance = 378;
			this.splitContainer4.TabIndex = 0;
			// 
			// grayscaleImageBox
			// 
			this.grayscaleImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grayscaleImageBox.Location = new System.Drawing.Point(0, 33);
			this.grayscaleImageBox.Name = "grayscaleImageBox";
			this.grayscaleImageBox.Size = new System.Drawing.Size(427, 345);
			this.grayscaleImageBox.TabIndex = 1;
			this.grayscaleImageBox.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label2);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(427, 33);
			this.panel2.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Grayscale Image:";
			// 
			// cannyImageBox
			// 
			this.cannyImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cannyImageBox.Location = new System.Drawing.Point(0, 35);
			this.cannyImageBox.Name = "cannyImageBox";
			this.cannyImageBox.Size = new System.Drawing.Size(427, 367);
			this.cannyImageBox.TabIndex = 1;
			this.cannyImageBox.TabStop = false;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.label4);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(427, 35);
			this.panel4.TabIndex = 0;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(17, 10);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(73, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Canny Edges:";
			// 
			// lbDbgTimers
			// 
			this.lbDbgTimers.AutoSize = true;
			this.lbDbgTimers.Location = new System.Drawing.Point(103, 10);
			this.lbDbgTimers.Name = "lbDbgTimers";
			this.lbDbgTimers.Size = new System.Drawing.Size(67, 13);
			this.lbDbgTimers.TabIndex = 9;
			this.lbDbgTimers.Text = "debug timers";
			// 
			// CameraCapture
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(842, 832);
			this.Controls.Add(this.splitContainer1);
			this.Name = "CameraCapture";
			this.Text = "Camera Capture";
			this.Shown += new System.EventHandler(this.CameraCapture_Shown);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel2.ResumeLayout(false);
			this.splitContainer3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.captureImageBox)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.smoothedGrayscaleImageBox)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.splitContainer4.Panel1.ResumeLayout(false);
			this.splitContainer4.Panel2.ResumeLayout(false);
			this.splitContainer4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grayscaleImageBox)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cannyImageBox)).EndInit();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button captureButton;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button flipHorizontalButton;
        private System.Windows.Forms.Button flipVerticalButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Emgu.CV.UI.ImageBox captureImageBox;
        private Emgu.CV.UI.ImageBox grayscaleImageBox;
        private Emgu.CV.UI.ImageBox smoothedGrayscaleImageBox;
        private Emgu.CV.UI.ImageBox cannyImageBox;
		private System.Windows.Forms.TextBox txScaleFactor;
		private System.Windows.Forms.Label lbScaleFactor;
		private System.Windows.Forms.TextBox txMinNeighbors;
		private System.Windows.Forms.Label lbMinNeighbors;
		private System.Windows.Forms.TextBox txMinObjectSize;
		private System.Windows.Forms.Label lbMinObjectSize;
		private System.Windows.Forms.Label lbDbgTimers;
	}
}

