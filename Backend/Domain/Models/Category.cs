using Domain.StronglyTypes;

namespace Domain.Models;

public class Category
{
    public CategoryId CategoryId { get; set; }
    public CategoryName CategoryName { get; set; }

    public CategoryId? ParentCategoryId { get; set; }
    public List<Category>? ChildCategories { get; set; }
}
