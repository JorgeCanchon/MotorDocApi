using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace MotorDocApi.Core.Models
{
    public partial class Routine
    {
        [Key]
        public long Idroutine { get; set; }
        public string Name { get; set; }
        public long Cost { get; set; }
        public BitArray Status { get; set; }
        public DateTime Fhcreated { get; set; }
    }
}
