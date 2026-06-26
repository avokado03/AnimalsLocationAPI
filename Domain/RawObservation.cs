namespace AnimalsLocationAPI.Domain;

/// <summary>
/// Сырые наблюдения, загруженные из внешних API.
/// </summary>
public class RawObservation
{
    public Guid Id { get; set; }
    public Guid StreamId { get; set; }
    public Guid RunId { get; set; }
    public required string ExternalObservationId { get; set; }
    public required string RawJson { get; set; }
    public DateTime IngestedAt { get; set; }
    public required string SourceName { get; set; }
    public DateTime LoadDate { get; set; }

    public virtual required IngestionStream Stream { get; set; }
    public virtual required IngestionRun Run { get; set; }
}
