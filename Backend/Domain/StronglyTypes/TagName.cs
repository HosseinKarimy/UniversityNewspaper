namespace Domain.StronglyTypes;

public class TagName
{
    public string Value { get; set; }

    public TagName(string value) => Value = value;

    public static TagName Of(string value)
    {
        return new TagName(value);
    }
}
