using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using PALProgrammingWebTest.Models;
using PALProgrammingWebTest.ViewModels;

namespace PALProgrammingWebTest.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            return View(new UsersVM());
        }

        [Route("/Edit/{id}")]
        public IActionResult Edit(int id) {
            return View("~/Views/Home/EditUser.cshtml", new UsersVM(id));
        }

        [Route("/Save/")]
        public IActionResult Save(Users u) {
            new UsersVM().Save(u);
            return Redirect("/?success=true");
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
