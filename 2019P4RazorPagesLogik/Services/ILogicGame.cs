using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logik.Services
{
    interface ILogicGame
    {
        void StartGame(int from, int to);
        int Round { get; }
        bool IsVictory { get; }
        string GetMessage();
        int Try(int triedValue);
    }
}
