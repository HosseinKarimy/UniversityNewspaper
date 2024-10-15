namespace Domain.StronglyTypes;

public record UserId
{
    public int Value { get; set; }

    private UserId(int value) => Value = value;

    public static UserId Of(int value)
    {
        ArgumentNullException.ThrowIfNull(value);
        return new UserId(value);
    }
    public static UserId Of(string value)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(value);
        return new UserId(int.Parse(value));
    }
}
