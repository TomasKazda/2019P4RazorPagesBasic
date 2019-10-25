using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesBasics.ViewModels
{
    public enum Operation
    {   
        [Display(Name = "součet")]
        sum = 1,
        rozdíl,
        součin,
        podíl
    }
    public class CalcData
    {
        [Display(Name = "První číslo")]
        public int A { get; set; }

        [Display(Name = "Druhé číslo")]
        [Range(1, 100, ErrorMessage = "Zadej jen číslo od {1} do {2}")]
        public int B { get; set; }

        [Display(Name = "Operace")]
        public Operation Op { get; set; }
    }
}
