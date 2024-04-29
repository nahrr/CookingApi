using MediatR;

namespace Cooking.Application.Recipes.Commands;

public sealed record AddRecipeCommand(AddRecipeRequest Recipe) : IRequest<AddRecipeResponse>;

