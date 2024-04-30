using System;
using System.Threading;
using System.Threading.Tasks;
using Cooking.Application.Recipes.Queries;
using MediatR;

namespace Cooking.Application.Recipes.QueryHandlers;

public sealed class GetRecipeQueryHandler : IRequestHandler<GetRecipeByIdQuery, GetRecipeResponse>
{
    public async Task<GetRecipeResponse> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(50), cancellationToken);

        return new GetRecipeResponse(request.Id, "Burgerz");
    }
}
