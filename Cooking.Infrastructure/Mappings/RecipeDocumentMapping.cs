using Cooking.Domain.Entities;
using Elastic.Clients.Elasticsearch.IndexManagement;

namespace Cooking.Infrastructure.Mappings;

public static class RecipeDocumentMapping
{
    public static CreateIndexRequestDescriptor<RecipeDocument> Create()
    {
        var descriptor = new CreateIndexRequestDescriptor<RecipeDocument>(nameof(RecipeDocument).ToLower())
            .Mappings(m => m
                .Properties(p => p
                    .Keyword(k => k.Id)
                    .Text(t => t.Name, c => c
                        .Fields(f => f
                            .Keyword("keyword", cc => cc
                                .IgnoreAbove(256)
                            )
                        )
                    )
                    .Text(t => t.Description, c => c
                        .Fields(f => f
                            .Keyword("keyword", cc => cc
                                .IgnoreAbove(256)
                            )
                        )
                    )
                    .Object(o => o.Ingredients, c => c
                        .Properties(f => f
                            .Text(t => t.Ingredients.First().Name, a => a
                                .Fields(i => i
                                    .Keyword("keyword", cc => cc
                                        .IgnoreAbove(256)))
                            )
                            .Keyword(t => t.Ingredients.First().Quantity)
                            .Keyword(t => t.Ingredients.First().Unit)
                        )
                    )
                    .Object(o => o.CookingSteps, c => c
                        .Properties(f => f
                            .Text(t => t.CookingSteps.First().CookingStep.Instruction, a => a
                                .Fields(i => i
                                    .Keyword("keyword", cc => cc
                                        .IgnoreAbove(256)))
                            )
                            .Keyword(t => t.CookingSteps.First().CookingStep.Duration)
                            .Keyword(t => t.CookingSteps.First().StepNumber)
                        )
                    )
                    .Keyword(k => k.Complexity)
                    .Keyword(k => k.TypeOfMeal)
                    .Keyword(k => k.Cuisine)
                    .Date(d => d.CreatedDateUtc)
                    .Date(d => d.LastModifiedDateUtc!)
                )
            );

        return descriptor;
    }
}