//using SkillsAssessment.Models;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Xml.Serialization;

//namespace SkillsAssessment.DataAccess
//{
//    public class MockDataRepository
//    {
//        static MockDataRepository()
//        {
//            LoadFromXml();
//        }

//        static List<CategoryModel> CategoryList = new List<CategoryModel>();

//        public IEnumerable<CategoryModel> GetCategoryModels()
//        {
//            return CategoryList;
//        }

//        // TODO: Add parameter for assessmentId.
//        public IEnumerable<CategoryModel> GetAssessmentCategories()
//        {
//            var cats = GetCategoryModels();
//            return cats;
//        }

//        public IEnumerable<CompetencyModel> GetCompetencyModels(int categoryId)
//        {
//            var category = CategoryList.FirstOrDefault(o => o.Id == categoryId);
//            return category?.Competencies ?? new List<CompetencyModel>();
//        }

//        public int AddCategory(string title, string quote)
//        {
//            var id = CategoryList.Max(o => o.Id + 1);
//            CategoryList.Add(new CategoryModel() { Id = id, Title = title, Quote = quote });
//            return id;
//        }

//        public void AddCompetency(int categoryId, string title, string question = null)
//        {
//            var category = CategoryList.FirstOrDefault(o => o.Id == categoryId);

//            if (category != null)
//            {
//                int id = category.Competencies.Select(o => o.Id).DefaultIfEmpty().Max() + 1;
//                category.Competencies.Add(new CompetencyModel() { Id = id, Title = title, Question = question });
//            }
//        }

//        public void UpdateSkillQuestion(int categoryId, int competencyId, string newQuestion)
//        {
//            var category = CategoryList.FirstOrDefault(o => o.Id == categoryId);
//            var competency = category.Competencies.FirstOrDefault(o => o.Id == competencyId);
//            competency.Question = newQuestion;
//        }

//        public void AddSkill(int categoryId, int competencyId, string skillText)
//        {
//            var category = CategoryList.FirstOrDefault(o => o.Id == categoryId);
//            var competency = category.Competencies.FirstOrDefault(o => o.Id == competencyId);

//            IEnumerable<int> topId = competency.Skills?.Select(o => o.Id).DefaultIfEmpty();
//            int id = (topId ?? new List<int>()).Max() + 1;
//            competency.Skills.Add(new SkillModel() { Id = id, Text = skillText });
//        }

//        public void DeleteCompetency(int categoryId, int competencyId)
//        {
//            var category = CategoryList.FirstOrDefault(o => o.Id == categoryId);
//            var competency = category.Competencies.FirstOrDefault(o => o.Id == competencyId);

//            if (competency == null)
//                return;

//            category.Competencies.Remove(competency);
//        }

//        public void DeleteSkill(int categoryId, int competencyId, int skillId)
//        {
//            var category = CategoryList.FirstOrDefault(o => o.Id == categoryId);
//            var competency = category.Competencies.FirstOrDefault(o => o.Id == competencyId);

//            if (competency == null)
//                return;

//            var skill = competency.Skills.FirstOrDefault(o => o.Id == skillId);

//            if (skill != null)
//                competency.Skills.Remove(skill);
//        }
    
//        public static void SaveToXml()
//        {
//            var path = @"C:\temp\SkillsAssessment_Categories.xml";
//            var writer = new XmlSerializer(typeof(List<CategoryModel>));
//            using (var file = File.Create(path))
//                writer.Serialize(file, CategoryList);
//        }

//        public static void LoadFromXml()
//        {
//            var path = @"C:\temp\SkillsAssessment_Categories.xml";
//            var reader = new XmlSerializer(typeof(List<CategoryModel>));
//            using (var file = new StreamReader(path))
//                CategoryList = (List<CategoryModel>)reader.Deserialize(file);
//        }
//    }
//}