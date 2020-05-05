using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OSRegister
{
    public partial class Client
    {
        public Client()
        {
            Order = new HashSet<Order>();
        }

        [Required]
        public int ClientId { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string ClientEmail { get; set; }
        [Required]
        public string ClientPhone { get; set; }
        [Required]
        public string ClientAdress { get; set; }
        [Required]
        public string ClientRole { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
