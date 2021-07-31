using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Rockstars.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Rockstars.Application.Interfaces;
using Rockstars.Application.Services;
using Rockstars.Application.Mappers;

namespace Rockstars.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Add database context
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DatabaseContext")));

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IRockstarsService, RockstarsService>();
            services.AddScoped<DbContext>();

            return services;
        }
    }
}
