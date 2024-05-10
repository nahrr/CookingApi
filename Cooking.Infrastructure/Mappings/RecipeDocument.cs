using Cooking.Domain.Entities;
using Cooking.Domain.Enums;
using Cooking.Domain.ValueObjects;

namespace Cooking.Infrastructure.Mappings;

public class RecipeDocument : IMappingDocument
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required IEnumerable<Ingredient> Ingredients { get; init; } = [];
    public required IEnumerable<CookingStepDto> CookingSteps { get; init; }

    public required Complexity Complexity { get; init; }
    public required TypeOfMeal TypeOfMeal { get; init; }
    public required Cuisine Cuisine { get; init; }
    public required DateTime CreatedDateUtc { get; init; }
    public  DateTime? LastModifiedDateUtc { get; init; }
}

public class CookingStepDto //TODO
{
    public int StepNumber { get; init; }
    public required CookingStep CookingStep { get; init; }
}