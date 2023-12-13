namespace timeasy_api.src.Core.Pagination;


public abstract class PagedRequest
{
    public int PageSize { get; set; }
    public int Page { get; set; }
}