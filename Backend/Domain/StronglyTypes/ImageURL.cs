namespace Domain.StronglyTypes;

public record ImageURL(string Value)
{
    public string Value { get; set; } = string.Empty;
}
