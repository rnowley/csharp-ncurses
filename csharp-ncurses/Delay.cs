namespace csharpncurses
{
    public static class Delay {

        public static int Napms(int milliseconds) {
            return NativeMethods.napms(milliseconds);
        } 
    }
}