using System;
using System.Collections.Generic;

namespace OSRegister
{
    public partial class Client
    {
        public Client()
        {
            Order = new HashSet<Order>();
        }

        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public int ClientPhone { get; set; }
        public string ClientAdress { get; set; }
        public string ClientRole { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
