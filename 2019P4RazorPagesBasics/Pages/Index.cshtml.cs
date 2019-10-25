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

        public string Result { get; set; }

        public void OnGet()
        {
            
            //Data = new CalcData() { A = 12, B = 33 };
        }

        public void OnGetOther(CalcData c)
        {
            Data = new CalcData() { A = 44, B = 66 };
        }

        public void OnGetForced(int a, int b)
        {
            Data = new CalcData() { A = a, B = b };
        }

        private int Calculate(int A, int B, Operation op)
        {
            if (op == Operation.sum) return A + B;
            if (op == Operation.rozdíl) return A - B;
            if (op == Operation.podíl) return A / B;
            return A * B;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                //data v public CalcData Data { get; set; } jsou OK

                Result = $"{Data.A} {Data.Op} {Data.B} = {Calculate(Data.A, Data.B, Data.Op)}";

            }

            return Page();
        }
    }
}