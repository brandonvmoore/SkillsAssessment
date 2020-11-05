using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsAssessment.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Quote { get; set; }
        public List<CompetencyModel> Competencies { get; set; }
        public int SortOrder { get; set; }
        public bool Visible { get; set; }
    }
}