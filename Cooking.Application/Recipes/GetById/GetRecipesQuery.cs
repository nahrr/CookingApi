using MediatR;

namespace Cooking.Application.Recipes.GetById;

public sealed record GetRecipesQuery() : IRequest<IEnumerable<GetRecipeResponse>>;
