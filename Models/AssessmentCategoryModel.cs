using SkillsDataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsAssessment.Models
{
    public class CategoryModel
    {
        public CategoryModel() { }

        public CategoryModel(AssessmentCategory category)
        {
            Id = category.Id;
            Title = category.Title;
            Quote = category.Quote;
            SortOrder = category.SortOrder;
            Visible = category.Visible;

            Competencies = category.Competencies.Select(o => new CompetencyModel(o)).ToList();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Quote { get; set; }
        public List<CompetencyModel> Competencies { get; set; }
        public int SortOrder { get; set; }
        public bool Visible { get; set; }
    }
}