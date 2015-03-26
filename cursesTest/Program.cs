using csharpncurses;
using System;

namespace cursesTest
{
	class MainClass
	{

		public static void Main(string[] args)
		{
			string[] labelText = { 
				"I", "AM", "SAM", "DO", "NOT", "LIKE", "THAT", "SAY",
				"WOULD", "COULD", "YOU", "GREEN EGGS AND HAM"
			};

			NCurses.InitSoftKeyLabels(2);
			IntPtr stdcr = NCurses.InitScreen();
			NCurses.NoEcho();
			NCurses.Keypad(stdcr, true);

			for(int label = 0; label < labelText.Length; ++label) {
				NCurses.SetSoftKeyLabel(label + 1, labelText[label], SoftLabelPositionEnum.CENTER);
			}

			NCurses.RefreshSoftKeyLabels();
			NCurses.AddStr("Use the function keys to type.\n");
			NCurses.AddStr("Press '?' or '!' or '.' to end a line.\n");
			NCurses.AddStr("Press Enter to quit.\n\n");
			NCurses.Refresh();

			int character;

			while((character = NCurses.GetChar()) != '\n') {

				switch(character) {
				case '?':
				case '!':
				case '.':
					NCurses.AddChar(character);
					NCurses.AddChar('\n');
					break;
				case (int)KeyCodesEnum.KEY_F1:
					NCurses.AddStr(string.Format("{0} ", labelText[0]));
					break;
				case (int)KeyCodesEnum.KEY_F2:
					NCurses.AddStr(string.Format("{0} ", labelText[1]));
					break;
				case (int)KeyCodesEnum.KEY_F3:
					NCurses.AddStr(string.Format("{0} ", labelText[2]));
					break;
				case (int)KeyCodesEnum.KEY_F4:
					NCurses.AddStr(string.Format("{0} ", labelText[3]));
					break;
				case (int)KeyCodesEnum.KEY_F5:
					NCurses.AddStr(string.Format("{0} ", labelText[4]));
					break;
				case (int)KeyCodesEnum.KEY_F6:
					NCurses.AddStr(string.Format("{0} ", labelText[5]));
					break;
				case (int)KeyCodesEnum.KEY_F7:
					NCurses.AddStr(string.Format("{0} ", labelText[6]));
					break;
				case (int)KeyCodesEnum.KEY_F8:
					NCurses.AddStr(string.Format("{0} ", labelText[7]));
					break;
				case (int)KeyCodesEnum.KEY_F9:
					NCurses.AddStr(string.Format("{0} ", labelText[8]));
					break;
				case (int)KeyCodesEnum.KEY_F10:
					NCurses.AddStr(string.Format("{0} ", labelText[9]));
					break;
				case (int)KeyCodesEnum.KEY_F11:
					NCurses.AddStr(string.Format("{0} ", labelText[10]));
					break;
				case (int)KeyCodesEnum.KEY_F12:
					NCurses.AddStr(string.Format("{0} ", labelText[11]));
					break;
				default:
					break;
				}
					
			}

			NCurses.EndWin();
		}

		private static void Bomb(string message)
		{
			NCurses.AddStr(message);
			NCurses.Refresh();
			NCurses.GetChar();
			NCurses.EndWin();
		}
			
	}
}
