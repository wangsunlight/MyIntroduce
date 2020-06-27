using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyIntroduce.Web.Common.Error;
using MyIntroduce.Web.Data;

namespace MyIntroduce.Web.Controllers
{
    public class AboutController : Controller
    {
        private MyContext _myContext;
        private readonly ILogger<AboutController> _logger;

        public AboutController(ILogger<AboutController> logger, MyContext myContext)
        {
            _logger = logger;
            _myContext = myContext;
        }

        [Route("/{Url}/About")]
        public async Task<IActionResult> Index(string Url)
        {
            var user = await _myContext.Users
                .Include(u => u.Summarys)
                .Include(u => u.Skills)
                .Include(u => u.Projects)
                .Include(u => u.Introduces)
                .SingleOrDefaultAsync(u => u.Url == Url);

            ViewBag.Project = await _myContext.Projects
                .Include(u => u.ProjectDetails)
                .Where(p => p.UserID == user.UserId).ToListAsync();

            if (user == null)
            {
                throw new MyExcepton("用户信息无效");
            }

            return View(user);
        }

        public async Task<IActionResult> Index()
        {
            var user = await _myContext.Users
                .Include(u => u.Summarys)
                .Include(u => u.Skills)
                .Include(u => u.Projects)
                .Include(u => u.Introduces)
                .SingleOrDefaultAsync(u => u.Url == "zhaoyang");

            ViewBag.Project = await _myContext.Projects
                .Include(u => u.ProjectDetails)
                .Where(p => p.UserID == user.UserId).ToListAsync();

            if (user == null)
            {
                throw new MyExcepton("用户信息无效");
            }

            return View(user);
        }
    }
}