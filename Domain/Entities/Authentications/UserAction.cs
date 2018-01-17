using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Authentications
{
    public class UserAction:BaseEntity
    {
        [Column("user_action_id")]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserActionId { get; set; }

        [Column("user_action_name")]
        public string UserActionName { get; set; }
    }
}