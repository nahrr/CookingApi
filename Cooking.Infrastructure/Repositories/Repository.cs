using Cooking.Domain.Entities;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.IndexManagement;

namespace Cooking.Infrastructure.Repositories;

public abstract class Repository<TDocument>(ElasticsearchClient elasticsearchClient)
    where TDocument : IMappingDocument
{
    private readonly string _indexName = typeof(TDocument).Name.ToLower();

    protected async Task IndexAsync(TDocument document, CancellationToken cancellationToken)
    {
        if (document is null)
        {
            throw new ArgumentNullException(nameof(document));
        }

        //TODO: handle response
        var response =
            await elasticsearchClient.IndexAsync(document, document.Id,
                x => x.Index(_indexName), cancellationToken);
    }

    protected async Task<TDocument?> GetDocumentByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await elasticsearchClient.GetAsync<TDocument>(_indexName, id, cancellationToken);

        return response.Source;
    }

    protected async Task CreateIndexAsync(CreateIndexRequestDescriptor<TDocument> descriptor,
        CancellationToken cancellationToken)
    {
        //TODO: handle response
        var response = await elasticsearchClient.Indices.CreateAsync(descriptor, cancellationToken);
    }
}