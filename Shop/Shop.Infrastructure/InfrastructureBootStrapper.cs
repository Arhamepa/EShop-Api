using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Infrastructure
{
    public static class InfrastructureBootstrapper
    {
        public static void Init(this IServiceCollection service)
        {
            service.AddTransient<IProductRepository, IProductRepository>();
        }
    }
}