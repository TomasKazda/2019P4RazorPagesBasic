using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Logik.ViewModels
{
    public class LogikS
    {
  
        [ScaffoldColumn(false)]
        public int Secret { get; set; }
        [Display(Name = "Round #")]
        public int Round { get; set; }
        [Display(Name = "Enter Your Try")]
        public int LastTry { get; set; }

        public int SecretToLastTry => Secret - LastTry;
        
        public string GetMessage()
        {
            string result = "";
            if (SecretToLastTry > 0) result = "Too little";
            if (SecretToLastTry < 0) result = "Too much";
            if (SecretToLastTry == 0) result = "BINGO!";
            return result;
        }
    }
}