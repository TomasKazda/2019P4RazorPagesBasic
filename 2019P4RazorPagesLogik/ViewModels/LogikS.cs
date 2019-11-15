using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Logik.ViewModels
{
    public class LogikS
    {
        [Display(Name = "Enter Your Try")]
        public int LastTry { get; set; }
    }
}