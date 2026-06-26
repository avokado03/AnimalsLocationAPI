using AnimalsLocationAPI.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalLocationAPI.Core.Extensions;

public static class DIExtensions
{
    public static void AddAnimalsLocationDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AnimalsLocationDbContext>(options =>
            options.UseNpgsql(connectionString));
    }
}