using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace CurrencyConverter.EFCore.Common
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<CurrencyConverterDbContext>
    {
        public CurrencyConverterDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CurrencyConverterDbContext>();
            var st = "Server=localhost; port=3306; Database=CurrencyDatabase; User=root;Password=N1kan1kan1ka.;";
            optionsBuilder.UseMySql(st, ServerVersion.AutoDetect(st));

            return new CurrencyConverterDbContext(optionsBuilder.Options);
        }
    }
}
