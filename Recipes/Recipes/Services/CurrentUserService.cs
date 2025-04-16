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

    //public string? UserId => User?.FindFirstValue(ClaimTypes.Upn) ?? User?.FindFirstValue(JwtClaimTypes.PreferredUserName);
    //public string? Name => User?.Identity?.Name ?? User?.FindFirstValue(JwtClaimTypes.Name);
    public string? UserId => throw new NotImplementedException();
    public string? Name => throw new NotImplementedException();
}