using System;
using System.Runtime.InteropServices;
using System.Text;

namespace csharpncurses
{
	public enum NCursesStatusEnum: int
	{
		ERROR = -1,
		OK = 1
	}

	public enum SoftLabelPositionEnum: int
	{
		LEFT,
		CENTER,
		RIGHT
	}

	public enum KeyCodesEnum: int
	{
		KEY_CODE_YES = 256,
		KEY_MIN,
		KEY_BREAK = 257,
		KEY_DOWN,
		KEY_UP,
		KEY_LEFT,
		KEY_RIGHT,
		KEY_HOME,
		KEY_BACKSPACE,
		KEY_F0,
		KEY_F1,
		KEY_F2,
		KEY_F3,
		KEY_F4,
		KEY_F5,
		KEY_F6,
		KEY_F7,
		KEY_F8,
		KEY_F9,
		KEY_F10,
		KEY_F11,
		KEY_F12,
		// Delete-line key
		KEY_DL = 328,
		// Insert-line key
		KEY_IL,
		KEY_DC,
		KEY_IC,
		KEY_EIC,
		KEY_CLEAR,
		KEY_EOS
	}

	public enum NCursesColorEnum: short
	{
		BLACK = 0,
		RED,
		GREEN,
		YELLOW,
		BLUE,
		MAGENTA,
		CYAN,
		WHITE
	}

	public enum MouseEventEnum: long
	{
		BUTTON1_RELEASED = 1,
		BUTTON1_PRESSED,
		BUTTON1_CLICKED = 4,
		BUTTON1_DOUBLE_CLICKED = 8,
		BUTTON1_TRIPLE_CLICKED = 16,
		BUTTON2_RELEASED = 64,
		BUTTON2_PRESSED = 128,
		BUTTON2_CLICKED = 256,
		BUTTON2_DOUBLE_CLICKED = 512,
		BUTTON2_TRIPLE_CLICKED = 1024,
		BUTTON3_RELEASED = 4096,
		BUTTON3_DOUBLE_CLICKED = 32768,
		BUTTON3_TRIPLE_CLICKED = 65536,
		BUTTON4_RELEASED = 262144,
		BUTTON4_PRESSED = 524288,
		BUTTON4_CLICKED = 1048576,
		BUTTON4_DOUBLE_CLICKED = 2097152,
		BUTTON4_TRIPLE_CLICKED = 4194304,
		BUTTON1_RESERVED_EVENT = 32,
		BUTTON2_RESERVED_EVENT = 2048,
		BUTTON3_RESERVED_EVENT = 131072,
		BUTTON4_RESERVED_EVENT = 8388608,
		BUTTON_CTRL = 16777216,
		BUTTON_SHIFT = 33554432,
		BUTTON_ALT = 67108864,
		REPORT_MOUSE_POSITION = 134217728,
		ALL_MOUSE_EVENTS = 134217727
	}

	public enum NCursesAttribute: uint
	{
		NORMAL = 0,
		BOLD = 2097152,
		UNDERLINE = 131072,
		ATTRIBUTES = 4294967040,
		CHAR_TEXT = 255,
		REVERSE = 262144,
		BLINK = 524288,
		DIM = 1048576,
		ALT_CHARSET = 4194304,
		INVIS = 8388608,
		PROTECT = 16777216,
		HORIZONTAL = 33554432,
		LEFT = 67108864,
		LOW = 134217728,
		RIGHT = 268435456,
		TOP = 536870912,
		VERTICAL = 1073741824,
		ITALIC = 2147483648
	}

	public static class NCurses
	{
		const string cursesLib = "libncurses.so.5.9";

		public static int AddChar(int ch)
		{
			int result = addch(ch);
			InternalException.Verify(result, "AddChar");
			return result;
		}

		public static int AddStr(string stringToAdd)
		{
			int ret = addstr(stringToAdd);
			InternalException.Verify(ret, "AddStr");
			return ret;
		}

		public static void AssumeDefaultColors(int f, int b)
		{
			int result = assume_default_colors(f, b);
			InternalException.Verify(result, "AssumeDefaultColors");
		}

		public static void AttributeOff(uint attributes)
		{
			int result = attroff(attributes);
			InternalException.Verify(result, "AttributeOff");
		}

		public static void AttributeOn(uint attributes)
		{
			int result = attron(attributes);
			InternalException.Verify(result, "AttributeOn");
		}

