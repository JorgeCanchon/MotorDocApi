using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorDocApi.Core.Models
{
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
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Role { get; set; }
        public long MobilePhone { get; set; }
        public string Credential { get; set; }
        public string ProfilePic { get; set; }

        public virtual ICollection<Companies> Companies { get; set; }
        public virtual ICollection<Mechanics> Mechanics { get; set; }
        public virtual ICollection<Vehicles> Vehicles { get; set; }
        public virtual ICollection<Workshops> Workshops { get; set; }
    }
}
