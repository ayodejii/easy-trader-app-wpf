using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTrader.EntityFramework
{
    public class EasyTraderDbContextFactory : IDesignTimeDbContextFactory<EasyTraderDbContext>
    {
        public EasyTraderDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<EasyTraderDbContext>();
            options.UseSqlServer("Server=ISAAC\\ISAAC;Database=EasyTrader;Trusted_Connection=true");

            return new EasyTraderDbContext(options.Options);
        }
    }
}
