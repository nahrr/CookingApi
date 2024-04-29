namespace Cooking.Domain.Entities;

public abstract class RecipeBase(
    Guid id,
    string description)
{
    public Guid Id { get; } = ValidId(id)
        ? id
        : throw new ArgumentException("Invalid id", nameof(id));

    public string Description { get; } = ValidDescription(description)
        ? description
        : throw new ArgumentException("Invalid description", nameof(description));

    public DateTime CreatedDateUtc { get; } = DateTime.UtcNow;
    public DateTime? LastModifiedDateUtc { get; set; }

    private static bool ValidId(Guid id) => id != default;
    private static bool ValidDescription(string description) => !string.IsNullOrEmpty(description);
}