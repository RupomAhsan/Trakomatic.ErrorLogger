using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Authentications
{
    public class UserGroupMap:BaseEntity
    {
        [Column("user_group_map_id")]
        [Key]
        public int UserGroupMapId { get; set; }

        [Column("group_id")]
        public int UserGroupId { get; set; }
        public virtual UserGroup UserGroup { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}