namespace Domain.StronglyTypes;

public record AnnouncementId
{
    public Guid Value { get; set; }

    public AnnouncementId(Guid value) => Value = value;

    public static AnnouncementId Of(Guid value)
    {
        return new AnnouncementId(value);
    }
}
