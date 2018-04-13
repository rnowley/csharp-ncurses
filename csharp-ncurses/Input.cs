using System;
using System.Text;

namespace csharpncurses {

    public static class Input {

        public static char GetCh() {
            return Convert.ToChar(NativeMethods.getch());
        }

        public static string GetString() {
            StringBuilder buffer = new StringBuilder();

            NativeMethods.getstr(buffer);
            return buffer.ToString();
        }

        public static string GetNString(int length) {
            StringBuilder buffer = new StringBuilder();

            NativeMethods.getnstr(buffer, length);
            return buffer.ToString();
        }
    }
}