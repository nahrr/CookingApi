namespace Cooking.Domain.Entities;

public abstract class RecipeBase
{
    public required Guid Id { get; init; }
    public required string Description { get; init; }
    
    public required DateTime CreatedDateUtc { get; init; } = DateTime.UtcNow;
    public DateTime? LastModifiedDateUtc { get; set; }
}