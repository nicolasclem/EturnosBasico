using Eturnos.Models;
using Microsoft.EntityFrameworkCore;

namespace Eturnos.Data
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        :base(options)
        {

        }

        public DbSet<Especialidad> Especialidades { get; set; }
    }
}
