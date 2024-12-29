using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.SiteEntities.Slider.Edit;

public class EditSliderCommand:IBaseCommand
{

    public EditSliderCommand(string link, IFormFile? imageFile, string title, long sliderId)
    {
        Link = link;
        ImageFile = imageFile;
        Title = title;
        SliderId = sliderId;
    }

    public long SliderId { get; private set; }
    public string Link { get; private set; }
    public IFormFile? ImageFile { get; private set; }
    public string Title { get; private set; }

}