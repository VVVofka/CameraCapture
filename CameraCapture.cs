//----------------------------------------------------------------------------
//  Copyright (C) 2004-2019 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Cuda;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;

namespace CameraCapture {
	public partial class CameraCapture : Form {
		private VideoCapture _capture = null;
		private bool _captureInProgress;
		private UMat _frame; //!!!Mat
		private Mat _grayFrame;
		private Mat _smallGrayFrame;
		private Mat _smoothedGrayFrame;
		private Mat _cannyFrame;

		public CameraCapture() {
			InitializeComponent();
			CvInvoke.UseOpenCL = false;
			try {
				_capture = new VideoCapture();
				_capture.ImageGrabbed += ProcessFrame;
			} catch (NullReferenceException excpt) {
				MessageBox.Show(excpt.Message);
			}
			_frame = new UMat();     //!!!Mat
			_grayFrame = new Mat();
			_smallGrayFrame = new Mat();
			_smoothedGrayFrame = new Mat();
			_cannyFrame = new Mat();
		}

		private void ProcessFrame(object sender, EventArgs arg) {
			if (_capture != null && _capture.Ptr != IntPtr.Zero) {
				_capture.Retrieve(_frame, 0);

				CvInvoke.CvtColor(_frame, _grayFrame, ColorConversion.Bgr2Gray);

				CvInvoke.PyrDown(_grayFrame, _smallGrayFrame);

				CvInvoke.PyrUp(_smallGrayFrame, _smoothedGrayFrame);

				CvInvoke.Canny(_smoothedGrayFrame, _cannyFrame, 100, 60);
				Run(_frame);
				captureImageBox.Image = _frame;

				grayscaleImageBox.Image = _grayFrame;
				smoothedGrayscaleImageBox.Image = _smoothedGrayFrame;
				cannyImageBox.Image = _cannyFrame;
				//MyCaptur();
			}
		} // /////////////////////////////////////////////////////////////////////////////////////////////
		private void captureButtonClick(object sender, EventArgs e) {
			if (_capture != null) {
				if (_captureInProgress) {  //stop the capture
					captureButton.Text = "Start Capture";
					_capture.Pause();
				} else {
					//start the capture
					captureButton.Text = "Stop";
					_capture.Start();
				}
			}
			_captureInProgress = !_captureInProgress;
		} // ////////////////////////////////////////////////////////////////////////////////////////////////////
		private void ReleaseData() {
			if (_capture != null)
				_capture.Dispose();
		} // ////////////////////////////////////////////////////////////////////////////////////////////////////
		private void FlipHorizontalButtonClick(object sender, EventArgs e) {
			if (_capture != null)
				_capture.FlipHorizontal = !_capture.FlipHorizontal;
		} // ////////////////////////////////////////////////////////////////////////////////////////////////////
		private void FlipVerticalButtonClick(object sender, EventArgs e) {
			if (_capture != null)
				_capture.FlipVertical = !_capture.FlipVertical;
		} // /////////////////////////////////////////////////////////////////////////////////////////////////////////
		private void Run(UMat image) { //!!!UMat
			
			//IImage image;
			//Read the files as an 8-bit Bgr image  

			//image = new UMat("lena.jpg", ImreadModes.Color); //UMat version
			//image = new Mat("lena.jpg", ImreadModes.Color); //CPU version

			long detectionTime;
			List<Rectangle> faces = new List<Rectangle>();
			List<Rectangle> eyes = new List<Rectangle>();

//			DetectFace.Detect(
//			  image, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml",
//			  faces, eyes, out detectionTime);
			DetectFace.DetectOnlyFace(
			  image, "haarcascade_frontalface_default.xml",
			  faces, out detectionTime);

			foreach (Rectangle face in faces)
				CvInvoke.Rectangle(image, face, new Bgr(Color.Red).MCvScalar, 2);
			foreach (Rectangle eye in eyes)
				CvInvoke.Rectangle(image, eye, new Bgr(Color.Blue).MCvScalar, 2);

			//display the image 
			using (InputArray iaImage = image.GetInputArray()) {
				string sreport = String.Format(
				   "Completed face and eye detection using {0} in {1} milliseconds",
				   (iaImage.Kind == InputArray.Type.CudaGpuMat && CudaInvoke.HasCuda) ? "CUDA" :
				   (iaImage.IsUMat && CvInvoke.UseOpenCL) ? "OpenCL" : "CPU", detectionTime);
				Console.WriteLine(sreport);
			}
		}

	} // *************************************************************************************************************
}
