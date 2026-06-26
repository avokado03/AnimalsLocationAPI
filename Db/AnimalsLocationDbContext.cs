using AnimalsLocationAPI.Db.Configurations;
using AnimalsLocationAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace AnimalsLocationAPI.Db;

public class AnimalsLocationDbContext : DbContext
{
    public DbSet<IngestionStream> IngestionStreams { get; set; }
    public DbSet<IngestionWatermark> IngestionWatermarks { get; set; }
    public DbSet<RawObservation> RawObservations { get; set; }
    public DbSet<IngestionRun> IngestionRuns { get; set; }

    public AnimalsLocationDbContext()
    {
    }

    public AnimalsLocationDbContext(DbContextOptions<AnimalsLocationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new IngestionStreamConfig());
        modelBuilder.ApplyConfiguration(new IngestionWatermarkConfig());
        modelBuilder.ApplyConfiguration(new RawObservationConfig());
        modelBuilder.ApplyConfiguration(new IngestionRunConfig());
    }
}
