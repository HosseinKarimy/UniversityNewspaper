namespace Application.Exceptions;

public class NotFoundException(string? Message = null) : Exception(Message ?? "The Requested Source is Not Found")
{
}
