using Cooking.Domain.Enums;
using Cooking.Domain.ValueObjects;

namespace Cooking.Domain.Entities;

public sealed class Recipe : RecipeBase
{
    private readonly List<Ingredient> _ingredients = [];
    private readonly Dictionary<CookingStepNumber, CookingStep> _steps = [];
    public IEnumerable<Ingredient> Ingredients => _ingredients.AsReadOnly();
    public IReadOnlyDictionary<CookingStepNumber, CookingStep> Steps => _steps;

    private Recipe(
        string name,
        string description,
        Complexity complexity,
        TypeOfMeal typeOfMeal,
        Cuisine cuisine
    ) : base(Guid.NewGuid(), name, description, complexity, typeOfMeal, cuisine)
    {
    }

    public static Recipe Create(string name, string description, Complexity complexity, TypeOfMeal typeOfMeal,
        Cuisine cuisine) =>
        new(name, description, complexity, typeOfMeal, cuisine);

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