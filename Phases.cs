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
		long IntervalOut =  1 * 60;
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
					inSuspend(signal);
					break;
				case Modes.Sit:
					inSit(signal);
					break;
				case Modes.MaybeOut:
					inMaybeOut(signal);
					break;
				case Modes.Go:
					inGo(signal);
					break;
				case Modes.Ex:
					inEx(signal);
					break;
				case Modes.GoBack:
					inGoBack(signal);
					break;
				default:
					Console.WriteLine("Wrong case!");
					break;
			}   // switch (mode) 
		} // //////////////////////////////////////////////////////////////////////////////////
		void inSuspend(Signal signal) {
			if (signal == Signal.yes) {
				tmrSit.Start();
				tmrOut.Reset();
				tmrGo.Reset();
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
				ToSuspend();
			}
		} // //////////////////////////////////////////////////////////////////////////////////
		void inMaybeOut(Signal signal) {
			if (signal == Signal.yes) {
				tmrSit.Start();
				tmrOut.Reset();
				mode = Modes.Sit;
			} else if (signal == Signal.no) {
				if (tmrOut.ElapsedMilliseconds / 1000 > IntervalOut) {
					tmrGo.Start();
					PlaySound();
					mode = Modes.Go;
				}
			} else if (signal == Signal.control) {
				ToSuspend();
				tmrSit.Start();
			}
		} // //////////////////////////////////////////////////////////////////////////////////
		void inGo(Signal signal) { ///!!!
			if (signal == Signal.yes) {
				if (tmrOut.ElapsedMilliseconds / 1000 > IntervalOut) {
					tmrGo.Start();
					PlaySound();
					mode = Modes.Go;
				}
			} else if (signal == Signal.no) {
				tmrSit.Start();
				tmrOut.Reset();
				mode = Modes.Sit;
			} else if (signal == Signal.control) {
				ToSuspend();
			}
		} // //////////////////////////////////////////////////////////////////////////////////
		void inEx(Signal signal) { ///!!!!
			if (signal == Signal.yes) {
				tmrSit.Start();
				tmrOut.Reset();
				mode = Modes.Sit;
			} else if (signal == Signal.no) {
				if (tmrOut.ElapsedMilliseconds / 1000 > IntervalOut) {
					tmrGo.Start();
					PlaySound();
					mode = Modes.Go;
				}
			} else if (signal == Signal.control) {
				ToSuspend();
				tmrSit.Start();
			}
		} // //////////////////////////////////////////////////////////////////////////////////
		void inGoBack(Signal signal) { ///!!!!!
			if (signal == Signal.yes) {
				tmrSit.Start();
				tmrOut.Reset();
				mode = Modes.Sit;
			} else if (signal == Signal.no) {
				if (tmrOut.ElapsedMilliseconds / 1000 > IntervalOut) {
					tmrGo.Start();
					PlaySound();
					mode = Modes.Go;
				}
			} else if (signal == Signal.control) {
				ToSuspend();
				tmrSit.Start();
			}
		} // //////////////////////////////////////////////////////////////////////////////////
		void PlaySound() {

		} // //////////////////////////////////////////////////////////////////////////////////
		void ToSuspend() {
			tmrSit.Reset();
			tmrOut.Reset();
			tmrGo.Reset();
			mode = Modes.Suspend;
		} // //////////////////////////////////////////////////////////////////////////////////
	} // *************************************************************************************
}
