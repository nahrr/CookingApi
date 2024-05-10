using Cooking.Domain.Entities;

namespace Cooking.Infrastructure.Mappings;

public static class RecipeMapper
{
    public static Recipe ToDomainModel(this RecipeDocument document)
    {
        var recipe = Recipe.Create(
            document.Id,
            document.Name,
            document.Description,
            document.Complexity,
            document.TypeOfMeal,
            document.Cuisine);

        foreach (var ingredient in document.Ingredients)
        {
            recipe.AddIngredient(ingredient);
        }

        foreach (var step in document.CookingSteps)
        {
            recipe.AddStep(new CookingStepNumber(step.StepNumber), step.CookingStep);
        }

        return recipe;
    }
}