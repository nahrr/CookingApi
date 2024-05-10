using Cooking.Domain.Entities;
using Cooking.Infrastructure.Mappings;
using Elastic.Clients.Elasticsearch;

namespace Cooking.Infrastructure.Repositories;

public sealed class RecipeRepository(ElasticsearchClient elasticsearchClient)
    : Repository<RecipeDocument>(elasticsearchClient), IRepository<Recipe>
{
    private bool _isIndexCreated;

    public async Task IndexAsync(Recipe recipe, CancellationToken cancellationToken)
    {
        await EnsureIndexExistsAsync(cancellationToken);

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

        await base.IndexAsync(document, cancellationToken);
    }

    public new async Task<Recipe?> GetDocumentByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var recipeDocument = await base.GetDocumentByIdAsync(id, cancellationToken);

        return recipeDocument?.ToDomainModel();
    }

    //TODO: Tmp solution
    private async Task EnsureIndexExistsAsync(CancellationToken cancellationToken)
    {
        if (!_isIndexCreated)
        {
            var descriptor = RecipeDocumentMapping.Create();
            await CreateIndexAsync(descriptor, cancellationToken);

            _isIndexCreated = true;
        }
    }
}