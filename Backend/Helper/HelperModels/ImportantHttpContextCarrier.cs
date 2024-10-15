namespace Helper.HelperModels;

/// <summary>
/// this record carry the important elements of Request Context
/// </summary>
public record ImportantHttpContextCarrier
{
    /// <summary>
    /// the ID of user that send the request
    /// </summary>
    public int AuthenticatedUserId { get; set; }
}
