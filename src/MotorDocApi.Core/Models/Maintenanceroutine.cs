using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorDocApi.Core.Models
{
    [Table("maintenanceroutine")]
    public partial class Maintenanceroutine
    {
        [Column("idmaintenance")]
        public long IdMaintenance { get; set; }
        [Column("costroutine")]
        public long Costroutine { get; set; }
        [Column("timeroutine")]
        public DateTime Timeroutine { get; set; }
        [Column("idmechanic")]
        public long IdMechanic { get; set; }
        [Column("idroutine")]
        public long IdRoutine { get; set; }

        public virtual Maintenance Maintenances { get; set; }
        public virtual Mechanics Mechanics { get; set; }
        //public virtual Routine Routines { get; set; }
    }
}
