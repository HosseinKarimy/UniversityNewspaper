namespace Application.Users.DTO;

public record UserAccessDto(int UserId, bool? CanAddBanner, bool? CanAddEvent);
