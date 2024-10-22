namespace Domain.StronglyTypes;

public class TagId
{
    public Guid? Value { get; set; }

    public TagId(Guid? value) => Value = value;

    public static TagId Of(Guid? value)
    {
        return new TagId(value);
    }
    public static TagId Of(string value)
    {
        return new TagId(Guid.Parse(value));
    }
}
