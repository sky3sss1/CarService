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

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PostgreSqlDatabase")),ServiceLifetime.Scoped);

            // Регистрация контекста базы данных и репозиториев как Scoped
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IWashRepository, WashRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IFloorRepository, FloorRepository>();
            services.AddScoped<IParkingRepository, ParkingRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IRentRepository, RentRepository>();
            services.AddScoped<ITarifRepository, TarifRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            // Регистрация других сервисов
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
