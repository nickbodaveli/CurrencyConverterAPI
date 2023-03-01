using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CurrencyConverter.Domain;

namespace CurrencyConverter.EFCore.Common.Configuration
{
    public class UserHistoryReportConfiguration : IEntityTypeConfiguration<UserHistoryReport>
    {
        public void Configure(EntityTypeBuilder<UserHistoryReport> builder)
        {
            ConfigureUserHistoryReportTable(builder);
        }
        private void ConfigureUserHistoryReportTable(EntityTypeBuilder<UserHistoryReport> builder)
        {
            builder.ToTable("UserHistoryReports");

            builder.HasKey(x=>x.Id);

            //builder.Property(s => s.UserId).HasMaxLength(100);
            builder.Property(s => s.ConvertedPriceSum).HasMaxLength(100);
            builder.Property(s => s.ConvertedPriceSumOfGel).HasMaxLength(100);

            //builder.HasOne<UserHistory>(s => s.UserHistory).WithOne(x => x.UserHistoryReport).HasForeignKey<UserHistoryReport>(id => id.UserHistoryId);



            //builder.OwnsMany(f => f.UserHistoryReports, sb =>
            //{
            //    sb.ToTable("UserHistoryReports");

            //    //sb.HasKey("Id", "UserHistoryReportId");
            //    sb.HasKey("Id");

            //    sb.Property(x => x.ConvertedPriceSumOfGel).HasMaxLength(100);
            //    sb.Property(x => x.ConvertedPriceSum).HasMaxLength(100);

            //});

            //builder.Metadata.FindNavigation(nameof(UserHistoryReport.UserHistory))!
            // .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
