using AnimalsLocationAPI.Domain;

namespace AnimalsLocationAPI.Db.Configurations.Seeds;

/// <summary>
/// Предоставляет начальные данные (seeds) для таблицы IngestionStream.
/// </summary>
internal static class StreamSeeds
{
    #region Country Names and Codes
    private static string KazakhstanCountryName => "Kazakhstan";
    private static string KyrgystanCountryName => "Kyrgystan";
    private static string UzbekistanCountryName => "Uzbekistan";
    private static string KazakhstanCountryCode => "kz";
    private static string KyrgystanCountryCode => "kg";
    private static string UzbekistanCountryCode => "uz";
    #endregion

    #region Source Search Data from INaturalist
    private static string SourceName => "INaturalist";
    private static string ArachnidaTaxonName => "Arachnida";
    private static string MyriapodaTaxonName => "Myriapoda";
    private static int ArachnidaTaxonSourceId => 47119;
    private static int MyriapodaTaxonSourceId => 144128;
    #endregion

    private static DateTime SeedDate => new DateTime(2026, 06, 26, 20, 06, 07, DateTimeKind.Utc);

    private static string GenerateStreamKey(string countryCode, string taxonName) => $"{countryCode}|{taxonName}".ToLower();

    public static IEnumerable<IngestionStream> GetSeeds()
    {
        var streams = new List<IngestionStream>
        {
            new IngestionStream
            {
                Id = Guid.Parse("fbc6f71d-f519-43c5-b540-f8ba5dbd32a0"),
                StreamKey = GenerateStreamKey(KazakhstanCountryCode, ArachnidaTaxonName),
                CountryCode = KazakhstanCountryCode,
                CountryName = KazakhstanCountryName,
                TaxonName = ArachnidaTaxonName,
                TaxonSourceId = ArachnidaTaxonSourceId,
                SourceName = SourceName,
                IsActive = true,
                CreatedAt = SeedDate,
                UpdatedAt = SeedDate,
            },
            new IngestionStream
            {
                Id = Guid.Parse("d2b6f71d-f519-43c5-b540-f8ba5dbd32a1"),
                StreamKey = GenerateStreamKey(KazakhstanCountryCode, MyriapodaTaxonName),
                CountryCode = KazakhstanCountryCode,
                CountryName = KazakhstanCountryName,
                TaxonName = MyriapodaTaxonName,
                TaxonSourceId = MyriapodaTaxonSourceId,
                SourceName = SourceName,
                IsActive = true,
                CreatedAt = SeedDate,
                UpdatedAt = SeedDate,
            },
            new IngestionStream
            {
                Id = Guid.Parse("c3b6f71d-f519-43c5-b540-f8ba5dbd32a2"),
                StreamKey = GenerateStreamKey(KyrgystanCountryCode, ArachnidaTaxonName),
                CountryCode = KyrgystanCountryCode,
                CountryName = KyrgystanCountryName,
                TaxonName = ArachnidaTaxonName,
                TaxonSourceId = ArachnidaTaxonSourceId,
                SourceName = SourceName,
                IsActive = true,
                CreatedAt = SeedDate,
                UpdatedAt = SeedDate,
            },
            new IngestionStream
            {
                Id = Guid.Parse("b4b6f71d-f519-43c5-b540-f8ba5dbd32a3"),
                StreamKey = GenerateStreamKey(KyrgystanCountryCode, MyriapodaTaxonName),
                CountryCode = KyrgystanCountryCode,
                CountryName = KyrgystanCountryName,
                TaxonName = MyriapodaTaxonName,
                TaxonSourceId = MyriapodaTaxonSourceId,
                SourceName = SourceName,
                IsActive = true,
                CreatedAt = SeedDate,
                UpdatedAt = SeedDate,
            },
            new IngestionStream
            {
                Id = Guid.Parse("a5b6f71d-f519-43c5-b540-f8ba5dbd32a4"),
                StreamKey = GenerateStreamKey(UzbekistanCountryCode, ArachnidaTaxonName),
                CountryCode = UzbekistanCountryCode,
                CountryName = UzbekistanCountryName,
                TaxonName = ArachnidaTaxonName,
                TaxonSourceId = ArachnidaTaxonSourceId,
                SourceName = SourceName,
                IsActive = true,
                CreatedAt = SeedDate,
                UpdatedAt = SeedDate,
            },
            new IngestionStream
            {
                Id = Guid.Parse("96b6f71d-f519-43c5-b540-f8ba5dbd32a5"),
                StreamKey = GenerateStreamKey(UzbekistanCountryCode, MyriapodaTaxonName),
                CountryCode = UzbekistanCountryCode,
                CountryName = UzbekistanCountryName,
                TaxonName = MyriapodaTaxonName,
                TaxonSourceId = MyriapodaTaxonSourceId,
                SourceName = SourceName,
                IsActive = true,
                CreatedAt = SeedDate,
                UpdatedAt = SeedDate,
            }
        };

        return streams;
    }
}
