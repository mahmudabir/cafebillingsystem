using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeBillingSystem.Entity
{
    public class BillLineEntity
    {
        public string billLineId { set; get; }
        public string billId { set; get; }
        public string itemId { set; get; }
        public string amount { set; get; }
    }
}
