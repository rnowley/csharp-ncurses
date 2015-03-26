using System;

namespace csharpncurses
{
	public class MouseEvent
	{
		private short _id;
		private int _x;
		private int _y;
		private int _z;
		private long _buttonState;

		public MouseEvent(short id, int x, int y, int z, long buttonState)
		{
			_id = id;
			_x = x;
			_y = y;
			_z = z;
			_buttonState = buttonState;
		}
	}
}

