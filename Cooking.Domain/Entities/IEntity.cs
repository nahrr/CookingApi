namespace Cooking.Domain.Entities;

public interface IEntity
{
    Guid Id { get; }
    DateTime CreatedDateUtc { get; }
    DateTime? LastModifiedDateUtc { get; }
}