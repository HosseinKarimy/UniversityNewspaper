namespace Helper.CQRS;

public record PaginatedResult<T>(List<T>? Data, bool IsSuccess , int Page, int PageSize , string? Message = null) : RequestResult<List<T>>(Data, IsSuccess, Message);
