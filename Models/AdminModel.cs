using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsAssessment.Models
{
    public class AdminModel
    {
        public CategoryModel SelectedCategory { get; set; }

        public IEnumerable<CategoryModel> Categories { get; set; }

        public AdminModel(IEnumerable<CategoryModel> categoryModels)
        {
            Categories = categoryModels;
            SelectedCategory = Categories.FirstOrDefault();
        }

        public IEnumerable<SelectListItem> GetCategorySelectListItems()
        {
            return Categories.Select(o => new SelectListItem() { Text = o.Title, Value = o.Id.ToString() });
        }

    }
}
