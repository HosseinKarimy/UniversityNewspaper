using Application.Bazaar.BazzarRepositories;
using Application.Bazaar.DTO;
using MediatR;

namespace Application.Bazaar.BazzarHandlers.GetCategories;

public class GetCategoriesHandler(IBazaarUnitOfWork bazaarUnitOfWork) : IRequestHandler<GetCategoriesQuery, GetCategoriesResult>
{
    public async Task<GetCategoriesResult> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await bazaarUnitOfWork.CategoryRepository.GetAllCategoriesAsync(cancellationToken);
        var categoriesDto = categories.Select(category=>GetCategoryDto.FromCategory(category)).ToList();
        return new GetCategoriesResult(categoriesDto);
    }
}
