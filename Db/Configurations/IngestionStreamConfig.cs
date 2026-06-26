using AnimalsLocationAPI.Db.Configurations.Seeds;
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

        builder.Property(x => x.StreamKey).HasMaxLength(100).IsRequired();
        builder.Property(x => x.CountryCode).HasMaxLength(2).IsRequired();
        builder.Property(x => x.CountryName).HasMaxLength(100).IsRequired();
        builder.Property(x => x.TaxonName).HasMaxLength(100).IsRequired();
        builder.Property(x => x.TaxonSourceId).IsRequired();
        builder.Property(x => x.SourceName).HasMaxLength(100).IsRequired();

        builder.HasIndex(x => x.StreamKey).IsUnique();

        builder.HasData(StreamSeeds.GetSeeds());

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
