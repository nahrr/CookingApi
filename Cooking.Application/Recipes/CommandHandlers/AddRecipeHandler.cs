using Cooking.Application.Recipes.Commands;
using Cooking.Domain.Entities;
using Cooking.Domain.ValueObjects;
using MediatR;

namespace Cooking.Application.Recipes.CommandHandlers;

public sealed class AddRecipeHandler : IRequestHandler<AddRecipeCommand, AddRecipeResponse>
{
    public async Task<AddRecipeResponse> Handle(AddRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = Recipe.Create("description");

        recipe.AddIngredient(
            new Ingredient("Chicken", 1, "kg"));

        recipe.AddStep(
            new CookingStepNumber(1),
            new CookingStep("Chop", TimeSpan.FromMinutes(1)));
        
        await Task.Delay(TimeSpan.FromMilliseconds(0.2), cancellationToken);

        var test = recipe;
        return new AddRecipeResponse(recipe.Id, recipe.Description);
    }
}