using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Corporates
{
    public class SupportEmails : BaseEntity
    {
        [Column("support_email_id")]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int SupportEmailId { get; set; }

        [Column("corporate_id")]
        public int CorporateId { get; set; }
        public virtual Corporate Corporate { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("status")]
        public string Status { get; set; }
    }
}