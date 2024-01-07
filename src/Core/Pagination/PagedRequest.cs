using System.ComponentModel.DataAnnotations;

namespace timeasy_api.src.Core.Pagination;


public abstract class PagedRequest
{

    [Range(1, int.MaxValue, ErrorMessage = "O valor de 'PageSize' deve ser maior ou igual a 1.")]
    public int PageSize { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "O valor de 'Page' deve ser maior ou igual a 1.")]
    public int Page { get; set; }
}