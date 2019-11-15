using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Logik.Services
{
    public enum GameStatus
    {
        [Display(Name = "Hra není spuštěna")]
        NotStarted,
        [Display(Name = "Hra probíhá")]
        Running,
        [Display(Name = "Hra skončila")]
        Victory
    }
}
