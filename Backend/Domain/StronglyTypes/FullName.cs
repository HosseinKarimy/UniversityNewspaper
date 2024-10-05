namespace Domain.StronglyTypes;

public record FullName
{
    public string Value { get; set; }

    private FullName(string value) => Value = value;

    public static FullName Of(string value)
    {
        return new FullName(value);
    }
}
