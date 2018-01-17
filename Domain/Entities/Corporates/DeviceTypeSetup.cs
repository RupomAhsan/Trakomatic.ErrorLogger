using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Corporates
{
    public class DeviceTypeSetup : BaseEntity
    {
        [Column("device_type_setup_id")]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int DeviceTypeSetupId { get; set; }

        [Column("corporate_id")]
        public int CorporateId { get; set; }
        public virtual Corporate Corporate { get; set; }

        [Column("device_type_id")]
        public int DeviceTypeId { get; set; }
        public virtual DeviceType DeviceType { get; set; }

        [Column("status")]
        public string Status { get; set; }
    }
}