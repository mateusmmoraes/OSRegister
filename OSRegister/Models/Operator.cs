using System;
using System.Collections.Generic;

namespace OSRegister
{
    public partial class Operator
    {
        public int OperatorId { get; set; }
        public string OperatorName { get; set; }
        public string OperatorRole { get; set; }
        public int? ServiceId { get; set; }

        public virtual Service Service { get; set; }
    }
}
