using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorDocApi.Core.Models
{
    [Table("maintenance")]
    public partial class Maintenance
    {
        public Maintenance()
        {
            Maintenancerating = new HashSet<Maintenancerating>();
            Maintenanceroutines = new HashSet<Maintenanceroutine>();
            Vehicles = new HashSet<Vehicles>();
        }
        [Key] 
        [Column("idmaintenance")]
        public long Idmaintenance { get; set; }
        [Column("idappointment")]
        public long IdAppointment { get; set; }
        [Column("idvehicle")]
        public long IdVehicle { get; set; }
        [Column("status")]
        public short Status { get; set; }
        [Column("fhcreated")]
        public DateTime Fhcreated { get; set; }

        public virtual Appointment Appointments { get; set; }
        public virtual ICollection<Vehicles> Vehicles { get; set; }
        public virtual ICollection<Maintenancerating> Maintenancerating { get; set; }
        public ICollection<Maintenanceroutine> Maintenanceroutines { get; set; }
    }
}
