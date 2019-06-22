using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CameraCapture {
	class MyStopwatch : Stopwatch {
		public override string ToString() {
			return Convert.ToString(ElapsedMilliseconds / 1000);
		} // /////////////////////////////////////////////////////////////////////////
		public static bool operator > (MyStopwatch left, long right) {
			return left.ElapsedMilliseconds / 1000 > right;
		}
		public static bool operator >(MyStopwatch left, int right) {
			return (int)(left.ElapsedMilliseconds / 1000) > right;
		}
		public static bool operator < (MyStopwatch left, long right) {
			return left.ElapsedMilliseconds / 1000 > right;
		}
		public static bool operator <(MyStopwatch left, int right) {
			return (int)(left.ElapsedMilliseconds / 1000) > right;
		}
		public void Restart() {
			base.Reset();
			base.Start();
		}
	} // *************************************************************************
}
