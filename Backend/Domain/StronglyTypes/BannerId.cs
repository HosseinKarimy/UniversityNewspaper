namespace Domain.StronglyTypes;

public record BannerId
{
    public Guid Value { get; set; }

    private BannerId(Guid value) => Value = value;

    public static BannerId Of(Guid value)
    {
        return new BannerId(value);
    }
}
