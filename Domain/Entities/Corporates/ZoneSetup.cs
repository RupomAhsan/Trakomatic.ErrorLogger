using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Corporates
{
    public class ZoneSetup : BaseEntity
    {
        [Column("zone_setup_id")]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ZoneSetupId { get; set; }

        [Column("corporate_id")]
        public int CorporateId { get; set; }
        public virtual Corporate Corporate { get; set; }

        [Column("parent_id")]
        public int ParentId { get; set; }

        [Column("zone_name")]
        public string ZoneName { get; set; }

        [Column("status")]
        public string Status { get; set; }
    }
}