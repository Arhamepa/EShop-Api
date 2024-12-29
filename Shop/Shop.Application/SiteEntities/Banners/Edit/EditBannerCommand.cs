using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.SiteEntities.Banner.Create;

public class EditBannerCommand: IBaseCommand
{
    public EditBannerCommand(string link, IFormFile? imageFile, Domain.SiteEntities.Banner.BannerPosition position, long bannerId)
    {
        Link = link;
        ImageFile = imageFile;
        Position = position;
        BannerId = bannerId;
    }

    public long BannerId { get; private set; }
    public string Link { get; private set; }
    public IFormFile? ImageFile { get; private set; }
    public Domain.SiteEntities.Banner.BannerPosition Position { get; private set; }
}