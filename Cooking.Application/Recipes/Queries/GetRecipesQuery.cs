using System.Collections.Generic;
using MediatR;

namespace Cooking.Application.Recipes.Queries;

public sealed record GetRecipesQuery() : IRequest<IEnumerable<GetRecipeResponse>>;
