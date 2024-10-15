namespace Helper.ServerResponseDto;

public class ServerUserInfo
{
    public int Id { get; set; }
    public string Role { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string PhoneNumber { get; set; }
    public int GroupCode { get; set; }
    public string ProfileImage { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string GroupName { get; set; }
    public string ProfileImageTiny { get; set; }
}
