﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logik.ViewModels;
using Logik.Services;

namespace Logik.Pages
{
    public class GameModel : PageModel
    {
        private static readonly Random rnd = new Random();

        readonly ISessionController<LogicGame> logicgame;
        readonly LogicGame logic;
        public GameModel(ISessionController<LogicGame> logicgame)
        {
            this.logic = logicgame.LoadOrCreate(LogicGameKey.Key);
            this.logicgame = logicgame;
        }

        [BindProperty]
        public LogikS LogikData { get; set; }

        //zobrazované vlastnosti
        public string AlertClass
        {
            get
            {
                if (logic.SecretToLastTry > 0) { return "primary"; }
                if (logic.SecretToLastTry < 0) { return "danger"; }
                return "success";
            }
        }
        public bool IsRunning => logic.GameStatus == GameStatus.Running;
        public bool IsVictory => logic.GameStatus == GameStatus.Victory;
        public int Round => logic.Round;
        public int Secret => logic.Secret ?? -999;
        public string RoundStr => logic.RoundStr;
        public string Message { get; set; } = "";
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                logic.Try(LogikData.LastTry);
                Message = logic.GetMessage();
                logicgame.Save(LogicGameKey.Key, logic);
                RedirectToPage();
            }
            return Page();
        }
    }
}