namespace Application.Exceptions;

public class UnauthorizedExeption(string? Message = null) : Exception(Message ?? "Unauthorized")
{
}
