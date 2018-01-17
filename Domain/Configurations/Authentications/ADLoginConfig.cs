using Entities.Authentications;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurations.Authentications
{
    public class ADLoginConfig : EntityTypeConfiguration<ADLogin>
    {
        public ADLoginConfig()
        {
            ToTable("adlogin");
            Property(p => p.CorporateId).IsRequired();

            HasOptional(m => m.CreatedBy)
                       .WithMany(t => t.CreatedBy)
                       .HasForeignKey(m => m.CreatedByUserId)
                       .WillCascadeOnDelete(false);

            HasOptional(r => r.ModifiedBy)
                    .WithMany(t => t.ModifiedBy)
                    .HasForeignKey(m => m.ModifiedByUserID)
                    .WillCascadeOnDelete(false);
        }
    }
}
