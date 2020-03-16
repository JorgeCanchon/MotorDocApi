using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MotorDocApi.Core.Entities
{
    public class User
    {
        [Column("id")]
        public int Id { get; set; }
        //public DateTime Created_at { get; set; }
        //public DateTime Update_at { get; set; }
        //public string Name { get; set; }
        //public string Last_name { get; set; }
        //public string Password { get; set; }
        //public string Email { get; set; }
        //public string Address { get; set; }
        //public string City { get; set; }
        //public string Rol { get; set; }
        //public long Mobile_phone { get; set; }
        //public string Credential { get; set; }
        //public string Profile_pic { get; set; }
    }
}
