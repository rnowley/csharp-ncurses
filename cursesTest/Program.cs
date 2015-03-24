using System;
using csharpncurses;
using System.Text;

namespace cursesTest
{
	class MainClass
	{

		public static void Main(string[] args)
		{

			IntPtr p = IntPtr.Zero;

			IntPtr stdscr = NCurses.InitScreen();

			try {
				p = NCurses.NewPad(50, 100);
			}
			catch(InternalException) {
				NCurses.AddStr("Unable to create new pad");
				NCurses.Refresh();
				NCurses.EndWin();
			}

			NCurses.AddStr("New pad created");
			NCurses.PadRefresh(p, 0, 0, 0, 0, 1, 15);
			NCurses.GetChar();

			NCurses.EndWin();
		}
			
	}
}
