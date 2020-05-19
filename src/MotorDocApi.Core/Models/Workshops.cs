using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorDocApi.Core.Models
{
    [Table("workshops")]
    public partial class Workshops
    {
        public Workshops()
        {
            Appointments = new HashSet<Appointment>();
        }
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("logo")]
        public string Logo { get; set; }
        [Column("company_id")]
        public long? CompanyId { get; set; }
        [Column("user_id")]
        public long? UserId { get; set; }
        [Column("latitude")]
        public decimal? Latitude { get; set; }
        [Column("longitude")]
        public decimal? Longitude { get; set; }

        public virtual Companies Company { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Appointment> Appointments { get; }
    }
}
