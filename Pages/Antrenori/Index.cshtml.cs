using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Laslo_Antonio_examen.Data;
using Laslo_Antonio_examen.Sala;

namespace Laslo_Antonio_examen.Pages.Antrenori
{
    public class IndexModel : PageModel
    {
        private readonly Laslo_Antonio_examen.Data.Laslo_Antonio_examenContext _context;

        public IndexModel(Laslo_Antonio_examen.Data.Laslo_Antonio_examenContext context)
        {
            _context = context;
        }

        public IList<Antrenor> Antrenor { get;set; }
        public AntrenorData AntrenorD { get; set; }
        public int AntrenorID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            AntrenorD = new AntrenorData();

            AntrenorD.Antrenori = await _context.Antrenor
            .Include(b => b.TrainingPartner)
            .Include(b => b.AntrenorCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (id != null)
            {
                AntrenorID = id.Value;
                Antrenor Antrenor = AntrenorD.Antrenori
                .Where(i => i.ID == id.Value).Single();
                AntrenorD.Categories = Antrenor.AntrenorCategories.Select(s => s.Category);
            }
        }

        
    }
}
