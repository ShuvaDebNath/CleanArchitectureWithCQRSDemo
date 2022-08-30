using CRUD.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Infrastructure.Data
{
    // Context class for command
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ModelContext).Assembly);
        }



    }
}
