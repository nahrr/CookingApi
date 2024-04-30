using Cooking.Application.Recipes.Commands;
using Cooking.Domain.Entities;
using Cooking.Domain.ValueObjects;
using MediatR;

namespace Cooking.Application.Recipes.CommandHandlers;

public sealed class AddRecipeCommandHandler : IRequestHandler<AddRecipeCommand, AddRecipeResponse>
{
    public async Task<AddRecipeResponse> Handle(AddRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = Recipe.Create(request.Name, request.Description);

        request.Ingredients.ForEach(x =>
            recipe.AddIngredient(new Ingredient(x.Name, x.Quantity, x.Unit)));

        request.CookingSteps.ForEach(x =>
            recipe.AddStep(
                new CookingStepNumber(x.StepNumber),
                new CookingStep(
                    x.Instruction,
                    TimeSpan.FromMinutes(x.DurationInMinutes))));

        await Task.Delay(TimeSpan.FromMilliseconds(0.2), cancellationToken);

        return new AddRecipeResponse(recipe.Id);
    }
}