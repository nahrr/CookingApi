using Cooking.Domain.Enums;
using Cooking.Domain.ValueObjects;

namespace Cooking.Domain.Entities;

public interface IRecipeDocument : IMappingDocument
{
     Guid Id { get; init; }
     string Name { get; init; }
     string Description { get; init; }
     IEnumerable<Ingredient> Ingredients { get; init; }
     // IEnumerable<CookingStepDto> CookingSteps { get; init; }
     Complexity Complexity { get; init; }
     TypeOfMeal TypeOfMeal { get; init; }
     Cuisine Cuisine { get; init; }
}