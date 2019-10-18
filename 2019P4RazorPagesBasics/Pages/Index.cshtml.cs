using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesBasics.ViewModels;

namespace RazorPagesBasics.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public CalcData Data { get; set; }

        public void OnGet()
        {
            //Data = new CalcData() { A = 12, B = 33 };
        }

        public void OnGetOther()
        {
            Data = new CalcData() { A = 44, B = 66 };
        }

        public void OnGetForced(int a, int b)
        {
            Data = new CalcData() { A = a, B = b };
        }
    }
}