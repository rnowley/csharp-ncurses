using System;
using System.Runtime.InteropServices;

namespace csharpncurses
{
    public static class NativeMethods {
        const string cursesLib = "libncurses.so.5.9";

        [DllImport(cursesLib, CharSet = CharSet.Ansi)]
		public static extern int addstr(String str);

        [DllImport(cursesLib)]
		public static extern int endwin();

        [DllImport(cursesLib)]
		public static extern int getch();

        [DllImport(cursesLib)]
		public static extern IntPtr initscr();

        [DllImport(cursesLib)]
		public static extern int refresh();
    }
}