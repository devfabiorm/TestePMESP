using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestePMESP.Models;

namespace TestePMESP.Contexts
{
    internal class ImportConfiguration : IEntityTypeConfiguration<Import>
    {
        public void Configure(EntityTypeBuilder<Import> builder)
        {
            builder
                .HasKey(i => i.Id);

            builder
                .HasMany(i => i.Products)
                .WithOne(p => p.Import);

            builder
                .Property(i => i.ImportDate)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}