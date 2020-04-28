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
        [Key]
        [Column("idroutine")]
        public long Idroutine { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("cost")]
        public long Cost { get; set; }
        [Column("status")]
        public bool Status { get; set; }
        [Column("fhcreated")]
        public DateTime Fhcreated { get; set; }
        [Column("workshopsid")]
        public long WorkshopsId { get; set; }
    }
}
