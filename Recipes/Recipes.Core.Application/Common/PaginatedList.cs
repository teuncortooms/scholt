namespace Recipes.Core.Application.Common;

public class PaginatedList<T>
{
    public IList<T> Result { get; set; } = [];
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int Total { get; set; }
}