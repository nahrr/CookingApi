using System;

namespace Cooking.Application.Recipes.Queries;

public sealed record GetRecipeResponse(Guid Id, string Description);