using AnimalsLocationAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalsLocationAPI.Db.Configurations;

/// <summary>
/// Конфигурация сущности RawObservation для Entity Framework Core.
/// </summary>
internal class RawObservationConfig : IEntityTypeConfiguration<RawObservation>
{
    public void Configure(EntityTypeBuilder<RawObservation> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ExternalObservationId).IsRequired();
        builder.Property(x => x.RawJson).IsRequired()
            .HasColumnType("jsonb");
        builder.Property(x => x.SourceName).IsRequired();
    }
}
