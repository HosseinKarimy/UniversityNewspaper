namespace Application.Exceptions;

public class NotFoundException(string? Message) : Exception(Message ?? "The Requested Source is Not Found")
{
}
