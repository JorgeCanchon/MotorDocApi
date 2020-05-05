using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorDocApi.Core.Models
{
    public partial class Vehicles
    {
        public Vehicles()
        {
            Maintenance = new HashSet<Maintenance>();
        }
        [Key]
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long? ClientId { get; set; }
        public long CodRerefenceBrand { get; set; }
        public string Model { get; set; }
        public string Estado { get; set; }
        public string Image { get; set; }
        public string Reference { get; set; }
        public string Placa { get; set; }
        public virtual ReferenceBrand ReferenceBrand { get; set; }
        public virtual Users Client { get; set; }
        public virtual ICollection<Maintenance> Maintenance { get; set; }
    }
}
