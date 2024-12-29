using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.SiteEntities.Banners.Create;

public class CreateBannerCommand:IBaseCommand
{
    public CreateBannerCommand(string link, IFormFile imageFile, Domain.SiteEntities.Banner.BannerPosition position)
    {
        Link = link;
        ImageFile = imageFile;
        Position = position;
    }
    public string Link { get; private set; }
    public IFormFile ImageFile { get; private set; }
    public Domain.SiteEntities.Banner.BannerPosition Position { get; private set; }
}