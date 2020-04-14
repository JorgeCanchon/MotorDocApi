using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorDocApi.Core.Models
{
    public partial class Maintenancerating
    {
        [Key]
        public long Idmaintenancerating { get; set; }
        public short Stars { get; set; }
        public string Commentary { get; set; }
        public long Codmaintenance { get; set; }
        public DateTime Fhcreated { get; set; }

        public virtual Maintenance CodmaintenanceNavigation { get; set; }
    }
}
