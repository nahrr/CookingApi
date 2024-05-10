using Cooking.Domain.Entities;
using MediatR;

namespace Cooking.Application.Recipes.GetById;

public sealed class GetRecipeQueryHandler(IRepository<Recipe> repository)
    : IRequestHandler<GetRecipeByIdQuery, GetRecipeResponse>
{
    public async Task<GetRecipeResponse> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await repository.GetDocumentByIdAsync(request.Id, cancellationToken);

        if (response is null)
        {
            //TODO: implement result object
            throw new Exception("todo");
        }

        return new GetRecipeResponse(
            response.Name,
            response.Description,
            response.Ingredients,
            response.Cuisine,
            response.Complexity,
            response.TypeOfMeal);
    }
}