using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Corporates
{
    public class Settings : BaseEntity
    {
        [Column("settings_id")]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int SettingsId { get; set; }

        [Column("corporate_id")]
        public int CorporateId { get; set; }
        public virtual Corporate Corporate { get; set; }

        [Column("type")]
        public string type { get; set; }

        [Column("timezone")]
        public string timezone { get; set; }

        [Column("opening_hours")]
        public string OpeningHours { get; set; }

        [Column("closing_hours")]
        public string ClosingHours { get; set; }

        [Column("device_alert")]
        public string DeviceAlert { get; set; }

        [Column("session_time")]
        public string SessionTime { get; set; }

        [Column("max_login_attemps")]
        public string MaxLoginAttemps { get; set; }


        [Column("status")]
        public string Status { get; set; }
    }
}