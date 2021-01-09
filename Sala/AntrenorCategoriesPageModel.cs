using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Laslo_Antonio_examen.Data;


namespace Laslo_Antonio_examen.Sala
{
    public class AntrenorCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Laslo_Antonio_examenContext context,
        Antrenor Antrenor)
        {
            var allCategories = context.Category;
            var AntrenorCategories = new HashSet<int>(
            Antrenor.AntrenorCategories.Select(c => c.AntrenorID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = AntrenorCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateAntrenorCategories(Laslo_Antonio_examenContext context,
        string[] selectedCategories, Antrenor AntrenorToUpdate)
        {
            if (selectedCategories == null)
            {
                AntrenorToUpdate.AntrenorCategories = new List<AntrenorCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var AntrenorCategories = new HashSet<int>
            (AntrenorToUpdate.AntrenorCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!AntrenorCategories.Contains(cat.ID))
                    {
                        AntrenorToUpdate.AntrenorCategories.Add(
                        new AntrenorCategory
                        {
                            AntrenorID = AntrenorToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (AntrenorCategories.Contains(cat.ID))
                    {
                        AntrenorCategory courseToRemove
                        = AntrenorToUpdate
                        .AntrenorCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
