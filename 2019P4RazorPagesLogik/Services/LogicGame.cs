using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logik.Services
{
    public class LogicGame : ILogicGame
    {
        private static readonly Random rnd = new Random();
        public int Secret { get; private set; }
        private int? LastTry { get; set; }
        public int Round { get; private set; }

        public bool IsVictory => Secret == LastTry;
        public int SecretToLastTry
        {
            get
            {
                return LastTry is null? 0 : Secret - (int)LastTry;
            }
        }
        public string GetMessage()
        {
            string result = "";
            if (SecretToLastTry > 0) result = "Too little";
            if (SecretToLastTry < 0) result = "Too much";
            if (SecretToLastTry == 0) result = "BINGO!";
            return result;
        }
        public void StartGame(int from, int to)
        {
            Round = 1;
            Secret = rnd.Next(Math.Min(from, to), Math.Max(from, to) + 1);
        }
        public int Try(int triedValue)
        {
            Round++;
            LastTry = triedValue;
            return SecretToLastTry;
        }
        public string RoundStr
        {
            get
            {
                var ones = Round % 10;
                var tens = Round / 10 % 10;
                string suff = "th";
                if (tens == 1) { suff = "th"; }
                else switch (ones)
                    {
                        case 1: suff = "st"; break;
                        case 2: suff = "nd"; break;
                        case 3: suff = "rd"; break;
                    }
                return Round + suff;
            }
        }
    }
}
