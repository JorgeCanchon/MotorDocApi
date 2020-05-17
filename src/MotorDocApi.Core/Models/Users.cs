using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MotorDocApi.Core.Models
{
    [Table("users")]
    public partial class Users
    {
        public Users()
        {
            Companies = new HashSet<Companies>();
            Mechanics = new HashSet<Mechanics>();
            Vehicles = new HashSet<Vehicles>();
            Workshops = new HashSet<Workshops>();
        }
        [Key]
        [Column("id")]
        public long Id { get; set; }
        //public DateTime? CreatedAt { get; set; }
        // public DateTime? UpdatedAt { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("city")]
        public string City { get; set; }
        [Column("role")]
        public string Role { get; set; }
        [Column("mobile_phone")]
        public long MobilePhone { get; set; }
        [Column("credential")]
        public string Credential { get; set; }
        [Column("profile_pic")]
        public string ProfilePic { get; set; }

        [JsonIgnore]
        public virtual ICollection<Companies> Companies { get; set; }
        [JsonIgnore]
        public virtual ICollection<Mechanics> Mechanics { get; set; } 
        [JsonIgnore]
        public virtual ICollection<Vehicles> Vehicles { get; set; } 
        [JsonIgnore]
        public virtual ICollection<Workshops> Workshops { get; set; }
    }
}
