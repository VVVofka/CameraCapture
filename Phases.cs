using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CameraCapture {
	enum Signal {
		nodef,
		no,
		yes,
		control
	};
	class Phases {
		public static class Intervals {
			static public long Sit = 5 * 60;   // по истечении переход в mode.Go
			static public long ShortUp = 10;    // по истечении переход в mode.Ex
			static public long Ex = 45;     // по истечении переход в mode.Suspend
			static public long GoBigSound = 60; // большое напоминание встать
			static public long GoSmallSound = 5;// короткое напоминание встать
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
		readonly string SOUND_NOTIFY_EX = ""; // !!!
		readonly string SOUND_EX_COMPLETE = ""; // !!!
		readonly string SOUND_NOTIFY_SUSPEND = ""; // !!!
		static public readonly string SOUND_NOTIFY_GO_SMALL_TICK = ""; // !!!
		static public readonly string SOUND_NOTIFY_GO_BIG_TICK = ""; // !!!
		static public readonly string SOUND_SILENT = ""; // !!!

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
				tmrGo.Tick();
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
		public static void PlaySound(string fname) {
			Console.WriteLine("Sound {0}", fname);
		} // //////////////////////////////////////////////////////////////////////////////////
		void ToSuspend() {
			PlaySound(SOUND_NOTIFY_SUSPEND);
			tmrSit.Reset();
			tmrOut.Reset();
			tmrGo.Reset();
			mode = Modes.Suspend;
		} // //////////////////////////////////////////////////////////////////////////////////
		Go tmrGo = new Go();
		class Go : Stopwatch {
			int cnt = 0;
			Stopwatch tmrSmall = new Stopwatch();
			Stopwatch tmrBig = new Stopwatch();
			public new void Start() {
				base.Start();
				tmrSmall.Start();
				tmrBig.Start();
			} // //////////////////////////////////////////////////////////////////////////////////////
			public new void Stop() {
				base.Stop();
				tmrSmall.Reset();
				tmrBig.Reset();
			} // //////////////////////////////////////////////////////////////////////////////////////
			public new void Reset() {
				base.Reset();
				tmrSmall.Reset();
				tmrBig.Reset();
			} // //////////////////////////////////////////////////////////////////////////////////////
			public void Tick() {
				if (tmrBig.ElapsedMilliseconds / 1000 > Intervals.GoBigSound) {
					++cnt;
					for (int n = 0; n < cnt; n++) {
						PlaySound(SOUND_NOTIFY_GO_SMALL_TICK);
						PlaySound(SOUND_SILENT);
					}
					tmrBig.Reset();
					tmrBig.Start();
					tmrSmall.Reset();
					tmrSmall.Start();
				} else if (tmrSmall.ElapsedMilliseconds / 1000 > Intervals.GoSmallSound) {
					PlaySound(SOUND_NOTIFY_GO_BIG_TICK);
					tmrSmall.Reset();
					tmrSmall.Start();
				}
			} // //////////////////////////////////////////////////////////////////////////////////////
		} // ** Go ***********************************************************************************
	} // ** Phases ***********************************************************************************
}
