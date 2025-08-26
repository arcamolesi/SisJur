using Microsoft.EntityFrameworkCore;

namespace SisJur.Models
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Advogado> Advogados { get; set; }
        public DbSet<TipoProcesso> TipoProcessos { get; set; }
        public DbSet<Processo> Processos { get; set; }
        public DbSet<Vara> Varas { get; set; }




    }
}
