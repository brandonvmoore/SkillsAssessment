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

        [HttpPost]
        public PartialViewResult CompetenciesListPartial(int assessmentId, int categoryId)
        {
            var model = repo.GetCompetencyModels(categoryId);
            return PartialView(model);
        }

        [HttpPost]
        public PartialViewResult SkillsListPartial(int assessmentId, int categoryId, int competencyId)
        {
            if (competencyId == 0)
                return PartialView(new List<SkillModel>());

            var competency = repo.GetCompetencyModels(categoryId).FirstOrDefault(o => o.Id == competencyId);
            var model = competency.Skills ?? new List<SkillModel>();

            return PartialView(model);
        }

        [HttpPost]
        public JsonResult AddCompetency(int categoryId, string competencyName)
        {
            repo.AddCompetency(categoryId, competencyName);
            MockDataRepository.SaveToXml();
            return Json("Success");
        }

        [HttpPost]
        public JsonResult AddSkill(int categoryId, int competencyId, string skillText)
        {
            repo.AddSkill(categoryId, competencyId, skillText);
            MockDataRepository.SaveToXml();
            return Json("Success");
        }

        [HttpPost]
        public JsonResult UpdateSkillQuestion(int categoryId, int competencyId, string newQuestion)
        {
            repo.UpdateSkillQuestion(categoryId, competencyId, newQuestion);
            MockDataRepository.SaveToXml();
            return Json("Success");
        }
    }
}
