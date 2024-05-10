using Cooking.Domain.Enums;

namespace Cooking.Domain.Entities;

    public abstract class RecipeBase(
        Guid id,
        string name,
        string description,
        Complexity complexity,
        TypeOfMeal typeOfMeal,
        Cuisine cuisine) : IEntity
    {
        public Guid Id { get; } = IsValidId(id)
            ? id
            : throw new ArgumentException("Invalid id", nameof(id));

        public string Name { get; } = IsValidName(name)
            ? name
            : throw new ArgumentException("Invalid name", nameof(name));

        public string Description { get; } = IsValidDescription(description)
            ? description
            : throw new ArgumentException("Invalid description", nameof(description));

        public DateTime CreatedDateUtc { get; } = DateTime.UtcNow;
        public DateTime? LastModifiedDateUtc { get; set; }
        
        public Complexity Complexity { get; } = complexity;
        public TypeOfMeal TypeOfMeal { get; } = typeOfMeal;
        public Cuisine Cuisine { get; } = cuisine;

        private static bool IsValidName(string name) => !string.IsNullOrEmpty(name);
        private static bool IsValidId(Guid id) => id != default;
        private static bool IsValidDescription(string description) => !string.IsNullOrEmpty(description);
    }