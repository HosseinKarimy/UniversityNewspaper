using System.Text.Json;

namespace Helper.JsuServerResponse;

public static class JsuContractTemplate
{
    public static object GetContractTemplate(string status, object data)
    {
        if (string.IsNullOrWhiteSpace(status))
            throw new ArgumentException("Status cannot be null or empty.", nameof(status));

        return
            new
            {
                status,
                data
            };
    }
}
