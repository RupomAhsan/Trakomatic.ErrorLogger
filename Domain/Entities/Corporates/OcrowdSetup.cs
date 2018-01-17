using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Corporates
{
    public class OcrowdSetup : BaseEntity
    {
        [Column("ocrowd_setup_id")]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int OCrowdSetupId { get; set; }

        [Column("corporate_id")]
        public int CorporateId { get; set; }
        public virtual Corporate Corporate { get; set; }
    }
}