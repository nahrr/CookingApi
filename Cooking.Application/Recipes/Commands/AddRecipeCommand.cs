using MediatR;

namespace Cooking.Application.Recipes.Commands;

public sealed record AddRecipeCommand(
    string Name,
    string Description,
    List<IngredientRequest> Ingredients,
    List<CookingStepRequest> CookingSteps) : IRequest<AddRecipeResponse>;