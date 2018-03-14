using System;

namespace csharpncurses
{
    public class Screen {
        private IntPtr _stdscr;

        public Screen() {
            _stdscr = NativeMethods.initscr();
        }

        public int Close() {
            return NativeMethods.endwin();
        }

        public int Refresh() {
            return NativeMethods.refresh();
        }
    }
}