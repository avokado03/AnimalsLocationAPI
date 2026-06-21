namespace AnimalsLocationAPI.Domain
{
    /// <summary>
    /// Запуск процесса инжеста данных из внешнего источника.
    /// История запуска потока.
    /// </summary>
    public class IngestionRun
    {
        public Guid Id { get; set; }
        public Guid StreamId  { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public required string Status { get; set; }
        public int RecordsFetched { get; set; }
        public int RecordsInserted { get; set; }
        public string? ErrorMessage { get; set; }
        public int RetryCount { get; set; }

        public virtual required IngestionStream Stream { get; set; }
        public virtual List<RawObservation>? RawObservations { get; set; }
        public virtual IngestionWatermark? Watermark { get; set; }
    }
}
