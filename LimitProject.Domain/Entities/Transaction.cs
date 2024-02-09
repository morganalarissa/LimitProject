using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitProject.Domain.Entities
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public int ClientId { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
