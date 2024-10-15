namespace Domain.StronglyTypes;

public record ImageURL
{
    public string Value { get; set; }

    public ImageURL(string value) => Value = value;

    public static ImageURL Of(string value)
    {
        return new ImageURL(value);
    }
}
