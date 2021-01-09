using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laslo_Antonio_examen.Sala
{
    public class Antrenor
    {
        public int ID { get; set; }
        [Display(Name = "Trainer name")]
        public string Name { get; set; }
         public string Workout { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }
        public int TrainingPartnerID { get; set; }
        public TrainingPartner TrainingPartner { get; set; }
        public ICollection<AntrenorCategory> AntrenorCategories { get; set; }
    }
}
