using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsAssessment.Models
{
    public class CompetencyModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Question { get; set; }
        public List<SkillModel> Skills { get; set; }
        public bool AutoIncludeOnNewAssessments { get; set; }
        public string ScaleLowDescription { get; set; }
        public string ScaleHighDescription { get; set; }
    }
}
