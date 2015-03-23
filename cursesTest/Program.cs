using System;
using csharpncurses;
using System.Text;

namespace cursesTest
{
	class MainClass
	{

		public static void Main(string[] args)
		{ 
			IntPtr grandpa = IntPtr.Zero;
			IntPtr father = IntPtr.Zero;
			IntPtr boy = IntPtr.Zero;

			int maxX;
			int maxY;

			IntPtr stdscr = NCurses.InitScreen();
			NCurses.StartColor();
			NCurses.InitPair((short)1, (short)NCursesColor.WHITE, (short)NCursesColor.BLUE);
			NCurses.InitPair(2, (short)NCursesColor.RED, (short)NCursesColor.YELLOW);
			NCurses.InitPair(3, (short)NCursesColor.CYAN, (short)NCursesColor.WHITE);

			NCurses.GetMaxYX(stdscr, out maxY, out maxX);

			try {
				grandpa = NCurses.NewWindow(maxY - 4, maxX - 10, 2, 5);
				father = NCurses.SubWindow(grandpa, maxY - 8, maxX - 20, 4, 10);
				boy = NCurses.SubWindow(father, maxY - 16, maxX - 40, 8, 20);
			}
			catch(InternalException) {
				NCurses.AddStr("Unable to create subwindow\n");
				NCurses.EndWin();
			}

			NCurses.WindowBackground(grandpa, NCurses.ColorPair(1));
			NCurses.WAddStr(grandpa, "Grandpa");
			NCurses.WindowBackground(father, NCurses.ColorPair(2));
			NCurses.WAddStr(father, "Father");
			NCurses.WindowBackground(boy, NCurses.ColorPair(3));
			NCurses.WAddStr(boy, "Boy");
			NCurses.WRefresh(grandpa);
			NCurses.WGetChar(grandpa);

			NCurses.DeleteWindow(boy);
			NCurses.ClearWindow(father);
			NCurses.WAddStr(father, "Bye, son!\n");
			NCurses.WRefresh(father);
			NCurses.WGetChar(grandpa);

			NCurses.EndWin();
		}
			
	}
}