		public static void AttributeSet(uint attributes)
		{
			int result = attrset(attributes);
			InternalException.Verify(result, "AttributeSet");
		}

		public static void Background(uint ch)
		{
			int result = bkgd(ch);
			InternalException.Verify(result, "Background");
		}

		public static void Beep()
		{
			int result = beep();
			InternalException.Verify(result, "Beep");
		}

		public static bool CanChangeColor()
		{
			return can_change_color();
		}

		public static void Clear()
		{
			int result = clear();
			InternalException.Verify(result, "Clear");
		}

		public static void ClearSoftKeyLabels()
		{
			int result = slk_clear();
			InternalException.Verify(result, "ClearSoftKeyLabels");
		}

		public static void ClearToEndOfLine()
		{
			int result = clrtoeol();
			InternalException.Verify(result, "ClearToEndOfLine");
		}

		public static void ClearToBottom()
		{
			int result = clrtobot();
			InternalException.Verify(result, "ClearToBottom");
		}

		public static void ClearWindow(IntPtr window)
		{
			int result = wclear(window);
			InternalException.Verify(result, "ClearWindow");
		}

		public static void ColorContent(short color, out short red, out short green, out short blue)
		{
			int result = color_content(color, out red, out green, out blue);
			InternalException.Verify(result, "ColorContent");
		}

		public static uint ColorPair(int pairNumber)
		{
			return COLOR_PAIR(pairNumber);
		}

		/// <summary>
		/// Copies a chunk of text from one window to another window.
		/// </summary>
		/// <param name="sourceWindow">Source window.</param>
		/// <param name="destinationWindow">Destination window.</param>
		/// <param name="sourceRow">The starting row of the text to be copied.</param>
		/// <param name="sourceColumn">The starting column of the text to be copied.</param>
		/// <param name="destinationRow">The starting row that the text will be copied to.</param>
		/// <param name="destinationColumn">The starting column that the text will be copied to.</param>
		/// <param name="rowOffset">The number of rows of the chunk to be copied.</param>
		/// <param name="columnOffset">The numbe rof columns of the chunk to be copied.</param>
		/// <param name="type">If set to <c>true</c> the the text is copied non-destructively and overlays the 
		/// the existing text. If set to <c>false</c> then the text block replaces the original text.</param>
		public static void CopyWindow(IntPtr sourceWindow, IntPtr destinationWindow, int sourceRow, int sourceColumn,
		                              int destinationRow, int destinationColumn, int rowOffset, int columnOffset, bool type)
		{
			int result = copywin(sourceWindow, destinationWindow, sourceRow, sourceColumn, destinationRow,
				             destinationColumn, rowOffset, columnOffset, type);
			InternalException.Verify(result, "CopyWindow");
		}

		public static void DeleteCharacter()
		{
			int result = delch();
			InternalException.Verify(result, "DeleteCharacter");
		}

		public static void DeleteLine()
		{
			int result = deleteln();
			InternalException.Verify(result, "DeleteLine");
		}

		public static int DeleteWindow(IntPtr window)
		{
			int result = delwin(window);
			return result;
		}

		public static IntPtr DerWindow(IntPtr window, int rows, int columns, int y, int x)
		{
			IntPtr result = derwin(window, rows, columns, y, x);
			InternalException.Verify(result, "DerWindow");
			return result;
		}

		public static void DoUpdate()
		{
			int result = doupdate();
			InternalException.Verify(result, "DoUpdate");
		}

		public static IntPtr DuplicateWindow(IntPtr window)
		{
			IntPtr result = dupwin(window);
			InternalException.Verify(result, "DuplicateWindow");
			return result;
		}

		public static void Echo()
		{
			int result = echo();
			InternalException.Verify(result, "Echo");
		}

		public static void EndWin()
		{
			int ret = endwin();
			InternalException.Verify(ret, "EndWin");
		}

		public static void Erase()
		{
			int result = erase();
			InternalException.Verify(result, "Erase");
		}

		public static void Flash()
		{
			int result = flash();
			InternalException.Verify(result, "Flash");
		}

		public static void FlushInputBuffer()
		{
			int result = flushinp();
			InternalException.Verify(result, "FlushInputBuffer");
		}

		public static int GetChar()
		{
			int result = getch();
			return result;
		}

		public static void GetMaxYX(IntPtr window, out int y, out int x)
		{
			y = getmaxy(window);
			InternalException.Verify(y, "GetMaxYX");
			x = getmaxx(window);
			InternalException.Verify(x, "GetMaxYX");
		}

