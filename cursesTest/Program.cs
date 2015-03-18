using System;
using csharpncurses;
using csharpncurses.NCurses;
using System.Text;

namespace cursesTest
{
	class MainClass
	{
		public static void Main(string[] args)
		{

			var stdscr = InitScreen();

			AddStr("Press any key to end this program:");

			while(!KbHit(stdscr)) {
			}


			EndWin();
		}

		private static bool KbHit(IntPtr window)
		{
			int character;
			bool r;

			NoDelay(window, true);
			NoEcho();

			character = GetChar();

			if(character == (int)NCursesStatus.ERROR) {
				r = false;
			}
			else {
				r = true;
				UngetChar(character);
			}

			Echo();
			NoDelay(window, false);
			return r;
		}

	}
}
