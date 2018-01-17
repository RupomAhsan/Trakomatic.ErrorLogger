using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Corporates
{
    public class InstallDevice : BaseEntity
    {
        [Column("install_device_id")]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int InstallDeviceId { get; set; }

        [Column("corporate_id")]
        public int CorporateId { get; set; }
        public virtual Corporate Corporate { get; set; }

        [Column("device_uuid")]
        public string DeviceUUId { get; set; }

        [Column("device_type_id")]
        public int DeviceTypeId { get; set; }
        public virtual DeviceType DeviceType { get; set; }

        [Column("device_status")]
        public string DeviceStatus { get; set; }
    }
}