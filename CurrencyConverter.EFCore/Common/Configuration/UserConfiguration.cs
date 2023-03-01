using CurrencyConverter.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CurrencyConverter.EFCore.Common.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureCurrencyTable(builder);
        }
        private void ConfigureCurrencyTable(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(m => m.PrivateNumber)
               .HasMaxLength(100);
            builder.Property(m => m.Name)
                .HasMaxLength(100);
            builder.Property(m => m.LastName)
              .HasMaxLength(100);
        }
    }
}
