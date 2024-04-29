using System;
using MediatR;

namespace Cooking.Application.Recipes.Queries;

public sealed record GetRecipeByIdQuery(Guid Id) : IRequest<GetRecipeResponse>;