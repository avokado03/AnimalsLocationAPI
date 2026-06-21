using Microsoft.EntityFrameworkCore;
using AnimalsLocationAPI.Domain;

namespace Db
{
    public class AnimalsLocationDbContext : DbContext
    {
        public DbSet<IngestionStream> IngestionStreams { get; set; }
        public DbSet<IngestionWatermark> IngestionWatermarks { get; set; }
        public DbSet<RawObservation> RawObservations { get; set; }
        public DbSet<IngestionRun> IngestionRuns { get; set; }

        public AnimalsLocationDbContext(DbContextOptions<AnimalsLocationDbContext> options)
            : base(options)
        {
        }
    }
}
