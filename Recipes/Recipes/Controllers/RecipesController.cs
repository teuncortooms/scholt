using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Recipes.Core.Application.Common;
using Recipes.Core.Application.Recipes;
using Recipes.Core.Application.Recipes.Models;
using Recipes.NewFolder;

namespace Recipes.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipesController : ControllerBase
{
    private readonly IMediator mediator;

    public RecipesController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public Task<PaginatedList<RecipeDto>> List([FromQuery] RecipesListQuery query)
    {
        return mediator.Send(query);
    }

    [HttpGet("{name}")]
    public Task<RecipeDetailsDto?> GetByName(string name)
    {
        return mediator.Send(new RecipeGetByNameQuery(name));
    }

    [HttpGet("{id:guid}")]
    public Task<RecipeDetailsDto?> GetById(Guid id)
    {
        return mediator.Send(new RecipeGetByIdQuery(id));
    }

    [HttpPost]
    [Authorize(Policy = Policies.MembersOnly)]
    public Task Create(RecipeCreateCommand command)
    {
        return mediator.Send(command);
    }
}