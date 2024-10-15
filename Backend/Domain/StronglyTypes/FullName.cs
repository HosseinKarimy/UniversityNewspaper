namespace Domain.StronglyTypes;

public record FullName
{
    public string Value { get; set; }

    public FullName(string value) => Value = value;

    public static FullName Of(string value)
    {
        return new FullName(value);
    }
}
