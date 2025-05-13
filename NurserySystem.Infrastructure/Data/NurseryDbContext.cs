using Microsoft.EntityFrameworkCore;
using NurserySystem.Domain.Entities;

namespace NurserySystem.Infrastructure.Data
{
    public interface INurseryDbContext
    {

    }
    public class NurseryDbContext : DbContext, INurseryDbContext
    {
        public NurseryDbContext(DbContextOptions<NurseryDbContext> options)
            : base(options) { }

        public DbSet<Child> Children { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Child>()
                .Property(c => c.Gender)
                .HasConversion<string>();

            modelBuilder.Entity<Child>()
                .Property(c => c.Status)
                .HasConversion<string>();
            
            modelBuilder.Entity<Child>()
                .Property(c => c.BloodType)
                .HasConversion<string>();
        }
    }

}