using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Secret_Words.Data;
using Secret_Words.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Secret_Words.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> user;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userman)
        {
            db = context;

            user = userman;
        }
        public IActionResult Index()
        {
            var word = db.Secret_Words
                .OrderByDescending(am => am.TimeStamp).First();

            return View();
        }

        public IActionResult AddWord(string Secret_Words)
        {
            WordModel newWord = new WordModel();

            newWord.Time = DateTime.Now;

            newWord.Username = User.Identity.Name;

            newWord.Word = Secret_Words;

            db.Secret_Words.Add(newWord);

            db.SaveChanges();

            return Redirect(@"/Home/Index");
        }
        public IActionResult Words()
        {
            var allWords = db.Secret_Words.OrderByDescending(am => am.TimeStamp);
            return View(allWords);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
