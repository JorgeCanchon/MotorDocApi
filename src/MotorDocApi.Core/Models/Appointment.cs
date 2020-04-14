using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace MotorDocApi.Core.Models
{
    [Table("appointment")]
    public partial class Appointment
    {
        public Appointment()
        {
            Maintenance = new HashSet<Maintenance>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idappointment")]
        public long Idappointment { get; set; }
//        [DisplayFormat(DataFormatString = "{0:DD/MM/YYYY}")]
        [Column("appointmentstart"), Required]
        public DateTime Appointmentstart { get; set; }
        [Column("appointmentend"), DataType(DataType.DateTime), Required]
        public DateTime Apopointmentend { get; set; }
        [Column("status")]
        public short Status { get; set; }
        [Column("fhcreated")]
        public DateTime Fhcreated { get; set; }
        [Column("workshopsid")]
        public long WorkshopsId { get; set; }
        public virtual ICollection<Maintenance> Maintenance { get; set; }
    }
}
