namespace AnimalsLocationAPI.Domain
{
    /// <summary>
    /// Водяные знаки для отслеживания состояния загрузки данных о таксонах.
    /// Текущее состояние потока.
    /// </summary>
    public class IngestionWatermark
    {
        public Guid StreamId { get; set; }
        public DateTime LastObservedAt { get; set; }
        public required string LastExternalId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? LastRunId { get; set; }

        public virtual required IngestionStream Stream { get; set; }
        public virtual IngestionRun? LastRun { get; set; }
    }
}
