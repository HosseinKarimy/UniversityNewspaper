namespace Domain.Enums;

public enum RegistrationStatus
{
    Pending = 0,        // ثبت‌نام شده ولی تایید نشده
    Approved = 1,       // تایید شده (عضو رسمی رویداد)
    WaitingList = 2,    // در صف انتظار
    Rejected = 3,       // رد شده
    Cancelled = 4       // لغو توسط کاربر یا ادمین
}
