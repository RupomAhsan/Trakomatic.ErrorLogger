using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Corporates
{
    public class SetupZoneDevices : BaseEntity
    {
        [Column("setup_group_id")]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int SetupGroupId { get; set; }

        [Column("zone_setup_id")]
        public int ZoneSetupId { get; set; }
        public virtual ZoneSetup ZoneSetup { get; set; }

        [Column("install_device_id")]
        public int InstallDeviceId { get; set; }
        public virtual InstallDevice InstalledDevice { get; set; }
    }
}