using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Reflection;
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
		private Gemor gemor = new Gemor();
		private Phases phases = new Phases();
		Signal signal = Signal.nodef;

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
					//_capture.FlipHorizontal = !_capture.FlipHorizontal; // my
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
			  faces, out detectionTime,
			  FaceParam.ScaleFactor(txScaleFactor), FaceParam.MinNeighbors(txMinNeighbors), FaceParam.MinObjectSize(txMinObjectSize));

			foreach (Rectangle face in faces)
				CvInvoke.Rectangle(image, face, new Bgr(Color.Red).MCvScalar, 2);
			foreach (Rectangle eye in eyes)
				CvInvoke.Rectangle(image, eye, new Bgr(Color.Blue).MCvScalar, 2);
			double r = gemor.put(faces.Count > 0);

			if (r < 0.4 && (signal == Signal.yes || signal == Signal.nodef))
				signal = Signal.no;
			else if (r > 0.6 && (signal == Signal.no || signal == Signal.nodef))
				signal = Signal.yes;
			string sret = phases.Run(signal, r);
			//lbDbgTimers.Text = sret;
			MCvScalar color = new MCvScalar(255, 0, 255, 0);
			CvInvoke.PutText(image, sret, new Point(2, 25), FontFace.HersheyComplexSmall, 1, color); //_grayFrame
			if (signal == Signal.nodef && false)
				if (faces.Count > 0)
					using (InputArray iaImage = image.GetInputArray()) {
						string sreport = String.Format(
						   "Completed face detection using {0} in {1} milliseconds. Rct={2} x {3} r={4}",
						   (iaImage.Kind == InputArray.Type.CudaGpuMat && CudaInvoke.HasCuda) ? "CUDA" :
						   (iaImage.IsUMat && CvInvoke.UseOpenCL) ? "OpenCL" : "CPU", detectionTime,
						   faces[0].Width, faces[0].Height, r);
						Console.WriteLine(sreport);
					}
				else
					Console.WriteLine(r.ToString());
		} // ////////////////////////////////////////////////////////////////////////////////////////////////////////////
		private void CameraCapture_Shown(object sender, EventArgs e) {
			captureButtonClick(null, null);
			FlipHorizontalButtonClick(null, null);
			string sret = "zzzzzzzzzzzzzzzz";
			lbDbgTimers.Text = sret;
		} // ////////////////////////////////////////////////////////////////////////////////////////////////////////////
	} // *************************************************************************************************************
}
