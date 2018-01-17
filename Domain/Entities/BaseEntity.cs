using Entities.Authentications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            IsActive = true;
            IsDeleted = false;
        }
        //public int ID { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
        [Column("modified_date")]
        public DateTime? ModifiedDate { get; set; }
        [Column("is_active")]
        public bool? IsActive { get; set; }
        [Column("is_deleted")]
        public bool? IsDeleted { get; set; }

        [Column("created_by_userid")]
        //[ForeignKey("created_by_userid")]
        public Guid CreatedByUserId { get; set; }
        public virtual User CreatedBy { get; set; }

        [Column("modified_by_userid")]
        //[ForeignKey("modified_by_userid")]
        public Guid ModifiedByUserID { get; set; }
        public virtual User ModifiedBy { get; set; }

        //public int CreatedByID { get; set; }
        //public virtual User CreatedBy { get; set; }

        //public int UpdatedByID { get; set; }
        //public virtual User UpdatedBy { get; set; }
    }
}
