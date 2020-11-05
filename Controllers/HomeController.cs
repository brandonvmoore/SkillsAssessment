using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillsAssessment.Models;
using SkillsDataAccess;
using SkillsDataAccess.Domain;

namespace SkillsAssessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var o = new DbContextOptionsBuilder<AppDbContext>();
            o.UseSqlServer(Startup.SkillsCxnString);
            AppDbContext ctx = new AppDbContext(o.Options);

            ctx.Assessments.Add(new Assessment()
            {
                Title = "Sales Assessment",
                Categories = new List<AssessmentCategory>() { new AssessmentCategory() { Title = "Test Category"} }
            });
            ctx.SaveChanges();
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
