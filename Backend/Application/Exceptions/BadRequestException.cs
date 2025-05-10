namespace Application.Exceptions;

public class BadRequestException(string? Message) : Exception(Message ?? "BadRequest")
{
}
