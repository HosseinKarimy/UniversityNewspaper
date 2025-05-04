namespace Helper.CQRS;

public record PaginatedResult<T>(
List<T> Items,
int Page,
int PageSize
);
