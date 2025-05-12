namespace Domain.StronglyTypes;

public record CurrencyUnit
{
    public string Value { get; set; }

    public CurrencyUnit(string value) => Value = value;

    public static CurrencyUnit Of(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        return new CurrencyUnit(value);
    }
}
