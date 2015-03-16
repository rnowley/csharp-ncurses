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
			InitScreen();

			StartColor();
			InitPair(1, (short)NCursesColor.WHITE, (short)NCursesColor.BLUE);
			InitPair(2, (short)NCursesColor.GREEN, (short)NCursesColor.WHITE);
			InitPair(3, (short)NCursesColor.RED, (short)NCursesColor.GREEN);
			Background(ColorPair(1));
			AddStr("I think I shall never see\n");
			AddStr("A colour screen as pretty as thee.\n");
			AddStr("For seasons may change\n");
			AddStr("and storms may thunder;\n");
			AddStr("But colour text shall always wonder.");

			Refresh();
			GetChar();

			Background(ColorPair(2));
			Refresh();
			GetChar();

			Background(ColorPair(3));
			Refresh();
			GetChar();

			EndWin();
		}

		private static void Bomb(string message)
		{
			NCurses.EndWin();
			Console.WriteLine(message);
		}
	}
}
