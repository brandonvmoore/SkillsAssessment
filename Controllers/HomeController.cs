using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillsAssessment.DataAccess;
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
            //MigrateData();
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

        //public void MigrateData()
        //{
        //    // Migrate Mock data
        //    var data = new MockDataRepository();
        //    var categories = data.GetCategoryModels();

        //    var o = new DbContextOptionsBuilder<AppDbContext>();
        //    o.UseSqlServer(Startup.SkillsCxnString);
        //    AppDbContext ctx = new AppDbContext(o.Options);

        //    // Create 1st assessment
        //    Assessment asmt = new Assessment();
        //    asmt.Title = "Sales Assessment";
        //    asmt.Tenant = new Tenant() { TenantName = "Arlensa" };
        //    asmt.Categories = new List<AssessmentCategory>();


        //    foreach (var c in categories)
        //    {
        //        var asmtCat = new AssessmentCategory();
        //        asmtCat.Quote = c.Quote;
        //        asmtCat.Title = c.Title;
        //        asmtCat.Visible = true;
        //        asmtCat.Competencies = new List<AssessmentCompetency>();

        //        foreach (var cc in c.Competencies)
        //        {
        //            var comp = new AssessmentCompetency();
        //            comp.Question = cc.Question;
        //            comp.ScaleHighDescription = cc.ScaleHighDescription;
        //            comp.ScaleLowDescription = cc.ScaleLowDescription;
        //            comp.Title = cc.Title;
        //            comp.Visible = true;
        //            comp.Skills = new List<AssessmentSkill>();

        //            foreach (var skill in cc.Skills)
        //            {
        //                var s = new AssessmentSkill();
        //                s.Text = skill.Text;
        //                s.Visible = true;
        //                comp.Skills.Add(s);
        //            }
        //            asmtCat.Competencies.Add(comp);
        //        }
        //        asmt.Categories.Add(asmtCat);
        //    }

        //    ctx.Add(asmt);
        //    ctx.SaveChanges();
        //}
    }
}
