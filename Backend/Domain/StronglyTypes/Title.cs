namespace Domain.StronglyTypes;

public record Title
{
    public string Value { get; set; }

    public Title(string value) => Value = value;

    public static Title Of(string value)
    {
        return new Title(value);
    }
}
