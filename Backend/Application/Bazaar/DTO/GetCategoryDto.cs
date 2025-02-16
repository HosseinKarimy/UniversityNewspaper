using Domain.Models;

namespace Application.Bazaar.DTO;

public record GetCategoryDto(Guid CategoryId , string CategoryName , Guid? ParentCategoryId, List<GetCategoryDto>? ChildCategories)
{   
    public static GetCategoryDto FromCategory(Category category)
    {
        return new GetCategoryDto(
            category.CategoryId.Value!.Value,
            category.CategoryName,
            category.ParentCategoryId?.Value,
            category.ChildCategories?.Select(c => GetCategoryDto.FromCategory(c)).ToList()           
        );
    }
}
