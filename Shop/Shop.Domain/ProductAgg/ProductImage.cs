using Common.Domain;

namespace Shop.Domain.ProductAgg;

public class ProductImage : BaseEntity
{
    public ProductImage(int imagePriority, string imageName)
    {
        ImagePriority = imagePriority;
        ImageName = imageName;
    }

    public long ProductId { get; internal set; }
    public string ImageName { get; private set; }
    public int ImagePriority { get; private set; }
}