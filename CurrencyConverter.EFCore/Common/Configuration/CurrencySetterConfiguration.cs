using CurrencyConverter.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CurrencyConverter.EFCore.Common.Configuration
{
    public class CurrencySetterConfiguration : IEntityTypeConfiguration<CurrencySetter>
    {
        public void Configure(EntityTypeBuilder<CurrencySetter> builder)
        {
            ConfigureCurrencySetterTable(builder);
        }
        private void ConfigureCurrencySetterTable(EntityTypeBuilder<CurrencySetter> builder)
        {
            builder.ToTable("CurrencySetters");

            builder.HasKey(x => x.Id);

            builder.Property(s => s.SetCurrencyCode).HasMaxLength(100);
            builder.Property(s => s.SetCurrencyPrice).HasMaxLength(100);
            builder.Property(s => s.SetSellPrice).HasMaxLength(100);
        }
    }
}
