using System;

namespace main.Domain;

public class Activity
{

    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Title { get; set; }
    public DateTime Date { get; set; }
    public required string Description { get; set; }
    public required string Category { get; set; }
    public bool IsCancelled { get; set; }

    public string? City { get; set; }
    public string? State { get; set; }
    public string? Venue { get; set; }
}
