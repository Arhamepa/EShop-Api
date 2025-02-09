using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.Configurations.SiteEntities.Repositories;

public class BannerRepository:BaseRepository<Banner> , IBannerRepository
{
    public BannerRepository(ShopContext context) : base(context)
    {
    }
}