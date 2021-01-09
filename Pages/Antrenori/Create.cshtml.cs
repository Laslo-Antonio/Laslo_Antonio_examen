using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Laslo_Antonio_examen.Data;
using Laslo_Antonio_examen.Sala;


namespace Laslo_Antonio_examen.Pages.Antrenori
{
    public class CreateModel : AntrenorCategoriesPageModel
    {
        private readonly Laslo_Antonio_examen.Data.Laslo_Antonio_examenContext _context;

        public CreateModel(Laslo_Antonio_examen.Data.Laslo_Antonio_examenContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["TrainingPartnerID"] = new SelectList(items: _context.Set<TrainingPartner>(), "ID", "TrainingPartnerName");
            var Antrenor = new Antrenor();
            Antrenor.AntrenorCategories = new List<AntrenorCategory>();
            PopulateAssignedCategoryData(_context, Antrenor);
            return Page();
        }

        [BindProperty]
        public Antrenor Antrenor { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newAntrenor = new Antrenor();
            if (selectedCategories != null)
            {
                newAntrenor.AntrenorCategories = new List<AntrenorCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new AntrenorCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newAntrenor.AntrenorCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Antrenor>(
            newAntrenor,
            "Antrenor",
            i => i.Name, i => i.Workout,
            i => i.Price, i => i.PublishingDate, i => i.TrainingPartnerID))
            {
                _context.Antrenor.Add(newAntrenor);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newAntrenor);
            return Page();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.

    }
}
