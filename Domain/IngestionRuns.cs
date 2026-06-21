namespace Domain
{
    internal class IngestionRuns
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
    }
}
