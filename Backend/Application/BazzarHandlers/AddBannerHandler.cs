using Application.BazaarRepositories;
using Application.DTO;
using Domain.Models;
using MediatR;

namespace Application.BazaarHandlers;


public record AddBannerCommand(BannerDTO BannerDto) : IRequest<AddBannerResult>;
public record AddBannerResult(Banner Banner);

public class AddBannerHandler(IBannerRepository bannerRepository) : IRequestHandler<AddBannerCommand, AddBannerResult>
{
    public async Task<AddBannerResult> Handle(AddBannerCommand request, CancellationToken cancellationToken)
    {        
        var banner = await bannerRepository.AddBannerAsync(request.BannerDto.ToBanner(), cancellationToken);
        return new AddBannerResult(banner);
    }
}
