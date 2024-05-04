using Cooking.Domain.Entities;
using Cooking.Infrastructure.Mappings;
using Elastic.Clients.Elasticsearch;

namespace Cooking.Infrastructure.Repositories;

public sealed class RecipeRepository(ElasticsearchClient elasticsearchClient)
    : Repository<RecipeDocument>(elasticsearchClient), IRepository<Recipe>
{
    public new async Task IndexAsync(Recipe recipe, CancellationToken cancellationToken)
    {
        var document = new RecipeDocument
        {
            Id = recipe.Id,
            Name = recipe.Name,
            Description = recipe.Description,
            Ingredients = recipe.Ingredients,
            CookingSteps = recipe.Steps.Select(x => new CookingStepDto
            {
                StepNumber = x.Key.Step,
                CookingStep = new CookingStep(x.Value.Instruction,
                    x.Value.Duration)
            }),
            Complexity = recipe.Complexity,
            TypeOfMeal = recipe.TypeOfMeal,
            Cuisine = recipe.Cuisine,
            CreatedDateUtc = recipe.CreatedDateUtc,
            LastModifiedDateUtc = recipe.LastModifiedDateUtc
        };

        //TODO: tmp

        await CreateIndexAsync(cancellationToken);
        
        await base.IndexAsync(document, cancellationToken);
    }

    public async Task CreateIndexAsync(CancellationToken cancellationToken)
    {
        var descriptor = RecipeDocumentMapping.Create();
        await base.CreateIndexAsync(descriptor, cancellationToken);
    }
}