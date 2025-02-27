using GenericRepository.Core.Entities.Concrete;
using GenericRepository.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.DataAccess.Concrete.EntityFramework.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KURTULUSOCL;Database=GenericRepository;user Id=sa;Password=123;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var item in datas)
            {
                _ = item.State switch
                {
                    EntityState.Added => item.Entity.CreatedDate = DateTime.Now.ToLocalTime(),
                    _ => DateTime.Now.ToLocalTime(),
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
