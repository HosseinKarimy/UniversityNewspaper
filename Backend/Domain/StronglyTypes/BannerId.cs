namespace Domain.StronglyTypes;

public record BannerId(Guid Value)
{
    public Guid Value { get; set; }
}
