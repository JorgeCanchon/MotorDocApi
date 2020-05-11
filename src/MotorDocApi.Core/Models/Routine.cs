using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorDocApi.Core.Models
{
    [Table("routine")]
    public partial class Routine
    {
        public Routine()
        {
            RoutineBrand = new HashSet<RoutineBrand>();
        }
        [Key]
        [Column("idroutine")]
        public long IdRoutine { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("status")]
        public bool Status { get; set; }
        [Column("fhcreated")]
        public DateTime Fhcreated { get; set; }
        [Column("workshopsid")]
        public long WorkshopsId { get; set; }
        public ICollection<RoutineBrand> RoutineBrand { get; set; }
    }
}
