using AnimalsLocationAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalsLocationAPI.Db.Configurations;

/// <summary>
/// Конфигурация сущности IngestionWatermark для Entity Framework Core.
/// </summary>
internal class IngestionWatermarkConfig : IEntityTypeConfiguration<IngestionWatermark>
{
    public void Configure(EntityTypeBuilder<IngestionWatermark> builder)
    {
        builder.HasKey(x => x.StreamId);

        builder.Property(x => x.LastObservedAt).IsRequired();
    }
}
