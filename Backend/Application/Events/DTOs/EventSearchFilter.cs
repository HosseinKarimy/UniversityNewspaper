using Domain.Enums;

namespace Application.Events.DTOs;

public record EventSearchFilter 
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? FilteredTitle { get; set; }
    public EventStatus? Status { get; set; } 
}
