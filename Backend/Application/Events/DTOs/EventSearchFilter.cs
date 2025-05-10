using Domain.Enums;

namespace Application.Events.DTOs;

public record EventSearchFilter 
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Title { get; set; }
    public EventStatus? Status { get; set; }
    public int? OwnerId { get; set; }
}
