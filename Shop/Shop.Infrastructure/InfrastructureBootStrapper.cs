using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CommentAgg.Repository;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.RoleAgg.Repository;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SiteEntities.Repository;
using Shop.Domain.UserAgg.Repository;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Infrastructure.Persistent.Ef.Configurations.CategoryAgg;
using Shop.Infrastructure.Persistent.Ef.Configurations.CommentAgg;
using Shop.Infrastructure.Persistent.Ef.Configurations.OrderAgg;
using Shop.Infrastructure.Persistent.Ef.Configurations.ProductAgg;
using Shop.Infrastructure.Persistent.Ef.Configurations.RoleAgg;
using Shop.Infrastructure.Persistent.Ef.Configurations.SellerAgg;
using Shop.Infrastructure.Persistent.Ef.Configurations.SiteEntities.Repositories;
using Shop.Infrastructure.Persistent.Ef.Configurations.UserAgg;

namespace Shop.Infrastructure
{
    public static class InfrastructureBootstrapper
    {
        public static void Init(this IServiceCollection service , string connectionString)
        {
            service.AddTransient<IProductRepository, ProductRepository>();
            service.AddTransient<ICategoryRepository, CategoryRepository>();
            service.AddTransient<IOrderRepository, OrderRepository>();
            service.AddTransient<IRoleRepository, RoleRepository>();
            service.AddTransient<ISellerRepository, SellerRepository>();
            service.AddTransient<IBannerRepository, BannerRepository>();
            service.AddTransient<ISliderRepository, SliderRepository>();
            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient<ICommentRepository, CommentRepository>();


            service.AddTransient(_ => new ShopDapperContext(connectionString));
            service.AddDbContext<ShopContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });

        }
    }
}