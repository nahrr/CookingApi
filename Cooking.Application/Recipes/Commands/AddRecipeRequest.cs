namespace Cooking.Application.Recipes.Commands;

public sealed record AddRecipeRequest(
    string Name,
    string Description,
    List<IngredientRequest> Ingredients,
    List<CookingStepRequest> Steps
);

public sealed record IngredientRequest(
    string Name,
    decimal Quantity,
    string Unit
);

public sealed record CookingStepRequest(
    int StepNumber,
    string Instruction,
    double DurationInMinutes 
);
