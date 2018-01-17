using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Authentications
{
    public class GooglePlus : BaseEntity
    {
        [Column("google_plus_id")]
        [Key]
        public int GooglePlusId { get; set; }

        [Column("social_login_id")]
        public string UserDisplayName { get; set; }
        public virtual User User { get; set; }
    }
}
