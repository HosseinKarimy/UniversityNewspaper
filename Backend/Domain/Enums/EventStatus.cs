
namespace Domain.Enums;

public enum EventStatus
{
    Draft = 0,           // پیش‌نویس - هنوز منتشر نشده
    Published = 1,       // منتشر شده و قابل مشاهده
    RegistrationOpen = 2,  // در حال ثبت‌نام
    CapacityFull = 3,    // ظرفیت تکمیل شده
    RegistrationClosed = 4, // مهلت ثبت‌نام تمام شده
    Completed = 5,       // رویداد برگزار شده
    Canceled = 6         // لغو شده
}