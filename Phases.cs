using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CameraCapture {
	enum Signal {
		no,
		yes,
		control
	};
	class Phases {
		long IntervalSit = 30 * 60;
		enum Modes {
			Suspend,
			Sit,
			MaybeOut,
			Go,
			Ex,
			GoBack
		};
		Modes mode = Modes.Suspend;
		Stopwatch tmrSit = new Stopwatch();
		Stopwatch tmrOut = new Stopwatch();
		Stopwatch tmrGo = new Stopwatch();
		public void Run(Signal signal) {
			switch (mode) {
				case Modes.Suspend:
					inSuspend(i);
					break;
				case Modes.Sit:
					inSit(i);
					break;
				case Modes.MaybeOut:
					inMaybeOut(i);
					break;
				case Modes.Go:
					inGo(i);
					break;
				case Modes.Ex:
					inEx(i);
					break;
				case Modes.GoBack:
					inGoBack(i);
					break;
				default:
					Console.WriteLine("Wrong case!");
					break;
			}   // switch (mode) 
		} // //////////////////////////////////////////////////////////////////////////////////
		void inSuspend(Signal signal) {
			if (signal == Signal.yes) {
				tmrSit.Start();
				tmrOut.Stop();
				mode = Modes.Sit;
			}
		} // //////////////////////////////////////////////////////////////////////////////////
		void inSit(Signal signal) {
			if (signal == Signal.yes) {
				if(tmrSit.ElapsedMilliseconds / 1000 > IntervalSit) {
					tmrGo.Start();
					PlaySound();
					mode = Modes.Go;
				}
			} else if(signal == Signal.no){
				tmrSit.Stop();
				tmrOut.Start();
				mode = Modes.MaybeOut;
			} else if (signal == Signal.control) {
				tmrSit.Reset();
				tmrSit.Start();
			}
		} // //////////////////////////////////////////////////////////////////////////////////
		void inMaybeOut(Signal signal) {
			if (signal == Signal.yes) {
				tmrSit.Start();
				tmrOut.Stop();
				mode = Modes.Sit;
			} else {

			}
		} // //////////////////////////////////////////////////////////////////////////////////
		void inGo(Signal signal) {
			if (i) {

			} else {

			}
		} // //////////////////////////////////////////////////////////////////////////////////
		void inEx(Signal signal) {
			if (i) {

			} else {

			}
		} // //////////////////////////////////////////////////////////////////////////////////
		void inGoBack(Signal signal) {
			if (i) {

			} else {

			}
		} // //////////////////////////////////////////////////////////////////////////////////
		void PlaySound() {

		} // //////////////////////////////////////////////////////////////////////////////////
	} // *************************************************************************************
}
