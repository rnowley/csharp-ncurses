namespace csharpncurses {

    public static class Input {

        public static int GetCh() {
            return NativeMethods.getch();
        }
    }
}