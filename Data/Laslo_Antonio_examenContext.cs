using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Laslo_Antonio_examen.Sala;

namespace Laslo_Antonio_examen.Data
{
    public class Laslo_Antonio_examenContext : DbContext
    {
        public Laslo_Antonio_examenContext (DbContextOptions<Laslo_Antonio_examenContext> options)
            : base(options)
        {
        }

        public DbSet<Laslo_Antonio_examen.Sala.Antrenor> Antrenor { get; set; }

        public DbSet<Laslo_Antonio_examen.Sala.TrainingPartner> TrainingPartner { get; set; }
        public DbSet<Laslo_Antonio_examen.Sala.AntrenorCategory> AntrenorCategory { get; set; }
        public DbSet<Laslo_Antonio_examen.Sala.Category> Category { get; set; }

    }
}
