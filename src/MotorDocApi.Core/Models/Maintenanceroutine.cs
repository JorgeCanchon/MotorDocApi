using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorDocApi.Core.Models
{
    public partial class Maintenanceroutine
    {
        public long Codmaintenance { get; set; }
        public long Costroutine { get; set; }
        public DateTime Timeroutine { get; set; }
        public long Codmechanic { get; set; }
        public long Codroutine { get; set; }

        public virtual Maintenance CodmaintenanceNavigation { get; set; }
        public virtual Mechanics CodmechanicNavigation { get; set; }
        public virtual Routine CodroutineNavigation { get; set; }
    }
}
