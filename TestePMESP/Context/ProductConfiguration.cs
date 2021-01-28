using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestePMESP.Models;

namespace TestePMESP.Contexts
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .HasOne(p => p.Import);

            builder
                .Property(p => p.ImportId)
                .IsRequired();

            builder
                .Property(p => p.DeliveryDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .Property(p => p.ProductDescription)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(p => p.ProductQuantity)
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(p => p.UnitaryPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}