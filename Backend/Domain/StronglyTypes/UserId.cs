namespace Domain.StronglyTypes;

public readonly record struct UserId(int Value)
{
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
