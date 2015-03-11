using System;
using System.Runtime.InteropServices;

namespace csharpncurses
{

	public static class NCurses
	{
		const string cursesLib = "libncurses.so.5.9";

		public static int AddStr(string stringToAdd)
		{
			int ret = addstr(stringToAdd);
			InternalException.Verify(ret, "AddStr");
			return ret;
		}

		public static void AssumeDefaultColors(int f, int b)
		{
			int result = assume_default_colors(f, b);
			InternalException.Verify(result, "AssumeDefaultColors");
		}

		public static void Background(uint ch)
		{
			int result = bkgd(ch);
			InternalException.Verify(result, "Background");
		}

		public static bool CanChangeColor()
		{
			return can_change_color();
		}

		public static void ColorContent(short color, out short red, out short green, out short blue)
		{
			int result = color_content(color, out red, out green, out blue);
			InternalException.Verify(result, "ColorContent");
		}

		public static uint ColorPair(int pairNumber)
		{
			return COLOR_PAIR(pairNumber);
		}

		public static void EndWin()
		{
			int ret = endwin();
			InternalException.Verify(ret, "EndWin");
		}

		public static int GetCh()
		{
			return getch();
		}

		public static bool HasColors()
		{
			return has_colors();
		}

		public static void InitColor(short color, short red, short green, short blue)
		{
			int result = init_color(color, red, green, blue);
			InternalException.Verify(result, "InitColor");
		}

		public static IntPtr InitScreen()
		{
			IntPtr ret = initscr();
			InternalException.Verify(ret, "InitScreen");
			return ret;
		}

		public static bool IsEndWin()
		{
			return isendwin();
		}

		public static void PairContent(short pair, out short fg, out short bg)
		{
			int result = pair_content(pair, out fg, out bg);
			InternalException.Verify(result, "PairContent");
		}

		public static short PairNumber(uint pairNumber)
		{
			return PAIR_NUMBER(pairNumber);
		}

		public static int Refresh()
		{
			int ret = refresh();
			InternalException.Verify(ret, "Refresh");
			return ret;
		}

		public static void ResizeTerminal(int numberOfLines, int numberOfColumns)
		{
			int ret = resize_term(numberOfLines, numberOfColumns);
			InternalException.Verify(ret, "ResizeTerminal");
		}

		public static void UseDefaultColors()
		{
			int result = use_default_colors();
			InternalException.Verify(result, "UseDefaultColors");
		}

		// ------------------------------------

		[DllImport(cursesLib)]
		private static extern uint COLOR_PAIR(int n);

		[DllImport(cursesLib)]
		private static extern short PAIR_NUMBER(uint n);

		[DllImport(cursesLib)]
		private static extern int assume_default_colors(int f, int b);

		[DllImport(cursesLib, CharSet = CharSet.Ansi)]
		private static extern int addstr(String str);

		[DllImport(cursesLib)]
		private static extern int bkgd(uint ch);

		[DllImport(cursesLib)]
		private static extern Boolean can_change_color();

		[DllImport(cursesLib)]
		private static extern int color_content(short color, out short red, out short green, out short blue);

		[DllImport(cursesLib)]
		private static extern int endwin();

		[DllImport(cursesLib)]
		private static extern int getch();

		[DllImport(cursesLib)]
		private static extern Boolean has_colors();

		[DllImport(cursesLib)]
		private static extern int init_color(short color, short red, short green, short blue);

		[DllImport(cursesLib)]
		private static extern IntPtr initscr();

		[DllImport(cursesLib)]
		private static extern int init_pair(short color, short fg, short bg);

		[DllImport(cursesLib)]
		private static extern Boolean isendwin();

		[DllImport(cursesLib)]
		private static extern int pair_content(short pair, out short fg, out short bg);

		[DllImport(cursesLib)]
		private static extern int refresh();

		[DllImport(cursesLib)]
		private static extern int resize_term(int nlines, int ncols);

		[DllImport(cursesLib)]
		private static extern int start_color();

		[DllImport(cursesLib)]
		private static extern int use_default_colors();

		[DllImport(cursesLib, CharSet = CharSet.Ansi)]
		private static extern int waddnstr(IntPtr win, String str, int n);

		[DllImport(cursesLib)]
		private static extern int wrefresh(IntPtr win);

	}
}

