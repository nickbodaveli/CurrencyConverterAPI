using CurrencyConverter.Domain;
using CurrencyConverter.EFCore.Common.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CurrencyConverter.EFCore.Common
{
    public class CurrencyConverterDbContext : DbContext
    {
        public CurrencyConverterDbContext(DbContextOptions<CurrencyConverterDbContext> options) : base(options)
        {

        }

        public DbSet<Currency> Currencies => Set<Currency>();
        public DbSet<CurrencySetter> CurrencySetters => Set<CurrencySetter>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserHistory> UserHistories => Set<UserHistory>();
        public DbSet<UserHistoryReport> UserHistoryReports => Set<UserHistoryReport>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(CurrencyConfiguration).Assembly);
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
            modelBuilder
               .ApplyConfigurationsFromAssembly(typeof(UserHistoryConfiguration).Assembly);

            modelBuilder
              .ApplyConfigurationsFromAssembly(typeof(UserHistoryReportConfiguration).Assembly);

        }
    }
}
