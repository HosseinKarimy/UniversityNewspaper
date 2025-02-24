using Domain.Enums;
using Domain.Models;
using Domain.StronglyTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(p => p.Id)
            .HasConversion(eventId => eventId.Value, dbEventId => EventId.Of(dbEventId));

        builder.Property(p => p.OwnerId).HasConversion(OwnerId => OwnerId.Value, dbUserId => UserId.Of(dbUserId));

        builder.OwnsOne(p => p.RegistrationInfo);
        builder.OwnsOne(p => p.Targets);

        builder.UseTphMappingStrategy();

        builder.HasData(
                [
                new Event(){
                      Id = EventId.Of(Guid.NewGuid()),
                      OwnerId = UserId.Of(8800),
                      CreatedAt = DateTime.Now,
                      Description = "\r\n🎤با اجرای مجریان توانمند\r\n\r\n📜آیتم های جذاب و مفرح این برنامه:\r\n\r\n\U0001f9d1‍🎓مناظره جنجالی دانشجویی\r\n\U0001fa91صندلی داغ با حضور رئیس اداره کار و اساتید\r\n🎁مسابقات جذاب همراه با اهدای جوایز ارزنده\r\n🎛🎚🎙پخش موسیقی و تصنیف خوانی\r\n🎇نورافشانی\r\nو...",
                      Title = "🎉جشن بزرگ روز مهندس و روز جوان🎉",
                      Location = "سالن ورزشی دانشگاه",
                      Organizers = [Department.Law , Department.Nursing],
                      Date = DateTime.Now
                }
                ]);
    }
}
