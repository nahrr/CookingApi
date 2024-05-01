using Cooking.Application.Recipes.Commands;
using Cooking.Domain.Entities;
using Cooking.Domain.ValueObjects;
using MediatR;

namespace Cooking.Application.Recipes.CommandHandlers;

public sealed class AddRecipeCommandHandler(IRepository<RecipeDocument> repository)
    : IRequestHandler<AddRecipeCommand, AddRecipeResponse>
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

        //TODO: fix response
        await repository.IndexAsync(new RecipeDocument
        {
            Id = recipe.Id,
            Name = recipe.Name,
            Description = recipe.Description,
            Ingredients = recipe.Ingredients.ToList()
        }, cancellationToken);

        return new AddRecipeResponse(recipe.Id);
    }
}