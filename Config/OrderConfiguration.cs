using ELSAPI.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace ELSAPI.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.Total).HasColumnType("decimal(18,2)");
        }
    }
}