		public static void GetNString(StringBuilder message, int numberOfCharacters)
		{
			int result = getnstr(message, numberOfCharacters);
			InternalException.Verify(result, "GetNString");
		}

		public static void GetString(StringBuilder message)
		{
			int result = getstr(message);
			InternalException.Verify(result, "Getstring");
		}

		public static void GetYX(IntPtr window, out int y, out int x)
		{
			y = getcury(window);
			InternalException.Verify(y, "GetYX");
			x = getcurx(window);
			InternalException.Verify(x, "GetYX");
		}

		public static bool HasColors()
		{
			return has_colors();
		}

		public static void InitColor(short color, short red, short green, short blue)
		{
			int result = init_color(color, red, green, blue);
			InternalException.Verify(result, "InitColor");
		}

		public static int InitPair(short color, short foreground, short background)
		{
			int result = init_pair(color, foreground, background);
			InternalException.Verify(result, "InitPair");
			return result;
		}

		public static IntPtr InitScreen()
		{
			IntPtr ret = initscr();
			InternalException.Verify(ret, "InitScreen");
			return ret;
		}

		public static void InsertCharacter(uint character)
		{
			int result = insch(character);
			InternalException.Verify(result, "InsertCharacter");
		}

		public static void InsertLine()
		{
			int result = insertln();
			InternalException.Verify(result, "InsertLine");
		}

		/// <summary>
		/// Initialises the specified number of soft labels.
		/// </summary>
		/// <param name="numberOfLabels">Number of soft key labels to create.</param>
		/// <remarks>This method must be called before <see cref="InitScreen"/></remarks>
		public static void InitSoftKeyLabels(int numberOfLabels)
		{
			int result = slk_init(numberOfLabels);
			InternalException.Verify(result, "InitSoftLabelKeys");
		}

		public static bool IsEndWin()
		{
			return isendwin();
		}

		public static void Keypad(IntPtr window, bool enable)
		{
			int result = keypad(window, enable);
			InternalException.Verify(result, "Keypad");
		}

		public static int Move(int y, int x)
		{
			int result = move(y, x);
			InternalException.Verify(result, "Move");
			return result;
		}

		public static int MoveAddCharacter(int y, int x, uint character)
		{
			int result = mvaddch(y, x, character);
			InternalException.Verify(result, "MoveAddCharacter");
			return result;
		}

		public static int MoveAddString(int y, int x, string message)
		{
			int result = mvaddstr(y, x, message);
			InternalException.Verify(result, "MoveAddString");
			return result;
		}

		public static int MoveWAddString(IntPtr window, int y, int x, string message)
		{
			int result = mvwaddstr(window, y, x, message);
			InternalException.Verify(result, "MoveWAddString");
			return result;
		}

		public static void MoveWindow(IntPtr window, int row, int column)
		{
			int result = mvwin(window, row, column);
			InternalException.Verify(result, "MoveWindow");
		}

		public static int NapMilliseconds(int milliseconds)
		{
			int result = napms(milliseconds);
			InternalException.Verify(result, "NapMilliseconds");
			return result;
		}

		public static IntPtr NewPad(int row, int column)
		{
			IntPtr result = newpad(row, column);
			InternalException.Verify(result, "NewPad");
			return result;
		}

		public static IntPtr NewWindow(int rows, int columns, int yOrigin, int xOrigin)
		{
			IntPtr result = newwin(rows, columns, yOrigin, xOrigin);
			InternalException.Verify(result, "NewWindow");
			return result;
		}

		public static void NoDelay(IntPtr window, bool removeDelay)
		{
			int result = nodelay(window, removeDelay);
			InternalException.Verify(result, "NoDelay");
		}

		public static void NoEcho()
		{
			int result = noecho();
			InternalException.Verify(result, "NoEcho");
		}

		public static void Overlay(IntPtr sourceWindow, IntPtr destinationWindow)
		{
			int result = overlay(sourceWindow, destinationWindow);
			InternalException.Verify(result, "Overlay");
		}

		public static void OverWrite(IntPtr sourceWindow, IntPtr destinationWindow)
		{
			int result = overwrite(sourceWindow, destinationWindow);
			InternalException.Verify(result, "Overwrite");
		}



		public static void PadNOutRefresh(IntPtr pad, int padMinRow, int padMinColumn, int screenMinRow,
		                                  int screenMinColumn, int screenMaxRow, int screenMaxColumn)
		{
			int result = pnoutrefresh(pad, padMinRow, padMinColumn, screenMinRow, screenMinColumn,
				             screenMaxRow, screenMaxColumn);
			InternalException.Verify(result, "PadNOutRefresh");
		}

