using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laslo_Antonio_examen.Sala
{
    public class TrainingPartner
    {
        public int ID { get; set; }
        public string TrainingPartnerName { get; set; }
        public ICollection<Antrenor> Antrenori { get; set; }
    }
}
