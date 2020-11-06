using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkillsAssessment.DataAccess;
using SkillsAssessment.Models;

namespace SkillsAssessment.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            // TODO: Add DI and refactor
            AdminModel model = null; // new AdminModel(repo.GetCategoryModels());

            return View(model);
        }

        public IActionResult Categories()
        {
            AdminModel model = null; // new AdminModel(repo.GetCategoryModels());
            return View(model);
        }

        public JsonResult GetCompetencies(int categoryId)
        {
            IEnumerable<CompetencyModel> competencies = null; // repo.GetCompetencyModels(categoryId);
            return Json(competencies);
        }
    }
}
