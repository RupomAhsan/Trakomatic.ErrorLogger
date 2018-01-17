using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Authentications
{
    public class Logins : BaseEntity
    {
        [Column("login_id")]
        [Key]
        public int LoginId { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("login_type")]
        public int LoginTypeId { get; set; }
        public virtual UserGroupMap LoginType { get; set; }

        [Column("token")]
        public string Token { get; set; }

        [Column("status")]
        public string Status { get; set; }
    }
}
