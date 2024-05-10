using Cooking.Domain.Enums;
using Cooking.Domain.ValueObjects;

namespace Cooking.Application.Recipes.GetById;

public sealed record GetRecipeResponse(
    string Name,
    string Description,
    IEnumerable<Ingredient> Ingredients,
    Cuisine Cuisine,
    Complexity Complexity,
    TypeOfMeal TypeOfMeal);