using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laslo_Antonio_examen.Sala
{
    public class AntrenorData
    {
        public IEnumerable<Antrenor> Antrenori { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<AntrenorCategory> AntrenorCategories { get; set; }

    }
}
