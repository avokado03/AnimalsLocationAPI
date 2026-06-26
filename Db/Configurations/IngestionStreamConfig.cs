using AnimalsLocationAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalsLocationAPI.Db.Configurations;

/// <summary>
/// Конфигурация сущности IngestionStream для Entity Framework Core.
/// </summary>
internal class IngestionStreamConfig : IEntityTypeConfiguration<IngestionStream>
{
    public void Configure(EntityTypeBuilder<IngestionStream> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.StreamKey).IsRequired();
        builder.Property(x => x.CountryCode).IsRequired();
        builder.Property(x => x.CountryName).IsRequired();
        builder.Property(x => x.TaxonName).IsRequired();
        builder.Property(x => x.TaxonId).IsRequired();
        builder.Property(x => x.SourceName).IsRequired();

        builder.HasIndex(x => x.StreamKey).IsUnique();

        builder.HasMany(x => x.IngestionRuns)
            .WithOne(x => x.Stream)
            .HasForeignKey(x => x.StreamId);

        builder.HasOne(x => x.Watermark)
            .WithOne(x => x.Stream)
            .HasForeignKey<IngestionWatermark>(x => x.StreamId);

        builder.HasMany(x => x.RawObservations)
            .WithOne(x => x.Stream)
            .HasForeignKey(x => x.StreamId);
    }
}
