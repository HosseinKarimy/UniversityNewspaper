using Application.Bazaar.DTO;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Bazaar.BazzarHandlers.GetCategories;

public record GetCategoriesQuery : IQuery<GetCategoriesResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

public record GetCategoriesResult(List<GetCategoryDto> CategoriesDto);