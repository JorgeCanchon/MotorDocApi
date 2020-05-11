using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorDocApi.Core.Models
{
    [Table("referencebrand")]
    public partial class ReferenceBrand
    {
        public ReferenceBrand()
        {
            RoutineBrand = new HashSet<RoutineBrand>();
        }
        [Key]
        [Column("idreferencebrand")]
        public long IdReferenceBrand { get; set; }
        [Column("namereference")]
        public string NameReference { get; set; }
        [Column("idbrand")]
        public long IdBrand { get; set; }
        [Column("status")]
        public bool Status { get; set; }
        public ICollection<RoutineBrand> RoutineBrand { get; set; }
    }
}
