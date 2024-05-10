using MediatR;

namespace Cooking.Application.Recipes.GetById;

public sealed class GetRecipesHandler : IRequestHandler<GetRecipesQuery, IEnumerable<GetRecipeResponse>>
{
    public async Task<IEnumerable<GetRecipeResponse>> Handle(GetRecipesQuery request,
        CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(200), cancellationToken);

        return new List<GetRecipeResponse>();
    }
}