		public static void PadRefresh(IntPtr pad, int padMinRow, int padMinColumn, int screenMinRow,
		                              int screenMinColumn, int screenMaxRow, int screenMaxColumn)
		{
			int result = prefresh(pad, padMinRow, padMinColumn, screenMinRow, screenMinColumn,
				             screenMaxRow, screenMaxColumn);
			InternalException.Verify(result, "PadRefresh");
		}

		public static void PairContent(short pair, out short fg, out short bg)
		{
			int result = pair_content(pair, out fg, out bg);
			InternalException.Verify(result, "PairContent");
		}

		public static int PadEchoChar(IntPtr pad, int character)
		{
			int result = pechochar(pad, character);
			InternalException.Verify(result, "PadEchoChar");
			return result;
		}

		public static short PairNumber(uint pairNumber)
		{
			return PAIR_NUMBER(pairNumber);
		}

		public static int Refresh()
		{
			int ret = refresh();
			InternalException.Verify(ret, "Refresh");
			return ret;
		}

		public static void RefreshSoftKeyLabels()
		{
			int result = slk_refresh();
			InternalException.Verify(result, "RefreshSoftKeyLabels");
		}

		public static void ResizeTerminal(int numberOfLines, int numberOfColumns)
		{
			int ret = resize_term(numberOfLines, numberOfColumns);
			InternalException.Verify(ret, "ResizeTerminal");
		}

		public static void RestoreSoftKeyLabels()
		{
			int result = slk_restore();
			InternalException.Verify(result, "RestoreSoftKeyLabels");
		}

		public static void ScrollNLines(int numberOfLines)
		{
			int result = scrl(numberOfLines);
			InternalException.Verify(result, "NumberOfLInes");
		}

		public static void Scroll(IntPtr window)
		{
			int result = scroll(window);
			InternalException.Verify(result, "Scroll");
		}

		public static void ScrollOk(IntPtr window, bool canScroll)
		{
			int result = scrollok(window, canScroll);
			InternalException.Verify(result, "ScrollOk");
		}





		public static void SetSoftKeyLabel(int labelNumber, string text, SoftLabelPositionEnum position)
		{
			int result = slk_set(labelNumber, text, (int)position);
			InternalException.Verify(result, "SetSoftKeyLabel");
		}

		public static void StartColor()
		{
			int result = start_color();
			InternalException.Verify(result, "StartColour");
		}

		/// <summary>
		/// Creates a new subpad.
		/// </summary>
		/// <returns>A new subpad that belongs to the specified pad.</returns>
		/// <param name="parent">The parent pad that the sub pad belongs to.</param>
		/// <param name="rows">The number of rows that the subpad is to have.</param>
		/// <param name="columns">The number of columns that the subpad is to have.</param>
		/// <param name="y">The y coordinate relative to the parent.</param>
		/// <param name="x">The x coordinate relative to the parent.</param>
		public static IntPtr SubPad(IntPtr parent, int rows, int columns, int y, int x)
		{
			IntPtr result = subpad(parent, rows, columns, y, x);
			InternalException.Verify(result, "SubPad");
			return result;
		}

		public static IntPtr SubWindow(IntPtr parent, int rows, int columns, int y, int x)
		{
			IntPtr result = subwin(parent, rows, columns, y, x);
			InternalException.Verify(result, "SubWindow");
			return result;
		}

		public static void TouchLine(IntPtr window, int row, int column)
		{
			int result = touchline(window, row, column);
			InternalException.Verify(result, "TouchLine");
		}

		public static int TouchWindow(IntPtr window)
		{
			int result = touchwin(window);
			InternalException.Verify(result, "TouchWindow");
			return result;
		}

		public static int UngetChar(int character)
		{
			return ungetch(character);
		}

		public static void UseDefaultColors()
		{
			int result = use_default_colors();
			InternalException.Verify(result, "UseDefaultColors");
		}

		public static int WAddChar(IntPtr window, int character)
		{
			int result = waddch(window, character);
			InternalException.Verify(result, "WAddChar");
			return result;
		}

		public static int WAddStr(IntPtr window, string message)
		{
			int result = waddstr(window, message);
			InternalException.Verify(result, "WAddStr");
			return result;
		}

