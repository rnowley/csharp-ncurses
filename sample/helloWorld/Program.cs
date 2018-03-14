using System;
using csharpncurses;

namespace helloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var screen = new Screen();
            Output.AddString("Goodbye cruel C# programming");
            screen.Refresh();
            Input.GetCh();
            screen.Close();
        }
    }
}
