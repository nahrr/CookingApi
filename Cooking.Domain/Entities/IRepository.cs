namespace Cooking.Domain.Entities;

public interface IRepository<in TDocument> where TDocument : IMappingDocument 
{
    Task IndexAsync(TDocument document, CancellationToken cancellationToken);
    Task CreateIndexAsync(CancellationToken cancellationToken);
}