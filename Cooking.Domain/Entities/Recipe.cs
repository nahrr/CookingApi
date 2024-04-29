using Cooking.Domain.ValueObjects;

namespace Cooking.Domain.Entities;

public sealed class Recipe : RecipeBase
{
    private readonly List<Ingredient> _ingredients = [];
    private readonly Dictionary<CookingStepNumber, CookingStep> _steps = [];
    public IReadOnlyList<Ingredient> Ingredients => _ingredients.AsReadOnly();
    public IReadOnlyDictionary<CookingStepNumber, CookingStep> Steps => _steps;

    private Recipe(string description) : base(Guid.NewGuid(), description)
    {
    }

    public static Recipe Create(string description) => new Recipe(description);

    public void AddIngredient(Ingredient ingredient)
    {
        ArgumentNullException.ThrowIfNull(ingredient);

        _ingredients.Add(ingredient);
    }

    public bool RemoveIngredient(Ingredient ingredient)
    {
        return _ingredients.Remove(ingredient);
    }

    public void AddStep(CookingStepNumber stepNumber, CookingStep step)
    {
        ArgumentNullException.ThrowIfNull(stepNumber);

        ArgumentNullException.ThrowIfNull(step);

        _steps[stepNumber] = step;
    }

    public bool RemoveStep(CookingStepNumber stepNumber)
    {
        return _steps.Remove(stepNumber);
    }
}