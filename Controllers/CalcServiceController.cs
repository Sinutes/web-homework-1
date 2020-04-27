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

        public IActionResult PassUsingViewData()
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

        public IActionResult PassUsingViewBag()
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

        public IActionResult PassUsingModel()
        {
            ViewData["calcTitle"] = "PassUsingModel";

            CalcModel calcModel = new CalcModel();

            ViewData["firstRandom"] = calcModel._firstRandom;
            ViewData["secondRandom"] = calcModel._secondRandom;
            ViewData["add"] = calcModel.add();
            ViewData["sub"] = calcModel.sub();
            ViewData["mult"] = calcModel.mult();
            if (calcModel.div() < 0) {
                ViewData["div"] = "error";
            } else {
                ViewData["div"] = calcModel.div();
            }

            return View("ModelCalc");
        }

        public IActionResult AccessServiceDirectly()
        {
            return View("Injection");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
