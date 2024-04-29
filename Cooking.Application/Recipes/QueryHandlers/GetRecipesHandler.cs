using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cooking.Application.Recipes.Queries;
using MediatR;

namespace Cooking.Application.Recipes.QueryHandlers;

public sealed class GetRecipesHandler : IRequestHandler<GetRecipesQuery, IEnumerable<GetRecipeResponse>>
{
    public async Task<IEnumerable<GetRecipeResponse>> Handle(GetRecipesQuery request,
        CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(200), cancellationToken);

        return new List<GetRecipeResponse>()
        {
            new(Guid.NewGuid(), "Test")
        };
    }
}