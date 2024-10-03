namespace Domain.StronglyTypes;

public record UserId(Guid Value)
{
    public Guid Value { get; set; }
}
