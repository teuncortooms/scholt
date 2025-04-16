using System.Security.Claims;
using Recipes.Core.Application.Common.Interfaces;

namespace Recipes.Services;

internal class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor httpContextAccessor;
    private ClaimsPrincipal? User => this.httpContextAccessor.HttpContext?.User;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public string? Name => User?.FindFirstValue("name");
}