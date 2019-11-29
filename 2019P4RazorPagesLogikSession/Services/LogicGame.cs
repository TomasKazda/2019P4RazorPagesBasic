using System;
using System.Runtime.Serialization;

namespace Logik.Services
{
    public class LogicGame : ILogicGame
    {
        private static readonly Random rnd = new Random();
        //public LogicGame() { }

        //[SerializationConstructor]
        //protected LogicGame(int? secret = null, int? lastTry = null, int round = 0)
        //{
        //    Secret = secret;
        //    LastTry = lastTry;
        //    Round = round;
        //}

        public int? Secret { get; private set; }
        private int? LastTry { get; set; }
        public int Round { get; private set; }
        public int Min { get; private set; }
        public int Max { get; private set; }

        [IgnoreDataMember]
        protected bool IsVictory => Secret == LastTry;

        [IgnoreDataMember]
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
            Min = Math.Min(from, to);
            Max = Math.Max(from, to);
            Secret = rnd.Next(Min, Max + 1);
        }
        public int Try(int triedValue)
        {
            if (triedValue >= Secret) Max = triedValue-1;
            if (triedValue <= Secret) Min = triedValue+1;
            Round++;
            LastTry = triedValue;
            return SecretToLastTry;
        }

        [IgnoreDataMember]
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

        [IgnoreDataMember]
        public GameStatus GameStatus {
            get {
                if (Secret is null) return GameStatus.NotStarted;
                if (IsVictory) return GameStatus.Victory;
                return GameStatus.Running;
            }
        }
    }
}
