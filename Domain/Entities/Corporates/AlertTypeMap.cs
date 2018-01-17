using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Corporates
{
    public class AlertTypeMap : BaseEntity
    {
        [Column("alert_type_map_id")]
        [Key]
        public int AlertTypeMapId { get; set; }

        [Column("alert_type_id")]
        public int AlertTypeId { get; set; }
        public virtual AlertType AlertType { get; set; }

        [Column("corporate_id")]
        public int CorporateId { get; set; }
        public virtual Corporate Corporate { get; set; }
    }
}