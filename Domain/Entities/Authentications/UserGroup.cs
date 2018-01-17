using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Authentications
{
    public class UserGroup:BaseEntity
    {
        [Column("group_id")]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int GroupId { get; set; }

        [Column("group_name")]
        public string GroupName { get; set; }
    }
}