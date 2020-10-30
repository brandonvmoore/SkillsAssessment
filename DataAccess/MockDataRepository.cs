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