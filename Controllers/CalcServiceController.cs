using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Backend1.Models;

namespace Backend1.Controllers
{
    public class CalcServiceController : Controller
    {
        private readonly ILogger<CalcServiceController> _logger;

        public CalcServiceController(ILogger<CalcServiceController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewDataCalc()
        {
            ViewData["calcTitle"] = "PassUsingViewData";

            var rand = new Random();
            int firstRandom = rand.Next(0, 10);
            int secondRandom = rand.Next(0, 10);
            int add = firstRandom + secondRandom;
            int sub = firstRandom - secondRandom;
            int mult = firstRandom * secondRandom;

            try {
                int div = firstRandom / secondRandom;
                ViewData["div"] = div;
            }
            catch (DivideByZeroException) {
                ViewData["div"] = "error";
            }

            ViewData["firstRandom"] = firstRandom;
            ViewData["secondRandom"] = secondRandom;
            ViewData["add"] = add;
            ViewData["sub"] = sub;
            ViewData["mult"] = mult;

            return View("ViewDataCalc");
        }

        public IActionResult ViewBagCalc()
        {
            ViewBag.calcTitle = "PassUsingViewBag";

            var rand = new Random();
            int firstRandom = rand.Next(0, 10);
            int secondRandom = rand.Next(0, 10);
            int add = firstRandom + secondRandom;
            int sub = firstRandom - secondRandom;
            int mult = firstRandom * secondRandom;

            try {
                int div = firstRandom / secondRandom;
                ViewBag.div = div;
            }
            catch (DivideByZeroException) {
                ViewBag.div = "error";
            }

            ViewBag.firstRandom = firstRandom;
            ViewBag.secondRandom = secondRandom;
            ViewBag.add = add;
            ViewBag.sub = sub;
            ViewBag.mult = mult;

            return View("ViewBagCalc");
        }

        public IActionResult WithModelCalc()
        {
            ViewData["calcTitle"] = "PassUsingModel";

            CalcModel calcModel = new CalcModel();

            var rand = new Random();
            int firstRandom = rand.Next(0, 10);
            int secondRandom = rand.Next(0, 10);

            ViewData["firstRandom"] = firstRandom;
            ViewData["secondRandom"] = secondRandom;
            ViewData["add"] = calcModel.add(firstRandom, secondRandom);
            ViewData["sub"] = calcModel.sub(firstRandom, secondRandom);
            ViewData["mult"] = calcModel.mult(firstRandom, secondRandom);
            if (calcModel.div(firstRandom, secondRandom) < 0) {
                ViewData["div"] = "error";
            } else {
                ViewData["div"] = calcModel.div(firstRandom, secondRandom);
            }

            return View("ModelCalc");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
