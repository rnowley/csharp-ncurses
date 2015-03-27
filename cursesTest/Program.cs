using csharpncurses;
using System;

namespace cursesTest
{
	class MainClass
	{

		public static void Main(string[] args)
		{
			IntPtr stdscr = NCurses.InitScreen();

			NCurses.SetCursor(CursorStateEnum.INVISIBLE);
			NCurses.AddStr("  <- The cursor has been turned off");
			NCurses.Move(0, 0);
			NCurses.Refresh();
			NCurses.GetChar();

			NCurses.SetCursor(CursorStateEnum.NORMAL);
			NCurses.AddStr("\n  <- The cursor now on");
			NCurses.Move(1, 0);
			NCurses.Refresh();
			NCurses.GetChar();

			NCurses.SetCursor(CursorStateEnum.VERY_VISIBLE);
			NCurses.AddStr("\n  <- Yhe cursor is now very on");
			NCurses.Move(2, 0);
			NCurses.Refresh();
			NCurses.GetChar();

			NCurses.EndWin();
		}

		private static void Bomb(string message)
		{
			NCurses.AddStr(message);
			NCurses.Refresh();
			NCurses.GetChar();
			NCurses.EndWin();
		}
			
	}
}
