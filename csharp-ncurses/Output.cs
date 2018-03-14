namespace csharpncurses {

    public static class Output {
        
        public static int AddString(string stringToAdd) {
            return NativeMethods.addstr(stringToAdd);
        }
    }
}