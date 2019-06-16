using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CameraCapture {
	static class FaceParam {
		//public float fScaleFactor = 1.1f;
		//public int iMinNeighbors = 10;
		//public Size szMinObjectSize = Size.Empty;

		static public double ScaleFactor(TextBox txt) {
			string s = txt.Text.Trim();
			double ret = Convert.ToDouble(s);
			if (ret <= 1)
				ret = 1.01;
			return ret;
		} // ///////////////////////////////////////////////////////////////////////
		static public int MinNeighbors(TextBox txt) {
			string s = txt.Text.Trim();
			int ret = Convert.ToInt32(s);
			return ret;
		} // ///////////////////////////////////////////////////////////////////////
		static public Size MinObjectSize(TextBox txt) {
			string s = txt.Text.Trim();
			string[] sar;
			sar = s.Split(' ');
			if(sar.Length == 0) {
				return Size.Empty;
			}else if(sar.Length == 1) {
				if(sar[0].Trim().Length == 0)
					return Size.Empty;
				int i = Convert.ToInt32(sar[0]);
				return new Size(i, i);
			}
			int i1 = Convert.ToInt32(sar[0]);
			int i2 = Convert.ToInt32(sar[1]);
			return new Size(i1, i2);
		} // ///////////////////////////////////////////////////////////////////////
	} // ******************************************************************************
}
