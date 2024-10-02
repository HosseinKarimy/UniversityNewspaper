using Domain.Models;

namespace Infrastructure;

public static class FakeDataBase
{
    public static List<User> Users { get; set; } = [];
    public static List<Banner> Banners { get; set; } = [];
    public static List<Category> Categories { get; set; } = [];
}
