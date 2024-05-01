using Cooking.Domain.ValueObjects;

namespace Cooking.Domain.Entities;

public class RecipeDocument : IMappingDocument
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }

    public required List<Ingredient> Ingredients { get; init; } = [];
    //public required List //TODO: cooking step, think about data structure
}