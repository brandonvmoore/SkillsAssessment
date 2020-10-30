using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkillsAssessment.Models;
using SkillsAssessment.DataAccess;
using Microsoft.AspNetCore.Cors;

namespace SkillsAssessment.Controllers
{
    public class AssessmentsController : Controller
    {
        MockDataRepository repo = new MockDataRepository();

        public IActionResult Index()
        {
            var model = new AssessmentModel();
            model.Title = "Sales Assessment";
            model.Categories = repo.GetAssessmentCategories();
            return View(model);
        }

        public JsonResult GetCompetencies(int assessmentId, int categoryId)
        {
            var competencies = repo.GetCompetencyModels(categoryId);
            return Json(competencies);
        }

        public JsonResult GetSkills(int assessmentId, int categoryId, int competencyId)
        {
            var competency = repo.GetCompetencyModels(categoryId).FirstOrDefault(o => o.Id == competencyId);
            return Json(competency.Skills);
        }

        [EnableCors]
        public PartialViewResult CompetenciesListPartial(int assessmentId, int categoryId)
        {
            var model = repo.GetCompetencyModels(categoryId);
            return PartialView(model);
        }

        [EnableCors]
        public PartialViewResult SkillsListPartial(int assessmentId, int categoryId, int competencyId)
        {
            if (competencyId == 0)
                return PartialView(new List<SkillModel>());

            var competency = repo.GetCompetencyModels(categoryId).FirstOrDefault(o => o.Id == competencyId);
            var model = competency.Skills ?? new List<SkillModel>();

            return PartialView(model);
        }
    }
}
