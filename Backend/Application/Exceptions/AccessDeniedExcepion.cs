namespace Application.Exceptions;

public class AccessDeniedExcepion(string? Message = null) : Exception(Message ?? "Access Denied.")
{
}
