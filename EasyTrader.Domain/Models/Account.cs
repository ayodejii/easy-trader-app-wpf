using System.Collections.Generic;

namespace EasyTrader.Domain.Models
{
    public class Account : DomainObject
    {
        public User AccountHolder { get; set; }
        public IEnumerable<AssetTransaction> AssetTransactions { get; set; }
    }
}