		public static void WindowBackground(IntPtr window, uint ch)
		{
			int result = wbkgd(window, ch);
			InternalException.Verify(result, "WindowBackground");
		}

		public static int WGetChar(IntPtr window)
		{
			int result = wgetch(window);
			InternalException.Verify(result, "WGetChar");
			return result;
		}

		public static int WRefresh(IntPtr window)
		{
			int result = wrefresh(window);
			InternalException.Verify(result, "WRefresh");
			return result;
		}

		public static void WScrollNLines(IntPtr window, int numberOfLines)
		{
			int result = wscrl(window, numberOfLines);
			InternalException.Verify(result, "WScrollNLInes");
		}

		// ------------------------------------

		[DllImport(cursesLib)]
		private static extern uint COLOR_PAIR(int n);

		[DllImport(cursesLib)]
		private static extern short PAIR_NUMBER(uint n);

		[DllImport(cursesLib)]
		private static extern int assume_default_colors(int f, int b);

		[DllImport(cursesLib)]
		private static extern int addch(int ch);

		[DllImport(cursesLib, CharSet = CharSet.Ansi)]
		private static extern int addstr(String str);

		[DllImport(cursesLib)]
		private static extern int attroff(uint attributes);

		[DllImport(cursesLib)]
		private static extern int attron(uint attributes);

		[DllImport(cursesLib)]
		private static extern int attrset(uint attributes);

		[DllImport(cursesLib)]
		private static extern int beep();

		[DllImport(cursesLib)]
		private static extern int bkgd(uint ch);

		[DllImport(cursesLib)]
		private static extern Boolean can_change_color();

		[DllImport(cursesLib)]
		private static extern int clear();

		[DllImport(cursesLib)]
		private static extern int color_content(short color, out short red, out short green, out short blue);

		[DllImport(cursesLib)]
		private static extern int copywin(IntPtr sourceWindow, IntPtr destinationWindow, int sourceRow, int sourceColumn,
		                                  int destinationRow, int destinationColumn, int rowOffset, int columnOffset, bool type);

		[DllImport(cursesLib)]
		private static extern int clrtobot();

		[DllImport(cursesLib)]
		private static extern int clrtoeol();

		[DllImport(cursesLib)]
		private static extern int delch();

		[DllImport(cursesLib)]
		private static extern int deleteln();

		[DllImport(cursesLib)]
		private static extern int delwin(IntPtr window);

		[DllImport(cursesLib)]
		private static extern IntPtr derwin(IntPtr window, int rows, int columns, int y, int x);

		[DllImport(cursesLib)]
		private static extern int doupdate();

		[DllImport(cursesLib)]
		private static extern IntPtr dupwin(IntPtr window);

		[DllImport(cursesLib)]
		private static extern int echo();

		[DllImport(cursesLib)]
		private static extern int endwin();

		[DllImport(cursesLib)]
		private static extern int erase();

		[DllImport(cursesLib)]
		private static extern int flash();

		[DllImport(cursesLib)]
		private static extern int flushinp();

		[DllImport(cursesLib)]
		private static extern int getch();

		[DllImport(cursesLib)]
		private static extern int getcurx(IntPtr window);

		[DllImport(cursesLib)]
		private static extern int getcury(IntPtr window);

		[DllImport(cursesLib)]
		private static extern int getmaxx(IntPtr window);

		[DllImport(cursesLib)]
		private static extern int getmaxy(IntPtr window);

		[DllImport(cursesLib)]
		private static extern int getnstr(StringBuilder message, int numberOfCharacters);

		[DllImport(cursesLib)]
		private static extern int getstr(StringBuilder message);

		[DllImport(cursesLib)]
		private static extern Boolean has_colors();

		[DllImport(cursesLib)]
		private static extern int init_color(short color, short red, short green, short blue);

		[DllImport(cursesLib)]
		private static extern IntPtr initscr();

		[DllImport(cursesLib)]
		private static extern int init_pair(short color, short fg, short bg);

		[DllImport(cursesLib)]
		private static extern int insch(uint character);

		[DllImport(cursesLib)]
		private static extern int insertln();

		[DllImport(cursesLib)]
		private static extern Boolean isendwin();

		[DllImport(cursesLib)]
		private static extern int keypad(IntPtr window, bool enable);

		[DllImport(cursesLib)]
		private static extern long mousemask(long newMask, long? oldmask);

		[DllImport(cursesLib)]
		private static extern int move(int y, int x);

