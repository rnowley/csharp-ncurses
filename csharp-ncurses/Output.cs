using System;

namespace csharpncurses {

    public static class Output {
        
        public static int AddString(string stringToAdd) {
            return NativeMethods.addstr(stringToAdd);
        }

        public static int AddLine(string stringToAdd) {
            return AddString(stringToAdd + Environment.NewLine);
        }

        public static int AddChar(char characterToAdd) {
            return NativeMethods.addch(characterToAdd);
        }

        public static int AttributeOn(TextAttribute attribute) {
            return NativeMethods.attron((uint)attribute);
        }

        public static int AttributeOff(TextAttribute attribute) {
            return NativeMethods.attroff((uint)attribute);
        }

        public static int AttributeSet(TextAttribute attribute) {
            return NativeMethods.attrset((uint)attribute);
        }
    }
}