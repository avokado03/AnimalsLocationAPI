namespace AnimalsLocationAPI.Domain
{
    /// <summary>
    /// Логический поток загрузки данных о таксонах.
    /// </summary>
    public class IngestionStream
    {
        public Guid Id { get; set; }
        public required string StreamKey { get; set; }
        public required string CountryCode { get; set; }
        public required string CountryName { get; set; }
        public required string TaxonName { get; set; }
        public required string TaxonId { get; set; }
        public required string SourceName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
