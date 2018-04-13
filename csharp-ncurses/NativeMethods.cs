using System;
using System.Runtime.InteropServices;
using System.Text;

namespace csharpncurses
{
    public static class NativeMethods {
        const string cursesLib = "libncurses.so.5.9";

        [DllImport(cursesLib)]
		public static extern int addch(int ch);

        [DllImport(cursesLib, CharSet = CharSet.Ansi)]
		public static extern int addstr(String str);

        [DllImport(cursesLib)]
		public static extern int attroff(uint attributes);

		[DllImport(cursesLib)]
		public static extern int attron(uint attributes);

		[DllImport(cursesLib)]
		public static extern int attrset(uint attributes);

        [DllImport(cursesLib)]
		public static extern int endwin();

        [DllImport(cursesLib)]
		public static extern int getch();

        [DllImport(cursesLib)]
		public static extern int getnstr(StringBuilder message, int numberOfCharacters);

		[DllImport(cursesLib)]
		public static extern int getstr(StringBuilder message);

        [DllImport(cursesLib)]
		public static extern Boolean has_colors();

        [DllImport(cursesLib)]
		public static extern IntPtr initscr();

        [DllImport(cursesLib)]
		public static extern int move(int y, int x);

        [DllImport(cursesLib)]
		public static extern int napms(int milliseconds);

        [DllImport(cursesLib)]
		public static extern int refresh();

        [DllImport(cursesLib)]
		public static extern int start_color();
    }
}