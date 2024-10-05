namespace Domain.StronglyTypes;

public record CategoryName
{
    public string Value { get; set; }

    private CategoryName(string value) => Value = value;

    public static CategoryName Of(string value)
    {
        return new CategoryName(value);
    }
}

