namespace AnimalsLocationAPI.Domain
{
    /// <summary>
    /// Водяные знаки для отслеживания состояния загрузки данных о таксонах.
    /// </summary>
    public class IngestionWatermark
    {
        public Guid StreamId { get; set; }
        public DateTime LastObservedAt { get; set; }
        public required string LastExternalId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? LastRunId { get; set; }
    }
}
