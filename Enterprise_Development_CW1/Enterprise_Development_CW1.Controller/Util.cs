using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_Development_CW1.Controller
{
    public static class Util
    {
        public delegate void ScoreUpdateHandler(ValueType from, ValueType to, string fromVal, string toVal);
        public static event ScoreUpdateHandler UpdateScoreEvent;

        public delegate void GameOverHandler();
        public static event GameOverHandler GameOverEvent;

        public delegate void GameStartHandler();
        public static event GameStartHandler GameStartEvent;

        public delegate void LostLifeHandler();
        public static event LostLifeHandler LostLifeEvent;

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

        public static string BuildGameString(ValueType from, ValueType to)
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

        public static string BuildScoringString(ValueType from, ValueType to, string fromVal, string toVal)
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

            return "Converted  " + fromType + ": " +fromVal +" to " + toType + ": " + toVal;
        }

        public static string BuildScoringString(string from, string to, string fromVal, string toVal)
        {
            

            return "Converted  " + from + ": " + fromVal + " to " + to + ": " + toVal;
        }

        public static void UpdateScore(ValueType from, ValueType to, string fromVal, string toVal)
        {
            UpdateScoreEvent(from, to, fromVal, toVal);
        }

        public static void GameOver()
        {
            GameOverEvent();
        }

        public static void GameStart()
        {
            GameStartEvent();
        }

        public static void LostLife()
        {
            LostLifeEvent();
        }
    }
}
