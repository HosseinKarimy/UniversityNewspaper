namespace Domain.StronglyTypes;

public record Description(string Value)
{
    public string Value { get; set; } = string.Empty;
}
