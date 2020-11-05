using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsAssessment.Models
{
    public class SkillModel
    {
        public int Id { get; set; }
        public int AssessmentId { get; set; }
        public int SectionName { get; set; }
        public int CompetencyId { get; set; }
        public int SectionId { get; set; }
        public string Text { get; set; }
        public bool Visible { get; set; }
        public int Response { get; set; }
        public int SortOrder { get; set; }
    }
}
