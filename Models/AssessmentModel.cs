using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsAssessment.Models
{
    public class AssessmentModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string IntroPage { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }

    }
}
