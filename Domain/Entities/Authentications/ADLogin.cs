using Entities.Corporates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Authentications
{
    [Table("ADLogin")]
    public class ADLogin : BaseEntity
    {
        [Column("ad_login_id")]
        [Key]
        public int ADLoginId { get; set; }

        [Column("corporate_id")]
        [ForeignKey("Corporate")]
        public int CorporateId { get; set; }
        public virtual Corporate Corporate { get; set; }
    }
}
