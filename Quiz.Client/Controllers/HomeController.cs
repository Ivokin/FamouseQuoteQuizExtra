using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Quiz.Client.Models;

namespace Quiz.Client.Controllers
{
    public class HomeController : Controller
    {
        public bool binary;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Binary()
        {
            binary = true;
            return View();
        }

        public IActionResult MultipleChoice()
        {
            binary = false;
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult QuizQuestions()
        {
            return View("QuizQuestions");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
