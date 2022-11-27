using Microsoft.EntityFrameworkCore;
using UserManger.Api.Data;
using UserManger.Api.Interfaces;
using UserManger.Api.Services;

namespace UserManger.Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddScoped<ITokenService, TokenService>();




            services.AddDbContext<DatabaseContext>(options =>
            {
                //Install-Package Microsoft.EntityFrameworkCore.SqlServer || options.UseSqlServer
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}
