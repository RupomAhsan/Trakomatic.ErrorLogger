using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Corporates
{
    public class FTPSetup : BaseEntity
    {
        [Column("ftp_setup_id")]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int FtpSetupId { get; set; }

        [Column("corporate_id")]
        public int CorporateId { get; set; }
        public virtual Corporate Corporate { get; set; }

        [Column("host")]
        public string Host { get; set; }

        [Column("user_name")]
        public string UserName { get; set; }

        [Column("port")]
        public string Port { get; set; }

        [Column("type")]
        public string type { get; set; }


        [Column("status")]
        public string Status { get; set; }
    }
}