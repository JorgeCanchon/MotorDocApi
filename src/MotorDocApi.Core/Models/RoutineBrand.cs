using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MotorDocApi.Core.Models
{
    [Table("routinebrand")]
    public partial class RoutineBrand
    {
        [Column("idroutine")]
        public long IdRoutine { get; set; }
        [Column("idreferencebrand")]
        public long IdReferenceBrand { get; set; }
        [Column("cost")]
        public double Cost { get; set; }
        [Column("estimatedtime")]
        public int EstimatedTime { get; set; }
        [JsonIgnore]
        public Routine Routine { get; set; }
        [JsonIgnore]
        public ReferenceBrand ReferenceBrand { get; set; }
    }
}
