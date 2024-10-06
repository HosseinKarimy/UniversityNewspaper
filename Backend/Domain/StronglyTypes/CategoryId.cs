namespace Domain.StronglyTypes;


public record CategoryId
{
    public Guid Value { get; set; }

    private CategoryId(Guid value) => Value = value;

    public static CategoryId Of(Guid value)
    {
        return new CategoryId(value);
    }
    public static CategoryId Of(string value)
    {
        return new CategoryId(Guid.Parse(value));
    }
}

