using CSharpTest.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharpTest.Models
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Veiculo> Veiculos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

    }
}
