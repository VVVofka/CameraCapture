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
		static class Intervals {
			static public long Sit = 30 * 60;   // по истечении переход в mode.Go
			static public long ShortUp = 12;    // по истечении переход в mode.Ex
			static public long Ex = 1 * 60;     // по истечении переход в mode.Suspend
		}
		enum Modes {
			Suspend,
			Sit,
			ShortUpInSit,
			ExAfterSit,
			Go,
			ShortUpAfterGo,
			ExAfterGo
		};
		readonly string SOUND_GO_BACK = ""; // !!!
		readonly string SOUND_NOTIFY_EX = ""; // !!!
		readonly string SOUND_EX_COMPLETE = ""; // !!!
		readonly string SOUND_NOTIFY_SUSPEND = ""; // !!!

		Modes mode = Modes.Suspend;
		Stopwatch tmrSit = new Stopwatch();
		Stopwatch tmrOut = new Stopwatch();
		public void Run(Signal signal) {
			switch (mode) {
				case Modes.Suspend:
					inSuspend(signal);
					break;
				case Modes.Sit:
					inSit(signal);
					break;
				case Modes.ShortUpInSit:
					inShortUpInSit(signal);
					break;
				case Modes.ExAfterSit:
					inExAfterSit(signal);
					break;
				case Modes.Go:
					inGo(signal);
					break;
				case Modes.ShortUpAfterGo:
					inShortUpAfterGo(signal);
					break;
				case Modes.ExAfterGo:
					inExAfterGo(signal);
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
				if (tmrSit.ElapsedMilliseconds / 1000 > Intervals.Sit) { //  пора вставать
					tmrGo.Start();
					mode = Modes.Go;
				}
			} else if (signal == Signal.no) { // возможно встал
				tmrOut.Reset();
				tmrOut.Start();
				mode = Modes.ShortUpInSit;
			} else if (signal == Signal.control)
				ToSuspend();
		} // //////////////////////////////////////////////////////////////////////////////////
		void inShortUpInSit(Signal signal) {
			if (signal == Signal.yes) {
				tmrSit.Start(); // continue
				tmrOut.Reset();
				mode = Modes.Sit;
			} else if (signal == Signal.no) {
				if (tmrOut.ElapsedMilliseconds / 1000 > Intervals.ShortUp) { // Начал заниматься
					tmrSit.Stop();
					PlaySound(SOUND_NOTIFY_EX);
					mode = Modes.ExAfterGo;
				}
			} else if (signal == Signal.control)
				ToSuspend();
		} // //////////////////////////////////////////////////////////////////////////////////
		void inExAfterSit(Signal signal) { //
			if (signal == Signal.yes) { // это была не полноценная тренировка!
				tmrSit.Start();
				tmrOut.Reset();
				mode = Modes.Sit;
			} else if (signal == Signal.no) {
				if (tmrOut.ElapsedMilliseconds / 1000 > Intervals.Ex) { // досрочная тренировка окончена
					PlaySound(SOUND_EX_COMPLETE);
					ToSuspend();
				}
			} else if (signal == Signal.control)
				ToSuspend();
		} // //////////////////////////////////////////////////////////////////////////////////
		void inGo(Signal signal) { // пищит сигнал на подъём
			if (signal == Signal.yes) {
				tmrGo.Tick(tmrSit.ElapsedMilliseconds);
			} else if (signal == Signal.no) { // Вроде встал
				tmrGo.Stop();
				tmrSit.Stop();
				tmrOut.Reset();
				tmrOut.Start();
				mode = Modes.ShortUpAfterGo;
			} else if (signal == Signal.control)
				ToSuspend();
		} // //////////////////////////////////////////////////////////////////////////////////
		void inShortUpAfterGo(Signal signal) { //
			if (signal == Signal.yes) { // ложная тревога, продолжает сидеть сволочь!
				tmrGo.Start();
				tmrSit.Start();
				tmrOut.Reset();
				mode = Modes.Go;
			} else if (signal == Signal.no) {
				if (tmrOut.ElapsedMilliseconds / 1000 > Intervals.ShortUp) { // Начал заниматься
					tmrSit.Stop();
					tmrGo.Stop();
					PlaySound(SOUND_NOTIFY_EX);
					mode = Modes.ExAfterGo;
				}
			} else if (signal == Signal.control)
				ToSuspend();
		} // //////////////////////////////////////////////////////////////////////////////////
		void inExAfterGo(Signal signal) { ///!!!!
			if (signal == Signal.yes) { // это была не полноценная тренировка!
				tmrSit.Start();
				tmrGo.Start();
				tmrOut.Reset();
				mode = Modes.Go;
			} else if (signal == Signal.no) {
				if (tmrOut.ElapsedMilliseconds / 1000 > Intervals.Ex) { // плановая тренировка окончена
					PlaySound(SOUND_EX_COMPLETE);
					ToSuspend();
				}
			} else if (signal == Signal.control)
				ToSuspend();
		} // //////////////////////////////////////////////////////////////////////////////////
		void PlaySound(string fname) {

		} // //////////////////////////////////////////////////////////////////////////////////
		void ToSuspend() {
			PlaySound(SOUND_NOTIFY_SUSPEND);
			tmrSit.Reset();
			tmrOut.Reset();
			tmrGo.Reset();
			mode = Modes.Suspend;
		} // //////////////////////////////////////////////////////////////////////////////////
		class Go : Stopwatch {
			long intervalBigSound = 1 * 60;
			long intervalSmallSound = 5;
			long tmrGo = 0;
			int cnt = 0;
			public new void Start() {
				base.Start();
			}
			public new void Stop() {
				base.Stop();
			}
			public new void Reset() {
				base.Reset();
			}
			public void Tick(long msec) {

			}
		} // ** Go ***********************************************************************************
		Go tmrGo = new Go();
	} // ** Phases ***********************************************************************************
}
