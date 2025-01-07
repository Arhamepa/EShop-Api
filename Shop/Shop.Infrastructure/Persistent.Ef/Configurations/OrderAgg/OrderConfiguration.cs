using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.OrderAgg;

namespace Shop.Infrastructure.Persistent.Ef.Configurations.OrderAgg;

internal class OrderConfiguration:IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders", "order");

        builder.OwnsMany(it => it.Items, option =>
        {
            option.HasKey(b => b.Id);
            option.ToTable("Items", "order");
        });

        builder.OwnsOne(d => d.Address, option =>
        {
            option.HasKey(b => b.Id);
            option.ToTable("Addresses", "order");

            option.Property(b => b.Province)
                .IsRequired().HasMaxLength(100);

            option.Property(b => b.City)
                .IsRequired().HasMaxLength(100);

            option.Property(b => b.Name)
                .IsRequired().HasMaxLength(50);

            option.Property(b => b.Family)
                .IsRequired().HasMaxLength(50);

            option.Property(b => b.PhoneNumber)
                .IsRequired().HasMaxLength(12);

            option.Property(b => b.NationalCode)
                .IsRequired().HasMaxLength(10);

            option.Property(b => b.PostalCode)
                .IsRequired().HasMaxLength(20);

        });

        builder.OwnsOne(b => b.Discount, option =>
        {
            option.Property(b => b.DiscountTitle)
                .IsRequired()
                .HasMaxLength(100);
        });

        builder.OwnsOne(b => b.OrderShippingMethod, option =>
        {
            option.Property(b => b.ShippingType)
                .IsRequired(false)
                .HasMaxLength(100);
        });
    }
}