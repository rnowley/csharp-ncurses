using System;
using csharpncurses;
using System.Text;

namespace cursesTest
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			StringBuilder first = new StringBuilder(24);
			NCurses.InitScreen();

			NCurses.AddStr("What is your first name? ");
			NCurses.Refresh();
			NCurses.GetString(first);

			NCurses.AddStr(string.Format("Pleased to meet you {0}", first));
			NCurses.Refresh();
			NCurses.GetChar();

			NCurses.EndWin();
		}
	}
}
