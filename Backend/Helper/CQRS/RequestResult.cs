namespace Helper.CQRS;

public record RequestResult<T>(T? Data , bool IsSuccess, string? Message = null);
