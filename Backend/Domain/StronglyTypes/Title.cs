namespace Domain.StronglyTypes;

public record Title(string Value)
{
    public string Value { get; set; } = string.Empty;
}
