using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Webapp.dal;
using Webapp.Models;

namespace Webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BodyDataDAL bodyDataDAL;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            bodyDataDAL = new BodyDataDAL();
        }

        public async Task<IActionResult> IndexAsync()
        {
            Task<string> bodyDatas = bodyDataDAL.getBodyDatasAsync();
            string a = bodyDatas.Result;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}