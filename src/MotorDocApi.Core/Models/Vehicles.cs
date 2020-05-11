using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorDocApi.Core.Models
{
    [Table("vehicles")]
    public partial class Vehicles
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        //public DateTime? CreatedAt { get; set; }
        //public DateTime? UpdatedAt { get; set; }
        [Column("client_id")]
        public long? ClientId { get; set; }
        [Column("idreferencebrand")]
        public long IdRerefenceBrand { get; set; }
        [Column("model")]
        public string Model { get; set; }
        [Column("estado")]
        public string Estado { get; set; }
        [Column("image")]
        public string Image { get; set; }
        [Column("placa")]
        public string Placa { get; set; }
        //public virtual ReferenceBrand ReferenceBrand { get; set; }
        public virtual Users Client { get; set; }
        public virtual Maintenance Maintenances { get; set; }
    }
}
