using AnimalsLocationAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalsLocationAPI.Db.Configurations
{
    /// <summary>
    /// Конфигурация сущности IngestionRun для Entity Framework Core.
    /// </summary>
    internal class IngestionRunConfig : IEntityTypeConfiguration<IngestionRun>
    {
        public void Configure(EntityTypeBuilder<IngestionRun> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status).IsRequired();

            builder.HasOne(x => x.Watermark)
                .WithOne(x => x.LastRun)
                .HasForeignKey<IngestionWatermark>(x => x.LastRunId);
        }
    }
}
