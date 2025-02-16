namespace Domain.StronglyTypes;


public record EventId
{
    public Guid Value { get; set; }

    public EventId(Guid value) => Value = value;

    public static EventId Of(Guid value)
    {
        return new EventId(value);
    }
}