		[DllImport(cursesLib)]
		private static extern int mvaddch(int row, int column, uint character);

		[DllImport(cursesLib)]
		private static extern int mvaddchnstr(int row, int column, uint character, int numberOfCharacters);

		[DllImport(cursesLib)]
		private static extern int mvaddchstr(int row, int column, uint character);

		[DllImport(cursesLib)]
		private static extern int mvaddnstr(int row, int column, uint character, int numberOfCharacters);

		[DllImport(cursesLib)]
		private static extern int mvaddstr(int row, int column, string message);

		[DllImport(cursesLib)]
		private static extern int mvwaddstr(IntPtr window, int y, int x, string message);

		[DllImport(cursesLib)]
		private static extern int mvwin(IntPtr window, int row, int column);

		[DllImport(cursesLib)]
		private static extern int napms(int milliseconds);

		[DllImport(cursesLib)]
		private static extern IntPtr newpad(int row, int column);

		[DllImport(cursesLib)]
		private static extern IntPtr newwin(int rows, int columns, int yOrigin, int xOrigin);

		[DllImport(cursesLib)]
		private static extern int nodelay(IntPtr window, bool removeDelay);

		[DllImport(cursesLib)]
		private static extern int noecho();

		[DllImport(cursesLib)]
		private static extern int overlay(IntPtr sourceWindow, IntPtr destinationWindow);

		[DllImport(cursesLib)]
		private static extern int overwrite(IntPtr sourceWindow, IntPtr destinationWindow);

		[DllImport(cursesLib)]
		private static extern int pair_content(short pair, out short fg, out short bg);

		[DllImport(cursesLib)]
		private static extern int pechochar(IntPtr pad, int character);

		[DllImport(cursesLib)]
		private static extern int pnoutrefresh(IntPtr pad, int padMinRow, int padMinColumn, int screenMinRow,
		                                       int screenMinColumn, int screenMaxRow, int screenMaxColumn);

		[DllImport(cursesLib)]
		private static extern int prefresh(IntPtr pad, int padMinRow, int padMinColumn, int screenMinRow,
		                                   int screenMinColumn, int screenMaxRow, int screenMaxColumn);

		[DllImport(cursesLib)]
		private static extern int refresh();

		[DllImport(cursesLib)]
		private static extern int resize_term(int nlines, int ncols);

		[DllImport(cursesLib)]
		private static extern int scrl(int numberOfLines);

		[DllImport(cursesLib)]
		private static extern int scroll(IntPtr window);

		[DllImport(cursesLib)]
		private static extern int scrollok(IntPtr window, bool canScroll);

		[DllImport(cursesLib)]
		private static extern int slk_clear();

		[DllImport(cursesLib)]
		private static extern int slk_init(int numberOfLabels);

		[DllImport(cursesLib)]
		private static extern int slk_refresh();

		[DllImport(cursesLib)]
		private static extern int slk_restore();

		[DllImport(cursesLib)]
		private static extern int slk_set(int labelNumber, string text, int position);

		[DllImport(cursesLib)]
		private static extern int start_color();

		[DllImport(cursesLib)]
		private static extern IntPtr subpad(IntPtr parent, int row, int column, int y, int x);

		[DllImport(cursesLib)]
		private static extern IntPtr subwin(IntPtr window, int rows, int colums, int y, int x);

		[DllImport(cursesLib)]
		private static extern int touchline(IntPtr window, int row, int column);

		[DllImport(cursesLib)]
		private static extern int touchwin(IntPtr window);

		[DllImport(cursesLib)]
		private static extern int ungetch(int character);

		[DllImport(cursesLib)]
		private static extern int use_default_colors();

		[DllImport(cursesLib)]
		private static extern int waddch(IntPtr window, int character);

		[DllImport(cursesLib, CharSet = CharSet.Ansi)]
		private static extern int waddstr(IntPtr window, string message);

		[DllImport(cursesLib, CharSet = CharSet.Ansi)]
		private static extern int waddnstr(IntPtr win, String str, int n);

		[DllImport(cursesLib)]
		private static extern int wbkgd(IntPtr window, uint ch);

		[DllImport(cursesLib)]
		private static extern int wclear(IntPtr window);

		[DllImport(cursesLib)]
		private static extern int wgetch(IntPtr win);

		[DllImport(cursesLib)]
		private static extern int wrefresh(IntPtr win);

		[DllImport(cursesLib)]
		private static extern int wscrl(IntPtr window, int numberOfLines);

	}
}

