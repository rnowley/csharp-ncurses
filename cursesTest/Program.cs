using System;
using csharpncurses;
using System.Text;

namespace cursesTest
{
	class MainClass
	{

		public static void Main(string[] args)
		{ 
			IntPtr a = IntPtr.Zero, b = IntPtr.Zero, c = IntPtr.Zero, d = IntPtr.Zero, stdscr;
			int maxX, maxY, halfX, halfY;

			stdscr = NCurses.InitScreen();

			NCurses.GetMaxYX(stdscr, out maxY, out maxX);
			halfX = maxX >> 1;
			halfY = maxY >> 1;

			try {
				a = NCurses.NewWindow(halfY, halfX, 0, 0);
			}
			catch(InternalException) {
				Bomb();
			}

			try {
				b = NCurses.NewWindow(halfY, halfX, 0, halfX);
			}
			catch(InternalException) {
				Bomb();
			}

			try {
				c = NCurses.NewWindow(halfY, halfX, halfY, 0);
			}
			catch(InternalException) {
				Bomb();
			}

			try {
				d = NCurses.NewWindow(halfY, halfX, halfY, halfX);
			}
			catch(InternalException) {
				Bomb();
			}

			NCurses.MoveWAddString(a, 0, 0, "This is window A\n");
			NCurses.WRefresh(a);
			NCurses.MoveWAddString(b, 0, 0, "This is window B\n");
			NCurses.WRefresh(b);
			NCurses.MoveWAddString(c, 0, 0, "This is window C\n");
			NCurses.WRefresh(c);
			NCurses.MoveWAddString(d, 0, 0, "This is window D\n");
			NCurses.WRefresh(d);

			NCurses.NapMilliseconds(5000);

			NCurses.EndWin();
		}

		private static void Bomb()
		{
			NCurses.AddStr("Unable to allocate memory for the new window.\n");
			NCurses.Refresh();
			NCurses.EndWin();
		}

	}
}
