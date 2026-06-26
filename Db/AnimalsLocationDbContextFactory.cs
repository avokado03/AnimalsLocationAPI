using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AnimalsLocationAPI.Db;

/// <summary>
/// Фабрика контекста базы данных для использования в миграциях.
/// </summary>
public class AnimalsLocationDbContextFactory : IDesignTimeDbContextFactory<AnimalsLocationDbContext>
{
    public AnimalsLocationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AnimalsLocationDbContext>();
        string connectionString = Environment.GetEnvironmentVariable("AnimalConnection")!;

        optionsBuilder.UseNpgsql(connectionString);

        return new AnimalsLocationDbContext(optionsBuilder.Options);
    }
}
