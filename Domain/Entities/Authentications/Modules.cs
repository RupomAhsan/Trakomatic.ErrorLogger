using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Authentications
{
    public class Modules : BaseEntity
    {
        [Column("module_id")]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ModuleId { get; set; }

        [Column("module_name")]
        public string ModuleName { get; set; }

        [Column("module_version")]
        public string ModuleVersion { get; set; }
    }
}