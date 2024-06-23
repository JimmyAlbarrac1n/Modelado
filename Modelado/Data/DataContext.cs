using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelado.Models;

namespace Modelado
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Modelado.Models.Paciente> Paciente { get; set; } = default!;
        public DbSet<Modelado.Models.Cita> Cita { get; set; } = default!;
        public DbSet<Modelado.Models.Historial> Historial { get; set; } = default!;
        public DbSet<Modelado.Models.Tratamiento> Tratamiento { get; set; } = default!;
    }
}
