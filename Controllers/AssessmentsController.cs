using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkillsAssessment.Models;
using SkillsAssessment.DataAccess;
using Microsoft.AspNetCore.Cors;
using SkillsDataAccess;
using Microsoft.EntityFrameworkCore;
using Omu.ValueInjecter;

namespace SkillsAssessment.Controllers
{
    public class AssessmentsController : Controller
    {
        readonly SqlRepository sqlRepo;

        public AssessmentsController(SqlRepository sqlRepository)
        {
            sqlRepo = sqlRepository;
        }

        public IActionResult Index()
        {
            var model = new AssessmentModel(sqlRepo.GetAssessment(10));
            return View(model);
        }

        public JsonResult GetCompetencies(int assessmentId, int categoryId)
        {
            var comps = sqlRepo.GetCompetencies(categoryId, assessmentId);
            var compModels = comps.Select(o => new CompetencyModel(o));

            return Json(compModels);
        }

        public JsonResult GetSkills(int assessmentId, int categoryId, int competencyId)
        {
            var comp = sqlRepo.GetCompetencies(categoryId, assessmentId).Single(o => o.Id == competencyId);
            var skillModels = comp.Skills.Select(o => new SkillModel(o));

            return Json(skillModels);
        }

        [HttpPost]
        public PartialViewResult CompetenciesListPartial(int assessmentId, int categoryId)
        {
            var model = sqlRepo.GetCompetencies(categoryId, assessmentId).Select(o => new CompetencyModel(o)).ToList();
            return PartialView(model);
        }

        [HttpPost]
        public PartialViewResult SkillsListPartial(int assessmentId, int categoryId, int competencyId)
        {
            if (competencyId == 0)
                return PartialView(new List<SkillModel>());

            var competency = sqlRepo.GetCompetencies(categoryId, assessmentId).FirstOrDefault(o => o.Id == competencyId);
            var skills = competency.Skills.Select(o => new SkillModel(o)).ToList();
            var model = skills ?? new List<SkillModel>();

            return PartialView(model);
        }

        [HttpPost]
        public JsonResult AddCompetency(int categoryId, string competencyName)
        {
            sqlRepo.AddCompetency(categoryId, competencyName);
            return Json("Success");
        }

        [HttpPost]
        public JsonResult AddSkill(int categoryId, int competencyId, string skillText)
        {
            sqlRepo.AddSkill(categoryId, competencyId, skillText);
            return Json("Success");
        }

        [HttpPost]
        public JsonResult UpdateSkillQuestion(int categoryId, int competencyId, string newQuestion)
        {
            sqlRepo.UpdateSkillQuestion(categoryId, competencyId, newQuestion);
            return Json("Success");
        }
    }
}
