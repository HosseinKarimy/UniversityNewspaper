namespace Domain.StronglyTypes;

public record CurrencyUnit
{
    public decimal Value { get; set; }

    private CurrencyUnit(decimal value) => Value = value;

    public static CurrencyUnit Of(decimal value)
    {
        ArgumentNullException.ThrowIfNull(value);
        return new CurrencyUnit(value);
    }
    public static CurrencyUnit Of(string value)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(value);
        return new CurrencyUnit(decimal.Parse(value));
    }
}
