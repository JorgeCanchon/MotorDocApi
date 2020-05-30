using System.ComponentModel.DataAnnotations.Schema;

namespace MotorDocApi.Core.Models
{
    [Table("routinemechanic")]
    public partial class Routinemechanic
    {
        [Column("idroutine")]
        public long IdRoutine { get; set; }
        [Column("idmechanic")]
        public long IdMechanic { get; set; }
        //public DateTime Estimatedtime { get; set; }

        public virtual Mechanics CodmechanicNavigation { get; set; }
        public virtual Routine CodroutineNavigation { get; set; }
    }
}
