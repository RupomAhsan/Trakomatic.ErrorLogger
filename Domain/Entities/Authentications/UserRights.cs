using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Authentications
{
    public class UserRights:BaseEntity
    {
        [Column("rights_id")]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RightsId { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [Column("module_id")]
        public int ModuleId { get; set; }
        public virtual Modules Modules { get; set; }

        [Column("action_id")]
        public int UserActionId { get; set; }
        public virtual UserAction UserAction { get; set; }

        [Column("has_rigths")]
        public bool HasRights { get; set; }
    }
}
