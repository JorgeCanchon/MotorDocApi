using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorDocApi.Core.Models
{
    public partial class Mechanics
    {
        [Key]
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long? UserId { get; set; }
        public long? CompanyId { get; set; }
        public long? WorkshopId { get; set; }

        public virtual Companies Company { get; set; }
        public virtual Users User { get; set; }
    }
}
