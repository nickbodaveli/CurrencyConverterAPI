using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CurrencyConverter.Domain;

namespace CurrencyConverter.EFCore.Common.Configuration
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            ConfigureCurrencyTable(builder);
        }
        private void ConfigureCurrencyTable(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("Currencies");

            builder.HasKey(x => x.Id);

            builder.Property(m => m.Code)
                .HasMaxLength(100);
            builder.Property(m => m.Name)
              .HasMaxLength(100);
            builder.Property(m => m.NameLatin)
              .HasMaxLength(100);
        }
    }
}
