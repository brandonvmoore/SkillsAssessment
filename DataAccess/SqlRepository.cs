using Microsoft.EntityFrameworkCore;
using SkillsAssessment.Models;
using SkillsDataAccess;
using SkillsDataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsAssessment.DataAccess
{
    public class SqlRepository
    {
        readonly AppDbContext dbc;

        public SqlRepository(AppDbContext dbContext)
        {
            dbc = dbContext;
        }

        public Assessment GetAssessment(int assessmentId)
        {
            return dbc.Assessments
                .Include(o => o.Tenant)
                .Include(o => o.Categories)
                .ThenInclude(o => o.Competencies)
                .ThenInclude(o => o.Skills)
                .Single(o => o.Id == assessmentId);
        }

        public IEnumerable<AssessmentCategory> GetCategoryModels(int assessmentId)
        {
            return dbc.Assessments.Include(o => o.Categories).Single(o => o.Id == assessmentId).Categories;
        }

        public IEnumerable<AssessmentCompetency> GetCompetencies(int categoryId, int assessmentId)
        {
            return dbc.Assessments
                .Include(o => o.Categories)
                .ThenInclude(o => o.Competencies)
                .ThenInclude(o => o.Skills)
                .Single(o => o.Id == assessmentId)
                .Categories.Single(o => o.Id == categoryId)
                .Competencies;
        }

        public void AddCompetency(int categoryId, string title, string question = null)
        {
            var category = dbc.AssessmentCategories.Include(o => o.Competencies).First(o => o.Id == categoryId);
            category.Competencies.Add(new AssessmentCompetency { Title = title, Question = question });
            dbc.SaveChanges();
        }

        public void UpdateSkillQuestion(int categoryId, int competencyId, string newQuestion)
        {
            var category = dbc.AssessmentCategories.Include(o => o.Competencies).First(o => o.Id == categoryId);
            var competency = category.Competencies.First(o => o.Id == competencyId);
            competency.Question = newQuestion;
            dbc.SaveChanges();
        }

        public void AddSkill(int categoryId, int competencyId, string skillText)
        {
            var category = dbc.AssessmentCategories
                .Include(o => o.Competencies)
                .ThenInclude(o => o.Skills)
                .First(o => o.Id == categoryId);

            var competency = category.Competencies.FirstOrDefault(o => o.Id == competencyId);
            competency.Skills.Add(new AssessmentSkill() { Text = skillText });
            dbc.SaveChanges();
        }

        //public void DeleteCompetency(int categoryId, int competencyId)
        //{
        //    var category = CategoryList.FirstOrDefault(o => o.Id == categoryId);
        //    var competency = category.Competencies.FirstOrDefault(o => o.Id == competencyId);

        //    if (competency == null)
        //        return;

        //    category.Competencies.Remove(competency);
        //}

        //public void DeleteSkill(int categoryId, int competencyId, int skillId)
        //{
        //    var category = CategoryList.FirstOrDefault(o => o.Id == categoryId);
        //    var competency = category.Competencies.FirstOrDefault(o => o.Id == competencyId);

        //    if (competency == null)
        //        return;

        //    var skill = competency.Skills.FirstOrDefault(o => o.Id == skillId);

        //    if (skill != null)
        //        competency.Skills.Remove(skill);
        //}

        //public static void SaveToXml()
        //{
        //    var path = @"C:\temp\SkillsAssessment_Categories.xml";
        //    var writer = new XmlSerializer(typeof(List<CategoryModel>));
        //    using (var file = File.Create(path))
        //        writer.Serialize(file, CategoryList);
        //}

        //public static void LoadFromXml()
        //{
        //    var path = @"C:\temp\SkillsAssessment_Categories.xml";
        //    var reader = new XmlSerializer(typeof(List<CategoryModel>));
        //    using (var file = new StreamReader(path))
        //        CategoryList = (List<CategoryModel>)reader.Deserialize(file);
        //}
    }
}
