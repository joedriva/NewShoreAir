using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewShoreAir.Application.Contracts.Flight;
using NewShoreAir.Application.Contracts.Persistence;
using NewShoreAir.Infrastructure.Flights;
using NewShoreAir.Infrastructure.Persistence;
using NewShoreAir.Infrastructure.Repositories;

namespace NewShoreAir.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NewShoreAirDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
            services.AddTransient<IFlightService, FlightService>();

            return services;
        }
    }
}
