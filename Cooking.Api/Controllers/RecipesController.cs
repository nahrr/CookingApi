using System;
using System.Threading.Tasks;
using Cooking.Application.Recipes.Commands;
using Cooking.Application.Recipes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cooking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController(
    ILogger<RecipesController> logger,
    ISender sender) : ControllerBase
{
    private readonly ILogger<RecipesController> _logger = logger;
    private readonly ISender _sender = sender;

    [HttpGet("{id:guid}", Name = "GetRecipe")]
    public async Task<IActionResult> GetRecipe(Guid id)
    {
        var recipe = await _sender.Send(new GetRecipeByIdQuery(id));

        return new ObjectResult(recipe);
    }

    [HttpGet(Name = "GetRecipes")]
    public async Task<IActionResult> GetRecipes()
    {
        var recipes = await _sender.Send(new GetRecipesQuery());

        return new ObjectResult(recipes);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRecipe([FromBody] AddRecipeRequest request)
    {
        var response = await _sender.Send(new AddRecipeCommand(
            request.Name,
            request.Description,
            request.Ingredients,
            request.Steps,
            request.TypeOfMeal,
            request.Complexity,
            request.Cuisine));

        return CreatedAtAction(nameof(GetRecipe), new { id = response.Id }, response);
    }
}