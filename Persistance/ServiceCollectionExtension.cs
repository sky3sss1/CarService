using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application;
using Persistance.Repositories;
using Persistence;

namespace Persistance
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCarCollectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSqlDatabase")));

            services.AddTransient<IApplicationDbContext, ApplicationDbContext>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IWashRepository, WashRepository>();
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddTransient<IFloorRepository, FloorRepository>();
            services.AddTransient<IParkingRepository, ParkingRepository>();
            services.AddTransient<IPlaceRepository, PlaceRepository>();
            services.AddTransient<IRentRepository, RentRepository>();
            services.AddTransient<ITarifRepository, TarifRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddHostedService<LoosedDaysService>();
            services.AddApplication();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                DatabaseInitializer.Initialize(serviceProvider);
            }

            return services;
        }
    }
}
