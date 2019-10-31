using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Logik.ViewModels
{
    public class LogikInit
    {
        [Display(Name = "From number")]
        [Range(1, 100, ErrorMessage = "Only number from {1} to {2}")]
        public int From { get; set; }

        [Display(Name = "To number")]
        [Range(1, 10000, ErrorMessage = "Only number from {1} to {2}")]
        public int To { get; set; }
    }
}
