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

			var s = InitScreen();

			Centre(s, 1, "Penguin Football Finals");
			Centre(s, 5, "Cattle Dung Samples from Temecula");
			Centre(s, 7, "Catatonic Theater");
			Centre(s, 9, "Why Do Ions Hate Each Other?");
			GetChar();

			EndWin();
		}

		private static void Centre(IntPtr standardScreen, int row, string title)
		{
			int y;
			int width;
			int indent;

			GetMaxYX(standardScreen, out y, out width);
			indent = width - title.Length;
			indent /= 2;

			MoveAddString(row, indent, title);
			Refresh();
		}
	}
}
