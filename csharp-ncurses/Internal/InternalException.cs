using System;

namespace csharpncurses
{
	public class InternalException : CursesException
	{
		internal InternalException()
		{
		}

		internal InternalException(string message)
			: base(message)
		{
		}

		internal InternalException(string message, Exception inner)
			: base(message, inner)
		{
		}

		internal static void Verify(int result, string fname)
		{
			if(result == -1)
				throw new InternalException(fname + "() returned ERR");
		}

		internal static void Verify(IntPtr result, string fname)
		{
			if(result == IntPtr.Zero)
				throw new InternalException(fname + "() returned NULL");
		}
	}
}

