using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkillsAssessment.Models;

namespace SkillsAssessment.Controllers
{
    public class CategoryTitleController : Controller
    {
        public IActionResult Index(string categoryName)
        {
            var model = new CategoryModel();
            model.Title = "Leadership";
            model.Quote = "If you delegate tasks you create followers.\n\nIf you delegate authority you create leaders.";
            return View(model);
        }

        public IActionResult Competencies()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Assessment()
        {
            return View();
        }
    }
}
