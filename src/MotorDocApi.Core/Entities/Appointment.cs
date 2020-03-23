using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorDocApi.Core.Entities
{
    public class Appointment
    {
        [Column("id")]
        public int Id { get; set; }
        //public int CompanyId { get; set; }
        [Column("appointmentstart")]
        public DateTime AppointmentStart { get; set; }
        [Column("appointmentend")]
        public DateTime AppointmentEnd { get; set; }
    }
}
