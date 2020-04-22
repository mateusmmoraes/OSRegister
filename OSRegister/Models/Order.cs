using System;
using System.Collections.Generic;

namespace OSRegister
{
    public partial class Order
    {
        public Order()
        {
            Service = new HashSet<Service>();
        }

        public int OrderId { get; set; }
        public string OrderReason { get; set; }
        public int ClientId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime FinalDate { get; set; }
        public string Operator { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Service> Service { get; set; }
    }
}
