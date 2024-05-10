namespace Cooking.Domain.Entities;

public interface IRepository<TDocument> where TDocument : IEntity
{
    Task IndexAsync(TDocument document, CancellationToken cancellationToken);

    Task<TDocument?> GetDocumentByIdAsync(Guid id, CancellationToken cancellationToken);
}