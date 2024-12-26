using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elex.Instances
{
    internal class Order
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int CustomerId { get; set; }
        public int Price { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
    }
}
