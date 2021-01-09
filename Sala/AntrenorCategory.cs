using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laslo_Antonio_examen.Sala
{
    public class AntrenorCategory
    {
        public int ID { get; set; }
        public int AntrenorID { get; set; }
        public Antrenor Antrenor { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
