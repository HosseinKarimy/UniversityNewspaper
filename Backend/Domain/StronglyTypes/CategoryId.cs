namespace Domain.StronglyTypes;


public record CategoryId(Guid Value)
{
    public Guid Value { get; set; }
}

