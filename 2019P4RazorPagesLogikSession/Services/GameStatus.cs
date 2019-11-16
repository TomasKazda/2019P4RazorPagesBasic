using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Logik.Services
{
    public enum GameStatus
    {
        [Display(Name = "Game is not Running")]
        NotStarted,
        [Display(Name = "Game runníng...")]
        Running,
        [Display(Name = "Game is over")]
        Victory
    }
}
