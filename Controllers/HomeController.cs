using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RedisTest.Models;
using StackExchange.Redis;

namespace RedisTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ConnectionMultiplexer _redis;
        private IDatabase _redisDatabase;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
             
         
        }

        public IActionResult Index()

        {

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