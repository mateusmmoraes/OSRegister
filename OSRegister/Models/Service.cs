using System;
using System.Collections.Generic;

namespace OSRegister
{
    public partial class Service
    {
        public Service()
        {
            Operator = new HashSet<Operator>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int OrderId { get; set; }
        public string Diagnostic { get; set; }
        public string Solution { get; set; }
        public bool Status { get; set; }
        public string TechnicianName { get; set; }
        public string Comments { get; set; }

        public virtual Order Order { get; set; }
        public virtual ICollection<Operator> Operator { get; set; }
    }
}
