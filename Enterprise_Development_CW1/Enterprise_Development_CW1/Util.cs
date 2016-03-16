using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_Development_CW1
{
    static class Util
    {
        public delegate void ScoreUpdateHandler(ValueType from, ValueType to);
        public static event ScoreUpdateHandler UpdateScoreEvent;
        public static string HexConverted(string strBinary)
        {
            string strHex = Convert.ToInt32(strBinary, 2).ToString("X");
            return strHex;
        }

        public static bool OnlyHexInString(string test)
        {
            // For C-style hex notation (0xFF) you can use @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z"
            return System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z");
        }

        public static string buildGameString(ValueType from, ValueType to)
        {
            string fromType = "";
            string toType = "";
            switch (from)
            {
                case ValueType.Decimal:
                    fromType = "Decimal";
                    break;
                case ValueType.Binary:
                    fromType = "Binary";
                    break;
                case ValueType.Hexadecimal:
                    fromType = "Hexadecimal";
                    break;
            }

            switch (to)
            {
                case ValueType.Decimal:
                    toType = "Decimal";
                    break;
                case ValueType.Binary:
                    toType = "Binary";
                    break;
                case ValueType.Hexadecimal:
                    toType = "Hexadecimal";
                    break;
            }

            return "Convert the above value of type " + fromType + " to type " + toType;
        }

        public static void UpdateScore(ValueType from, ValueType to)
        {
            UpdateScoreEvent(from, to);
        }
    }
}
