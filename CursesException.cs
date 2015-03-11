using System;

namespace csharpncurses
{
	public class CursesException : Exception
	{
		public CursesException()
		{
		}

		public CursesException(string message)
			: base(message)
		{
		}

		public CursesException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}

