using SkillsAssessment.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SkillsAssessment.DataAccess
{
    public class MockDataRepository
    {
        static MockDataRepository()
        {
            LoadFromXml();
        }

        static List<CategoryModel> CategoryList = new List<CategoryModel>();
        //{
        //    new CategoryModel() { 
        //        Id = 1, 
        //        Title = "Leadership", 
        //        Quote = "If you delegate tasks you create followers.\n\nIf you delegate authority you create leaders.",
        //        Competencies = new List<CompetencyModel>() 
        //        {
        //            //new CompetencyModel() { Id = 1, Title = "Team Size", Question = "Note the team sizes you’ve led and want to lead" },
        //            //new CompetencyModel() { Id = 2, Title = "Company Size", Question = "Note the company sizes you’ve worked at & want to work for" },
        //            new CompetencyModel() 
        //            { 
        //                Id = 3, 
        //                Title = "Impact", 
        //                Question = "How do you impact organizations?" ,
        //                Skills = new List<SkillModel>()
        //                {
        //                    new SkillModel() { Id = 1, Text = "Build things from scratch" },
        //                    new SkillModel() { Id = 2, Text = "Manage growing companies" },
        //                    new SkillModel() { Id = 3, Text = "Business Process Optimization" },
        //                    new SkillModel() { Id = 4, Text = "Governance, Risk & Compliance" },
        //                    new SkillModel() { Id = 5, Text = "Improve underperforming orgs" },
        //                    new SkillModel() { Id = 6, Text = "Get projects back on track" },
        //                    new SkillModel() { Id = 7, Text = "Maintain smooth running teams" },
        //                    new SkillModel() { Id = 8, Text = "Right-sizing/Down-sizing" },
        //                    new SkillModel() { Id = 9, Text = "M&A - selling" },
        //                    new SkillModel() { Id = 10, Text = "M&A - buying" },
        //                    new SkillModel() { Id = 11, Text = "Prep for IPO" }
        //                }
        //            },
        //            new CompetencyModel() { Id = 4, Title = "Talented At Leading", Question = "Who are you skilled at leading?"}
        //        } 
        //    },
        //    new CategoryModel() { Id = 2, Title = "Communication" },
        //    new CategoryModel() { Id = 3, Title = "Productivity" },
        //};

        public IEnumerable<CategoryModel> GetCategoryModels()
        {
            return CategoryList;
        }

        // TODO: Add parameter for assessmentId.
        public IEnumerable<CategoryModel> GetAssessmentCategories()
        {
            var cats = GetCategoryModels();
            return cats;
        }

        public IEnumerable<CompetencyModel> GetCompetencyModels(int categoryId)
        {
            var category = CategoryList.FirstOrDefault(o => o.Id == categoryId);
            return category?.Competencies ?? new List<CompetencyModel>();
        }

        public int AddCategory(string title, string quote)
        {
            var id = CategoryList.Max(o => o.Id + 1);
            CategoryList.Add(new CategoryModel() { Id = id, Title = title, Quote = quote });
            return id;
        }

        public void AddCompetency(string title, string description, int categoryId)
        {
            var category = CategoryList.FirstOrDefault(o => o.Id == categoryId);

            if (category != null)
            {
                int id = category.Competencies.Select(o => o.Id).DefaultIfEmpty().Max() + 1;
                category.Competencies.Add(new CompetencyModel() { Id = id, Title = title, Question = description });
            }
        }
    
        public static void SaveToXml()
        {
            var path = @"C:\temp\SkillsAssessment_Categories.xml";
            var writer = new XmlSerializer(typeof(List<CategoryModel>));
            using (var file = File.Create(path))
                writer.Serialize(file, CategoryList);
        }

        public static void LoadFromXml()
        {
            var path = @"C:\temp\SkillsAssessment_Categories.xml";
            var reader = new XmlSerializer(typeof(List<CategoryModel>));
            using (var file = new StreamReader(path))
                CategoryList = (List<CategoryModel>)reader.Deserialize(file);
        }
    }
}