using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorDocApi.Core.Models
{
    public partial class Companies
    {
        public Companies()
        {
            Mechanics = new HashSet<Mechanics>();
            Workshops = new HashSet<Workshops>();
        }
        [Key]
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long? UserId { get; set; }
        public string BusinessName { get; set; }
        public string Nit { get; set; }
        public string Logo { get; set; }
        public int? Status { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Mechanics> Mechanics { get; set; }
        public virtual ICollection<Workshops> Workshops { get; set; }
    }
}
