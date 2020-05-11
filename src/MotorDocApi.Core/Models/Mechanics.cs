using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorDocApi.Core.Models
{
    [Table("mechanics")]
    public partial class Mechanics
    {
        public Mechanics()
        {
            Maintenanceroutines = new HashSet<Maintenanceroutine>();
        }
        [Key]
        [Column("id")]
        public long Id { get; set; }
        //public DateTime? CreatedAt { get; set; }
        //public DateTime? UpdatedAt { get; set; }
        [Column("user_id")]
        public long? UserId { get; set; }
        [Column("company_id")]
        public long? CompanyId { get; set; }
        [Column("workshop_id")]
        public long? WorkshopId { get; set; }

        public virtual Companies Company { get; set; }
        public virtual Users User { get; set; }
        public ICollection<Maintenanceroutine> Maintenanceroutines { get; set; }
    }
}
