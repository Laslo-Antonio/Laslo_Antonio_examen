using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Laslo_Antonio_examen.Data;
using Laslo_Antonio_examen.Sala;

namespace Laslo_Antonio_examen.Pages.Antrenori
{
    public class EditModel : AntrenorCategoriesPageModel

    {
        private readonly Laslo_Antonio_examen.Data.Laslo_Antonio_examenContext _context;

        public EditModel(Laslo_Antonio_examen.Data.Laslo_Antonio_examenContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Antrenor Antrenor { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Antrenor = await _context.Antrenor
            .Include(b => b.TrainingPartner)
            .Include(b => b.AntrenorCategories).ThenInclude(b => b.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);
            if (Antrenor == null)
            {
                return NotFound();
            }
            //apelam PopulateAssignedCategoryData pentru o obtine informatiile necesare checkbox-
            //urilor folosind clasa AssignedCategoryData
            PopulateAssignedCategoryData(_context, Antrenor);
            ViewData["TrainingPartnerID"] = new SelectList(_context.TrainingPartner, "ID",
           "TrainingPartnerName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[]
       selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var AntrenorToUpdate = await _context.Antrenor
            .Include(i => i.TrainingPartner)
            .Include(i => i.AntrenorCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (AntrenorToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Antrenor>(
            AntrenorToUpdate,
            "Antrenor",
            i => i.Name, i => i.Workout,
            i => i.Price, i => i.PublishingDate, i => i.TrainingPartner))
            {
                UpdateAntrenorCategories(_context, selectedCategories, AntrenorToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateAntrenorCategories pentru a aplica informatiile din checkboxuri la entitatea Antrenors care
            //este editata
            UpdateAntrenorCategories(_context, selectedCategories, AntrenorToUpdate);
            PopulateAssignedCategoryData(_context, AntrenorToUpdate);
            return Page();
        }
        /*{
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Antrenor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AntrenorExists(Antrenor.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
        private bool AntrenorExists(int id)
        {
            return _context.Antrenor.Any(e => e.ID == id);
        }*/

    }
}

