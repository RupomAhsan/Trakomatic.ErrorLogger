using Entities.Corporates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Authentications
{
    public class User//:BaseEntity
    {
        public User()
        {
            this.UserId = Guid.NewGuid();

            // Add any custom User properties/code here
        }
        [Column("user_id")]
        [Key]
        public Guid UserId { get; set; }

        [Column("display_name")]
        public string DisplayName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("corporate_id")]
        public int? CorporateId { get; set; }
        public virtual Corporate Corporate { get; set; }

        #region Foriegn Key Values
        public virtual ICollection<ADLogin> CreatedBy { get; set; }
        public virtual ICollection<ADLogin> ModifiedBy { get; set; }
        #endregion
    }
}