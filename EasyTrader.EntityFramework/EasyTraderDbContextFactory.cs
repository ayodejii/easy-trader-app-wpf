using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EasyTrader.EntityFramework
{
    public class EasyTraderDbContextFactory : IDesignTimeDbContextFactory<EasyTraderDbContext>
    {
        public EasyTraderDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<EasyTraderDbContext>();
            options.UseSqlServer("Server=ISAAC\\ISAAC;Database=EasyTrader;Trusted_Connection=true"); //make this dynamic

            return new EasyTraderDbContext(options.Options);
        }
    }
}
