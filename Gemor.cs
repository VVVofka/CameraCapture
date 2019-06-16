using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CameraCapture {
	class Gemor {
		private Queue<long> q = new Queue<long>();
		int sum = 0;
		public double put(bool is_rect) {
			long nowtick = DateTime.Now.Ticks;
			while (q.Count > 0) {
				long peek = q.Peek();
				if ((nowtick - peek) / 10000 < 10000)   // 10 sec
					break;
				q.Dequeue();
				if ((peek & 1) == 1)
					sum--;
			}
			if (is_rect) {
				nowtick |= 1;
				sum++;
			} else {
				if ((nowtick & 1) == 1) {
					nowtick--;      // 0xFFFFFFFFFFFFFFFE;
				}
			}
			q.Enqueue(nowtick);
			if(q.Count > 0)
				return (double)sum / q.Count;
			return 0;
		} // ///////////////////////////////////////////////////////////////////////////////
	} // *************************************************************************************
}
