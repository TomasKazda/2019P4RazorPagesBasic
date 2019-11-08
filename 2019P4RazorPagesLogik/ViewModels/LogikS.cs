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

        public bool EndGame => Secret > 0 && SecretToLastTry == 0;

        public string RoundStr
        {
            get
            {
                var ones = Round % 10;
                var tens = Round / 10 % 10;
                string suff = "th";
                if (tens == 1) { suff = "th"; } 
                else switch (ones) {
                        case 1: suff = "st"; break;
                        case 2: suff = "nd"; break;
                        case 3: suff = "rd"; break;
                    }
                return Round + suff;
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

        public string GetAlertClass()
        {
            if (SecretToLastTry > 0) { return "primary"; }
            if (SecretToLastTry < 0) { return "danger"; }
            return "success";
        }
    }
}