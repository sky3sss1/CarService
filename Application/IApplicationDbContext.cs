namespace Application
{
    public interface IApplicationDbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Parking> Parkings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Tarif> Tarifs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
