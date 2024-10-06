namespace Domain.StronglyTypes;

public record UserId
{
    public Guid Value { get; set; }

    private UserId(Guid value) => Value = value;

    public static UserId Of(Guid value)
    {
        return new UserId(value);
    }
    public static UserId Of(string value)
    {
        return new UserId(Guid.Parse(value));
    }
}
