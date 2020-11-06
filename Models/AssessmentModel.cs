using SkillsDataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsAssessment.Models
{
    public class AssessmentModel
    {
        public AssessmentModel() { }

        public AssessmentModel(Assessment asmt)
        {
            Id = asmt.Id;
            Title = asmt.Title;
            IntroPage = asmt.IntroPage;
            Categories = asmt.Categories.Select(o => new CategoryModel(o)).ToList();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string IntroPage { get; set; }
        public List<CategoryModel> Categories { get; set; }

    }
}
