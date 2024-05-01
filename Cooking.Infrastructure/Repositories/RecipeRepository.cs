using Cooking.Domain.Entities;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.IndexManagement;

namespace Cooking.Infrastructure.Repositories;

public sealed class RecipeRepository(ElasticsearchClient elasticsearchClient)
    : Repository<RecipeDocument>(elasticsearchClient), IRepository<RecipeDocument>
{
    public new async Task IndexAsync(RecipeDocument document, CancellationToken cancellationToken)
    {
        await base.IndexAsync(document, cancellationToken);
    }

    public async Task CreateIndexAsync(CancellationToken cancellationToken)
    {
        var descriptor = new CreateIndexRequestDescriptor<RecipeDocument>(nameof(RecipeDocument))
            .Mappings(m => m
                .Properties(p => p
                    .Keyword(f => f.Id)
                    .Keyword(f => f.Name)
                    .Text(f => f.Name)
                    .Text(f => f.Description)
                ));

        await base.CreateIndexAsync(descriptor, cancellationToken);
    }
}