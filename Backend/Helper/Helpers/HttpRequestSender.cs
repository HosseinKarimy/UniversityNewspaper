namespace Helper.Helpers;

using System.Net.Http.Headers;


public class HttpRequestSender
{
    private readonly string _bearerToken;
    private readonly HttpClient _httpClient;
    private readonly AuthenticationHeaderValue _authorizationHeader;

    public HttpRequestSender(string bearerToken)
    {
        _bearerToken = bearerToken.Replace("Bearer ", "");
        _httpClient = new HttpClient();
        _authorizationHeader = new AuthenticationHeaderValue("Bearer", _bearerToken);

        _httpClient.BaseAddress = new Uri("https://cm.jsu.ac.ir/");
    }

    private async Task<string> SendRequest(string endpoint, HttpMethod method)
    {
        using var request = new HttpRequestMessage(method, endpoint);
        request.Headers.Authorization = _authorizationHeader; 

        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        } else
        {
            return response.StatusCode + " Error: " + response.ReasonPhrase;
        }
    }

    public async Task<string> GetUserInfoFromMainServer()
    {
        return await SendRequest("/api/v2/get_my_info", HttpMethod.Post);
    }
}

