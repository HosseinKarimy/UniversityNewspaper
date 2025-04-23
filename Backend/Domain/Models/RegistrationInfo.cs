using Domain.Enums;
using Domain.StronglyTypes;

namespace Domain.Models;

public class RegistrationInfo
{
    public DateOnly? Deadline { get; set; }
    public int? Capacity { get; set; }
    public decimal? Fee { get; set; }
}
