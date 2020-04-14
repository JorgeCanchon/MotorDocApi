using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorDocApi.Core.Models
{
    public partial class Maintenance
    {
        public Maintenance()
        {
            Maintenancerating = new HashSet<Maintenancerating>();
        }
        [Key]
        public long Idmaintenance { get; set; }
        public long Codappointment { get; set; }
        public long Codvehicle { get; set; }
        public short Status { get; set; }
        public DateTime Fhcreated { get; set; }

        public virtual Appointment CodappointmentNavigation { get; set; }
        public virtual Vehicles CodvehicleNavigation { get; set; }
        public virtual ICollection<Maintenancerating> Maintenancerating { get; set; }
    }
}
