namespace Domain.StronglyTypes;

public record Description
{
    public string Value { get; set; }

    public Description(string value) => Value = value;

    public static Description Of(string value)
    {
        return new Description(value);
    }
}
