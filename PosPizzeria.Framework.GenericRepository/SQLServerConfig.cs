using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PosPizzeria.Framework.GenericRepository.GenericRepository;

namespace PosPizzeria.Framework.GenericRepository;


public static class SQLServerConfig
{
    public static IServiceCollection ISQLServer(this IServiceCollection services, IConfiguration configuration)
    {
        var sqlServerConnectionString = Environment.GetEnvironmentVariable("ConnectionString") ?? configuration.GetConnectionString("ConnectionString");
        return services.AddScoped<IRepository<SqlServerRepository>>(x => new SqlServerRepository(sqlServerConnectionString));
    }
}
