using SkillsDataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsAssessment.Models
{
    public class SkillModel
    {
        public SkillModel() { }

        public SkillModel(AssessmentSkill skill) 
        {
            Id = skill.Id;
            SectionName = skill.SectionName;
            CompetencyId = skill.CompetencyId;
            SectionId = skill.SectionId;
            Text = skill.Text;
            Visible = skill.Visible;
            SortOrder = skill.SortOrder;
        }

        public int Id { get; set; }
        public int SectionName { get; set; }
        public int CompetencyId { get; set; }
        public int SectionId { get; set; }
        public string Text { get; set; }
        public bool Visible { get; set; }
        public int SortOrder { get; set; }
    }
}
