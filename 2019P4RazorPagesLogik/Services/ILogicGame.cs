using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logik.Services
{
    public interface ILogicGame
    {
        void StartGame(int from, int to);
        int Round { get; }
        string RoundStr { get; }
        int? Secret { get; }
        GameStatus GameStatus { get; }
        string GetMessage();
        int Try(int triedValue);
        int SecretToLastTry { get; }
    }
}
