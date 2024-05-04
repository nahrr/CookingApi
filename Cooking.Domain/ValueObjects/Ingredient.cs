using Cooking.Domain.Enums;

namespace Cooking.Domain.ValueObjects;

public sealed record Ingredient(string Name, decimal Quantity, Unit Unit);
