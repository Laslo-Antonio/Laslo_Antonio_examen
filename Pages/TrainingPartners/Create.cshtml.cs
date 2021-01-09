using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Laslo_Antonio_examen.Data;
using Laslo_Antonio_examen.Sala;

namespace Laslo_Antonio_examen.Pages.TrainingPartners
{
    public class CreateModel : PageModel
    {
        private readonly Laslo_Antonio_examen.Data.Laslo_Antonio_examenContext _context;

        public CreateModel(Laslo_Antonio_examen.Data.Laslo_Antonio_examenContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TrainingPartner TrainingPartner { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TrainingPartner.Add(TrainingPartner);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
