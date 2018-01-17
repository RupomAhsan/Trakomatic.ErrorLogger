using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Corporates
{
    public class DeviceType : BaseEntity
    {
        [Column("device_type_id")]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int DeviceTypeId { get; set; }

        [Column("type_name")]
        public string TypeName { get; set; }
    }
}