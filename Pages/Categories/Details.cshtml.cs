﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Laslo_Antonio_examen.Data;
using Laslo_Antonio_examen.Sala;

namespace Laslo_Antonio_examen.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly Laslo_Antonio_examen.Data.Laslo_Antonio_examenContext _context;

        public DetailsModel(Laslo_Antonio_examen.Data.Laslo_Antonio_examenContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
