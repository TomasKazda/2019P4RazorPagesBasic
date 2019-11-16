using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utf8Json;

namespace Logik.Services
{
    public class LogicGame : ILogicGame
    {
        private static readonly Random rnd = new Random();
        public LogicGame() { }

        [SerializationConstructor]
        protected LogicGame(int? secret = null, int? lastTry = null, int round = 0)
        {
            Secret = secret;
            LastTry = lastTry;
            Round = round;
        }

        public int? Secret { get; private set; }
        private int? LastTry { get; set; }
        public int Round { get; private set; }

        protected bool IsVictory => Secret == LastTry;
        public int SecretToLastTry
        {
            get
            {
                return LastTry is null? -1 : (int)Secret - (int)LastTry;
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
                int Round = this.Round - 1;
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
        public GameStatus GameStatus {
            get {
                if (Secret is null) return GameStatus.NotStarted;
                if (IsVictory) return GameStatus.Victory;
                return GameStatus.Running;
            }
        }
    }
}
