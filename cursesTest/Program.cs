using System;
using csharpncurses;

namespace cursesTest
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			IntPtr stdscr = NCurses.InitScreen();
			NCurses.AddStr("Hello NCurses C#!");
			NCurses.Refresh();
			NCurses.GetCh();

			NCurses.EndWin();
		}
	}
}
