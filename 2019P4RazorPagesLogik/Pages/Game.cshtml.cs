using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logik.Model;

namespace Logik.Pages
{
    public class GameModel : PageModel
    {
        private static readonly Random rnd = new Random();

        [BindProperty]
        public LogikS LogikData { get; set; }

        public IActionResult OnGet()
        {
            return RedirectToPage("Index");
        }

        public void OnGetInit(int from, int to)
        {
            LogikData = new LogikS() { LastTry = Math.Abs((from - to) / 2), Round = 1, Secret = rnd.Next(Math.Min(from, to), Math.Max(from, to) + 1) };
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                LogikData.Round++;
            }
            return Page();
        }
    }
}