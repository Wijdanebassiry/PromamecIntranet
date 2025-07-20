using Microsoft.EntityFrameworkCore;
using PromamecIntranet.Models;

namespace PromamecIntranet.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<FormulaireProjet> Formulaires { get; set; }
    }
}
