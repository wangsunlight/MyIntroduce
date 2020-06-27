using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyIntroduce.Web.Common.Error;
using MyIntroduce.Web.Data;

namespace MyIntroduce.Web.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _myContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MyContext myContext)
        {
            _logger = logger;
            _myContext = myContext;
        }

        [Route("/{Url}")]
        public async Task<IActionResult> Index(string Url)
        {
            var user = await _myContext.Users.SingleOrDefaultAsync(u => u.Url == Url);

            if (user == null)
            {
                throw new MyExcepton("用户信息无效");
            }

            return View(user);
        }

        public async Task<IActionResult> Index()
        {
            var user = await _myContext.Users.SingleOrDefaultAsync(u => u.Url == "zhaoyang");

            if (user == null)
            {
                throw new MyExcepton("用户信息无效");
            }

            return View(user);
        }
    }
}
