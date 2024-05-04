using Cooking.Domain.Enums;
using MediatR;

namespace Cooking.Application.Recipes.Commands;

public sealed record AddRecipeCommand(
    string Name,
    string Description,
    List<IngredientRequest> Ingredients,
    List<CookingStepRequest> CookingSteps,
    TypeOfMeal TypeOfMeal,
    Complexity Complexity,
    Cuisine Cuisine
) : IRequest<AddRecipeResponse>;