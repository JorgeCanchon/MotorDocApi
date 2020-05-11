using System;
using System.Collections.Generic;

namespace MotorDocApi.Core.Models
{
    public partial class Routinemechanic
    {
        public long Codroutine { get; set; }
        public long Codmechanic { get; set; }
        //public DateTime Estimatedtime { get; set; }

        public virtual Mechanics CodmechanicNavigation { get; set; }
        public virtual Routine CodroutineNavigation { get; set; }
    }
}
