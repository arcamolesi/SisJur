using Microsoft.EntityFrameworkCore;

namespace SisJur.Models
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Area> Areas { get; set; }

    }
}
