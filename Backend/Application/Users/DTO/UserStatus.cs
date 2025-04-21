namespace Application.Users.DTO;

public record UserStatusDto(int UserId, int BannerCount, int EventCount, bool CanAddBanner, bool CanAddEvent);
