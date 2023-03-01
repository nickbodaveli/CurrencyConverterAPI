using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CurrencyConverter.Domain;

namespace CurrencyConverter.EFCore.Common.Configuration
{
    public class UserHistoryConfiguration : IEntityTypeConfiguration<UserHistory>
    {
        public void Configure(EntityTypeBuilder<UserHistory> builder)
        {
            ConfigureUserHistoryTable(builder);
        }
        private void ConfigureUserHistoryTable(EntityTypeBuilder<UserHistory> builder)
        {
            builder.ToTable("UserHistories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PrivateNumber).HasMaxLength(100);
            builder.Property(x => x.RecomendatorPrivateNumber).HasMaxLength(100);
            builder.Property(x => x.ConvertedPrice).HasMaxLength(100);
        }
    }
}
