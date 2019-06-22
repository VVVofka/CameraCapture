using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
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
			static public int Sit = 1 * 60;   // по истечении переход в mode.Go
			static public int ShortUp = 5;    // по истечении переход в mode.Ex
			static public int Ex = 40;     // по истечении переход в mode.Suspend
			static public int GoBigSound = 15; // большое напоминание встать
			static public int GoSmallSound = 5;// короткое напоминание встать
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
		readonly string SOUND_NOTIFY_EX = "Go.wav"; // !!!
		readonly string SOUND_EX_COMPLETE = "GoBack.wav"; // !!!
		readonly string SOUND_NOTIFY_SUSPEND = "Suspend.wav"; // !!!
		static public readonly string SOUND_NOTIFY_GO_SMALL_TICK = "Short.wav"; // !!!
		static public readonly string SOUND_NOTIFY_GO_BIG_TICK = "Big.wav"; // !!!
		static public readonly string SOUND_SILENT = ""; // !!!

		Modes mode = Modes.Suspend;
		MyStopwatch tmrSit = new MyStopwatch();
		MyStopwatch tmrOut = new MyStopwatch();
		public void Run(Signal signal, double r) {
			bool show = false;
			switch (mode) {
				case Modes.Suspend:
					show = inSuspend(signal);
					break;
				case Modes.Sit:
					show = inSit(signal);
					break;
				case Modes.ShortUpInSit:
					show = inShortUpInSit(signal);
					break;
				case Modes.ExAfterSit:
					show = inExAfterSit(signal);
					break;
				case Modes.Go:
					show = inGo(signal);
					break;
				case Modes.ShortUpAfterGo:
					show = inShortUpAfterGo(signal);
					break;
				case Modes.ExAfterGo:
					show = inExAfterGo(signal);
					break;
				default:
					Console.WriteLine("Wrong case!");
					break;
			}   // switch (mode) 
			if (show)
				Console.WriteLine("Signal:{0} mode:{1} tmrSit:{2} tmrOut:{3} tmrGo:{4} r={5}", signal, mode, tmrSit, tmrOut, tmrGo, r);
		} // //////////////////////////////////////////////////////////////////////////////////
		bool inSuspend(Signal signal) {
			if (signal == Signal.yes) {
				tmrSit.Start();
				tmrOut.Reset();
				tmrGo.Reset();
				mode = Modes.Sit;
				return true;
			}
			return false;
		} // //////////////////////////////////////////////////////////////////////////////////
		bool inSit(Signal signal) {
			if (signal == Signal.yes) {
				if (tmrSit > Intervals.Sit) { //  пора вставать
					tmrGo.Start();
					mode = Modes.Go;
					return true;
				}
			} else if (signal == Signal.no) { // возможно встал
				tmrOut.Restart();
				mode = Modes.ShortUpInSit;
				return true;
			} else if (signal == Signal.control) {
				ToSuspend();
				return true;
			}
			return false;
		} // //////////////////////////////////////////////////////////////////////////////////
		bool inShortUpInSit(Signal signal) {
			if (signal == Signal.yes) {
				tmrSit.Start(); // continue
				tmrOut.Reset();
				mode = Modes.Sit;
				return true;
			} else if (signal == Signal.no) {
				if (tmrOut > Intervals.ShortUp) { // Начал заниматься
					tmrSit.Stop();
					PlaySound(SOUND_NOTIFY_EX);
					mode = Modes.ExAfterGo;
					return true;
				}
			} else if (signal == Signal.control) {
				ToSuspend();
				return true;
			}
			return false;
		} // //////////////////////////////////////////////////////////////////////////////////
		bool inExAfterSit(Signal signal) { //
			if (signal == Signal.yes) { // это была не полноценная тренировка!
				tmrSit.Start();
				tmrOut.Reset();
				mode = Modes.Sit;
				return true;
			} else if (signal == Signal.no) {
				if (tmrOut > Intervals.Ex) { // досрочная тренировка окончена
					PlaySound(SOUND_EX_COMPLETE);
					ToSuspend();
					return true;
				}
			} else if (signal == Signal.control) {
				ToSuspend();
				return true;
			}
			return false;
		} // //////////////////////////////////////////////////////////////////////////////////
		bool inGo(Signal signal) { // пищит сигнал на подъём
			if (signal == Signal.yes) {
				tmrGo.Tick();
				return true;
			} else if (signal == Signal.no) { // Вроде встал
				tmrGo.Stop();
				tmrSit.Stop();
				tmrOut.Reset();
				tmrOut.Start();
				mode = Modes.ShortUpAfterGo;
				return true;
			} else if (signal == Signal.control) {
				ToSuspend();
				return true;
			}
			return false;
		} // //////////////////////////////////////////////////////////////////////////////////
		bool inShortUpAfterGo(Signal signal) { //
			if (signal == Signal.yes) { // ложная тревога, продолжает сидеть сволочь!
				tmrGo.Start();
				tmrSit.Start();
				tmrOut.Reset();
				mode = Modes.Go;
				return true;
			} else if (signal == Signal.no) {
				if (tmrOut > Intervals.ShortUp) { // Начал заниматься
					tmrSit.Stop();
					tmrGo.Stop();
					PlaySound(SOUND_NOTIFY_EX);
					mode = Modes.ExAfterGo;
					return true;
				}
			} else if (signal == Signal.control) {
				ToSuspend();
				return true;
			}
			return false;
		} // //////////////////////////////////////////////////////////////////////////////////
		bool inExAfterGo(Signal signal) { ///!!!!
			if (signal == Signal.yes) { // это была не полноценная тренировка!
				tmrSit.Start();
				tmrGo.Start();
				tmrOut.Reset();
				mode = Modes.Go;
				return true;
			} else if (signal == Signal.no) {
				if (tmrOut > Intervals.Ex) { // плановая тренировка окончена
					PlaySound(SOUND_EX_COMPLETE);
					ToSuspend();
					return true;
				}
			} else if (signal == Signal.control) {
				ToSuspend();
				return true;
			}
			return false;
		} // //////////////////////////////////////////////////////////////////////////////////
		public static void PlaySound(string fname) {
			Console.WriteLine("Sound {0}", fname);
			System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
			//System.IO.Stream s = a.GetManifestResourceStream("CameraCapture.Sounds.Big.wav");
			System.IO.Stream s = a.GetManifestResourceStream("CameraCapture.Sounds." + fname);
			SoundPlayer player = new SoundPlayer(s);
			player.Play();

			//SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
			//simpleSound.Play();
			//SystemSounds.Asterisk.Play();
		} // //////////////////////////////////////////////////////////////////////////////////
		void ToSuspend() {
			PlaySound(SOUND_NOTIFY_SUSPEND);
			tmrSit.Reset();
			tmrOut.Reset();
			tmrGo.Reset();
			mode = Modes.Suspend;
		} // //////////////////////////////////////////////////////////////////////////////////
		Go tmrGo = new Go();
		class Go : MyStopwatch {
			int cnt = 0;
			MyStopwatch tmrSmall = new MyStopwatch();
			MyStopwatch tmrBig = new MyStopwatch();
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
				if (tmrBig > Intervals.GoBigSound) {
					++cnt;
					for (int n = 0; n < cnt; n++) {
						PlaySound(SOUND_NOTIFY_GO_SMALL_TICK);
						PlaySound(SOUND_SILENT);
					}
					tmrBig.Restart();
					tmrSmall.Restart();
				} else if (tmrSmall > Intervals.GoSmallSound) {
					PlaySound(SOUND_NOTIFY_GO_BIG_TICK);
					tmrSmall.Restart();
				}
			} // //////////////////////////////////////////////////////////////////////////////////////
			public override string ToString() {
				return "`" + base.ToString() + " small:" + tmrSmall.ToString() + " big:" + tmrBig.ToString() + " cnt:" + cnt + "`";
			} // //////////////////////////////////////////////////////////////////////////////////////
		} // ** Go ***********************************************************************************
	} // ** Phases ***********************************************************************************
}
