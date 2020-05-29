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
        public int Timeroutine { get; set; }
        [Column("idmechanic")]
        public long IdMechanic { get; set; }
        [Column("idroutine")]
        public long IdRoutine { get; set; }
        [Column("kilometraje")]
        public long? Kilometraje { get; set; }
        [Column("observaciones")]
        public string Observaciones { get; set; }
        public virtual Maintenance Maintenances { get; set; }
        public virtual Mechanics Mechanics { get; set; }
        //public virtual Routine Routines { get; set; }
    }
}
