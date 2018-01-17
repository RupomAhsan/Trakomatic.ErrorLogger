using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Corporates
{
    public class AlertType:BaseEntity
    {
        [Column("alert_type_id")]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AlertTypeId { get; set; }

        [Column("alert_type_name")]
        public string AlertTypeName { get; set; }
    }
}