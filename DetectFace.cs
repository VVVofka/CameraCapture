using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
#if !(__IOS__ || NETFX_CORE)
using Emgu.CV.Cuda;
#endif

namespace CameraCapture {
	public static class DetectFace {
		public static void DetectOnlyFace(
		   IInputArray image, String faceFileName,
		   List<Rectangle> faces,
		   out long detectionTime) {
			Stopwatch watch;
			using (InputArray iaImage = image.GetInputArray()) {
#if !(__IOS__ || NETFX_CORE)
				if (iaImage.Kind == InputArray.Type.CudaGpuMat && CudaInvoke.HasCuda) {
					using (CudaCascadeClassifier face = new CudaCascadeClassifier(faceFileName)) {
						face.ScaleFactor = 1.1;
						face.MinNeighbors = 10;
						face.MinObjectSize = Size.Empty;
						watch = Stopwatch.StartNew();
						using (CudaImage<Bgr, Byte> gpuImage = new CudaImage<Bgr, byte>(image))
						using (CudaImage<Gray, Byte> gpuGray = gpuImage.Convert<Gray, Byte>())
						using (GpuMat region = new GpuMat()) {
							face.DetectMultiScale(gpuGray, region);
							Rectangle[] faceRegion = face.Convert(region);
							faces.AddRange(faceRegion);
						}
						watch.Stop();
					}
				} else
#endif
				{
					using (CascadeClassifier face = new CascadeClassifier(faceFileName)) { //Read the HaarCascade objects
						watch = Stopwatch.StartNew();

						using (UMat ugray = new UMat()) {
							CvInvoke.CvtColor(image, ugray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

							CvInvoke.EqualizeHist(ugray, ugray); //normalizes brightness and increases contrast of the image

							//Detect the faces  from the gray scale image and store the locations as rectangle
							//The first dimensional is the channel
							//The second dimension is the index of the rectangle in the specific channel                     
							Rectangle[] facesDetected = face.DetectMultiScale(
							   ugray,
							   1.1,
							   10,
							   new Size(20, 20));

							faces.AddRange(facesDetected);
						}
						watch.Stop();
					}
				}
				detectionTime = watch.ElapsedMilliseconds;
			}
		} // /////////////////////////////////////////////////////////////////////////////////////////////////
	}
}
