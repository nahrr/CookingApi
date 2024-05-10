using MediatR;

namespace Cooking.Application.Recipes.GetById;

public sealed record GetRecipeByIdQuery(Guid Id) : IRequest<GetRecipeResponse>;