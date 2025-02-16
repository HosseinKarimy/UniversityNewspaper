using Domain.StronglyTypes;

namespace Domain.Models;

public class Category
{
    public CategoryId CategoryId { get; set; }
    public string CategoryName { get; set; }

    public CategoryId? ParentCategoryId { get; set; }
    public List<Category>? ChildCategories { get; set; }
}
