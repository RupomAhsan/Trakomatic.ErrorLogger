using Entities.Authentications;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Corporates
{
    public class Corporate:BaseEntity
    {
        [Column("corporate_id")]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CorporateId { get; set; }

        [Column("corporate_name")]
        public string CorporateName { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("email")]
        public string Email { get; set; }

        #region Foriegn Key Values
        public virtual ICollection<User> UserCorporate { get; set; }
        #endregion
    }
}