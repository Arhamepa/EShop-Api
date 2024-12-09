using Common.Domain;

namespace Shop.Domain.ProductAgg;

public class ProductImage : BaseEntity
{
    public ProductImage(int sequence, string imageName)
    {
        Sequence = sequence;
        ImageName = imageName;
    }

    public long ProductId { get; internal set; }
    public string ImageName { get; private set; }
    public int Sequence { get; private set; }
}