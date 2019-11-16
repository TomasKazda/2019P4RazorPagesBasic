using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logik.ViewModels;
using Logik.Services;

namespace Logik.Pages
{
    public class IndexModel : PageModel
    {
        ILogicGame logic;
        public IndexModel(ILogicGame logic)
        {
            this.logic = logic;
        }

        [BindProperty]
        public LogikInit FromTo { get; set; }

        public void OnGet()
        {
            FromTo = new LogikInit() { From = 1, To = 5 };
        }

        public void OnGetRange(int from, int to)
        {
            FromTo = new LogikInit() { From = from, To = to };
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                logic.StartGame(FromTo.From, FromTo.To);

                return RedirectToPage("./Game");
            }
            return Page();
        }
    }
}