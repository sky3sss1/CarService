using Application;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Wash> Washes { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Floor> Floors { get; set; } = null!;
        public DbSet<Parking> Parkings { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<Place> Places { get; set; } = null!;
        public DbSet<Rent> Rents { get; set; } = null!;
        public DbSet<Tarif> Tarifs { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Feedback> Feedbacks { get; set; } = null!;

        public List<string> GetTableNames()
        {
            var tableNames = this.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType.IsGenericType &&
                            p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .Select(p => p.Name)
                .ToList();

            return tableNames;
        }
    }
}
