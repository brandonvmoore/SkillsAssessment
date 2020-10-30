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
        MockDataRepository repo = new MockDataRepository();

        public IActionResult Index()
        {
            // TODO: Add DI and refactor
            var model = new AdminModel(repo.GetCategoryModels());

            return View(model);
        }

        public IActionResult Categories()
        {
            var model = new AdminModel(repo.GetCategoryModels());
            return View(model);
        }

        public JsonResult GetCompetencies(int categoryId)
        {
            var competencies = repo.GetCompetencyModels(categoryId);
            return Json(competencies);
        }

        [HttpPost]
        public JsonResult AddCategory(CategoryModel model)
        {
            return Json(new { id = repo.AddCategory(model.Title, model.Quote) });
        }
    }
}
