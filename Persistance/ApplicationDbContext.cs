using Application;

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
    }
}
