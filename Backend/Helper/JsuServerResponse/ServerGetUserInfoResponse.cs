using Newtonsoft.Json;

namespace Helper.JsuServerResponse;

public class ServerGetUserInfoResponse
{
    public string Status { get; set; }
    public ServerUserInfo User { get; set; }

    public static ServerGetUserInfoResponse? FromJsonRequest(string jsonRequest)
    {
        return JsonConvert.DeserializeObject<ServerGetUserInfoResponse>(jsonRequest);
    }
}
