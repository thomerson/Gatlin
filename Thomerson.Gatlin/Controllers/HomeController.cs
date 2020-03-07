using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using Thomerson.Gatlin.Models;

namespace Thomerson.Gatlin.Controllers
{
    //[EnableCors("AppDomain")]  //路由跨域设置
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Logger _dblogger = LogManager.GetLogger("DbLogger");
            LogEventInfo ei = new LogEventInfo();
            ei.Properties["Desc"] = "我是自定义消息";
            _dblogger.Info(ei);


            _logger.LogInformation("Index page says hello");
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
