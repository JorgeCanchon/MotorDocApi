using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorDocApi.Core.Models
{
    public partial class Brands
    {
        public Brands()
        {
            Vehicles = new HashSet<Vehicles>();
        }
        [Key]
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Vehicles> Vehicles { get; set; }
    }
}
