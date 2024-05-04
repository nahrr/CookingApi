using Cooking.Domain.Enums;

namespace Cooking.Application.Recipes.Commands;

public sealed record AddRecipeRequest(
    string Name,
    string Description,
    List<IngredientRequest> Ingredients,
    List<CookingStepRequest> Steps,
    Cuisine Cuisine,
    Complexity Complexity,
    TypeOfMeal TypeOfMeal
);

public sealed record IngredientRequest(
    string Name,
    decimal Quantity,
    Unit Unit
);

public sealed record CookingStepRequest(
    int StepNumber,
    string Instruction,
    double DurationInMinutes
);

