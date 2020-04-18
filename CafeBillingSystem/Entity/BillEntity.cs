using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeBillingSystem.Database_Connection;

namespace CafeBillingSystem.Entity
{
    public class BillEntity
    {
        public string billId { set; get; }
        public string billAmount { set; get; }
    }
}
