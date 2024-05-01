using Cooking.Domain.Entities;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.IndexManagement;

namespace Cooking.Infrastructure.Repositories;

public abstract class Repository<TDocument>(ElasticsearchClient elasticsearchClient)
    where TDocument : IMappingDocument
{
    public async Task IndexAsync(TDocument document, CancellationToken cancellationToken)
    {
        if (document is null)
        {
            throw new ArgumentNullException(nameof(document));
        }

        //TODO: handle response
        var response =
            await elasticsearchClient.IndexAsync(document, x => x.Id(document.Id), cancellationToken);
    }

    public async Task CreateIndexAsync(CreateIndexRequestDescriptor<TDocument> descriptor,
        CancellationToken cancellationToken)
    {
        //TODO: handle response
        var response = await elasticsearchClient.Indices.CreateAsync(descriptor, cancellationToken);
    }
}