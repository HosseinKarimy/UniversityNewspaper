namespace Application.Exceptions;

public class AccessDeniedExcepion(string? Message) : Exception(Message ?? "Access Denied.")
{
}
