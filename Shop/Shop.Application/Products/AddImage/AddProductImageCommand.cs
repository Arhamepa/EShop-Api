using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Products.AddImage;

public class AddProductImageCommand:IBaseCommand
{
    public AddProductImageCommand(IFormFile imageFile, long productId, int imagePriority)
    {
        ImageFile = imageFile;
        ProductId = productId;
        ImagePriority = imagePriority;
    }

    public IFormFile ImageFile { get; private set; }
    public long ProductId { get; private set; }
    public int ImagePriority { get; private set; }
    
}