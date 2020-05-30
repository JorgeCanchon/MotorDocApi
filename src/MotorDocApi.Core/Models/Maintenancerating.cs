using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorDocApi.Core.Models
{
    [Table("maintenancerating")]
    public partial class Maintenancerating
    {
        [Key]
        [Column("idmaintenancerating")]
        public long IdMaintenanceRating { get; set; }
        [Column("stars")]
        public short Stars { get; set; }
        [Column("commentary")]
        public string Commentary { get; set; }
        [Column("idmaintenance")]
        public long IdMaintenance { get; set; }
        [Column("fhcreated")]
        public DateTime Fhcreated { get; set; }

        public virtual Maintenance Maintenance{ get; set; }
    }
}
