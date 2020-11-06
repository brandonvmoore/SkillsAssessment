using SkillsDataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsAssessment.Models
{
    public class CompetencyModel
    {
        public CompetencyModel() { }

        public CompetencyModel(AssessmentCompetency competency)
        {
            Id = competency.Id;
            Title = competency.Title;
            Question = competency.Question;
            Visible = competency.Visible;
            ScaleLowDescription = competency.ScaleLowDescription;
            ScaleHighDescription = competency.ScaleHighDescription;
            SortOrder = competency.SortOrder;

            Skills = competency.Skills.Select(o => new SkillModel(o)).ToList();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Question { get; set; }
        public List<SkillModel> Skills { get; set; }
        public bool Visible { get; set; }
        public string ScaleLowDescription { get; set; }
        public string ScaleHighDescription { get; set; }
        public int SortOrder { get; set; }
    }
}
