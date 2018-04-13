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

        public bool HasColours() {
            return NativeMethods.has_colors();
        }

        public int MoveCursor(int row, int column) {
            return NativeMethods.move(row, column);
        }

        public int Refresh() {
            return NativeMethods.refresh();
        }
    }
}